using ExxoAvalonOrigins.Logic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Ranged;

public class Hellrazer : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Hellrazer");
        Tooltip.SetDefault("Fires a powerful, high velocity bullet\nMusket Balls turn into Explosive rounds"); //Nusket
    }
    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.UseSound = SoundID.Item11;
        Item.damage = 110;
        Item.autoReuse = true;
        Item.useTurn = false;
        Item.useAmmo = AmmoID.Bullet;
        Item.shootSpeed = 8f;
        Item.crit += 10;
        Item.DamageType = DamageClass.Ranged;
        Item.rare = ItemRarityID.Yellow;
        Item.noMelee = true;
        Item.width = dims.Width;
        Item.knockBack = 12f;
        Item.useTime = 30;
        Item.shoot = ProjectileID.Bullet;
        Item.value = Item.sellPrice(0, 30, 0, 0);
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.useAnimation = 30;
        Item.height = dims.Height;
        Item.UseSound = SoundID.Item40;
        if (!Main.dedServ)
        {
            Item.GetGlobalItem<ItemUseGlow>().glowTexture = ModContent.Request<Texture2D>(Texture + "_Glow");
        }
        Item.GetGlobalItem<ItemUseGlow>().glowOffsetX = -5;
        Item.GetGlobalItem<ItemUseGlow>().glowOffsetY = 0;
    }
    public override Vector2? HoldoutOffset()
    {
        return new Vector2(-5, 0);
    }
    public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
    {
        Texture2D texture = Mod.Assets.Request<Texture2D>("Items/Weapons/Ranged/Hellrazer_Glow").Value;
        spriteBatch.Draw
        (
            texture,
            new Vector2
            (
                Item.position.X - Main.screenPosition.X + Item.width * 0.5f,
                Item.position.Y - Main.screenPosition.Y + Item.height - texture.Height * 0.5f + 2f
            ),
            new Rectangle(0, 0, texture.Width, texture.Height),
            Color.White,
            rotation,
            texture.Size() * 0.5f,
            scale,
            SpriteEffects.None,
            0f
        );
    }
    public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
    {
        if (type == ProjectileID.Bullet)
        {
            type = ProjectileID.ExplosiveBullet;
        }
        return true;
    }
}