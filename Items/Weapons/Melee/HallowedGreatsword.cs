using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
    class HallowedGreatsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hallowed Greatsword");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.damage = 43;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.scale = 1.5f;
            Item.rare = ItemRarityID.Pink;
            Item.width = dims.Width;
            Item.useTime = 26;
            Item.knockBack = 2f;
            Item.DamageType = DamageClass.Melee;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.value = Item.sellPrice(0, 5, 55, 0);
            Item.useAnimation = 26;
            Item.height = dims.Height;
            Item.UseSound = SoundID.Item1;
        }
    }
}
