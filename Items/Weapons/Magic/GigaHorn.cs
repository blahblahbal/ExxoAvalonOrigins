using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic
{
    class GigaHorn : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Giga Horn");
            Tooltip.SetDefault("Summons a powerful sonic blast");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.DamageType = DamageClass.Magic;
            Item.damage = 45;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.scale = 0.9f;
            Item.shootSpeed = 2f;
            Item.mana = 60;
            Item.crit += 3;
            Item.noMelee = true;
            Item.rare = ItemRarityID.Yellow;
            Item.width = dims.Width;
            Item.knockBack = 4f;
            Item.useTime = 29;
            Item.shoot = ModContent.ProjectileType<Projectiles.Soundwave>();
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = Mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/GigaHorn");
            Item.value = Item.sellPrice(0, 9, 0, 0);
            Item.reuseDelay = 14;
            Item.useAnimation = 29;
            Item.height = dims.Height;
        }
    }
}
