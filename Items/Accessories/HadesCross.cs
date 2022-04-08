using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories;

public class HadesCross : ModItem
{
    public override void Load()
    {
        if (Main.netMode != NetmodeID.Server)
        {
            // Add equip textures
            Mod.AddEquipTexture(new EquipTexture(), this, EquipType.Head, $"{Texture}_{EquipType.Head}");
            Mod.AddEquipTexture(new EquipTexture(), this, EquipType.Body, $"{Texture}_{EquipType.Body}");
            Mod.AddEquipTexture(this, EquipType.Legs, $"{Texture}_{EquipType.Legs}");
        }
    }

    private void SetupDrawing()
    {
        int equipSlotHead = Mod.GetEquipSlot(Name, EquipType.Head);
        int equipSlotBody = Mod.GetEquipSlot(Name, EquipType.Body);
        int equipSlotLegs = Mod.GetEquipSlot(Name, EquipType.Legs);

        ArmorIDs.Head.Sets.DrawHead[equipSlotHead] = false;
        ArmorIDs.Body.Sets.HidesTopSkin[equipSlotBody] = true;
        ArmorIDs.Body.Sets.HidesArms[equipSlotBody] = true;
        ArmorIDs.Legs.Sets.HidesBottomSkin[equipSlotLegs] = true;
    }

    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Hades' Cross");
        Tooltip.SetDefault("Turns the holder into varefolk upon entering lava");

        SetupDrawing();
    }

    public override void SetDefaults()
    {
        Item.width = 24;
        Item.height = 28;
        Item.accessory = true;
        Item.defense = 3;
        Item.value = Item.buyPrice(0, 9, 72);
        Item.rare = ItemRarityID.LightPurple;
        Item.canBePlacedInVanityRegardlessOfConditions = true;
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {

        if (Collision.LavaCollision(player.position, player.width, player.height))
        {
            player.Avalon().hadesCross = true;
        }
        player.lavaImmune = true;
        player.fireWalk = true;
        player.ignoreWater = true;
    }

    public override bool IsVanitySet(int head, int body, int legs) => true;
}
