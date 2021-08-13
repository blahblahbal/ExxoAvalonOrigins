using Microsoft.Xna.Framework;
using System;using System.Collections.Generic;using System.IO;
using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ID;using Terraria.ModLoader;using Terraria.ModLoader.IO;

namespace ExxoAvalonOrigins{    class ExxoAvalonOriginsGlobalItemInstance : GlobalItem    {        public override bool InstancePerEntity        {            get { return true; }        }        public bool invince;        public int torch = 0;        public int wallWand = -1;        public int healStamina;        public bool tome = false;        public bool updateInvisibleVanity = false;        public AvalonRarity avalonRarity;        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine tooltipLine = tooltips.FirstOrDefault((TooltipLine x) => x.Name == "ItemName" && x.mod == "ExxoAvalonOrigins");            if (tooltipLine != null)
            {
                switch (avalonRarity)
                {
                    case AvalonRarity.Rainbow:
                        tooltipLine.overrideColor = new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB);
                        break;
                }
            }
        }        public override GlobalItem NewInstance(Item item)        {            return base.NewInstance(item);        }        public override bool NeedsSaving(Item item)
        {
            return true;
        }        public override TagCompound Save(Item item)
        {
            return new TagCompound
            {
                ["ExxoAvalonOrigins:Rarity"] = (int)avalonRarity
            };
        }

        public override void Load(Item item, TagCompound tag)
        {
            avalonRarity = (AvalonRarity)tag.GetInt("ExxoAvalonOrigins:Rarity");
        }        public override void NetSend(Item item, BinaryWriter writer)
        {
            writer.Write((int)avalonRarity);
        }

        public override void NetReceive(Item item, BinaryReader reader)
        {
            avalonRarity = (AvalonRarity)reader.ReadInt32();
        }    }}