using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
    class MinersSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Miner's Sword");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.damage = 20;
            Item.autoReuse = true;
            Item.scale = 1.2f;
            Item.rare = ItemRarityID.LightRed;
            Item.width = dims.Width;
            Item.useTime = 23;
            Item.knockBack = 5.5f;
            Item.DamageType = DamageClass.Melee;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.useAnimation = 23;
            Item.height = dims.Height;
            Item.UseSound = SoundID.Item1;
        }
    }
}
