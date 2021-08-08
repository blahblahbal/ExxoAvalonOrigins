using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using ExxoAvalonOrigins.Items;
using MonoMod.Cil;
using Mono.Cecil.Cil;

namespace ExxoAvalonOrigins.Hooks
{
    public class LargeGem
    {
        public static void OnDrawTile(On.Terraria.Main.orig_DrawItem orig, Main self, Item item, int whoami)
        {
            if (!(item.modItem is null))
            {
                Color color = Lighting.GetColor((int)((double)item.position.X + (double)item.width * 0.5) / 16, (int)((double)item.position.Y + (double)item.height * 0.5) / 16);
                Color currentColor = item.GetAlpha(color);
                float scale = 1f;

                Texture2D itemTexture = item.modItem.GetTexture();

                float rotation = item.velocity.X * 0.2f;
                float num5 = item.height - itemTexture.Height;
                float num6 = item.width / 2 - itemTexture.Width / 2;

                if (item.type == ModContent.ItemType<LargeZircon>() || item.type == ModContent.ItemType<LargeTourmaline>() || item.type == ModContent.ItemType<LargeTourmaline>() || item.type == ModContent.ItemType<LargePeridot>())
                {
                    Main.spriteBatch.Draw(itemTexture, new Vector2(item.position.X - Main.screenPosition.X + (float)(itemTexture.Width / 2) + num6, item.position.Y - Main.screenPosition.Y + (float)(itemTexture.Height / 2) + num5 + 2f), new Rectangle(0, 0, itemTexture.Width, itemTexture.Height), new Color(250, 250, 250, (int)Main.mouseTextColor / 2), rotation, new Vector2(itemTexture.Width / 2, itemTexture.Height / 2), (float)(int)Main.mouseTextColor / 1000f + 0.8f, SpriteEffects.None, 0f);
                    ItemLoader.PostDrawInWorld(item, Main.spriteBatch, color, currentColor, rotation, scale, whoami);
                }
                else
                {
                    orig(self, item, whoami);
                }
            }
            else
            {
                orig(self, item, whoami);
            }
        }

        public static void HookILDrawPlayer(ILContext il)
        {
            var c = new ILCursor(il);

            // Move il cursor into positon
            if (!c.TryGotoNext(i => i.MatchLdfld<Player>(nameof(Player.ownedLargeGems))))
                return;
            if (!c.TryGotoNext(i => i.MatchLdcI4(0)))
                return;

            // Automatically shift cursor after each emit
            c.MoveAfterLabels();

            // Make game skip original drawing of gems
            c.Emit(OpCodes.Pop);
            c.Emit(OpCodes.Ldc_I4_0);
        }
    }
}
