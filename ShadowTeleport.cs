using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace ExxoAvalonOrigins
{
    public class ShadowTeleport : GlobalItem
    {

        public static void Teleport(int teleportType = 0, bool forceHandle = false, int whoAmI = 0)
        {
            bool syncData = forceHandle || Main.netMode == 0;
            if (syncData)
            {
                TeleportPlayer(teleportType, forceHandle, whoAmI);
            }
            else
            {
                SyncTeleport(teleportType);
            }
        }

        private static void SyncTeleport(int teleportType = 0)
        {
            var netMessage = ExxoAvalonOrigins.mod.GetPacket();
            netMessage.Write((byte)AvalonMessageID.ShadowTeleport);
            netMessage.Write(teleportType);
            netMessage.Send();
        }

        private static void TeleportPlayer(int teleportType = 0, bool syncData = false, int whoAmI = 0)
        {
            Player player;
            if (!syncData)
            {
                player = Main.LocalPlayer;
            }
            else
            {
                player = Main.player[whoAmI];
            }
            switch (teleportType)
            {
                case 0:
                    DungeonTeleport(player, syncData);
                    break;
                case 1:
                    JungleTeleport(player, syncData);
                    break;
                case 2:
                    LeftOceanTeleport(player, syncData);
                    break;
                case 3:
                    RightOceanTeleport(player, syncData);
                    break;
                case 4:
                    UnderworldTeleport(player, syncData);
                    break;
                default:
                    break;
            }
        }

        private static void DungeonTeleport(Player player, bool syncData = false)
        {
            RunTeleport(player, new Vector2(Main.dungeonX, Main.dungeonY), syncData, true);
        }

        private static void LeftOceanTeleport(Player player, bool syncData = false)
        {
            Vector2 previousPos = player.position;
            Vector2 pos = previousPos;
            for (int x = 0; x < 200; ++x)
            {
                for (int y = 0; y < Main.tile.GetLength(1); ++y)
                {
                    if (Main.tile[x, y] == null) continue;
                    if (Main.tile[x, y].type != 81) continue;
                    pos = new Vector2((x + 1) * 16, (y - 16) * 16);
                    break;
                }
            }
            if (pos != previousPos)
            {
                RunTeleport(player, new Vector2(pos.X, pos.Y), syncData, false);
            }
            else return;
        }
        private static void RightOceanTeleport(Player player, bool syncData = false)
        {
            Vector2 previousPos = player.position;
            Vector2 pos = previousPos;
            for (int x = Main.maxTilesX - 200; x < Main.maxTilesX - 150; ++x)
            {
                for (int y = 0; y < Main.tile.GetLength(1); ++y)
                {
                    if (Main.tile[x, y] == null) continue;
                    if (Main.tile[x, y].type != 81) continue;
                    pos = new Vector2((x + 1) * 16, (y - 16) * 16);
                    break;
                }
            }
            if (pos != previousPos)
            {
                RunTeleport(player, new Vector2(pos.X, pos.Y), syncData, false);
            }
            else return;
        }

        private static void UnderworldTeleport(Player player, bool syncData = false)
        {
            Vector2 previousPos = player.position;
            Vector2 pos = previousPos;
            for (int x = Main.maxTilesX / 2 - 100; x < Main.maxTilesX / 2 + 100; ++x)
            {
                for (int y = 0; y < Main.tile.GetLength(1); ++y)
                {
                    if (Main.tile[x, y] == null) continue;
                    if (Main.tile[x, y].type != 75) continue;
                    pos = new Vector2((x - 3) * 16, (y + 2) * 16);
                    break;
                }
            }

            //for (int y = 0; y < Main.tile.GetLength(1); ++y)
            //{
            //    if (Main.tile[Main.maxTilesX / 2, y] == null) continue;
            //    //if (Main.tile[Main.maxTilesX / 2, y].type != 75) continue;
            //    pos = new Vector2(Main.maxTilesX / 2 * 16, (y + 2) * 16);
            //    break;
            //}
            if (pos != previousPos)
            {
                RunTeleport(player, new Vector2(pos.X, pos.Y), syncData, false);
            }
            else return;
        }

        private static void JungleTeleport(Player player, bool syncData = false)
        {
            Vector2 previousPos = player.position;
            Vector2 pos = previousPos;
            for (int y = Main.maxTilesY; y > Main.worldSurface - 150; --y)
            {
                for (int x = 0; x < Main.maxTilesX; ++x)
                {
                    if (Main.tile[x, y] == null) continue;
                    if (Main.tile[x, y].type != 233) continue;
                    pos = new Vector2((x) * 16, (y - 2) * 16);
                    break;
                }
            }
            if (pos != previousPos)
            {
                RunTeleport(player, new Vector2(pos.X, pos.Y), syncData, false);
            }
            else return;
        }

        private static void RunTeleport(Player player, Vector2 pos, bool syncData = false, bool convertFromTiles = false)
        {
            bool postImmune = player.immune;
            int postImmuneTime = player.immuneTime;

            if (convertFromTiles)
                pos = new Vector2(pos.X * 16 + 8 - player.width / 2, pos.Y * 16 - player.height);

            //Kill hooks
            player.grappling[0] = -1;
            player.grapCount = 0;
            for (int index = 0; index < 1000; ++index)
            {
                if (Main.projectile[index].active && Main.projectile[index].owner == player.whoAmI && Main.projectile[index].aiStyle == 7)
                    Main.projectile[index].Kill();
            }

            player.Teleport(pos, 2, 0);
            player.velocity = Vector2.Zero;
            player.immune = postImmune;
            player.immuneTime = postImmuneTime;

            if (Main.netMode != 2)
                return;

            if (syncData)
            {
                RemoteClient.CheckSection(player.whoAmI, player.position, 1);
                NetMessage.SendData(65, -1, -1, null, 0, (float)player.whoAmI, pos.X, pos.Y, 3, 0, 0);
            }
        }
    }
}