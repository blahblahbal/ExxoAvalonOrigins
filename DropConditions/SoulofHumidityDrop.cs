using ExxoAvalonOrigins.Systems;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.DropConditions;
public class SoulofHumidityDrop : IItemDropRuleCondition, IProvideItemConditionDescription
{
    public bool CanDrop(DropAttemptInfo info)
    {
        return (info.player.ZoneJungle || info.player.Avalon().ZoneTropics) && ModContent.GetInstance<ExxoAvalonOriginsWorld>().SuperHardmode && DownedBossSystem.stoppedArmageddon;
    }
    public bool CanShowItemDropInUI()
    {
        return true;
    }
    public string GetConditionDescription()
    {
        return "Drops in the Jungle or Tropics in Superhardmode after the Armageddon Slime is defeated";
    }
}

