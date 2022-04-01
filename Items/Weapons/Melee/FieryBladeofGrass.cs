using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
    class FieryBladeofGrass : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fiery Blade of Grass");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.damage = 33;
            Item.useTurn = Item.autoReuse = true;
            Item.scale = 1f;
            Item.rare = ItemRarityID.LightRed;
            Item.width = dims.Width;
            Item.useTime = 23;
            Item.knockBack = 3.5f;
            Item.DamageType = DamageClass.Melee;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.value = Item.sellPrice(0, 0, 54, 0);
            Item.useAnimation = 23;
            Item.height = dims.Height;
            Item.UseSound = SoundID.Item1;
        }
    }
}
