using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using Terraria.ModLoader.IO;
using Terraria.UI;

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

        public static void RecalculateSelf(this UIElement element)
        {
            CalculatedStyle calculatedStyle = ((element.Parent == null) ? UserInterface.ActiveInstance.GetDimensions() : element.Parent.GetInnerDimensions());
            var calculatedStyle2 = default(CalculatedStyle);
            calculatedStyle2.X = element.Left.GetValue(calculatedStyle.Width) + calculatedStyle.X;
            calculatedStyle2.Y = element.Top.GetValue(calculatedStyle.Height) + calculatedStyle.Y;
            float value = element.MinWidth.GetValue(calculatedStyle.Width);
            float value2 = element.MaxWidth.GetValue(calculatedStyle.Width);
            float value3 = element.MinHeight.GetValue(calculatedStyle.Height);
            float value4 = element.MaxHeight.GetValue(calculatedStyle.Height);
            calculatedStyle2.Width = MathHelper.Clamp(element.Width.GetValue(calculatedStyle.Width), value, value2);
            calculatedStyle2.Height = MathHelper.Clamp(element.Height.GetValue(calculatedStyle.Height), value3, value4);
            calculatedStyle2.Width += element.MarginLeft + element.MarginRight;
            calculatedStyle2.Height += element.MarginTop + element.MarginBottom;
            calculatedStyle2.X += calculatedStyle.Width * element.HAlign - calculatedStyle2.Width * element.HAlign;
            calculatedStyle2.Y += calculatedStyle.Height * element.VAlign - calculatedStyle2.Height * element.VAlign;
            typeof(UIElement).GetField("_outerDimensions", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(element, calculatedStyle2);
            calculatedStyle2.X += element.MarginLeft;
            calculatedStyle2.Y += element.MarginTop;
            calculatedStyle2.Width -= element.MarginLeft + element.MarginRight;
            calculatedStyle2.Height -= element.MarginTop + element.MarginBottom;
            typeof(UIElement).GetField("_dimensions", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(element, calculatedStyle2);
            calculatedStyle2.X += element.PaddingLeft;
            calculatedStyle2.Y += element.PaddingTop;
            calculatedStyle2.Width -= element.PaddingLeft + element.PaddingRight;
            calculatedStyle2.Height -= element.PaddingTop + element.PaddingBottom;
            typeof(UIElement).GetField("_innerDimensions", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(element, calculatedStyle2);
        }

        // Used to draw float coordinates to nearest pixel coordinates to avoid blurry rendering of textures
        public static Vector2 ToNearestPixel(this Vector2 vector)
        {
            return new Vector2((int)vector.X, (int)vector.Y);
        }

        public static void DrawWithoutUpdate(this UserInterface userInterface, SpriteBatch spriteBatch)
        {
            if (userInterface.CurrentState != null)
            {
                userInterface.Recalculate();
                userInterface.CurrentState.Draw(spriteBatch);
            }
        }

        public static TagCompound Save<TKey, TValue>(this Dictionary<TKey, TValue> dictionary)
        {
            TKey[] keys = dictionary.Keys.ToArray();
            TValue[] values = dictionary.Values.ToArray();
            var tag = new TagCompound();
            tag.Set("keys", keys);
            tag.Set("values", values);
            return tag;
        }

        public static void Load<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TagCompound tag)
        {
            if (tag.ContainsKey("keys") && tag.ContainsKey("values"))
            {
                TKey[] keys = tag.Get<TKey[]>("keys");
                TValue[] values = tag.Get<TValue[]>("values");

                for (int i = 0; i < keys.Length; i++)
                {
                    dictionary[keys[i]] = values[i];
                }
            }
        }
    }
}
