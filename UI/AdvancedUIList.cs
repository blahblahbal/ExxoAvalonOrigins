using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        public UIListItemParams(bool fillLength = false, bool autoDimensions = true)
        {
            FillLength = fillLength;
            AutoDimensions = autoDimensions;
        }
        public static UIListItemParams Default => new UIListItemParams(false, true);
        public readonly bool FillLength;
        public readonly bool AutoDimensions;
    }
    public class AdvancedUIList : UIElement
    {
        public Justification Justification = Justification.Start;
        public Direction Direction = Direction.Vertical;
        public bool FitParentToContentOppDirection;
        public bool FitParentToContentDirection;
        public delegate bool ElementSearchMethod(UIElement element);
        public float ListPadding = 5f;
        protected float TotalLength;
        protected AdvancedUIScrollbar ScrollBar;
        private readonly List<UIListItemParams> elementParamsList = new List<UIListItemParams>();

        public AdvancedUIList()
        {
            OverflowHidden = false;
            Width.Set(0, 1);
            Height.Set(0, 1);
        }

        public float GetTotalLength()
        {
            return TotalLength;
        }

        public void Goto(ElementSearchMethod searchMethod)
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
            Append(item, UIListItemParams.Default);
        }

        public void Append(UIElement item, UIListItemParams elementParams)
        {
            elementParamsList.Add(elementParams);
            if (FitParentToContentOppDirection || FitParentToContentDirection)
            {
                Parent.Width.Set(0, 1);
                Parent.Height.Set(0, 1);
                Parent.Recalculate();
            }
            base.Append(item);
            Recalculate();
        }

        public virtual void AddRange(IEnumerable<UIElement> items)
        {
            foreach (UIElement item in items)
            {
                Append(item);
            }
            Recalculate();
        }

        public virtual void Remove(UIElement item)
        {
            for (int i = 0; i < Elements.Count; i++)
            {
                if (Elements[i] == item)
                {
                    elementParamsList.RemoveAt(i);
                    break;
                }
            }
            RemoveChild(item);
        }

        public virtual void Clear()
        {
            elementParamsList.Clear();
            Elements.Clear();
        }

        public override void Recalculate()
        {
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
            base.RecalculateChildren();

            float largestOppLength = 0;
            int count = 0;
            float total = -ListPadding;
            for (int i = 0; i < Elements.Count; i++)
            {
                total += ListPadding;
                if (elementParamsList[i].FillLength)
                {
                    count++;
                }
                else
                {
                    Elements[i].Recalculate();
                    CalculatedStyle outerDimensions = Elements[i].GetOuterDimensions();
                    if (Direction == Direction.Vertical)
                    {
                        total += outerDimensions.Height;
                        if (outerDimensions.Height == 0)
                        {
                            total -= ListPadding;
                        }
                        largestOppLength = System.Math.Max(outerDimensions.Width, largestOppLength);
                    }
                    else
                    {
                        total += outerDimensions.Width;
                        if (outerDimensions.Width == 0)
                        {
                            total -= ListPadding;
                        }
                        largestOppLength = System.Math.Max(outerDimensions.Height, largestOppLength);
                    }
                }
            }

            float innerLength = (Direction == Direction.Vertical) ? GetInnerDimensions().Height : GetInnerDimensions().Width;
            float fillLength = (innerLength - total) / System.Math.Max(1, count);

            float num = 0f;

            // Needs checking, offset for centering
            if (Justification == Justification.Center)
            {
                num = (innerLength / 2) - (total / 2);
            }

            for (int i = 0; i < Elements.Count; i++)
            {
                if (elementParamsList[i].FillLength)
                {
                    if (Direction == Direction.Vertical)
                    {
                        Elements[i].Height.Set(fillLength, 0);
                    }
                    else
                    {
                        Elements[i].Width.Set(fillLength, 0);
                    }
                    Elements[i].Recalculate();
                }
                CalculatedStyle outerDimensions = Elements[i].GetOuterDimensions();
                if (Elements[i] is AdvancedUIList)
                {
                    var advancedUIList = (Elements[i] as AdvancedUIList);
                    if (advancedUIList.Direction == Direction.Vertical)
                    {
                        outerDimensions.Height = advancedUIList.GetTotalLength();
                    }
                    else
                    {
                        outerDimensions.Width = advancedUIList.GetTotalLength();
                    }
                }
                float outerLength = (Direction == Direction.Vertical) ? outerDimensions.Height : outerDimensions.Width;

                float pixels;
                switch (Justification)
                {
                    case Justification.Start:
                        pixels = num;
                        num += outerLength + ListPadding;
                        break;
                    case Justification.End:
                        num += outerLength;
                        pixels = innerLength - num;
                        num += ListPadding;
                        break;
                    case Justification.Center:
                        pixels = num;
                        num += outerLength + ListPadding;
                        break;
                    //case Justification.SpaceBetween:
                    //    GetOuterDimensions().Height - GetTotalHeight();
                    //    _items[i].Top.Set(num, 0f);
                    //    num += outerDimensions.Height + ListPadding;
                    //    break;
                    default:
                        pixels = 0;
                        break;
                }

                if (Direction == Direction.Vertical)
                {
                    Elements[i].Top.Set(pixels, 0);
                    if (elementParamsList[i].AutoDimensions)
                    {
                        Elements[i].Width.Set(0, 1);
                    }
                }
                else
                {
                    Elements[i].Left.Set(pixels, 0);
                    if (elementParamsList[i].AutoDimensions)
                    {
                        Elements[i].Height.Set(0, 1);
                    }
                }
            }

            TotalLength = num;

            if (FitParentToContentOppDirection)
            {
                if (Direction == Direction.Vertical)
                {
                    largestOppLength += Parent.PaddingLeft + Parent.PaddingRight;
                    Parent.Width.Set(largestOppLength, 0);
                }
                else
                {
                    largestOppLength += Parent.PaddingTop + Parent.PaddingBottom;
                    Parent.Height.Set(largestOppLength, 0);
                }
            }

            if (FitParentToContentDirection)
            {
                if (Direction == Direction.Vertical)
                {
                    Parent.Height.Set(total + Parent.PaddingTop + Parent.PaddingBottom, 0);
                }
                else
                {
                    Parent.Width.Set(total + Parent.PaddingLeft + Parent.PaddingRight, 0);
                }
            }
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

        private void UpdateScrollbar()
        {
            ScrollBar?.SetView(GetInnerDimensions().Height, TotalLength);
        }

        public void SetScrollbar(AdvancedUIScrollbar scrollbar)
        {
            ScrollBar = scrollbar;
            UpdateScrollbar();
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            if (ScrollBar != null)
            {
                Top.Set(0f - ScrollBar.GetValue(), 0f);
            }
            Recalculate();
        }
    }
}
