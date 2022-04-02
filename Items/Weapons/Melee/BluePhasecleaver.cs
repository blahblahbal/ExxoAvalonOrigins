using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee;

class BluePhasecleaver : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Blue Phasecleaver");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.damage = 80;
        Item.UseSound = SoundID.Item15;
        Item.autoReuse = true;
        Item.scale = 1.2f;
        Item.useTurn = true;
        Item.rare = ItemRarityID.Lime;
        Item.width = dims.Width;
        Item.useTime = 20;
        Item.knockBack = 5.25f;
        Item.DamageType = DamageClass.Melee;
        Item.value = 70000;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useAnimation = 20;
        Item.height = dims.Height;
    }
    public override void MeleeEffects(Player player, Rectangle hitbox)
    {
        Lighting.AddLight((int)((player.itemLocation.X + 6f + player.velocity.X) / 16f), (int)((player.itemLocation.Y - 14f) / 16f), 0.05f, 0.25f, 0.6f);
    }
}