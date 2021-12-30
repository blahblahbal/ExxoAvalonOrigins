using Microsoft.Xna.Framework;
using Terraria.UI;

namespace ExxoAvalonOrigins.UI
{
    internal class AttachmentManager
    {
        private readonly UIElement parent;
        private readonly UIElement element;
        public UIElement AttachmentHolder { get; private set; }
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
            AttachmentHolder = uiElement;
            if (AttachmentHolder == null)
            {
                UIElement topParent = parent;
                while (topParent.Parent != null)
                {
                    topParent = topParent.Parent;
                }
                if (topParent is AdvancedUIState)
                {
                    (topParent as AdvancedUIState)?.MarkForRemoval(element);
                }
                else
                {
                    element.Remove();
                }
            }
            else
            {
                parent.Append(element);
                Vector2 position = AttachmentHolder.GetDimensions().Position() - parent.GetDimensions().Position();
                element.Left.Set(position.X - parent.PaddingLeft, 0);
                element.Top.Set(position.Y - parent.PaddingTop, 0);
                OnAttachTo(element, AttachmentHolder);
            }
        }
        public bool ContainsPoint(Vector2 position)
        {
            if (AttachmentHolder == null)
            {
                return false;
            }
            else
            {
                return AttachmentHolder.ContainsPoint(position) || element.ContainsPoint(position);
            }
        }
    }
}
