using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.Items.Other;

class GoldCandyCane : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Golden Candy Cane");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.width = dims.Width;
        Item.height = dims.Height;
    }

    public override bool CanPickup(Player player)
    {
        return true;
    }

    public override bool OnPickup(Player player)
    {
        if (player.statLife + 40 > player.statLifeMax2) player.statLife = player.statLifeMax2; else player.statLife += 40;
        if (Main.myPlayer == player.whoAmI)
        {
            player.HealEffect(40, true);
        }
        SoundEngine.PlaySound(SoundID.Grab, player.position);
        return false;
    }
}