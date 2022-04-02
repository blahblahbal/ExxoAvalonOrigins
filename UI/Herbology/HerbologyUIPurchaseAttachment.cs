using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics;
using Terraria.UI;

namespace ExxoAvalonOrigins.UI.Herbology;

internal class HerbologyUIPurchaseAttachment : ExxoUIAttachment<ExxoUIItemSlot, ExxoUIPanelWrapper<ExxoUIList>>
{
    public readonly ExxoUINumberInputWithButtons NumberInputWithButtons;
    public readonly ExxoUIPanelButton<ExxoUIText> Button;
    public readonly ExxoUIPanelWrapper<ExxoUIList> DifferenceContainer;
    private readonly ExxoUIImage balanceIcon;
    private readonly ExxoUIText subBalance;
    private readonly ExxoUIList herbCountCostContainer;
    private readonly ExxoUIImage herbTypeIcon;
    private readonly ExxoUIText subHerbCountBalance;
    public HerbologyUIPurchaseAttachment() : base(new ExxoUIPanelWrapper<ExxoUIList>(new ExxoUIList()))
    {
        AttachmentElement.FitMinToInnerElement = true;

        AttachmentElement.InnerElement.FitHeightToContent = true;
        AttachmentElement.InnerElement.FitWidthToContent = true;
        AttachmentElement.InnerElement.ContentHAlign = UIAlign.Center;
        AttachmentElement.BackgroundColor.A = 255;

        OnPositionAttachment += (sender, e) => e.Position.Y += sender.AttachmentHolder.MinHeight.Pixels;

        NumberInputWithButtons = new ExxoUINumberInputWithButtons();
        AttachmentElement.InnerElement.Append(NumberInputWithButtons);

        DifferenceContainer = new ExxoUIPanelWrapper<ExxoUIList>(new ExxoUIList()
            {
                FitHeightToContent = true,
                FitWidthToContent = true,
                ListPadding = 10,
            })
            { FitMinToInnerElement = true };
        AttachmentElement.InnerElement.Append(DifferenceContainer);

        var tokenCostContainer = new ExxoUIList
        {
            FitHeightToContent = true,
            FitWidthToContent = true,
            ContentVAlign = UIAlign.Center,
            Direction = Direction.Horizontal,
            Justification = Justification.SpaceBetween
        };
        tokenCostContainer.Width.Set(0, 1);
        DifferenceContainer.InnerElement.Append(tokenCostContainer);

        balanceIcon = new ExxoUIImage(null);
        tokenCostContainer.Append(balanceIcon);

        subBalance = new ExxoUIText("");
        tokenCostContainer.Append(subBalance);

        herbCountCostContainer = new ExxoUIList
        {
            FitHeightToContent = true,
            FitWidthToContent = true,
            ContentVAlign = UIAlign.Center,
            Direction = Direction.Horizontal,
            Justification = Justification.SpaceBetween
        };
        herbCountCostContainer.Width.Set(0, 1);
        DifferenceContainer.InnerElement.Append(herbCountCostContainer);

        herbTypeIcon = new ExxoUIImage(null);
        herbCountCostContainer.Append(herbTypeIcon);

        subHerbCountBalance = new ExxoUIText("");
        herbCountCostContainer.Append(subHerbCountBalance);

        Button = new ExxoUIPanelButton<ExxoUIText>(new ExxoUIText("Exchange"), false)
        {
            HAlign = UIAlign.Center,
            FitMinToInnerElement = true,
        };
        Button.Width.Set(0, 1);
        Button.InnerElement.HAlign = UIAlign.Center;

        AttachmentElement.InnerElement.Append(Button);

        OnAttachTo += delegate
        {
            NumberInputWithButtons.NumberInput.Number = 1;
        };
    }
    public override void UpdateSelf(GameTime gameTime)
    {
        base.UpdateSelf(gameTime);

        Player player = Main.LocalPlayer;
        ExxoAvalonOriginsModPlayer modPlayer = player.GetModPlayer<ExxoAvalonOriginsModPlayer>();

        int balance;
        bool showHerbCount = HerbologyLogic.LargeHerbSeedIdByHerbSeedId.ContainsValue(AttachmentHolder.Item.type);
        herbCountCostContainer.Hidden = !showHerbCount;
        if (HerbologyLogic.ItemIsHerb(AttachmentHolder.Item))
        {
            balance = modPlayer.herbTotal;
            balanceIcon.SetImage(ExxoAvalonOrigins.Mod.Assets.Request<Texture2D>("Images/UI/WorldCreation/IconRandomSeed"));
            balanceIcon.Inset = new Vector2(11, 11);
        }
        else
        {
            balance = modPlayer.potionTotal;
            balanceIcon.SetImage(ExxoAvalonOrigins.Mod.Assets.Request<Texture2D>("Images/UI/WorldCreation/IconEvilCorruption"));
            balanceIcon.Inset = new Vector2(8, 5);
        }
        int cost = HerbologyLogic.GetItemCost(AttachmentHolder.Item, NumberInputWithButtons.NumberInput.Number);
        subBalance.SetText($"-{cost}");
        if (balance - cost < 0)
        {
            subBalance.TextColor = Color.Red;
        }
        else
        {
            subBalance.TextColor = Color.White;
        }

        if (showHerbCount)
        {
            int herbType = HerbologyLogic.GetBaseHerbType(AttachmentHolder.Item);
            if (herbType != -1)
            {
                herbTypeIcon.SetImage(Terraria.GameContent.TextureAssets.Item[herbType]);
                subHerbCountBalance.SetText($"-{cost}");
                if (!modPlayer.herbCounts.ContainsKey(herbType) || modPlayer.herbCounts[herbType] - cost < 0)
                {
                    subHerbCountBalance.TextColor = Color.Red;
                }
                else
                {
                    subHerbCountBalance.TextColor = Color.White;
                }
            }
        }
    }
}
