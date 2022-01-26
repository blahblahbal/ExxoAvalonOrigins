using Microsoft.Xna.Framework;
using Terraria;
using Terraria.UI;

namespace ExxoAvalonOrigins.UI.Herbology
{
    internal class HerbologyUIHerbCountAttachment : ExxoUIAttachment<ExxoUIItemSlot, ExxoUIPanelWrapper<ExxoUIList>>
    {
        public readonly ExxoUIImage Image;
        public readonly ExxoUIText Text;
        public HerbologyUIHerbCountAttachment() : base(new ExxoUIPanelWrapper<ExxoUIList>(new ExxoUIList()))
        {
            AttachmentElement.FitMinToInnerElement = true;
            AttachmentElement.BackgroundColor.A = 255;

            AttachmentElement.InnerElement.FitHeightToContent = true;
            AttachmentElement.InnerElement.FitWidthToContent = true;
            AttachmentElement.InnerElement.Direction = Direction.Horizontal;

            Image = new ExxoUIImage(null);
            AttachmentElement.InnerElement.Append(Image);

            Text = new ExxoUIText("")
            {
                VAlign = UIAlign.Center
            };
            AttachmentElement.InnerElement.Append(Text);

            OnPositionAttachment += (sender, e) => e.Position.Y -= sender.AttachmentElement.GetOuterDimensions().Height;
        }
        public override void UpdateSelf(GameTime gameTime)
        {
            base.UpdateSelf(gameTime);

            Player player = Main.LocalPlayer;
            ExxoAvalonOriginsModPlayer modPlayer = player.GetModPlayer<ExxoAvalonOriginsModPlayer>();

            int herbType = HerbologyLogic.GetBaseHerbType(AttachmentHolder.Item);
            if (herbType != -1)
            {
                if (modPlayer.herbCounts.ContainsKey(herbType))
                {
                    Text.SetText(modPlayer.herbCounts[herbType].ToString());
                }
                else
                {
                    Text.SetText("0");
                }
                Image.SetImage(Main.itemTexture[herbType]);
            }
        }
    }
}
