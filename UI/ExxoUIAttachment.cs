using System;
using Microsoft.Xna.Framework;
using Terraria.UI;

namespace ExxoAvalonOrigins.UI
{
    internal class ExxoUIAttachment<THolder> : ExxoUIElement where THolder : ExxoUIElement
    {
        public THolder AttachmentHolder { get; private set; }
        public delegate void AttachToEvent(UIElement attachment, THolder attachmentHolder);
        public event AttachToEvent OnAttachTo;
        protected readonly UIElement Element;
        private bool isAttached;
        public ExxoUIAttachment(UIElement uiElement, AttachToEvent attachToEvent)
        {
            Active = false;
            Width.Set(0, 1);
            Height.Set(0, 1);
            Element = uiElement;
            OnAttachTo += attachToEvent;
            Append(Element);
        }
        public override bool ContainsPoint(Vector2 point)
        {
            return IsVisible && Element.ContainsPoint(point);
        }
        public virtual void AttachTo(THolder attachmentHolder)
        {
            if (isAttached)
            {
                AttachmentHolder.OnRecalculateFinish -= OnRecalculateFinishHandler;
            }
            AttachmentHolder = attachmentHolder;
            if (AttachmentHolder == null)
            {
                isAttached = false;
                Active = false;
            }
            else
            {
                Active = true;
                OnAttachTo?.Invoke(Element, AttachmentHolder);
                AttachmentHolder.OnRecalculateFinish += OnRecalculateFinishHandler;
                isAttached = true;
            }
        }
        protected virtual void OnRecalculateFinishHandler(object sender, EventArgs e)
        {
            var exxoElement = (ExxoUIElement)sender;
            Vector2 position = exxoElement.GetDimensions().Position() - Parent.GetOuterDimensions().Position();
            Element.Left.Set(position.X, 0);
            Element.Top.Set(position.Y, 0);
            Recalculate();
        }
    }
}
