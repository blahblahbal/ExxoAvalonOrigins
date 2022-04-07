using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.Items.Consumables;

class EyeofOblivionAncient : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Eye of Oblivion");
        Tooltip.SetDefault("Summons Ancient Oblivion\nUse with care");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.consumable = true;
        Item.rare = ItemRarityID.Yellow;
        Item.width = dims.Width;
        Item.useTime = 45;
        Item.useStyle = ItemUseStyleID.HoldUp;
        Item.value = 0;
        Item.maxStack = 20;
        Item.useAnimation = 45;
        Item.height = dims.Height;
    }

    public override void AddRecipes()
    {
        CreateRecipe(3).AddIngredient(ModContent.ItemType<Material.Rock>()).AddIngredient(ModContent.ItemType<Material.PointingLaser>()).AddIngredient(ModContent.ItemType<Material.AlienApparatus>()).AddIngredient(ModContent.ItemType<Material.IllegalWeaponInstructions>()).AddTile(TileID.DemonAltar).ReplaceResult(ModContent.ItemType<EyeofOblivionAncient>());
    }

    public override bool CanUseItem(Player player)
    {
        return !NPC.AnyNPCs(ModContent.NPCType<NPCs.AncientOblivionPhase1Dead>()) && !NPC.AnyNPCs(ModContent.NPCType<NPCs.AncientOblivionPhase1>()) && !NPC.AnyNPCs(ModContent.NPCType<NPCs.AncientOblivionHead1>()) && !NPC.AnyNPCs(ModContent.NPCType<NPCs.AncientOblivionHead2>()) && !Main.dayTime;
    }

    public override bool? UseItem(Player player)
    {
        NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.AncientOblivionPhase1>());
        SoundEngine.PlaySound(SoundLoader.GetLegacySoundSlot(Mod, "Sounds/Item/WoS"), player.position);
        return true;
    }
}
