using Terraria;

namespace ExxoAvalonOrigins.Prefixes;

public class Mythic : ArmorPrefix
{
    public Mythic()
    {

    }

    public override bool CanRoll(Item item)
    {
        return IsArmor(item);
    }

    public override void ModifyValue(ref float valueMult)
    {
        valueMult *= 1.1f;
    }

    public override bool Autoload(ref string name)
    {
        if (base.Autoload(ref name))
        {
            Mod.AddPrefix("Mythic", new Mythic());
        }
        return false;
    }
    public override void UpdateEquip(Player player)
    {
        player.statManaMax2 += 20;
    }
}