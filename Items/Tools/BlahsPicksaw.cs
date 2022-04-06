using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools;

class BlahsPicksaw : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Blah's Picksaw");
        Tooltip.SetDefault("The user can mine at warp speed");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.UseSound = SoundID.Item1;
        Item.damage = 50;
        Item.autoReuse = true;
        Item.useTurn = true;
        Item.scale = 1.15f;
        Item.axe = 50;
        Item.pick = 425;
        Item.rare = ModContent.RarityType<Rarities.RainbowRarity>();
        Item.width = dims.Width;
        Item.useTime = 7;
        Item.knockBack = 7f;
        Item.DamageType = DamageClass.Melee;
        Item.tileBoost += 6;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.value = 1016000;
        Item.useAnimation = 7;
        Item.height = dims.Height;
    }

    public override void HoldItem(Player player)
    {
        if (player.inventory[player.selectedItem].type == Mod.Find<ModItem>("BlahsPicksaw").Type)
        {
            player.pickSpeed -= 0.5f;
        }
    }

    /*        public override bool UseItem(Player player)
            {
                if (Main.netMode != NetmodeID.Server)
                {
                    if (Main.tile[Player.tileTargetX, Player.tileTargetY].HasTile)
                    {
                        int tileId = player.hitTile.HitObject(Player.tileTargetX, Player.tileTargetY, 1);
                        if (player.inventory[player.selectedItem].pick >= ExxoAvalonOrigins.minPick[Main.tile[Player.tileTargetX, Player.tileTargetY].type])
                            player.hitTile.AddDamage(tileId, player.inventory[player.selectedItem].pick, true);
                        return true;
                    }
                }
                return false;
            }*/
}
