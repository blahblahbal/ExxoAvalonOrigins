using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.UI;

namespace ExxoAvalonOrigins.UI
{
    internal class AdvancedUIState : UIState
    {
        protected readonly List<UIElement> ElementsToRemove = new List<UIElement>();
        public void MarkForRemoval(UIElement element)
        {
            ElementsToRemove.Add(element);
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            foreach (UIElement element in ElementsToRemove)
            {
                element.Remove();
            }
            ElementsToRemove.Clear();
        }
    }
}
