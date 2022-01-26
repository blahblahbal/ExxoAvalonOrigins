using Microsoft.Xna.Framework;
using Terraria.Graphics;
using Terraria.UI;

namespace ExxoAvalonOrigins.UI.Herbology
{
    internal class HerbologyUIPotionExchange : ExxoUIPanelWrapper<ExxoUIList>
    {
        private readonly ExxoUIList list;
        private readonly ExxoUIText title;
        public readonly ExxoUIImageButtonToggle Toggle;
        public readonly ExxoUIElementWrapper<ExxoUIListGrid> Grid;
        public readonly ExxoUIElementWrapper<ExxoUIScrollbar> Scrollbar;
        public HerbologyUIPotionExchange() : base(new ExxoUIList(), true)
        {
            Height.Set(0, 1);
            InnerElement.Direction = Direction.Horizontal;

            list = new ExxoUIList();
            list.Height.Set(0, 1);
            InnerElement.Append(list, new ExxoUIList.ElementParams(fillLength: true));

            var herbExchangeTitleContainer = new ExxoUIList
            {
                FitHeightToContent = true,
                ContentVAlign = UIAlign.Center
            };
            herbExchangeTitleContainer.Width.Set(0, 1);
            herbExchangeTitleContainer.Direction = Direction.Horizontal;
            herbExchangeTitleContainer.Justification = Justification.Center;
            list.Append(herbExchangeTitleContainer);

            title = new ExxoUIText("Potion Exchange");
            herbExchangeTitleContainer.Append(title);

            Toggle = new ExxoUIImageButtonToggle(TextureManager.Load("Images/UI/WorldCreation/IconEvilCorruption"), Color.White, Color.Orange)
            {
                Tooltip = "Toggle Potions/Elixirs"
            };
            herbExchangeTitleContainer.Append(Toggle);

            var horizontalRule = new ExxoUIHorizontalRule();
            horizontalRule.Width.Set(0, 1);
            list.Append(horizontalRule);

            Grid = new ExxoUIElementWrapper<ExxoUIListGrid>(new ExxoUIListGrid())
            {
                OverflowHidden = true
            };
            Grid.Width.Set(0, 1);
            Grid.InnerElement.HAlign = UIAlign.Center;
            Grid.InnerElement.FitWidthToContent = true;
            list.Append(Grid, new ExxoUIList.ElementParams(fillLength: true));

            Scrollbar = new ExxoUIElementWrapper<ExxoUIScrollbar>(new ExxoUIScrollbar())
            {
                FitToInnerElement = true
            };
            Scrollbar.VAlign = UIAlign.Center;
            Scrollbar.SetPadding(0);
            InnerElement.Append(Scrollbar);
            Grid.InnerElement.SetScrollbar(Scrollbar.InnerElement);
            OnScrollWheel += Grid.InnerElement.ScrollWheelListener;
        }
    }
}
