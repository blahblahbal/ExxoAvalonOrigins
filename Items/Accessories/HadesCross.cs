using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    internal class HadesCross : ModItem
    {
        public static Texture2D[] lavaMermanTextures = new Texture2D[]
        {
            ExxoAvalonOrigins.mod.GetTexture("Sprites/LavaMerman_Head"),
            ExxoAvalonOrigins.mod.GetTexture("Sprites/LavaMerman_Body"),
            ExxoAvalonOrigins.mod.GetTexture("Sprites/LavaMerman_Arms"),
            ExxoAvalonOrigins.mod.GetTexture("Sprites/LavaMerman_FemaleBody"),
            ExxoAvalonOrigins.mod.GetTexture("Sprites/LavaMerman_Legs")
        };

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hades' Cross");
            Tooltip.SetDefault("Provides the ability to breathe in, and free movement in lava\nNegates damage from lava");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.defense = 3;
            item.rare = ItemRarityID.LightPurple;
            item.width = dims.Width;
            item.value = Item.sellPrice(0, 9, 72, 0);
            item.accessory = true;
            item.height = dims.Height;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            bool flag = Collision.LavaCollision(player.position, player.width, player.height);
            if (flag)
            {
                player.GetModPlayer<ExxoAvalonOriginsModPlayer>().mermanLava = true;
                player.merman = true;
                player.accFlipper = true;
                player.ignoreWater = true;
                player.lavaImmune = true;
            }
            player.lavaImmune = true;
            player.fireWalk = true;
            player.waterWalk = true;
        }
    }
}
