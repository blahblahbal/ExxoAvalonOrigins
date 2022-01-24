using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    class SpectrumHelmet : ModItem
    {
        public static int R { get; private set; } = 255;
        public static int G { get; private set; } = 0;
        public static int B { get; private set; } = 0;
        private static int style = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spectrum Helmet");
            Tooltip.SetDefault("20% increased ranged damage\n3% increased ranged critical strike chance");
        }
        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.defense = 32;
            item.rare = ItemRarityID.Red;
            item.width = dims.Width;
            item.value = Item.sellPrice(0, 40, 0, 0);
            item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Placeable.Bar.OblivionBar>(), 20);
            recipe.AddIngredient(ModContent.ItemType<Material.DarkMatterGel>(), 40);
            recipe.AddIngredient(ModContent.ItemType<AncientHeadpiece>());
            recipe.AddIngredient(ModContent.ItemType<Material.SoulofBlight>(), 3);
            recipe.AddIngredient(ModContent.ItemType<Placeable.Tile.Opal>(), 10);
            recipe.AddTile(ModContent.TileType<Tiles.SolariumAnvil>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<SpectrumBreastplate>() && legs.type == ModContent.ItemType<SpectrumGreaves>();
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "The slower you walk the more damage you gain, up to 25%" +
                "\nWhile moving at maximum speed, you have a chance to dodge attacks";
            player.Avalon().spectrumSpeed = true;
        }
        public override void UpdateEquip(Player player)
        {
            player.rangedDamage += 0.25f;
            player.rangedCrit += 3;
        }
        public override void PostDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            Texture2D texture = mod.GetTexture("Items/Armor/SpectrumHelmet_Glow");
            spriteBatch.Draw(texture, position, frame, new Color(R, G, B), 0f, origin, scale, SpriteEffects.None, 0f);
        }
        //public override void DrawArmorColor(Player drawPlayer, float shadow, ref Color color, ref int glowMask, ref Color glowMaskColor)
        //{
        //    //ModContent.GetEquipTexture(EquipType.Head, ModContent.GetInstance<SpectrumHelmet_Glow>().Slot);
            
        //    glowMask = mod.GetEquipSlot(ModContent.GetInstance<SpectrumHelmet_Glow>().Texture, EquipType.Head);
        //    glowMaskColor = new Color(R, G, B);
        //}
        public static void StaticUpdate()
        {
            int speed = 4;
            if (style == 0)
            {
                G += speed;
                if (G >= 255)
                {
                    G = 255;
                    style++;
                }
            }
            if (style == 1)
            {
                R -= speed;
                if (R <= 0)
                {
                    R = 0;
                    style++;
                }
            }
            if (style == 2)
            {
                B += speed;
                if (B >= 255)
                {
                    B = 255;
                    style++;
                }
            }
            if (style == 3)
            {
                G -= speed;
                if (G <= 0)
                {
                    G = 0;
                    style++;
                }
            }
            if (style == 4)
            {
                R += speed;
                if (R >= 255)
                {
                    R = 255;
                    style++;
                }
            }
            if (style == 5)
            {
                B -= speed;
                if (B <= 0)
                {
                    B = 0;
                    style = 0;
                }
            }
        }
    }
}
