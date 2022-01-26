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
    internal class ExxoUIAttachment<THolder, TAttachment> : ExxoUIElement where THolder : ExxoUIElement where TAttachment : UIElement
    {
        public THolder AttachmentHolder { get; private set; }
        public readonly TAttachment AttachmentElement;
        public delegate void ExxoUIAttachmentEventHandler(ExxoUIAttachment<THolder, TAttachment> sender, EventArgs e);
        public delegate void PositionAttachmentEventHandler(ExxoUIAttachment<THolder, TAttachment> sender, PositionAttachmentEventArgs e);
        public event PositionAttachmentEventHandler OnPositionAttachment;
        public event ExxoUIAttachmentEventHandler OnAttachTo;
        private bool isAttached;
        public ExxoUIAttachment(TAttachment uiElement)
        {
            Active = false;
            Width.Set(0, 1);
            Height.Set(0, 1);
            AttachmentElement = uiElement;
            Append(AttachmentElement);
        }
        public override bool ContainsPoint(Vector2 point)
        {
            return IsVisible && AttachmentElement.ContainsPoint(point);
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
                OnAttachTo?.Invoke(this, EventArgs.Empty);
                AttachmentHolder.OnRecalculateFinish += OnRecalculateFinishHandler;
                isAttached = true;
            }
        }
        protected virtual void OnRecalculateFinishHandler(object sender, EventArgs e)
        {
            Vector2 position = AttachmentHolder.GetDimensions().Position() - Parent.GetOuterDimensions().Position();
            var args = new PositionAttachmentEventArgs(position);
            OnPositionAttachment?.Invoke(this, args);
            AttachmentElement.Left.Set(args.Position.X, 0);
            AttachmentElement.Top.Set(args.Position.Y, 0);
            Recalculate();
        }
    }
}
