using Microsoft.Xna.Framework;

namespace ExxoAvalonOrigins.UI.Herbology;

internal class HerbologyUIHelpAttachment : ExxoUIAttachment<ExxoUIElement, ExxoUITextPanel>
{
    private bool enabled;
    public bool Enabled
    {
        get => enabled;
        set
        {
            enabled = value;
            if (!enabled)
            {
                AttachTo(null);
            }
        }
    }
    private bool attachedThisUpdate;
    public HerbologyUIHelpAttachment() : base(new ExxoUITextPanel(new ExxoUIText("")))
    {
        AttachmentElement.BackgroundColor.A = 255;

        OnPositionAttachment += (sender, e) => e.Position.Y -= sender.AttachmentElement.GetOuterDimensions().Height;
    }
    public void Register(ExxoUIElement element, string description)
    {
        element.OnMouseOver += (evt, _) =>
        {
            if (!attachedThisUpdate && Enabled && element.ContainsPoint(evt.MousePosition))
            {
                attachedThisUpdate = true;
                AttachTo(element);
                AttachmentElement.InnerElement.SetText(description);
            }
        };
        element.OnLastMouseOut += delegate
        {
            if (AttachmentHolder == element)
            {
                AttachTo(null);
            }
        };
    }

    public override void UpdateSelf(GameTime gameTime)
    {
        base.UpdateSelf(gameTime);
        attachedThisUpdate = false;
    }

    public override void AttachTo(ExxoUIElement attachmentHolder)
    {
        if (attachmentHolder != AttachmentHolder)
        {
            if (AttachmentHolder is ExxoUIPanel panel)
            {
                panel.BorderColor = ExxoUIPanel.DefaultBorderColor;
            }
        }
        base.AttachTo(attachmentHolder);
        if (AttachmentHolder != null)
        {
            if (AttachmentHolder is ExxoUIPanel panel)
            {
                panel.BorderColor = Color.Gold;
            }
        }
    }
}