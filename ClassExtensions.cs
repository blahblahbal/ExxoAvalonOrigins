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
        public static ExxoAvalonOriginsModPlayer Avalon(this Player player) => player.GetModPlayer<ExxoAvalonOriginsModPlayer>();

        public static Rectangle NewRectVector2(Vector2 V, Vector2 WH)
        {
            return new Rectangle((int)V.X, (int)V.Y, (int)WH.X, (int)WH.Y);
        }
        public static bool exists(this Item item)
        {
            return item.type > ItemID.None && item.stack > 0;
        }
        public static void AllCrit(this Player p, int amt)
        {
            p.magicCrit += amt;
            p.meleeCrit += amt;
            p.rangedCrit += amt;
            p.thrownCrit += amt;
        }
        public static bool DrawFishingLine(this Projectile projectile, int fishingRodType, Color lineColor, int xPositionAdditive = 45, float yPositionAdditive = 35f)
        {
            Player player = Main.player[projectile.owner];
            Item heldItem = player.HeldItem;
            if (!projectile.bobber || heldItem.holdStyle <= 0)
            {
                return false;
            }
            float playerMountedXCenter = player.MountedCenter.X;
            float y = player.MountedCenter.Y;
            y += player.gfxOffY;
            float gravDir = player.gravDir;
            if (heldItem.type == fishingRodType)
            {
                playerMountedXCenter += (float)(xPositionAdditive * player.direction);
                if (player.direction < 0)
                {
                    playerMountedXCenter -= 13f;
                }
                y -= yPositionAdditive * gravDir;
            }
            if (gravDir == -1f)
            {
                y -= 12f;
            }
            Vector2 playerPosModified = new Vector2(playerMountedXCenter, y);
            playerPosModified = player.RotatedRelativePoint(playerPosModified + new Vector2(8f)) - new Vector2(8f);
            Vector2 vector2 = projectile.Center - playerPosModified;
            bool flag = true;
            if (vector2.X == 0f && vector2.Y == 0f)
            {
                return false;
            }
            float num2 = vector2.Length();
            num2 = 12f / num2;
            vector2.X *= num2;
            vector2.Y *= num2;
            playerPosModified -= vector2;
            vector2 = projectile.Center - playerPosModified;
            while (flag)
            {
                float num3 = 12f;
                float num4 = vector2.Length();
                if (float.IsNaN(num4) || float.IsNaN(num4))
                {
                    break;
                }
                if (num4 < 20f)
                {
                    num3 = num4 - 8f;
                    flag = false;
                }
                num4 = 12f / num4;
                vector2.X *= num4;
                vector2.Y *= num4;
                playerPosModified += vector2;
                vector2 = projectile.Center - playerPosModified;
                if (num4 > 12f)
                {
                    float num5 = 0.3f;
                    float num6 = Math.Abs(projectile.velocity.X) + Math.Abs(projectile.velocity.Y);
                    if (num6 > 16f)
                    {
                        num6 = 16f;
                    }
                    num6 = 1f - num6 / 16f;
                    num5 *= num6;
                    num6 = num4 / 80f;
                    if (num6 > 1f)
                    {
                        num6 = 1f;
                    }
                    num5 *= num6;
                    if (num5 < 0f)
                    {
                        num5 = 0f;
                    }
                    num6 = 1f - projectile.localAI[0] / 100f;
                    num5 *= num6;
                    if (vector2.Y > 0f)
                    {
                        vector2.Y *= 1f + num5;
                        vector2.X *= 1f - num5;
                    }
                    else
                    {
                        num6 = Math.Abs(projectile.velocity.X) / 3f;
                        if (num6 > 1f)
                        {
                            num6 = 1f;
                        }
                        num6 -= 0.5f;
                        num5 *= num6;
                        if (num5 > 0f)
                        {
                            num5 *= 2f;
                        }
                        vector2.Y *= 1f + num5;
                        vector2.X *= 1f - num5;
                    }
                }
                Color color = Lighting.GetColor((int)playerPosModified.X / 16, (int)playerPosModified.Y / 16, lineColor);
                float rotation = vector2.ToRotation() - (float)Math.PI / 2f;
                Main.spriteBatch.Draw(Main.fishingLineTexture, new Vector2(playerPosModified.X - Main.screenPosition.X + (float)Main.fishingLineTexture.Width * 0.5f, playerPosModified.Y - Main.screenPosition.Y + (float)Main.fishingLineTexture.Height * 0.5f), new Rectangle(0, 0, Main.fishingLineTexture.Width, (int)num3), color, rotation, new Vector2((float)Main.fishingLineTexture.Width * 0.5f, 0f), 1f, SpriteEffects.None, 0f);
            }
            return false;
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
                    return ModContent.TileType<Tiles.Ores.OsmiumOre>();
                case ExxoAvalonOriginsWorld.RhodiumVariant.rhodium:
                    return ModContent.TileType<Tiles.Ores.RhodiumOre>();
                case ExxoAvalonOriginsWorld.RhodiumVariant.iridium:
                    return ModContent.TileType<Tiles.Ores.IridiumOre>();
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
