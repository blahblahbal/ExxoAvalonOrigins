using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
    public class AccelerationDrill : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Acceleration Drill");
            Tooltip.SetDefault("'Vroom vroom'");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.damage = 25;
            item.noUseGraphic = true;
            item.autoReuse = true;
            item.channel = true;
            item.scale = 1f;
            item.shootSpeed = 32f;
            item.pick = 400;
            item.rare = ItemRarityID.Red;
            item.noMelee = true;
            item.width = dims.Width;
            item.useTime = 7;
            item.knockBack = 1f;
            item.shoot = ModContent.ProjectileType<Projectiles.AccelerationDrill>();
            item.UseSound = SoundID.Item23;
            item.melee = true;
            item.tileBoost += 6;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.value = 1016000;
            item.useAnimation = 9;
            item.height = dims.Height;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            List<string> assignedKeys = ExxoAvalonOrigins.Mod.ModeChangeHotkey.GetAssignedKeys();

            var assignedKeyInfo = new TooltipLine(mod, "Controls:PromptKey", "Press " + (assignedKeys.Count > 0 ? string.Join(", ", assignedKeys) : "[c/565656:<Unbound>]") + " to change mining modes");
            tooltips.Add(assignedKeyInfo);

            if (!(assignedKeys.Count > 0))
            {
                var unboundKeyInfo = new TooltipLine(mod, "Controls:PromptKeyInfo", "[c/900C3F:Please bind hotkey in the settings to change mining modes!]");
                tooltips.Add(unboundKeyInfo);
            }
        }

        public override void HoldItem(Player player)
        {
            if (player.Avalon().speed && player.controlUseItem)
            {
                if (player.position.X / 16f - Player.tileRangeX - player.inventory[player.selectedItem].tileBoost <= Player.tileTargetX && (player.position.X + player.width) / 16f + Player.tileRangeX + player.inventory[player.selectedItem].tileBoost - 1f >= Player.tileTargetX && player.position.Y / 16f - Player.tileRangeY - player.inventory[player.selectedItem].tileBoost <= Player.tileTargetY && (player.position.Y + player.height) / 16f + Player.tileRangeY + player.inventory[player.selectedItem].tileBoost - 2f >= Player.tileTargetY)
                {
                    for (int x = Player.tileTargetX - 1; x <= Player.tileTargetX + 1; x++)
                    {
                        for (int y = Player.tileTargetY - 1; y <= Player.tileTargetY + 1; y++)
                        {
                            if (Main.tile[x, y].active() && !Main.tileHammer[Main.tile[x, y].type] && !Main.tileAxe[Main.tile[x, y].type])
                            {
                                if (Main.tile[x, y].type != 21)
                                {
                                    WorldGen.KillTile(x, y);
                                    if (Main.netMode == NetmodeID.MultiplayerClient)
                                    {
                                        NetMessage.SendData(MessageID.TileChange, -1, -1, NetworkText.Empty, 0, x, y, 0f, 0);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
