using System;
using System.Collections.Generic;
using System.Linq;
using ExxoAvalonOrigins.Tiles.Ores;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Mono.Cecil;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using ReLogic.Content;
using ReLogic.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace ExxoAvalonOrigins;

public static class ClassExtensions
{
    /// <summary>
    ///     Helper method to reduce code writing.
    /// </summary>
    /// <param name="player">The current player.</param>
    /// <returns>Returns the ExxoAvalonOriginsModPlayer instance.</returns>
    public static ExxoAvalonOriginsModPlayer Avalon(this Player player)
    {
        return player.GetModPlayer<ExxoAvalonOriginsModPlayer>();
    }

    /// <summary>
    ///     A helper method to check if the given Player is touching the ground.
    /// </summary>
    /// <param name="player"></param>
    /// <returns>Returns true if the player is touching the ground.</returns>
    public static bool isOnGround(this Player player)
    {
        return (Main.tile[(int)(player.position.X / 16f), (int)(player.position.Y / 16f) + 3].HasTile &&
                Main.tileSolid
                    [Main.tile[(int)(player.position.X / 16f), (int)(player.position.Y / 16f) + 3].TileType]) ||
               (Main.tile[(int)(player.position.X / 16f) + 1, (int)(player.position.Y / 16f) + 3].HasTile &&
                Main.tileSolid[
                    Main.tile[(int)(player.position.X / 16f) + 1, (int)(player.position.Y / 16f) + 3].TileType] &&
                player.velocity.Y == 0f);
    }

    /// <summary>
    ///     Rotate a Vector2.
    /// </summary>
    /// <param name="spinningpoint">The origin.</param>
    /// <param name="radians">The angle in radians to rotate the Vector2 by.</param>
    /// <param name="center"></param>
    /// <returns>Returns the rotated Vector2.</returns>
    public static Vector2 Rotate(this Vector2 spinningpoint, double radians, Vector2 center = default)
    {
        float num = (float)Math.Cos(radians);
        float num2 = (float)Math.Sin(radians);
        Vector2 vector = spinningpoint - center;
        Vector2 result = center;
        result.X += (vector.X * num) - (vector.Y * num2);
        result.Y += (vector.X * num2) + (vector.Y * num);
        return result;
    }

    public static Rectangle NewRectVector2(Vector2 v, Vector2 wH)
    {
        return new Rectangle((int)v.X, (int)v.Y, (int)wH.X, (int)wH.Y);
    }

    /// <summary>
    ///     Checks if the current player has an item in their armor/accessory slots.
    /// </summary>
    /// <param name="p">The player.</param>
    /// <param name="type">The item ID to check.</param>
    /// <returns>Whether or not the item is found.</returns>
    public static bool HasItemInArmor(this Player p, int type)
    {
        for (int i = 0; i < p.armor.Length; i++)
        {
            if (type == p.armor[i].type)
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    ///     Helper method for Vampire Teeth and Blah's Knives lifesteal.
    /// </summary>
    /// <param name="p">The player.</param>
    /// <param name="dmg">The damage to use in the lifesteal calculation.</param>
    /// <param name="position">The position to spawn the lifesteal projectile at.</param>
    public static void VampireHeal(this Player p, int dmg, Vector2 position)
    {
        float num = dmg * 0.075f;
        if ((int)num == 0)
        {
            return;
        }

        if (p.lifeSteal <= 0f)
        {
            return;
        }

        p.lifeSteal -= num;
        int num2 = p.whoAmI;
        Projectile.NewProjectile(p.GetProjectileSource_Accessory(new Item(ModContent.ItemType<Items.Accessories.VampireTeeth>())), position.X, position.Y, 0f, 0f, ProjectileID.VampireHeal, 0, 0f, p.whoAmI, num2, num);
    }

    public static bool Slope(this Tile t)
    {
        return t.BottomSlope || t.LeftSlope || t.RightSlope || t.TopSlope;
    }

    public static bool Exists(this Item item)
    {
        return item.type > ItemID.None && item.stack > 0;
    }

    /// <summary>
    ///     Increases all of the Player instance's critical strike chance values.
    /// </summary>
    /// <param name="p">The Player instance.</param>
    /// <param name="amt">The amount to increase the crit chance by.</param>
    public static void AllCrit(this Player p, int amt)
    {
        p.GetCritChance(DamageClass.Magic) += amt;
        p.GetCritChance(DamageClass.Melee) += amt;
        p.GetCritChance(DamageClass.Ranged) += amt;
        p.GetCritChance(DamageClass.Throwing) += amt;
    }

    /// <summary>
    ///     Finds the closest NPC to the Projectile instance.
    /// </summary>
    /// <param name="p">The Projectile instance.</param>
    /// <param name="dist">The distance from this Projectile instance that is desired.</param>
    /// <returns>Returns the index in the Main.npc[] NPC array.</returns>
    public static int FindClosestNPC(this Projectile p, float dist)
    {
        int closest = -1;
        float last = dist;
        for (int i = 0; i < Main.npc.Length; i++)
        {
            NPC n = Main.npc[i];
            if (!n.active || n.townNPC || n.dontTakeDamage)
            {
                continue;
            }

            if (Vector2.Distance(p.Center, n.Center) < last)
            {
                last = Vector2.Distance(p.Center, n.Center);
                closest = i;
            }
        }

        return closest;
    }

    public static bool DrawFishingLine(this Projectile projectile, int fishingRodType, Color lineColor,
                                       int xPositionAdditive = 45, float yPositionAdditive = 35f)
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
            playerMountedXCenter += xPositionAdditive * player.direction;
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

        var playerPosModified = new Vector2(playerMountedXCenter, y);
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

                num6 = 1f - (num6 / 16f);
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

                num6 = 1f - (projectile.localAI[0] / 100f);
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
            float rotation = vector2.ToRotation() - ((float)Math.PI / 2f);
            Main.spriteBatch.Draw(TextureAssets.FishingLine.Value,
                new Vector2(playerPosModified.X - Main.screenPosition.X + (TextureAssets.FishingLine.Value.Width * 0.5f),
                    playerPosModified.Y - Main.screenPosition.Y + (TextureAssets.FishingLine.Value.Height * 0.5f)),
                new Rectangle(0, 0, TextureAssets.FishingLine.Value.Width, (int)num3), color, rotation,
                new Vector2(TextureAssets.FishingLine.Value.Width * 0.5f, 0f), 1f, SpriteEffects.None, 0f);
        }

        return false;
    }

