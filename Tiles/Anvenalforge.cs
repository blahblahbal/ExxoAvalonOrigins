using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ExxoAvalonOrigins.Tiles
{
    public class Anvenalforge : ModTile
    {
        public override void SetDefaults()
        {
            AddMapEntry(new Color(76, 255, 0), LanguageManager.Instance.GetText("Anvenalforge"));
            Main.tileFrameImportant[Type] = true;
            animationFrameHeight = 54;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.DrawYOffset = 2;
            TileObjectData.newTile.LavaDeath = false;
            TileObjectData.addTile(Type);
            Main.tileLighted[Type] = true;
            adjTiles = new int[]
            {
                ModContent.TileType<CaesiumForge>(),
                TileID.AdamantiteForge,
                TileID.Hellforge,
                TileID.Furnaces,
                TileID.WorkBenches,
                TileID.DemonAltar,
                ModContent.TileType<SolariumAnvil>(),
                TileID.MythrilAnvil,
                TileID.Anvils,
                ModContent.TileType<HallowedAltar>(),
                TileID.LunarCraftingStation
            };
        }

        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            frameCounter++;
            if (frameCounter > 4)
            {
                frameCounter = 0;
                frame++;
                if (frame > 3) frame = 0;
            }
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 48, 32, ModContent.ItemType<Items.Placeable.Crafting.Anvenalforge>());
        }
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 230f / 255f;
            g = 155f / 255f;
            b = 115f / 255f;
        }
        public override void NearbyEffects(int i, int j, bool closer)
        {
            if (Main.rand.Next(40) == 0)
            {
                int num56 = Dust.NewDust(new Vector2(i * 16 - 4, j * 16 - 6), 8, 6, 6, 0f, 0f, 100, default, 1f);
                if (Main.rand.Next(3) != 0)
                {
                    Main.dust[num56].noGravity = true;
                }
            }
        }
    }
}
