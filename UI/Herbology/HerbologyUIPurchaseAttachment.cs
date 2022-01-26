using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics;
using Terraria.UI;

namespace ExxoAvalonOrigins.UI.Herbology
{
    internal class HerbologyUIPurchaseAttachment : ExxoUIAttachment<ExxoUIItemSlot, ExxoUIPanelWrapper<ExxoUIList>>
    {
        public readonly ExxoUINumberInputWithButtons NumberInputWithButtons;
        public readonly ExxoUIPanelButton<ExxoUIText> Button;
        public readonly ExxoUIPanelWrapper<ExxoUIList> DifferenceContainer;
        private readonly ExxoUIImage balanceIcon;
        private readonly ExxoUIText startBalance;
        private readonly ExxoUIText subBalance;
        private readonly ExxoUIText endBalance;
        public HerbologyUIPurchaseAttachment() : base(new ExxoUIPanelWrapper<ExxoUIList>(new ExxoUIList()))
        {
            AttachmentElement.FitMinToInnerElement = true;

            AttachmentElement.InnerElement.FitHeightToContent = true;
            AttachmentElement.InnerElement.FitWidthToContent = true;
            AttachmentElement.InnerElement.ContentHAlign = UIAlign.Center;
            AttachmentElement.BackgroundColor.A = 255;

            OnPositionAttachment += (sender, e) => e.Position.Y += sender.AttachmentHolder.GetOuterDimensions().Height;

            NumberInputWithButtons = new ExxoUINumberInputWithButtons();
            AttachmentElement.InnerElement.Append(NumberInputWithButtons);

            DifferenceContainer = new ExxoUIPanelWrapper<ExxoUIList>(new ExxoUIList()
            {
                FitHeightToContent = true,
                FitWidthToContent = true,
                Direction = Direction.Horizontal,
                ListPadding = 10,
            })
            { FitMinToInnerElement = true, HAlign = UIAlign.Center };
            AttachmentElement.InnerElement.Append(DifferenceContainer);

            var iconContainer = new ExxoUIList
            {
                FitWidthToContent = true,
                FitHeightToContent = true,
                ContentHAlign = UIAlign.Center,
                ListPadding = 18,
            };
            DifferenceContainer.InnerElement.Append(iconContainer);

            balanceIcon = new ExxoUIImage(TextureManager.Load("Images/UI/WorldCreation/IconRandomSeed"))
            {
                Inset = new Vector2(11, 11)
            };
            iconContainer.Append(balanceIcon);

            var tallyContainer = new ExxoUIList
            {
                FitWidthToContent = true,
                FitHeightToContent = true,
                ListPadding = 10,
            };
            DifferenceContainer.InnerElement.Append(tallyContainer);

            startBalance = new ExxoUIText("");
            tallyContainer.Append(startBalance);

            subBalance = new ExxoUIText("");
            tallyContainer.Append(subBalance);

            endBalance = new ExxoUIText("");
            tallyContainer.Append(endBalance);

            Button = new ExxoUIPanelButton<ExxoUIText>(new ExxoUIText("Exchange"), false)
            {
                HAlign = UIAlign.Center,
                FitMinToInnerElement = true,
            };
            Button.Width.Set(0, 1);
            Button.Height.Pixels = Button.InnerElement.MinHeight.Pixels + Button.PaddingBottom + Button.PaddingTop;
            Button.InnerElement.HAlign = UIAlign.Center;

            AttachmentElement.InnerElement.Append(Button);
        }
        public override void UpdateSelf(GameTime gameTime)
        {
            base.UpdateSelf(gameTime);

            Player player = Main.LocalPlayer;
            ExxoAvalonOriginsModPlayer modPlayer = player.GetModPlayer<ExxoAvalonOriginsModPlayer>();

            int balance;
            if (HerbologyLogic.ItemIsHerb(AttachmentHolder.Item))
            {
                balance = modPlayer.herbTotal;
                balanceIcon.SetImage(TextureManager.Load("Images/UI/WorldCreation/IconRandomSeed"));
                balanceIcon.Inset = new Vector2(11, 11);
            }
            else
            {
                balance = modPlayer.potionTotal;
                balanceIcon.SetImage(TextureManager.Load("Images/UI/WorldCreation/IconEvilCorruption"));
                balanceIcon.Inset = new Vector2(8, 5);
            }
            startBalance.SetText(balance.ToString("+0;-#"));
            int cost = HerbologyLogic.GetItemCost(AttachmentHolder.Item, NumberInputWithButtons.NumberInput.Number);
            subBalance.SetText($"-{cost}");
            int end = balance - cost;
            if (end < 0)
            {
                endBalance.TextColor = Color.Red;
            }
            else
            {
                endBalance.TextColor = Color.White;
            }
            endBalance.SetText(end.ToString("+0;-#"));
        }
    }
}
