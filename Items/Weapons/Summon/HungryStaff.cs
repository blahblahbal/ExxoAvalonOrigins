using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Summon;

class HungryStaff : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Hungry Staff");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.DamageType = DamageClass.Summon;
        Item.damage = 27;
        Item.shootSpeed = 14f;
        Item.mana = 15;
        Item.noMelee = true;
        Item.rare = ItemRarityID.LightRed;
        Item.width = dims.Width;
        Item.useTime = 30;
        Item.knockBack = 5.5f;
        Item.shoot = ModContent.ProjectileType<Projectiles.Summon.HungrySummon>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.value = Item.sellPrice(0, 1, 0, 0);
        Item.useAnimation = 30;
        Item.height = dims.Height;
        Item.UseSound = SoundID.Item44;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<Material.FleshyTendril>(), 14).AddTile(TileID.Anvils).Register();
    }
    public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage,
                               ref float knockBack)
    {
        float posX = (float)Main.mouseX + Main.screenPosition.X;
        float posY = (float)Main.mouseY + Main.screenPosition.Y;
        int num227 = Projectile.NewProjectile(posX, posY, 0f, 0f, type, damage, knockBack, player.whoAmI, 0f, 0f);
        if (player.Avalon().fleshLaser)
        {
            Main.projectile[num227].minionSlots = 0.25f;
        }

        return false;
    }
}