using Terraria;

namespace ExxoAvalonOrigins.Prefixes;

public class Busted : ArmorPrefix
{
    public Busted()
    {

    }

    public override bool CanRoll(Item item)
    {
        return IsArmor(item);
    }

    public override void ModifyValue(ref float valueMult)
    {
        valueMult *= 0.9f;
    }

    public override bool Autoload(ref string name)
    {
        if (base.Autoload(ref name))
        {
            Mod.AddPrefix("Busted", new Busted());
        }
        return false;
    }
    public override void UpdateEquip(Player player)
    {
        player.statDefense--;
    }
}