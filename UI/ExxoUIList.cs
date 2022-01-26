using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.UI;

namespace ExxoAvalonOrigins.UI
{
    public class ExxoUIList : ExxoUIElement
    {
        public struct ElementParams
        {
            public ElementParams(bool fillLength = false, bool ignoreContentAlign = false)
            {
                FillLength = fillLength;
                IgnoreContentAlign = ignoreContentAlign;
            }
            public readonly bool FillLength;
            public readonly bool IgnoreContentAlign;
        }

        public delegate bool ElementSearchMethod(UIElement element);

        public Justification Justification = Justification.Start;
        public float ContentVAlign;
        public float ContentHAlign;
        public Direction Direction = Direction.Vertical;
        public bool FitWidthToContent;
        private StyleDimension origWidth;
        private StyleDimension origHeight;
        public bool FitHeightToContent;

        public float ListPadding = 5f;
        public float TotalLength { get; set; }

        protected ExxoUIScrollbar ScrollBar;
        protected readonly List<ElementParams> ElementParamsList = new List<ElementParams>();

        public void ScrollTo(ElementSearchMethod searchMethod)
        {
            int num;
            for (num = 0; num < Elements.Count; num++)
            {
                if (searchMethod(Elements[num]))
                {
                    break;
                }
            }
            ScrollBar.ViewPosition = Elements[num].Top.Pixels;
        }

        public new void Append(UIElement item)
        {
            Append(item, new ElementParams());
        }

        public void Append(UIElement item, ElementParams elementParams)
        {
            ElementParamsList.Add(elementParams);
            base.Append(item);
        }

        public virtual void AddRange(IEnumerable<UIElement> items)
        {
            Elements.AddRange(items);
            foreach (UIElement item in items)
            {
                item.Remove();
                item.Parent = this;
                ElementParamsList.Add(new ElementParams());
            }
        }

        public virtual void Remove(UIElement item)
        {
            for (int i = 0; i < Elements.Count; i++)
            {
                if (Elements[i] == item)
                {
                    ElementParamsList.RemoveAt(i);
                    break;
                }
            }
            RemoveChild(item);
        }

        public virtual void Clear()
        {
            ElementParamsList.Clear();
            Elements.Clear();
        }

        public override void PreRecalculate()
        {
            base.PreRecalculate();
            if (FitHeightToContent)
            {
                MinHeight.Set(0, 0);
                origHeight = Height;
                Height.Set(0, 1);
            }
            if (FitWidthToContent)
            {
                MinWidth.Set(0, 0);
                origWidth = Width;
                Width.Set(0, 1);
            }
        }

        public void ScrollWheelListener(UIScrollWheelEvent evt, UIElement _)
        {
            if (ScrollBar != null)
            {
                ScrollBar.ViewPosition -= evt.ScrollWheelValue;
            }
        }

