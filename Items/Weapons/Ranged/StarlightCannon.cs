using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Ranged
{
    public class StarlightCannon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Starlight Cannon");
            Tooltip.SetDefault("Fires large balls of star matter\nCharges for 2.5 seconds");
        }
        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.damage = 350;
            item.scale = 1.1f;
            item.magic = true;
            item.autoReuse = true;
            item.useTurn = true;
            item.rare = ItemRarityID.Lime;
            item.noMelee = true;
            item.width = dims.Width;
            item.channel = true;
            item.height = dims.Height;
            item.mana = 50;
            item.useTime = 40;
            item.useAnimation = 40;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 7f;
            item.shoot = ModContent.ProjectileType<Projectiles.ChargingStar>();
            item.shootSpeed = 6f;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/Charging");
            item.value = 15500000;
        }

    }
}
