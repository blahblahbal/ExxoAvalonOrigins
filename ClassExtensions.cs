using System;
using System.Collections.Generic;
using System.Linq;
using ExxoAvalonOrigins.Items.Placeable.Tile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Mono.Cecil;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using ReLogic.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins
{
    public static class ClassExtensions
    {
        public static Rectangle NewRectVector2(Vector2 V, Vector2 WH)
        {
            return new Rectangle((int)V.X, (int)V.Y, (int)WH.X, (int)WH.Y);
        }
        public static bool exists(this Item item)
        {
            return item.type > ItemID.None && item.stack > 0;
        }
        public static bool InPillarZone(this Player p)
        {
            if (!p.ZoneTowerStardust && !p.ZoneTowerVortex && !p.ZoneTowerSolar)
            {
                return p.ZoneTowerNebula;
            }
            return true;
        }
        public static int RemoveAtIndex(this List<int> list, int index)
        {
            int item = list[index];
            list.RemoveAt(index);
            return item;
        }
        public static int AddVariable(this ILContext context, Type type)
        {
            context.Body.Variables.Add(new VariableDefinition(context.Import(type)));
            return context.Body.Variables.Count - 1;
        }

        public static int GetArgumentIndex(this ILContext context, string name)
        {
            ParameterDefinition def = context.Method.Parameters.FirstOrDefault(parameter => parameter.Name == name);
            return def?.Index + 1 ?? throw new Exception($"Parameter with name '{name}' does not exist!");
        }
        public static void DrawOutlinedString(this SpriteBatch spriteBatch, DynamicSpriteFont spriteFont, string text, Vector2 position, Color normalColor, Color outlineColor, float strength, float scale)
        {
            var positions = new Vector2[] { new Vector2(position.X + strength, position.Y + strength), new Vector2(position.X - strength, position.Y - strength), new Vector2(position.X + strength, position.Y - strength), new Vector2(position.X - strength, position.Y + strength) };
            foreach (Vector2 v in positions)
            {
                spriteBatch.DrawString(spriteFont, text, new Vector2(v.X + (spriteFont.MeasureString(text).X / 2), v.Y + (spriteFont.MeasureString(text).Y / 2)), outlineColor, 0f, new Vector2(spriteFont.MeasureString(text).X / 2, spriteFont.MeasureString(text).Y / 2), scale, SpriteEffects.None, 1f);
            }
            spriteBatch.DrawString(spriteFont, text, new Vector2(position.X + (spriteFont.MeasureString(text).X / 2), position.Y + (spriteFont.MeasureString(text).Y / 2)), normalColor, 0f, new Vector2(spriteFont.MeasureString(text).X / 2, spriteFont.MeasureString(text).Y / 2), scale, SpriteEffects.None, 1f);
        }

        public static Texture2D GetTexture(this ModItem item)
        {
            return ModContent.GetTexture(item.Texture);
        }
        public static Rectangle GetDims(this ModItem item)
        {
            if (Main.netMode == NetmodeID.Server)
            {
                return new Rectangle(0, 0, 1, 1);
            }

            return item.GetTexture().Bounds;
        }
        public static int GetTile(this ExxoAvalonOriginsWorld.RhodiumVariant osmiumVariant)
        {
            switch (osmiumVariant)
            {
                case ExxoAvalonOriginsWorld.RhodiumVariant.osmium:
                    return ModContent.TileType<Tiles.OsmiumOre>();
                case ExxoAvalonOriginsWorld.RhodiumVariant.rhodium:
                    return ModContent.TileType<Tiles.RhodiumOre>();
                case ExxoAvalonOriginsWorld.RhodiumVariant.iridium:
                    return ModContent.TileType<Tiles.IridiumOre>();
                default:
                    return -1;
            }
        }
        public static int GetItemOre(this ExxoAvalonOriginsWorld.RhodiumVariant osmiumVariant)
        {
            switch (osmiumVariant)
            {
                case ExxoAvalonOriginsWorld.RhodiumVariant.osmium:
                    return ModContent.ItemType<OsmiumOre>();
                case ExxoAvalonOriginsWorld.RhodiumVariant.rhodium:
                    return ModContent.ItemType<RhodiumOre>();
                case ExxoAvalonOriginsWorld.RhodiumVariant.iridium:
                    return ModContent.ItemType<IridiumOre>();
                default:
                    return -1;
            }
        }
    }
}
