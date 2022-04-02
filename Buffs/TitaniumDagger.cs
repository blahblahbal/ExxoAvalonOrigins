namespace ExxoAvalonOrigins.Buffs;

public class TitaniumDagger : BaseDagger<Projectiles.Summon.TitaniumDagger>
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Titanium Dagger");
        Description.SetDefault("The dagger will fight for you");
        base.SetStaticDefaults();
    }
}
