using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Ammo
{
    public class FrostCanister : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 12;
            item.ranged = true;
            item.width = 14;
            item.height = 18;
            item.maxStack = 999;
            item.consumable = true;
            item.value = 10;
            item.rare = ItemRarityID.Red;
            item.ammo = ModContent.ItemType<Canister>();
            item.shoot = ModContent.ProjectileType<Projectiles.FrostFire>();
        }
    }
}
