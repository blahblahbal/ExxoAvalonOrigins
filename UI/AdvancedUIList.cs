using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.UI;

namespace ExxoAvalonOrigins.UI
{
    public enum Justification
    {
        Start,
        End,
        Center,
        SpaceBetween,
    }
    public enum Direction
    {
        Vertical,
        Horizontal
    }
    public struct UIListItemParams
    {
        public UIListItemParams(bool fillLength = false)
        {
            FillLength = fillLength;
        }
        public readonly bool FillLength;
    }
    public class AdvancedUIList : UIElement, IElementListener
    {
        public delegate bool ElementSearchMethod(UIElement element);

        public Justification Justification = Justification.Start;
        public Direction Direction = Direction.Vertical;
        public bool FitHeightToContent;
        public bool FitWidthToContent;
        public bool IsRecalculating { get; set; }

        public float ListPadding = 5f;
        public float TotalLength { get; set; }

        protected AdvancedUIScrollbar ScrollBar;
        protected readonly List<UIListItemParams> ElementParamsList = new List<UIListItemParams>();

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
            Append(item, new UIListItemParams());
        }

        public void Append(UIElement item, UIListItemParams elementParams)
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
                ElementParamsList.Add(new UIListItemParams());
            }
            Recalculate();
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
            Recalculate();
        }

        public virtual void Clear()
        {
            ElementParamsList.Clear();
            Elements.Clear();
            Recalculate();
        }

        public override void Recalculate()
        {
            if (FitHeightToContent)
            {
                Height.Set(0, 1);
            }
            if (FitWidthToContent)
            {
                Width.Set(0, 1);
            }
            base.Recalculate();
            UpdateScrollbar();
        }

        public void ScrollWheelListener(UIScrollWheelEvent evt, UIElement listeningElement)
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
                if (ElementParamsList[i].FillLength)
                {
                    fillLengthCount++;
                }
                else
                {
                    Elements[i].Recalculate();
                    CalculatedStyle outerDimensions = Elements[i].GetOuterDimensions();
                    float length = (Direction == Direction.Vertical) ? outerDimensions.Height : outerDimensions.Width;
                    total += length;
                    if ((Direction == Direction.Vertical && Elements[i].Width.Precent == 0) || (Direction == Direction.Horizontal && Elements[i].Height.Precent == 0))
                    {
                        float oppLength = (Direction == Direction.Vertical) ? outerDimensions.Width : outerDimensions.Height;
                        largestOppLength = System.Math.Max(oppLength, largestOppLength);
                    }
                }
            }

            // Set largest opposite length
            if (FitHeightToContent && Direction == Direction.Horizontal)
            {
                Height.Set(largestOppLength, 0);
            }

            if (FitWidthToContent && Direction == Direction.Vertical)
            {
                Width.Set(largestOppLength, 0);
            }

            this.RecalculateSelf();

            float innerLength = (Direction == Direction.Vertical) ? GetInnerDimensions().Height : GetInnerDimensions().Width;
            float padding = ListPadding;

            // List padding
            if (Justification == Justification.SpaceBetween)
            {
                padding = (innerLength - total) / (Elements.Count - 1);
            }

            for (int i = 0; i < Elements.Count - 1; i++)
            {
                if (Direction == Direction.Vertical)
                {
                    Elements[i].MarginBottom = padding;
                }
                else
                {
                    Elements[i].MarginRight = padding;
                }
            }

            float fillLength = (innerLength - total) / System.Math.Max(1, fillLengthCount);
            float offset = 0f;

            // Needs checking, offset for centering
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

                Elements[i].Recalculate();

                CalculatedStyle outerDimensions = Elements[i].GetOuterDimensions();
                float outerLength = (Direction == Direction.Vertical) ? outerDimensions.Height : outerDimensions.Width;
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

            if (FitHeightToContent && Direction == Direction.Vertical)
            {
                Height.Set(offset, 0);
            }

            if (FitWidthToContent && Direction == Direction.Horizontal)
            {
                Width.Set(offset, 0);
            }

            TotalLength = offset;

            this.RecalculateSelf();
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

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (ScrollBar != null)
            {
                Top.Set(0 - ScrollBar.GetValue(), 0f);
            }
        }

        private void UpdateScrollbar()
        {
            ScrollBar?.SetView(GetInnerDimensions().Height, TotalLength);
        }

        public void SetScrollbar(AdvancedUIScrollbar scrollbar)
        {
            ScrollBar = scrollbar;
            UpdateScrollbar();
        }

        public void PostRecalculate()
        {
        }
    }
}
