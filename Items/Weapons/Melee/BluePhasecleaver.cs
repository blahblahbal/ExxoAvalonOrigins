using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
    class BluePhasecleaver : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blue Phasecleaver");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.damage = 80;
            item.UseSound = SoundID.Item15;
            item.autoReuse = true;
            item.scale = 1.2f;
            item.useTurn = true;
            item.rare = ItemRarityID.Lime;
            item.width = dims.Width;
            item.useTime = 20;
            item.knockBack = 5.25f;
            item.melee = true;
            item.value = 70000;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useAnimation = 20;
            item.height = dims.Height;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            Lighting.AddLight((int)((player.itemLocation.X + 6f + player.velocity.X) / 16f), (int)((player.itemLocation.Y - 14f) / 16f), 0.05f, 0.25f, 0.6f);
        }
    }
}
