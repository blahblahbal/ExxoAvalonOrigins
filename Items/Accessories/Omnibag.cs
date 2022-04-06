using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories;

class Omnibag : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Omnibag");
        Tooltip.SetDefault("A lot of particles cover you when you move");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.Lime;
        Item.width = dims.Width;
        Item.accessory = true;
        Item.vanity = true;
        Item.value = Item.sellPrice(0, 2, 0, 0);
        Item.height = dims.Height;
        Item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().updateInvisibleVanity = true;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<BagofIck>()).AddIngredient(ModContent.ItemType<BagofBlood>()).AddIngredient(ModContent.ItemType<BagofShadows>()).AddIngredient(ModContent.ItemType<BagofHallows>()).AddIngredient(ModContent.ItemType<BagofFrost>()).AddIngredient(ModContent.ItemType<BagofFire>()).AddTile(TileID.MythrilAnvil).Register();
    }
    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        if (player.controlRight)
        {
            int dust = Dust.NewDust(player.position, player.width - 20, player.height, DustID.Torch, 0, 0, 100, Color.White, 2f);
            Main.dust[dust].noGravity = true;
            dust = Dust.NewDust(player.position, player.width - 20, player.height, DustID.Shadowflame, 0, 0, 100, Color.White, 2f);
            Main.dust[dust].noGravity = true;
            dust = Dust.NewDust(player.position, player.width - 20, player.height, DustID.Enchanted_Gold, 0, 0, 100, Color.White, 2f);
            Main.dust[dust].noGravity = true;
            int dust3 = Dust.NewDust(player.position, player.width - 20, player.height, DustID.TheDestroyer, 0, 0, 100, Color.White, .9f);
            Main.dust[dust3].noGravity = true;
            int dust2 = Dust.NewDust(player.position, player.width - 20, player.height, DustID.Blood, 0, 0, 100, Color.White, 1.5f);
            Main.dust[dust2].noGravity = true;
            dust = Dust.NewDust(player.position, player.width - 20, player.height, DustID.CorruptGibs, 0, 0, 100, Color.White, .9f);
            Main.dust[dust].noGravity = true;
            dust2 = Dust.NewDust(player.position, player.width - 20, player.height, DustID.CorruptGibs, 0, 0, 100, Color.White, 1.5f);
            Main.dust[dust2].noGravity = true;
            for (int num126 = 0; num126 < 4; num126++)
            {
                float num127 = player.velocity.X / 3f * (float)num126;
                float num128 = player.velocity.Y / 3f * (float)num126;
                int num129 = 4;
                int num130 = Dust.NewDust(new Vector2(player.position.X + (float)num129, player.position.Y + (float)num129), player.width - num129 * 2, player.height - num129 * 2, DustID.IceTorch, 0f, 0f, 100, default(Color), 1.8f);
                Main.dust[num130].noGravity = true;
                Main.dust[num130].velocity *= 0.1f;
                Main.dust[num130].velocity += player.velocity * 0.1f;
                Main.dust[num130].position.X -= num127;
                Main.dust[num130].position.Y -= num128;
            }
            if (Main.rand.Next(3) == 0)
            {
                int num131 = 4;
                int num132 = Dust.NewDust(new Vector2(player.position.X + (float)num131, player.position.Y + (float)num131), player.width - num131 * 2, player.height - num131 * 2, DustID.MagicMirror, 0f, 0f, 100, default(Color), 0.6f);
                Main.dust[num132].noGravity = true;
                Main.dust[num132].velocity *= 0.25f;
                Main.dust[num132].velocity += player.velocity * 0.5f;
            }
        }
        if (player.controlLeft)
        {
            int dust = Dust.NewDust(player.position, player.width + 20, player.height, DustID.Torch, 0, 0, 100, Color.White, 2f);
            Main.dust[dust].noGravity = true;
            dust = Dust.NewDust(player.position, player.width + 20, player.height, DustID.Shadowflame, 0, 0, 100, Color.White, 2f);
            Main.dust[dust].noGravity = true;
            dust = Dust.NewDust(player.position, player.width + 20, player.height, DustID.Enchanted_Gold, 0, 0, 100, Color.White, 2f);
            Main.dust[dust].noGravity = true;
            int dust3 = Dust.NewDust(player.position, player.width + 20, player.height, DustID.TheDestroyer, 0, 0, 100, Color.White, .9f);
            Main.dust[dust3].noGravity = true;
            int dust2 = Dust.NewDust(player.position, player.width + 20, player.height, DustID.Blood, 0, 0, 100, Color.White, 1.5f);
            Main.dust[dust2].noGravity = true;
            dust = Dust.NewDust(player.position, player.width + 20, player.height, DustID.CorruptGibs, 0, 0, 100, Color.White, .9f);
            Main.dust[dust].noGravity = true;
            dust2 = Dust.NewDust(player.position, player.width + 20, player.height, DustID.CorruptGibs, 0, 0, 100, Color.White, 1.5f);
            Main.dust[dust2].noGravity = true;
            for (int num126 = 0; num126 < 4; num126++)
            {
                float num127 = player.velocity.X / 3f * (float)num126;
                float num128 = player.velocity.Y / 3f * (float)num126;
                int num129 = 4;
                int num130 = Dust.NewDust(new Vector2(player.position.X + (float)num129, player.position.Y + (float)num129), player.width - num129 * 2, player.height - num129 * 2, DustID.IceTorch, 0f, 0f, 100, default(Color), 1.8f);
                Main.dust[num130].noGravity = true;
                Main.dust[num130].velocity *= 0.1f;
                Main.dust[num130].velocity += player.velocity * 0.1f;
                Main.dust[num130].position.X -= num127;
                Main.dust[num130].position.Y -= num128;
            }
            if (Main.rand.Next(3) == 0)
            {
                int num131 = 4;
                int num132 = Dust.NewDust(new Vector2(player.position.X + (float)num131, player.position.Y + (float)num131), player.width - num131 * 2, player.height - num131 * 2, DustID.MagicMirror, 0f, 0f, 100, default(Color), 0.6f);
                Main.dust[num132].noGravity = true;
                Main.dust[num132].velocity *= 0.25f;
                Main.dust[num132].velocity += player.velocity * 0.5f;
            }
        }
        if (player.controlJump)
        {
            int dust = Dust.NewDust(player.position, player.width + 20, player.height + 20, DustID.Torch, 0, 0, 100, Color.White, 2f);
            Main.dust[dust].noGravity = true;
            dust = Dust.NewDust(player.position, player.width + 20, player.height + 20, DustID.Shadowflame, 0, 0, 100, Color.White, 2f);
            Main.dust[dust].noGravity = true;
            dust = Dust.NewDust(player.position, player.width + 20, player.height + 20, DustID.Enchanted_Gold, 0, 0, 100, Color.White, 2f);
            Main.dust[dust].noGravity = true;
            int dust3 = Dust.NewDust(player.position, player.width + 20, player.height + 20, DustID.TheDestroyer, 0, 0, 100, Color.White, .9f);
            Main.dust[dust3].noGravity = true;
            int dust2 = Dust.NewDust(player.position, player.width + 20, player.height + 20, DustID.Blood, 0, 0, 100, Color.White, 1.5f);
            Main.dust[dust2].noGravity = true;
            dust = Dust.NewDust(player.position, player.width + 20, player.height + 20, DustID.CorruptGibs, 0, 0, 100, Color.White, .9f);
            Main.dust[dust].noGravity = true;
            dust2 = Dust.NewDust(player.position, player.width + 20, player.height + 20, DustID.CorruptGibs, 0, 0, 100, Color.White, 1.5f);
            Main.dust[dust2].noGravity = true;
            dust = Dust.NewDust(player.position, player.width - 20, player.height, DustID.IceTorch, 0, 0, 100, Color.White, 2f);
            Main.dust[dust].noGravity = true;
        }
    }

    public override void UpdateVanity(Player player)
    {
        if (player.controlRight)
        {
            int dust = Dust.NewDust(player.position, player.width - 20, player.height, DustID.Torch, 0, 0, 100, Color.White, 2f);
            Main.dust[dust].noGravity = true;
            dust = Dust.NewDust(player.position, player.width - 20, player.height, DustID.Shadowflame, 0, 0, 100, Color.White, 2f);
            Main.dust[dust].noGravity = true;
            dust = Dust.NewDust(player.position, player.width - 20, player.height, DustID.Enchanted_Gold, 0, 0, 100, Color.White, 2f);
            Main.dust[dust].noGravity = true;
            int dust3 = Dust.NewDust(player.position, player.width - 20, player.height, DustID.TheDestroyer, 0, 0, 100, Color.White, .9f);
            Main.dust[dust3].noGravity = true;
            int dust2 = Dust.NewDust(player.position, player.width - 20, player.height, DustID.Blood, 0, 0, 100, Color.White, 1.5f);
            Main.dust[dust2].noGravity = true;
            dust = Dust.NewDust(player.position, player.width - 20, player.height, DustID.CorruptGibs, 0, 0, 100, Color.White, .9f);
            Main.dust[dust].noGravity = true;
            dust2 = Dust.NewDust(player.position, player.width - 20, player.height, DustID.CorruptGibs, 0, 0, 100, Color.White, 1.5f);
            Main.dust[dust2].noGravity = true;
            for (int num126 = 0; num126 < 4; num126++)
            {
                float num127 = player.velocity.X / 3f * (float)num126;
                float num128 = player.velocity.Y / 3f * (float)num126;
                int num129 = 4;
                int num130 = Dust.NewDust(new Vector2(player.position.X + (float)num129, player.position.Y + (float)num129), player.width - num129 * 2, player.height - num129 * 2, DustID.IceTorch, 0f, 0f, 100, default(Color), 1.8f);
                Main.dust[num130].noGravity = true;
                Main.dust[num130].velocity *= 0.1f;
                Main.dust[num130].velocity += player.velocity * 0.1f;
                Main.dust[num130].position.X -= num127;
                Main.dust[num130].position.Y -= num128;
            }
            if (Main.rand.Next(3) == 0)
            {
                int num131 = 4;
                int num132 = Dust.NewDust(new Vector2(player.position.X + (float)num131, player.position.Y + (float)num131), player.width - num131 * 2, player.height - num131 * 2, DustID.MagicMirror, 0f, 0f, 100, default(Color), 0.6f);
                Main.dust[num132].noGravity = true;
                Main.dust[num132].velocity *= 0.25f;
                Main.dust[num132].velocity += player.velocity * 0.5f;
            }
        }
        if (player.controlLeft)
        {
            int dust = Dust.NewDust(player.position, player.width + 20, player.height, DustID.Torch, 0, 0, 100, Color.White, 2f);
            Main.dust[dust].noGravity = true;
            dust = Dust.NewDust(player.position, player.width + 20, player.height, DustID.Shadowflame, 0, 0, 100, Color.White, 2f);
            Main.dust[dust].noGravity = true;
            dust = Dust.NewDust(player.position, player.width + 20, player.height, DustID.Enchanted_Gold, 0, 0, 100, Color.White, 2f);
            Main.dust[dust].noGravity = true;
            int dust3 = Dust.NewDust(player.position, player.width + 20, player.height, DustID.TheDestroyer, 0, 0, 100, Color.White, .9f);
            Main.dust[dust3].noGravity = true;
            int dust2 = Dust.NewDust(player.position, player.width + 20, player.height, DustID.Blood, 0, 0, 100, Color.White, 1.5f);
            Main.dust[dust2].noGravity = true;
            dust = Dust.NewDust(player.position, player.width + 20, player.height, DustID.CorruptGibs, 0, 0, 100, Color.White, .9f);
            Main.dust[dust].noGravity = true;
            dust2 = Dust.NewDust(player.position, player.width + 20, player.height, DustID.CorruptGibs, 0, 0, 100, Color.White, 1.5f);
            Main.dust[dust2].noGravity = true;
            for (int num126 = 0; num126 < 4; num126++)
            {
                float num127 = player.velocity.X / 3f * (float)num126;
                float num128 = player.velocity.Y / 3f * (float)num126;
                int num129 = 4;
                int num130 = Dust.NewDust(new Vector2(player.position.X + (float)num129, player.position.Y + (float)num129), player.width - num129 * 2, player.height - num129 * 2, DustID.IceTorch, 0f, 0f, 100, default(Color), 1.8f);
                Main.dust[num130].noGravity = true;
                Main.dust[num130].velocity *= 0.1f;
                Main.dust[num130].velocity += player.velocity * 0.1f;
                Main.dust[num130].position.X -= num127;
                Main.dust[num130].position.Y -= num128;
            }
            if (Main.rand.Next(3) == 0)
            {
                int num131 = 4;
                int num132 = Dust.NewDust(new Vector2(player.position.X + (float)num131, player.position.Y + (float)num131), player.width - num131 * 2, player.height - num131 * 2, DustID.MagicMirror, 0f, 0f, 100, default(Color), 0.6f);
                Main.dust[num132].noGravity = true;
                Main.dust[num132].velocity *= 0.25f;
                Main.dust[num132].velocity += player.velocity * 0.5f;
            }
        }
        if (player.controlJump)
        {
            int dust = Dust.NewDust(player.position, player.width + 20, player.height + 20, DustID.Torch, 0, 0, 100, Color.White, 2f);
            Main.dust[dust].noGravity = true;
            dust = Dust.NewDust(player.position, player.width + 20, player.height + 20, DustID.Shadowflame, 0, 0, 100, Color.White, 2f);
            Main.dust[dust].noGravity = true;
            dust = Dust.NewDust(player.position, player.width + 20, player.height + 20, DustID.Enchanted_Gold, 0, 0, 100, Color.White, 2f);
            Main.dust[dust].noGravity = true;
            int dust3 = Dust.NewDust(player.position, player.width + 20, player.height + 20, DustID.TheDestroyer, 0, 0, 100, Color.White, .9f);
            Main.dust[dust3].noGravity = true;
            int dust2 = Dust.NewDust(player.position, player.width + 20, player.height + 20, DustID.Blood, 0, 0, 100, Color.White, 1.5f);
            Main.dust[dust2].noGravity = true;
            dust = Dust.NewDust(player.position, player.width + 20, player.height + 20, DustID.CorruptGibs, 0, 0, 100, Color.White, .9f);
            Main.dust[dust].noGravity = true;
            dust2 = Dust.NewDust(player.position, player.width + 20, player.height + 20, DustID.CorruptGibs, 0, 0, 100, Color.White, 1.5f);
            Main.dust[dust2].noGravity = true;
            dust = Dust.NewDust(player.position, player.width - 20, player.height, DustID.IceTorch, 0, 0, 100, Color.White, 2f);
            Main.dust[dust].noGravity = true;
        }
    }
}
