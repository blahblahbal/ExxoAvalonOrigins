using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic
{
    class FocusPulse : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Focus Pulse");
            Tooltip.SetDefault("Fires a sustained-beam chaining-homing laser\nDO NOT USE THIS WEAPON, IT IS VERY UNFINISHED AND BUGGY");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.DamageType = DamageClass.Magic;
            Item.damage = 10;
            Item.useTurn = true;
            Item.scale = 1f;
            Item.shootSpeed = 15f;
            Item.crit += 1;
            Item.mana = 18;
            Item.rare = ItemRarityID.Orange;
            Item.channel = true;
            Item.noMelee = true;
            Item.width = dims.Width;
            Item.useTime = 27;
            Item.knockBack = 5f;
            Item.shoot = ModContent.ProjectileType<Projectiles.PulseLaserCharging>();
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.value = 388500;
            Item.useAnimation = 27;
            Item.height = dims.Height;
            //item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/Beam");
        }
    }
}
