using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    class BagofIck : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bag of Ick");
            Tooltip.SetDefault("Icky particles cover you when you move");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.rare = ItemRarityID.Green;
            Item.width = dims.Width;
            Item.accessory = true;
            Item.vanity = true;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.height = dims.Height;
            Item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().updateInvisibleVanity = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.controlRight)
            {
                var num24 = Dust.NewDust(player.position, player.width - 20, player.height, DustID.Vile, 0f, 0f, 100, Color.White, 0.9f);
                Main.dust[num24].noGravity = true;
                var num25 = Dust.NewDust(player.position, player.width - 20, player.height, DustID.Vile, 0f, 0f, 100, Color.White, 1.5f);
                Main.dust[num25].noGravity = true;
            }
            if (player.controlLeft)
            {
                var num26 = Dust.NewDust(player.position, player.width + 20, player.height, DustID.Vile, 0f, 0f, 100, Color.White, 0.9f);
                Main.dust[num26].noGravity = true;
                var num27 = Dust.NewDust(player.position, player.width + 20, player.height, DustID.Vile, 0f, 0f, 100, Color.White, 1.5f);
                Main.dust[num27].noGravity = true;
            }
            if (player.controlJump)
            {
                var num28 = Dust.NewDust(player.position, player.width + 20, player.height + 20, DustID.Vile, 0f, 0f, 100, Color.White, 0.9f);
                Main.dust[num28].noGravity = true;
                var num29 = Dust.NewDust(player.position, player.width + 20, player.height + 20, DustID.Vile, 0f, 0f, 100, Color.White, 1.5f);
                Main.dust[num29].noGravity = true;
            }
            if (player.controlRight)
            {
                var num67 = Dust.NewDust(player.position, player.width - 20, player.height, DustID.Vile, 0f, 0f, 100, Color.White, 0.9f);
                Main.dust[num67].noGravity = true;
                var num68 = Dust.NewDust(player.position, player.width - 20, player.height, DustID.Vile, 0f, 0f, 100, Color.White, 1.5f);
                Main.dust[num68].noGravity = true;
            }
            if (player.controlLeft)
            {
                var num69 = Dust.NewDust(player.position, player.width + 20, player.height, DustID.Vile, 0f, 0f, 100, Color.White, 0.9f);
                Main.dust[num69].noGravity = true;
                var num70 = Dust.NewDust(player.position, player.width + 20, player.height, DustID.Vile, 0f, 0f, 100, Color.White, 1.5f);
                Main.dust[num70].noGravity = true;
            }
            if (player.controlJump)
            {
                var num71 = Dust.NewDust(player.position, player.width + 20, player.height + 20, DustID.Vile, 0f, 0f, 100, Color.White, 0.9f);
                Main.dust[num71].noGravity = true;
                var num72 = Dust.NewDust(player.position, player.width + 20, player.height + 20, DustID.Vile, 0f, 0f, 100, Color.White, 1.5f);
                Main.dust[num72].noGravity = true;
            }
        }

        public override void UpdateVanity(Player player, EquipType type)
        {
            if (player.controlRight)
            {
                var num24 = Dust.NewDust(player.position, player.width - 20, player.height, DustID.Vile, 0f, 0f, 100, Color.White, 0.9f);
                Main.dust[num24].noGravity = true;
                var num25 = Dust.NewDust(player.position, player.width - 20, player.height, DustID.Vile, 0f, 0f, 100, Color.White, 1.5f);
                Main.dust[num25].noGravity = true;
            }
            if (player.controlLeft)
            {
                var num26 = Dust.NewDust(player.position, player.width + 20, player.height, DustID.Vile, 0f, 0f, 100, Color.White, 0.9f);
                Main.dust[num26].noGravity = true;
                var num27 = Dust.NewDust(player.position, player.width + 20, player.height, DustID.Vile, 0f, 0f, 100, Color.White, 1.5f);
                Main.dust[num27].noGravity = true;
            }
            if (player.controlJump)
            {
                var num28 = Dust.NewDust(player.position, player.width + 20, player.height + 20, DustID.Vile, 0f, 0f, 100, Color.White, 0.9f);
                Main.dust[num28].noGravity = true;
                var num29 = Dust.NewDust(player.position, player.width + 20, player.height + 20, DustID.Vile, 0f, 0f, 100, Color.White, 1.5f);
                Main.dust[num29].noGravity = true;
            }
            if (player.controlRight)
            {
                var num67 = Dust.NewDust(player.position, player.width - 20, player.height, DustID.Vile, 0f, 0f, 100, Color.White, 0.9f);
                Main.dust[num67].noGravity = true;
                var num68 = Dust.NewDust(player.position, player.width - 20, player.height, DustID.Vile, 0f, 0f, 100, Color.White, 1.5f);
                Main.dust[num68].noGravity = true;
            }
            if (player.controlLeft)
            {
                var num69 = Dust.NewDust(player.position, player.width + 20, player.height, DustID.Vile, 0f, 0f, 100, Color.White, 0.9f);
                Main.dust[num69].noGravity = true;
                var num70 = Dust.NewDust(player.position, player.width + 20, player.height, DustID.Vile, 0f, 0f, 100, Color.White, 1.5f);
                Main.dust[num70].noGravity = true;
            }
            if (player.controlJump)
            {
                var num71 = Dust.NewDust(player.position, player.width + 20, player.height + 20, DustID.Vile, 0f, 0f, 100, Color.White, 0.9f);
                Main.dust[num71].noGravity = true;
                var num72 = Dust.NewDust(player.position, player.width + 20, player.height + 20, DustID.Vile, 0f, 0f, 100, Color.White, 1.5f);
                Main.dust[num72].noGravity = true;
            }
        }
    }
}
