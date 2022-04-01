using ExxoAvalonOrigins.Items.Placeable.Bar;
using ExxoAvalonOrigins.Items.Weapons.Magic;
using ExxoAvalonOrigins.Items.Weapons.Ranged;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace ExxoAvalonOrigins.World.Passes
{
    public class ReplaceChestItems
    {
        public static void Method(GenerationProgress progress)
        {
            foreach (Chest c in Main.chest)
            {
                if (c != null)
                {
                    foreach (Item i in c.item)
                    {
                        if (i != null && i.type == ItemID.EnchantedBoomerang)
                        {
                            i.SetDefaults(ModContent.ItemType<EnchantedBar>());
                            i.stack = WorldGen.genRand.Next(35, 49);
                        }
                        if (ExxoAvalonOriginsWorld.jungleMenuSelection == ExxoAvalonOriginsWorld.JungleVariant.tropics)
                        {
                            if (i != null && i.type == ItemID.Boomstick) i.SetDefaults(ModContent.ItemType<Thompson>());
                        }
                        if (i != null && i.type == ItemID.StaffofRegrowth && WorldGen.genRand.Next(2) == 0) i.SetDefaults(ModContent.ItemType<FlowerofTheJungle>());
                        if (i != null)
                        {
                            if (i.type == ItemID.BreathingReed && WorldGen.genRand.Next(3) == 0) i.SetDefaults(ModContent.ItemType<Items.Tools.MagicConch>());
                            if (i.type == ItemID.Flipper && WorldGen.genRand.Next(4) == 0) i.SetDefaults(ModContent.ItemType<Items.Tools.MagicConch>());
                        }
                    }
                }
            }
        }
    }
}
