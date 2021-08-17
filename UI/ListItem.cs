using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.Graphics;
using Terraria.UI;

namespace ExxoAvalonOrigins.UI
{
	public class ListItem : UIPanel
	{

		private Texture2D dividerTexture;
		private Texture2D innerPanelTexture;
		private UIImage worldIcon;
		private Color textColor;

		private string itemName;

		public ListItem(string name, Texture2D tex, UIElement.MouseEvent submitEvent)
		{
			itemName = name;
			LoadTextures();

			base.OnClick += submitEvent;

			worldIcon = new UIImage(tex);
			worldIcon.Left.Set(4f, 0);
			worldIcon.VAlign = 0.5f;
			InitializeAppearance();
			Append(worldIcon);
		}

		private void LoadTextures()
		{
			dividerTexture = TextureManager.Load("Images/UI/Divider");
			innerPanelTexture = TextureManager.Load("Images/UI/InnerPanelBackground");
		}

		private void InitializeAppearance()
		{
			Height.Set(worldIcon.Height.Pixels + 16f, 0f);
			Width.Set(0f, 1f);
			SetPadding(6f);
			BorderColor = new Color(89, 116, 213) * 0.7f;
			textColor = Color.White * 0.9f;
		}

		public override void MouseOver(UIMouseEvent evt)
		{
			base.MouseOver(evt);
			BackgroundColor = new Color(73, 94, 171);
			BorderColor = new Color(89, 116, 213);
			textColor = new Color(255, 215, 0);
		}

		public override void MouseOut(UIMouseEvent evt)
		{
			base.MouseOut(evt);
			BackgroundColor = new Color(63, 82, 151) * 0.7f;
			BorderColor = new Color(89, 116, 213) * 0.7f;
			textColor = Color.White * 0.9f;
		}

		private void DrawPanel(SpriteBatch spriteBatch, Vector2 position, float width)
		{
			spriteBatch.Draw(innerPanelTexture, position, new Rectangle(0, 0, 8, innerPanelTexture.Height), Color.White);
			spriteBatch.Draw(innerPanelTexture, new Vector2(position.X + 8f, position.Y), new Rectangle(8, 0, 8, innerPanelTexture.Height), Color.White, 0f, Vector2.Zero, new Vector2((width - 16f) / 8f, 1f), SpriteEffects.None, 0f);
			spriteBatch.Draw(innerPanelTexture, new Vector2(position.X + width - 8f, position.Y), new Rectangle(16, 0, 8, innerPanelTexture.Height), Color.White);
		}

		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			base.DrawSelf(spriteBatch);
			CalculatedStyle innerDimensions = GetInnerDimensions();
			CalculatedStyle dimensions = worldIcon.GetDimensions();
			float num = dimensions.X + dimensions.Width;
			Vector2 vector = new Vector2(num + 6f, innerDimensions.Y + (innerDimensions.Height * 0.25f));
			this.DrawPanel(spriteBatch, vector, innerDimensions.Width - dimensions.Width - 12f);
			Utils.DrawBorderStringBig(spriteBatch, itemName, new Vector2(num + 12f, innerDimensions.Y + (innerDimensions.Height * 0.25f)), textColor, 0.45f);
			spriteBatch.Draw(this.dividerTexture, new Vector2(num, innerDimensions.Y + (innerDimensions.Height * 0.65f)), null, Color.White, 0f, Vector2.Zero, new Vector2((GetDimensions().X + base.GetDimensions().Width - num) / 8f, 1f), SpriteEffects.None, 0f);
		}
	}
}