        public override void RecalculateChildren()
        {
            float largestOppLength = 0;
            float total = 0;
            int fillLengthCount = 0;

            for (int i = 0; i < Elements.Count; i++)
            {
                if (Elements[i] is ExxoUIElement exxoElement && (exxoElement?.Hidden == true || exxoElement?.Active == false))
                {
                    continue;
                }

                if (!ElementParamsList[i].IgnoreContentAlign)
                {
                    Elements[i].VAlign = ContentVAlign;
                    Elements[i].HAlign = ContentHAlign;
                }

                if (ElementParamsList[i].FillLength)
                {
                    fillLengthCount++;
                }

                float width = System.Math.Max(Elements[i].MinWidth.Pixels, Elements[i].Width.Pixels);
                float height = System.Math.Max(Elements[i].MinHeight.Pixels, Elements[i].Height.Pixels);

                if (!ElementParamsList[i].FillLength)
                {
                    float length = (Direction == Direction.Vertical) ? height : width;
                    total += length;
                }

                float oppLength = (Direction == Direction.Vertical) ? width : height;
                largestOppLength = System.Math.Max(oppLength, largestOppLength);
            }

            float innerLength = (Direction == Direction.Vertical) ? GetInnerDimensions().Height : GetInnerDimensions().Width;
            float padding = ListPadding;

            // List padding
            if (Justification == Justification.SpaceBetween)
            {
                padding = (innerLength - total) / (Elements.Count - 1);
            }

            for (int i = 0; i < Elements.Count - 1; i++)
            {
                Elements[i].MarginBottom = 0;
                Elements[i].MarginRight = 0;
                var exxoElement = Elements[i + 1] as ExxoUIElement;
                if (exxoElement?.IsVisible == false)
                {
                    continue;
                }
                else if (exxoElement == null && Elements[i + 1].GetOuterDimensions().Height > 0 && Elements[i + 1].GetOuterDimensions().Width > 0)
                {
                    continue;
                }

                if (Direction == Direction.Vertical)
                {
                    Elements[i].MarginBottom = padding;
                }
                else
                {
                    Elements[i].MarginRight = padding;
                }
                total += padding;
            }

            // Set largest opposite length
            if (FitHeightToContent && Direction == Direction.Horizontal)
            {
                MinHeight.Set(largestOppLength, 0);
                Height = origHeight;
            }

            if (FitWidthToContent && Direction == Direction.Vertical)
            {
                MinWidth.Set(largestOppLength, 0);
                Width = origWidth;
            }

            // Set direction length
            if (FitHeightToContent && Direction == Direction.Vertical)
            {
                MinHeight.Set(total, 0);
                Height = origHeight;
            }

            if (FitWidthToContent && Direction == Direction.Horizontal)
            {
                MinWidth.Set(total, 0);
                Width = origWidth;
            }

            TotalLength = total;

            RecalculateSelf();

            innerLength = (Direction == Direction.Vertical) ? GetInnerDimensions().Height : GetInnerDimensions().Width;
            float fillLength = (innerLength - total) / System.Math.Max(1, fillLengthCount);
            float offset = 0f;

            if (Justification == Justification.Center && !((FitWidthToContent && Direction == Direction.Horizontal) || (FitHeightToContent && Direction == Direction.Vertical)))
            {
                offset = (innerLength / 2) - (total / 2);
            }

            for (int i = 0; i < Elements.Count; i++)
            {
                if (ElementParamsList[i].FillLength)
                {
                    if (Direction == Direction.Vertical)
                    {
                        Elements[i].Height.Set(fillLength, 0);
                    }
                    else
                    {
                        Elements[i].Width.Set(fillLength, 0);
                    }
                }

                float width = System.Math.Max(Elements[i].MinWidth.Pixels, Elements[i].Width.Pixels);
                float height = System.Math.Max(Elements[i].MinHeight.Pixels, Elements[i].Height.Pixels);

                float outerLength = (Direction == Direction.Vertical) ? height + Elements[i].MarginBottom : width + Elements[i].MarginRight;
                float pixels;

                switch (Justification)
                {
                    case Justification.SpaceBetween:
                    case Justification.Start:
                    case Justification.Center:
                        pixels = offset;
                        offset += outerLength;
                        break;
                    case Justification.End:
                        offset += outerLength;
                        pixels = innerLength - offset;
                        break;
                    default:
                        pixels = 0;
                        break;
                }

                if (Direction == Direction.Vertical)
                {
                    Elements[i].Top.Set(pixels, 0);
                }
                else
                {
                    Elements[i].Left.Set(pixels, 0);
                }
            }

            base.RecalculateChildren();
        }

        public override bool ContainsPoint(Vector2 point)
        {
            foreach (UIElement uIElement in Elements)
            {
                if (uIElement.ContainsPoint(point))
                {
                    return true;
                }
            }
            return false;
        }

        public override void UpdateSelf(GameTime gameTime)
        {
            base.UpdateSelf(gameTime);
            if (ScrollBar != null)
            {
                Top.Set(-ScrollBar.GetValue(), 0f);
            }
        }

        public override void PostRecalculate()
        {
            base.PostRecalculate();
            UpdateScrollbar();
        }

        private void UpdateScrollbar()
        {
            ScrollBar?.SetView(GetInnerDimensions().Height, TotalLength);
        }

        public void SetScrollbar(ExxoUIScrollbar scrollbar)
        {
            ScrollBar = scrollbar;
        }
    }
}
