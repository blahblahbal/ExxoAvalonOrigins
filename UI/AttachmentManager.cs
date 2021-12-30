using Microsoft.Xna.Framework;
using Terraria.UI;

namespace ExxoAvalonOrigins.UI
{
    internal class AttachmentManager
    {
        private readonly UIElement parent;
        private readonly UIElement element;
        private UIElement attachmentHolder;
        public delegate void AttachToEvent(UIElement attachment, UIElement attachmentHolder);
        public event AttachToEvent OnAttachTo;
        public AttachmentManager(UIElement parent, UIElement uiElement, AttachToEvent attachToEvent)
        {
            this.parent = parent;
            element = uiElement;
            OnAttachTo += attachToEvent;
        }
        public virtual void AttachTo(UIElement uiElement)
        {
            attachmentHolder = uiElement;
            if (attachmentHolder == null)
            {
                element.Remove();
            }
            else
            {
                parent.Append(element);
                Vector2 position = attachmentHolder.GetDimensions().Position() - parent.GetDimensions().Position();
                element.Left.Set(position.X - parent.PaddingLeft, 0);
                element.Top.Set(position.Y - parent.PaddingTop, 0);
                OnAttachTo(element, attachmentHolder);
                //element.Recalculate();
            }
        }
        public bool ContainsPoint(Vector2 position)
        {
            if (attachmentHolder == null)
            {
                return false;
            }
            else
            {
                return attachmentHolder.ContainsPoint(position) || element.ContainsPoint(position);
            }
        }
    }
}
