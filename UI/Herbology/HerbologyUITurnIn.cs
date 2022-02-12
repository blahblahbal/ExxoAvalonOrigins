using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.UI;

namespace ExxoAvalonOrigins.UI.Herbology
{
    internal class HerbologyUITurnIn : ExxoUIPanelWrapper<ExxoUIList>
    {
        public readonly ExxoUIItemSlot ItemSlot;
        public readonly ExxoUIImageButton Button;
        public HerbologyUITurnIn() : base(new ExxoUIList())
        {
            FitMinToInnerElement = true;
            Height.Set(0, 1);

            InnerElement.Height.Set(0, 1);
            InnerElement.Justification = Justification.Center;
            InnerElement.FitWidthToContent = true;
            InnerElement.ContentHAlign = UIAlign.Center;

            Button = new ExxoUIImageButton(ExxoAvalonOrigins.Mod.GetTexture("Sprites/HerbButton"))
            {
                Tooltip = "Consume Herbs/Potions",
            };
            InnerElement.Append(Button);

            ItemSlot = new ExxoUIItemSlot(Main.inventoryBack7Texture, ItemID.None);
            InnerElement.Append(ItemSlot);
            ItemSlot.OnClick += delegate
            {
                if ((Main.mouseItem.type == ItemID.None && (ItemSlot.Item.type != ItemID.None && ItemSlot.Item.stack > 0)) || (Main.mouseItem.stack >= 1 && (ExxoAvalonOriginsGlobalItem.IsHerb(Main.mouseItem.type) || ExxoAvalonOriginsGlobalItem.IsPotion(Main.mouseItem.type) || ExxoAvalonOriginsGlobalItem.IsAdvancedPotion(Main.mouseItem.Name))))
                {
                    Main.PlaySound(SoundID.Grab);
                    Item item6 = Main.mouseItem;
                    Main.mouseItem = ItemSlot.Item;
                    ItemSlot.Item = item6;
                    Recipe.FindRecipes();
                }
            };
        }

        public override void UpdateSelf(GameTime gameTime)
        {
            base.UpdateSelf(gameTime);
            Button.LocalScale = 1 + ((1 + (float)Math.Sin(gameTime.TotalGameTime.TotalSeconds)) * 0.15f);
            Button.LocalRotation = (((float)Math.Sin(gameTime.TotalGameTime.TotalSeconds + 1)) * 0.25f);
        }
    }
}
