using System.Collections.Generic;
using ExxoAvalonOrigins.Items.Accessories;
using ExxoAvalonOrigins.Items.Material;
using ExxoAvalonOrigins.Items.Weapons.Magic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Hooks
{
    class BossBagDrops
    {
        public static void OnOpenBossBag(On.Terraria.Player.orig_OpenBossBag orig, Player self, int type)
        {
            if (type == ItemID.GolemBossBag)
            {
                var list = new List<int>
                {
                    ItemID.Stynger,
                    ItemID.StaffofEarth,
                    ItemID.EyeoftheGolem,
                    ItemID.Picksaw,
                    ItemID.PossessedHatchet,
                    ItemID.GolemFist,
                    ItemID.SunStone,
                    ItemID.HeatRay,
                    ModContent.ItemType<Sunstorm>(),
                    ModContent.ItemType<EarthenInsignia>(),
                    ModContent.ItemType<HeartoftheGolem>()
                };
                int item1 = list.RemoveAtIndex(Main.rand.Next(list.Count));
                int item2 = list.RemoveAtIndex(Main.rand.Next(list.Count));
                self.QuickSpawnItem(item1);
                self.QuickSpawnItem(item2);
                if (item1 == ItemID.Stynger || item2 == ItemID.Stynger)
                {
                    self.QuickSpawnItem(ItemID.StyngerBolt, Main.rand.Next(60, 101));
                }
                self.QuickSpawnItem(ModContent.ItemType<EarthStone>(), Main.rand.Next(1, 4));
                self.QuickSpawnItem(ItemID.BeetleHusk, Main.rand.Next(18, 24));
                self.QuickSpawnItem(ItemID.ShinyStone);
                self.QuickSpawnItem(ItemID.GoldCoin, 12);
                if (Main.rand.Next(7) == 0)
                {
                    self.QuickSpawnItem(ItemID.GolemMask);
                }
            }
            else orig(self, type);
        }
    }
}
