using Terraria.UI;

namespace ExxoAvalonOrigins.UI
{
    internal class AdvancedUIListGrid : AdvancedUIList
    {
        public override void RecalculateChildren()
        {
            foreach (UIElement element in Elements)
            {
                element.Recalculate();
            }

            float largestWidth = 0;
            float largestHeight = 0;
            float width = 0;
            float top = 0;
            for (int i = 0; i < Elements.Count; i++)
            {
                largestHeight = System.Math.Max(largestHeight, Elements[i].Height.Pixels);
                Elements[i].Top.Set(top, 0);
                Elements[i].Left.Set(width, 0);
                width += Elements[i].GetOuterDimensions().Width + ListPadding;
                if (i < Elements.Count - 1)
                {
                    largestWidth = System.Math.Max(largestWidth, width - ListPadding);
                    if (width + Elements[i + 1].GetOuterDimensions().Width >= GetInnerDimensions().Width)
                    {
                        top += largestHeight + ListPadding;
                        width = 0;
                        largestHeight = 0;
                    }
                }
            }

            if (FitWidthToContent)
            {
                Width.Set(largestWidth, 0);
            }
            if (FitHeightToContent)
            {
                Height.Set(top + largestHeight, 0);
            }

            TotalLength = top + largestHeight;

            this.RecalculateSelf();
        }
    }
}