    /// <summary>
    ///     A helper method to check if the player is in any of the Lunar event's pillar zones.
    /// </summary>
    /// <param name="p">The current player.</param>
    /// <returns>Whether or not the player is in a pillar zone.</returns>
    public static bool InPillarZone(this Player p)
    {
        if (!p.ZoneTowerStardust && !p.ZoneTowerVortex && !p.ZoneTowerSolar)
        {
            return p.ZoneTowerNebula;
        }

        return true;
    }

    /// <summary>
    ///     Removes the specified index of a List of int - used for Golem dropping 2 items from its 11-drop loot table.
    /// </summary>
    /// <param name="list">The List of int.</param>
    /// <param name="index">The index.</param>
    /// <returns>Returns the item ID of the removed index.</returns>
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

    /// <summary>
    ///     Draws an outlined string.
    /// </summary>
    public static void DrawOutlinedString(this SpriteBatch spriteBatch, DynamicSpriteFont spriteFont, string text,
                                          Vector2 position, Color normalColor, Color outlineColor, float strength,
                                          float scale)
    {
        Vector2[] positions =
        {
            new(position.X + strength, position.Y + strength), new(position.X - strength, position.Y - strength),
            new(position.X + strength, position.Y - strength), new(position.X - strength, position.Y + strength)
        };
        foreach (Vector2 v in positions)
        {
            spriteBatch.DrawString(spriteFont, text,
                new Vector2(v.X + (spriteFont.MeasureString(text).X / 2), v.Y + (spriteFont.MeasureString(text).Y / 2)),
                outlineColor, 0f,
                new Vector2(spriteFont.MeasureString(text).X / 2, spriteFont.MeasureString(text).Y / 2), scale,
                SpriteEffects.None, 1f);
        }

        spriteBatch.DrawString(spriteFont, text,
            new Vector2(position.X + (spriteFont.MeasureString(text).X / 2),
                position.Y + (spriteFont.MeasureString(text).Y / 2)), normalColor, 0f,
            new Vector2(spriteFont.MeasureString(text).X / 2, spriteFont.MeasureString(text).Y / 2), scale,
            SpriteEffects.None, 1f);
    }

    public static Asset<Texture2D> GetTexture(this ModTexturedType texturedType)
    {
        return ModContent.Request<Texture2D>(texturedType.Texture);
    }

    public static Rectangle GetDims(this ModTexturedType texturedType)
    {
        return Main.netMode == NetmodeID.Server ? Rectangle.Empty : texturedType.GetTexture().Frame();
    }

    public static int GetTile(this ExxoAvalonOriginsWorld.RhodiumVariant osmiumVariant)
    {
        switch (osmiumVariant)
        {
            case ExxoAvalonOriginsWorld.RhodiumVariant.osmium:
                return ModContent.TileType<OsmiumOre>();
            case ExxoAvalonOriginsWorld.RhodiumVariant.rhodium:
                return ModContent.TileType<RhodiumOre>();
            case ExxoAvalonOriginsWorld.RhodiumVariant.iridium:
                return ModContent.TileType<IridiumOre>();
            default:
                return -1;
        }
    }

    public static int GetItemOre(this ExxoAvalonOriginsWorld.RhodiumVariant osmiumVariant)
    {
        switch (osmiumVariant)
        {
            case ExxoAvalonOriginsWorld.RhodiumVariant.osmium:
                return ModContent.ItemType<Items.Placeable.Tile.OsmiumOre>();
            case ExxoAvalonOriginsWorld.RhodiumVariant.rhodium:
                return ModContent.ItemType<Items.Placeable.Tile.RhodiumOre>();
            case ExxoAvalonOriginsWorld.RhodiumVariant.iridium:
                return ModContent.ItemType<Items.Placeable.Tile.IridiumOre>();
            default:
                return -1;
        }
    }

    // Used to draw float coordinates to nearest pixel coordinates to avoid blurry rendering of textures
    public static Vector2 ToNearestPixel(this Vector2 vector)
    {
        return new Vector2((int)vector.X, (int)vector.Y);
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
