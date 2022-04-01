using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    class BagofHallows : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bag of Hallows");
            Tooltip.SetDefault("Hallow particles cover you when you move");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.rare = ItemRarityID.LightPurple;
            Item.width = dims.Width;
            Item.accessory = true;
            Item.vanity = true;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.height = dims.Height;
            Item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().updateInvisibleVanity = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.controlRight)
            {
                var num15 = Dust.NewDust(player.position, player.width - 20, player.height, DustID.Enchanted_Gold, 0f, 0f, 100, Color.White, 2f);
                Main.dust[num15].noGravity = true;
            }
            if (player.controlLeft)
            {
                var num16 = Dust.NewDust(player.position, player.width + 20, player.height, DustID.Enchanted_Gold, 0f, 0f, 100, Color.White, 2f);
                Main.dust[num16].noGravity = true;
            }
            if (player.controlJump)
            {
                var num17 = Dust.NewDust(player.position, player.width + 20, player.height + 20, DustID.Enchanted_Gold, 0f, 0f, 100, Color.White, 2f);
                Main.dust[num17].noGravity = true;
            }
            if (player.controlRight)
            {
                var num58 = Dust.NewDust(player.position, player.width - 20, player.height, DustID.Enchanted_Gold, 0f, 0f, 100, Color.White, 2f);
                Main.dust[num58].noGravity = true;
            }
            if (player.controlLeft)
            {
                var num59 = Dust.NewDust(player.position, player.width + 20, player.height, DustID.Enchanted_Gold, 0f, 0f, 100, Color.White, 2f);
                Main.dust[num59].noGravity = true;
            }
            if (player.controlJump)
            {
                var num60 = Dust.NewDust(player.position, player.width + 20, player.height + 20, DustID.Enchanted_Gold, 0f, 0f, 100, Color.White, 2f);
                Main.dust[num60].noGravity = true;
            }
        }

        public override void UpdateVanity(Player player, EquipType type)
        {
            if (player.controlRight)
            {
                var num15 = Dust.NewDust(player.position, player.width - 20, player.height, DustID.Enchanted_Gold, 0f, 0f, 100, Color.White, 2f);
                Main.dust[num15].noGravity = true;
            }
            if (player.controlLeft)
            {
                var num16 = Dust.NewDust(player.position, player.width + 20, player.height, DustID.Enchanted_Gold, 0f, 0f, 100, Color.White, 2f);
                Main.dust[num16].noGravity = true;
            }
            if (player.controlJump)
            {
                var num17 = Dust.NewDust(player.position, player.width + 20, player.height + 20, DustID.Enchanted_Gold, 0f, 0f, 100, Color.White, 2f);
                Main.dust[num17].noGravity = true;
            }
            if (player.controlRight)
            {
                var num58 = Dust.NewDust(player.position, player.width - 20, player.height, DustID.Enchanted_Gold, 0f, 0f, 100, Color.White, 2f);
                Main.dust[num58].noGravity = true;
            }
            if (player.controlLeft)
            {
                var num59 = Dust.NewDust(player.position, player.width + 20, player.height, DustID.Enchanted_Gold, 0f, 0f, 100, Color.White, 2f);
                Main.dust[num59].noGravity = true;
            }
            if (player.controlJump)
            {
                var num60 = Dust.NewDust(player.position, player.width + 20, player.height + 20, DustID.Enchanted_Gold, 0f, 0f, 100, Color.White, 2f);
                Main.dust[num60].noGravity = true;
            }
        }
    }
}
