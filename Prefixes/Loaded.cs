using Terraria;

namespace ExxoAvalonOrigins.Prefixes;

public class Loaded : ArmorPrefix
{
    public Loaded()
    {

    }

    public override bool CanRoll(Item item)
    {
        return IsArmor(item);
    }

    public override void ModifyValue(ref float valueMult)
    {
        valueMult *= 1.15f;
    }

    public override bool Autoload(ref string name)
    {
        if (base.Autoload(ref name))
        {
            Mod.AddPrefix("Loaded", new Loaded());
        }
        return false;
    }
    public override void UpdateEquip(Player player)
    {
        player.statDefense++;
    }
}