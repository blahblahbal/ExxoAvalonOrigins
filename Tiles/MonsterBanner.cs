using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ExxoAvalonOrigins.Tiles;

public class MonsterBanner : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        Main.tileNoAttach[Type] = true;
        Main.tileLavaDeath[Type] = true;
        TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
        TileObjectData.newTile.Height = 3;
        TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16 };
        TileObjectData.newTile.StyleHorizontal = true;
        TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom, TileObjectData.newTile.Width, 0);
        TileObjectData.newTile.StyleWrapLimit = 111;
        TileObjectData.addTile(Type);
        DustType = -1;
        TileID.Sets.DisableSmartCursor[Type] = true;
        ModTranslation name = CreateMapEntryName();
        name.SetDefault("Banner");
        AddMapEntry(new Color(13, 88, 130), name);
    }

    public override void KillMultiTile(int i, int j, int frameX, int frameY)
    {
        int style = frameX / 18;
        int item;
        switch (style)
        {
            case 0:
                item = ModContent.ItemType<Items.Banners.MimeBanner>();
                break;
            case 1:
                item = ModContent.ItemType<Items.Banners.DarkMatterSlimeBanner>();
                break;
            case 2:
                item = ModContent.ItemType<Items.Banners.CursedMagmaSkeletonBanner>();
                break;
            case 4:
                item = ModContent.ItemType<Items.Banners.VampireHarpyBanner>();
                break;
            case 5:
                item = ModContent.ItemType<Items.Banners.ArmoredWraithBanner>();
                break;
            case 6:
                item = ModContent.ItemType<Items.Banners.RedAegisBonesBanner>();
                break;
            case 7:
                item = ModContent.ItemType<Items.Banners.BloodshotEyeBanner>();
                break;
            case 8:
                item = ModContent.ItemType<Items.Banners.DragonflyBanner>();
                break;
            case 9:
                item = ModContent.ItemType<Items.Banners.BlazeBanner>();
                break;
            case 10:
                item = ModContent.ItemType<Items.Banners.ArmoredHellTortoiseBanner>();
                break;
            case 13:
                item = ModContent.ItemType<Items.Banners.ImpactWizardBanner>();
                break;
            case 14:
                item = ModContent.ItemType<Items.Banners.MechanicalDiggerBanner>();
                break;
            case 15:
                item = ModContent.ItemType<Items.Banners.CougherBanner>();
                break;
            case 16:
                item = ModContent.ItemType<Items.Banners.BactusBanner>();
                break;
            case 17:
                item = ModContent.ItemType<Items.Banners.IckslimeBanner>();
                break;
            case 18:
                item = ModContent.ItemType<Items.Banners.GrossyFloatBanner>();
                break;
            case 19:
                item = ModContent.ItemType<Items.Banners.PyrasiteBanner>();
                break;
            case 20:
                item = ModContent.ItemType<Items.Banners.EyeBonesBanner>();
                break;
            case 21:
                item = ModContent.ItemType<Items.Banners.EctosphereBanner>();
                break;
            case 22:
                item = ModContent.ItemType<Items.Banners.BombSkeletonBanner>();
                break;
            case 23:
                item = ModContent.ItemType<Items.Banners.CopperSlimeBanner>();
                break;
            case 24:
                item = ModContent.ItemType<Items.Banners.TinSlimeBanner>();
                break;
            case 25:
                item = ModContent.ItemType<Items.Banners.IronSlimeBanner>();
                break;
            case 26:
                item = ModContent.ItemType<Items.Banners.LeadSlimeBanner>();
                break;
            case 27:
                item = ModContent.ItemType<Items.Banners.SilverSlimeBanner>();
                break;
            case 28:
                item = ModContent.ItemType<Items.Banners.TungstenSlimeBanner>();
                break;
            case 29:
                item = ModContent.ItemType<Items.Banners.GoldSlimeBanner>();
                break;
            case 30:
                item = ModContent.ItemType<Items.Banners.PlatinumSlimeBanner>();
                break;
            case 31:
                item = ModContent.ItemType<Items.Banners.CobaltSlimeBanner>();
                break;
            case 32:
                item = ModContent.ItemType<Items.Banners.PalladiumSlimeBanner>();
                break;
            case 33:
                item = ModContent.ItemType<Items.Banners.MythrilSlimeBanner>();
                break;
            case 34:
                item = ModContent.ItemType<Items.Banners.OrichalcumSlimeBanner>();
                break;
            case 35:
                item = ModContent.ItemType<Items.Banners.AdamantiteSlimeBanner>();
                break;
            case 36:
                item = ModContent.ItemType<Items.Banners.TitaniumSlimeBanner>();
                break;
            case 37:
                item = ModContent.ItemType<Items.Banners.RhodiumSlimeBanner>();
                break;
            case 38:
                item = ModContent.ItemType<Items.Banners.OsmiumSlimeBanner>();
                break;
            case 39:
                item = ModContent.ItemType<Items.Banners.DurataniumSlimeBanner>();
                break;
            case 40:
                item = ModContent.ItemType<Items.Banners.NaquadahSlimeBanner>();
                break;
            case 41:
                item = ModContent.ItemType<Items.Banners.TroxiniumSlimeBanner>();
                break;
            case 42:
                item = ModContent.ItemType<Items.Banners.UnstableAnomalyBanner>();
                break;
            case 43:
                item = ModContent.ItemType<Items.Banners.MatterManBanner>();
                break;
            case 44:
                item = ModContent.ItemType<Items.Banners.BronzeSlimeBanner>();
                break;
            case 45:
                item = ModContent.ItemType<Items.Banners.NickelSlimeBanner>();
                break;
            case 46:
                item = ModContent.ItemType<Items.Banners.ZincSlimeBanner>();
                break;
            case 47:
                item = ModContent.ItemType<Items.Banners.BismuthSlimeBanner>();
                break;
            case 48:
                item = ModContent.ItemType<Items.Banners.IridiumSlimeBanner>();
                break;
            case 49:
                item = ModContent.ItemType<Items.Banners.HalloworBanner>();
                break;
            case 51:
                item = ModContent.ItemType<Items.Banners.IrateBonesBanner>();
                break;
            case 52:
                item = ModContent.ItemType<Items.Banners.AegisHalloworBanner>();
                break;
            case 55:
                item = ModContent.ItemType<Items.Banners.CursedScepterBanner>();
                break;
            case 56:
                item = ModContent.ItemType<Items.Banners.EctoHandBanner>();
                break;
            case 57:
                item = ModContent.ItemType<Items.Banners.CloudBatBanner>();
                break;
            case 58:
                item = ModContent.ItemType<Items.Banners.ValkyrieBanner>();
                break;
            case 59:
                item = ModContent.ItemType<Items.Banners.CaesiumSeekerBanner>();
                break;
            case 60:
                item = ModContent.ItemType<Items.Banners.CaesiumBruteBanner>();
                break;
            case 61:
                item = ModContent.ItemType<Items.Banners.CaesiumStalkerBanner>();
                break;
            case 62:
                item = ModContent.ItemType<Items.Banners.RafflesiaBanner>();
                break;
            default:
                return;
        }
        Item.NewItem(WorldGen.GetItemSource_FromTileBreak(i, j), i * 16, j * 16, 16, 48, item);
    }

    public override void NearbyEffects(int i, int j, bool closer)
    {
        if (closer)
        {
            Player player = Main.LocalPlayer;
            int style = Main.tile[i, j].TileFrameX / 18;
            string type;
            switch (style)
            {
                case 0:
                    type = "Mime";
                    break;
                case 1:
                    type = "DarkMatterSlime";
                    break;
                case 2:
                    type = "CursedMagmaSkeleton";
                    break;
                case 4:
                    type = "VampireHarpy";
                    break;
                case 5:
                    type = "ArmoredWraith";
                    break;
                case 6:
                    type = "RedAegisBones";
                    break;
                case 7:
                    type = "BloodshotEye";
                    break;
                case 8:
                    type = "Dragonfly";
                    break;
                case 9:
                    type = "Blaze";
                    break;
                case 10:
                    type = "ArmoredHellTortoise";
                    break;
                case 13:
                    type = "ImpactWizard";
                    break;
                case 14:
                    type = "MechanicalDigger";
                    break;
                case 15:
                    type = "Cougher";
                    break;
                case 16:
                    type = "Bactus";
                    break;
                case 17:
                    type = "Ickslime";
                    break;
                case 18:
                    type = "GrossyFloat";
                    break;
                case 19:
                    type = "Pyrasite";
                    break;
                case 20:
                    type = "EyeBones";
                    break;
                case 21:
                    type = "Ectosphere";
                    break;
                case 22:
                    type = "BombSkeleton";
                    break;
                case 23:
                    type = "CopperSlime";
                    break;
                case 24:
                    type = "TinSlime";
                    break;
                case 25:
                    type = "IronSlime";
                    break;
                case 26:
                    type = "LeadSlime";
                    break;
                case 27:
                    type = "SilverSlime";
                    break;
                case 28:
                    type = "TungstenSlime";
                    break;
                case 29:
                    type = "GoldSlime";
                    break;
                case 30:
                    type = "PlatinumSlime";
                    break;
                case 31:
                    type = "CobaltSlime";
                    break;
                case 32:
                    type = "PalladiumSlime";
                    break;
                case 33:
                    type = "MythrilSlime";
                    break;
                case 34:
                    type = "OrichalcumSlime";
                    break;
                case 35:
                    type = "AdamantiteSlime";
                    break;
                case 36:
                    type = "TitaniumSlime";
                    break;
                case 37:
                    type = "RhodiumSlime";
                    break;
                case 38:
                    type = "OsmiumSlime";
                    break;
                case 39:
                    type = "DurataniumSlime";
                    break;
                case 40:
                    type = "NaquadahSlime";
                    break;
                case 41:
                    type = "TroxiniumSlime";
                    break;
                case 42:
                    type = "UnstableAnomaly";
                    break;
                case 43:
                    type = "MatterMan";
                    break;
                case 44:
                    type = "BronzeSlime";
                    break;
                case 45:
                    type = "NickelSlime";
                    break;
                case 46:
                    type = "ZincSlime";
                    break;
                case 47:
                    type = "BismuthSlime";
                    break;
                case 48:
                    type = "IridiumSlime";
                    break;
                case 49:
                    type = "Hallowor";
                    break;
                case 51:
                    type = "IrateBones";
                    break;
                case 55:
                    type = "CursedScepter";
                    break;
                case 56:
                    type = "EctoHand";
                    break;
                case 57:
                    type = "CloudBat";
                    break;
                case 58:
                    type = "Valkyrie";
                    break;
                case 59:
                    type = "CaesiumSeeker";
                    break;
                case 60:
                    type = "CaesiumBrute";
                    break;
                case 61:
                    type = "CaesiumStalker";
                    break;
                case 62:
                    type = "Rafflesia";
                    break;
                default:
                    return;
            }
            Main.SceneMetrics.NPCBannerBuff[Mod.Find<ModNPC>(type).Type] = true;
            //player.hasBannerBuff = true;
        }
    }

    public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
    {
        if (i % 2 == 1)
        {
            spriteEffects = SpriteEffects.FlipHorizontally;
        }
    }
}
