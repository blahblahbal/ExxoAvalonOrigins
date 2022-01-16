using System;
using Microsoft.Xna.Framework;
using Terraria.UI;

namespace ExxoAvalonOrigins.UI
{
    internal class PositionAttachmentEventArgs : EventArgs
    {
        public Vector2 Position;

        public PositionAttachmentEventArgs(Vector2 position)
        {
            Position = position;
        }
    }
    internal class ExxoUIAttachment<THolder> : ExxoUIElement where THolder : ExxoUIElement
    {
        public THolder AttachmentHolder { get; private set; }
        public delegate void AttachToEvent(UIElement attachment, THolder attachmentHolder);
        public delegate void PositionAttachmentEventHandler(ExxoUIAttachment<THolder> sender, PositionAttachmentEventArgs e);
        public event PositionAttachmentEventHandler OnPositionAttachment;
        public event AttachToEvent OnAttachTo;
        protected readonly UIElement Element;
        private bool isAttached;
        public ExxoUIAttachment(UIElement uiElement)
        {
            Active = false;
            Width.Set(0, 1);
            Height.Set(0, 1);
            Element = uiElement;
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
            var args = new PositionAttachmentEventArgs(position);
            OnPositionAttachment?.Invoke(this, args);
            Element.Left.Set(args.Position.X, 0);
            Element.Top.Set(args.Position.Y, 0);
            Recalculate();
        }
    }
}
