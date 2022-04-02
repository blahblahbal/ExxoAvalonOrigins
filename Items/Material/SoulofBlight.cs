using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material;

class SoulofBlight : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Soul of Blight");
        Tooltip.SetDefault("'The essence of death'");
        Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 4));
        ItemID.Sets.AnimatesAsSoul[Item.type] = true;
        ItemID.Sets.ItemIconPulse[Item.type] = true;
        ItemID.Sets.ItemNoGravity[Item.type] = true;
    }
    public override Color? GetAlpha(Color lightColor)
    {
        return new Color(255, 255, 255, 100);
    }
    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.Yellow;
        Item.width = dims.Width;
        Item.maxStack = 999;
        Item.width = dims.Width;
        Item.value = 80000;
        Item.height = 28;
    }
    public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
    {
        float num7 = (float)Main.rand.Next(90, 111) * 0.01f;
        num7 *= Main.essScale;
        Lighting.AddLight((int)((Item.position.X + (float)(Item.width / 2)) / 16f), (int)((Item.position.Y + (float)(Item.height / 2)) / 16f), 0.4f * num7, 0.4f * num7, 0.4f * num7);
    }
}