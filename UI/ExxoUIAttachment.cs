using Microsoft.Xna.Framework;
using Terraria.UI;

namespace ExxoAvalonOrigins.UI
{
    internal class ExxoUIAttachment<THolder> : ExxoUIElement where THolder : UIElement
    {
        public THolder AttachmentHolder { get; private set; }
        private readonly UIElement element;
        public delegate void AttachToEvent(UIElement attachment, THolder attachmentHolder);
        public event AttachToEvent OnAttachTo;
        public ExxoUIAttachment(UIElement uiElement, AttachToEvent attachToEvent)
        {
            Active = false;
            Width.Set(0, 1);
            Height.Set(0, 1);
            element = uiElement;
            OnAttachTo += attachToEvent;
            Append(element);
        }
        public override bool ContainsPoint(Vector2 point)
        {
            return element.ContainsPoint(point);
        }
        public virtual void AttachTo(THolder attachmentHolder)
        {
            AttachmentHolder = attachmentHolder;
            if (AttachmentHolder == null)
            {
                Active = false;
            }
            else
            {
                Active = true;
                Vector2 position = AttachmentHolder.GetDimensions().Position() - Parent.GetDimensions().Position();
                element.Left.Set(position.X - Parent.PaddingLeft, 0);
                element.Top.Set(position.Y - Parent.PaddingTop, 0);
                OnAttachTo(element, AttachmentHolder);
            }
        }
    }
}
