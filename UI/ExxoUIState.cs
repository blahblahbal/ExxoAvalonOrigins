using Microsoft.Xna.Framework;
using Terraria;
using Terraria.UI;

namespace ExxoAvalonOrigins.UI
{
    internal class ExxoUIState : UIState
    {
        public bool DisableRecipeScrolling = true;
        public bool FocusInteractionsToUI = true;
        public bool HideItemHoverIcon = true;
        private int oldFocusRecipe;
        private bool mouseWasOver;
        public bool ChildrenContainsPoint(Vector2 point)
        {
            foreach (UIElement element in Elements)
            {
                if (element.ContainsPoint(point))
                {
                    return true;
                }
            }
            return false;
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (mouseWasOver)
            {
                Main.LocalPlayer.showItemIcon = !HideItemHoverIcon;
                Main.LocalPlayer.mouseInterface = FocusInteractionsToUI;
                if (DisableRecipeScrolling)
                {
                    Main.focusRecipe = oldFocusRecipe;
                }
            }
        }
        public override void OnInitialize()
        {
            base.OnInitialize();
            RemoveAllChildren();
        }
        public override void MiddleDoubleClick(UIMouseEvent evt)
        {
            base.MiddleDoubleClick(evt);
            if (ExxoAvalonOrigins.DevMode)
            {
                OnInitialize();
            }
        }

        public override void MouseOver(UIMouseEvent evt)
        {
            base.MouseOver(evt);
            if (evt.Target != this && !mouseWasOver)
            {
                mouseWasOver = true;
                oldFocusRecipe = Main.focusRecipe;
            }
        }

        public override void MouseOut(UIMouseEvent evt)
        {
            base.MouseOut(evt);
            if (!ChildrenContainsPoint(evt.MousePosition))
            {
                mouseWasOver = false;
            }
        }
    }
}
