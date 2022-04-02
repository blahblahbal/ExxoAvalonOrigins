using ExxoAvalonOrigins.Items.Accessories;
using ExxoAvalonOrigins.Network;
using ExxoAvalonOrigins.Projectiles.Summon;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs;

public class StingerProbe : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Stinger Probe");
        Description.SetDefault("'Don't get too close!'");
        Main.buffNoTimeDisplay[Type] = true;
        Main.buffNoSave[Type] = true;
    }

    public override void Update(Player player, ref int buffIndex)
    {
        ExxoAvalonOriginsModPlayer modPlayer = player.Avalon();

        if (player.dead || !player.active || !player.HasItemInArmor(ModContent.ItemType<AIController>()))
        {
            player.DelBuff(buffIndex);
            buffIndex--;
            return;
        }

        modPlayer.StingerProbeRotTimer += 0.5f;
        if (modPlayer.StingerProbeRotTimer >= 360)
        {
            modPlayer.StingerProbeRotTimer = 0;
        }

        if (player.whoAmI != Main.myPlayer)
        {
            return;
        }

        Vector2 mousePosition = Main.MouseWorld;
        if (Main.netMode == NetmodeID.MultiplayerClient)
        {
            modPlayer.MousePosition = mousePosition;
            CursorPosition.SendPacket(mousePosition, player.whoAmI);
        }
        else if (Main.netMode == NetmodeID.SinglePlayer)
        {
            modPlayer.MousePosition = mousePosition;
        }

        if (player.ownedProjectileCounts[ModContent.ProjectileType<StingerProbeMinion>()] < 4)
        {
            modPlayer.StingerProbeTimer++;
        }
        else
        {
            modPlayer.StingerProbeTimer = 0;
        }

        if (modPlayer.StingerProbeTimer >= 300)
        {
            Projectile.NewProjectile(player.GetProjectileSource_Buff(buffIndex), player.Center, Vector2.Zero,
                ModContent.ProjectileType<StingerProbeMinion>(), player.HeldItem.damage / 4 * 3, 0f, player.whoAmI);
            modPlayer.StingerProbeTimer = 0;
        }
    }
}
