using Terraria;

namespace ExxoAvalonOrigins.Prefixes;

public class Silly : ArmorPrefix
{
    public Silly()
    {

    }

    public override bool CanRoll(Item item)
    {
        return IsArmor(item);
    }

    public override void ModifyValue(ref float valueMult)
    {
        valueMult *= 1.2f;
    }

    public override bool Autoload(ref string name)
    {
        if (base.Autoload(ref name))
        {
            Mod.AddPrefix("Silly", new Silly());
        }
        return false;
    }
    public override void UpdateEquip(Player player)
    {
        player.GetCritChance(DamageClass.Magic) += 2;
        player.GetCritChance(DamageClass.Melee) += 2;
        player.GetCritChance(DamageClass.Ranged) += 2;
        player.GetCritChance(DamageClass.Throwing) += 2;
    }
}