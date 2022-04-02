using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools;

class TritanoriumPickaxe : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Tritanorium Pickaxe");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.damage = 30;
        Item.autoReuse = true;
        Item.useTurn = true;
        Item.scale = 1.15f;
        Item.pick = 260;
        Item.rare = ItemRarityID.Yellow;
        Item.width = dims.Width;
        Item.useTime = 13;
        Item.knockBack = 6.5f;
        Item.DamageType = DamageClass.Melee;
        Item.tileBoost += 2;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.value = 516000;
        Item.useAnimation = 15;
        Item.height = dims.Height;
        Item.UseSound = SoundID.Item1;
    }
    public override void HoldItem(Player player)
    {
        if (player.inventory[player.selectedItem].type == Item.type)
        {
            player.pickSpeed -= 0.25f;
        }
    }
}