using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.Projectiles.Torches
{
    public class BrownTorch : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Brown Torch");
        }

        public override void SetDefaults()
        {
            Projectile.width = 6;
            Projectile.height = 14;
            Projectile.aiStyle = 1;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.light = 1f;
            Projectile.damage = 0;
            Projectile.DamageType = // projectile.tileCollide = true /* tModPorter - this is redundant, for more info see https://github.com/tModLoader/tModLoader/wiki/Update-Migration-Guide#damage-classes */ ;
        }
        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item, (int)Projectile.position.X, (int)Projectile.position.Y, 10);
            if (Projectile.aiStyle == 1)
            {
                int it = ModContent.ItemType<Items.Placeable.Light.BrownTorch>();
                int style = 5;
                int TileX = (int)(Projectile.position.X + Projectile.width * 0.5f) / 16;
                int TileY = (int)(Projectile.position.Y + Projectile.height * 0.5f) / 16;

                if (TileX < 0 || TileX >= Main.maxTilesX || TileY < 0 || TileY >= Main.maxTilesY)
                {
                    Projectile.active = false;
                    return;
                }
                if (!Main.tile[TileX, TileY].HasTile)
                {
                    WorldGen.PlaceTile(TileX, TileY, ModContent.TileType<Tiles.Torches>(), false, true, -1, 0);
                    // not sure if PlaceTile calls TileFrame
                    WorldGen.TileFrame(TileX, TileY);
                    Main.tile[TileX, TileY].TileFrameY = (short)(style * 22);
                    if (Main.netMode != NetmodeID.SinglePlayer)
                    {
                        NetMessage.SendData(MessageID.TileChange, -1, -1, null, 1, TileX, TileY, ModContent.TileType<Tiles.Torches>(), style);
                    }
                    Projectile.active = false;
                }
                else
                {
                    Item.NewItem((int)Projectile.position.X, (int)Projectile.position.Y, 16, 16, it);
                    Projectile.active = false;
                }

                if (!Main.tile[TileX, TileY].HasTile && (Main.tile[TileX + 1, TileY + 1].HasTile || Main.tile[TileX - 1, TileY + 1].HasTile || Main.tile[TileX + 1, TileY - 1].HasTile || Main.tile[TileX - 1, TileY - 1].HasTile) && !Main.tile[TileX, TileY + 1].HasTile)
                {
                    Item.NewItem((int)Projectile.position.X, (int)Projectile.position.Y, 16, 16, it);
                    Projectile.active = false;
                }
                if (Main.tile[TileX, TileY].liquid > 0)
                {
                    Item.NewItem((int)Projectile.position.X, (int)Projectile.position.Y, 16, 16, it);
                    Projectile.active = false;
                }
                if (Main.tile[TileX, TileY + 1].slope() != 0 || Main.tile[TileX, TileY + 1].IsHalfBlock)
                {
                    Item.NewItem((int)Projectile.position.X, (int)Projectile.position.Y, 16, 16, it);
                    Projectile.active = false;
                }
                Projectile.active = false;
            }
        }
    }
}
