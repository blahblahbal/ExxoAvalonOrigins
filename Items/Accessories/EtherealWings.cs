using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    [AutoloadEquip(EquipType.Wings)]
    class EtherealWings : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ethereal Wings");
            Tooltip.SetDefault("Allows flight and slow fall\nOther bonuses apply when in the Dungeon");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.Yellow;
            item.width = dims.Width;
            item.value = 800000;
            item.accessory = true;
            item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(ItemID.GhostWings);
            r.AddIngredient(ItemID.Bone, 500);
            r.AddTile(TileID.MythrilAnvil);
            r.SetResult(this);
            r.AddRecipe();
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.wingTimeMax = 170;
            if (player.ZoneDungeon)
            {
                player.statLifeMax2 += 40;
                player.statDefense += 8;
                if (player.controlLeft)
                {
                    if (player.velocity.X > -5) player.velocity.X -= 0.31f;
                    if (player.velocity.X < -5 && player.velocity.X > -10)
                    {
                        player.velocity.X -= 0.29f;
                    }
                }
                if (player.controlRight)
                {
                    if (player.velocity.X < 5) player.velocity.X += 0.31f;
                    if (player.velocity.X > 5 && player.velocity.X < 10)
                    {
                        player.velocity.X += 0.29f;
                    }
                }
                if (player.velocity.X > 6 || player.velocity.X < -6)
                {
                    Color color = new Color();
                    int dust = Dust.NewDust(new Vector2((float)player.position.X, (float)player.position.Y), player.width, player.height, 16, Main.rand.Next(-5, 5), Main.rand.Next(-5, 5), 100, color, 2.0f);
                    Main.dust[dust].noGravity = true;
                }
            }
        }
    }
}
