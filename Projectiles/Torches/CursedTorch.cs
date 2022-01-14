using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Projectiles.Torches
{
    public class CursedTorch : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cursed Torch");
        }

        public override void SetDefaults()
        {
            projectile.width = 6;
            projectile.height = 14;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.light = 1f;
            projectile.damage = 0;
            projectile.ranged = projectile.tileCollide = true;
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 10);
            if (projectile.aiStyle == 1)
            {
                int it = ItemID.CursedTorch;
                int style = 8;
                int TileX = (int)(projectile.position.X + projectile.width * 0.5f) / 16;
                int TileY = (int)(projectile.position.Y + projectile.height * 0.5f) / 16;

                if (TileX < 0 || TileX >= Main.maxTilesX || TileY < 0 || TileY >= Main.maxTilesY)
                {
                    projectile.active = false;
                    return;
                }
                if (!Main.tile[TileX, TileY].active())
                {
                    WorldGen.PlaceTile(TileX, TileY, 4, false, true, -1, 0);
                    // not sure if PlaceTile calls TileFrame
                    WorldGen.TileFrame(TileX, TileY);
                    Main.tile[TileX, TileY].frameY = (short)(style * 22);
                    projectile.active = false;
                }
                else
                {
                    Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, 16, 16, it);
                    projectile.active = false;
                }

                if (!Main.tile[TileX, TileY].active() && (Main.tile[TileX + 1, TileY + 1].active() || Main.tile[TileX - 1, TileY + 1].active() || Main.tile[TileX + 1, TileY - 1].active() || Main.tile[TileX - 1, TileY - 1].active()) && !Main.tile[TileX, TileY + 1].active())
                {
                    Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, 16, 16, it);
                    projectile.active = false;
                }
                if (Main.tile[TileX, TileY + 1].slope() != 0 || Main.tile[TileX, TileY + 1].halfBrick())
                {
                    Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, 16, 16, it);
                    projectile.active = false;
                }
                //if (Main.tile[TileX, TileY].liquid > 0)
                //{
                //    Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, 16, 16, it);
                //    projectile.active = false;
                //}
                projectile.active = false;
            }
        }
    }
}
