using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.GameInput;
using Terraria.Localization;
using Terraria.UI;
using Terraria.UI.Gamepad;

namespace ExxoAvalonOrigins.UI
{
	public class GenericSelectionMenu : UIState
	{
		private UIList optionList;
		private UITextPanel<LocalizedText> backPanel;
		private UIPanel containerPanel;

		private bool skipDraw;

		public GenericSelectionMenu(string title, UIList list, UIElement.MouseEvent cancelAction)
        {
			UIElement uIElement = new UIElement();
			uIElement.Width.Set(0f, 0.8f);
			uIElement.MaxWidth.Set(400f, 0f);
			uIElement.Top.Set(220f, 0f);
			uIElement.Height.Set(-520f, 1f);
			uIElement.HAlign = 0.5f;

			UIPanel uIPanel = new UIPanel();
			uIPanel.Width.Set(0f, 1f);
			uIPanel.Height.Set(-110f, 1f);
			uIPanel.BackgroundColor = new Color(33, 43, 79) * 0.8f;
			uIElement.Append(uIPanel);

			containerPanel = uIPanel;
			optionList = list;
			optionList.Width.Set(-25f, 1f);
			optionList.Height.Set(0f, 1f);
			optionList.ListPadding = 5f;
			uIPanel.Append(optionList);

			UIScrollbar uIScrollbar = new UIScrollbar();
			uIScrollbar.SetView(100f, 1000f);
			uIScrollbar.Height.Set(0f, 1f);
			uIScrollbar.HAlign = 1f;
			uIPanel.Append(uIScrollbar);
			optionList.SetScrollbar(uIScrollbar);

			UITextPanel<string> uITextPanel = new UITextPanel<string>(title, 0.8f, large: true);
			uITextPanel.HAlign = 0.5f;
			uITextPanel.Top.Set(-35f, 0f);
			uITextPanel.SetPadding(15f);
			uITextPanel.BackgroundColor = new Color(73, 94, 171);
			uIElement.Append(uITextPanel);

			UITextPanel<LocalizedText> uITextPanel2 = new UITextPanel<LocalizedText>(Language.GetText("UI.Back"), 0.7f, large: true);
			uITextPanel2.Width.Set(-10f, 1f);
			uITextPanel2.Height.Set(50f, 0f);
			uITextPanel2.VAlign = 1f;
			uITextPanel2.Top.Set(-45f, 0f);
			uITextPanel2.OnMouseOver += FadedMouseOver;
			uITextPanel2.OnMouseOut += FadedMouseOut;
			uITextPanel2.OnClick += cancelAction;
			uIElement.Append(uITextPanel2);
			backPanel = uITextPanel2;

			base.Append(uIElement);
		}

		private void FadedMouseOver(UIMouseEvent evt, UIElement listeningElement)
		{
			Main.PlaySound(SoundID.MenuTick);
			((UIPanel)evt.Target).BackgroundColor = new Color(73, 94, 171);
		}

		private void FadedMouseOut(UIMouseEvent evt, UIElement listeningElement)
		{
			((UIPanel)evt.Target).BackgroundColor = new Color(63, 82, 151) * 0.7f;
		}

		public override void OnActivate()
		{
			if (PlayerInput.UsingGamepadUI)
			{
				UILinkPointNavigator.ChangePoint(3000 + ((optionList.Count == 0) ? 1 : 2));
			}
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			if (skipDraw)
			{
				skipDraw = false;
				return;
			}
			base.Draw(spriteBatch);
		}
    }
}
