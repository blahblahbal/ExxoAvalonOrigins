namespace ExxoAvalonOrigins.Buffs;

public class PlatinumDagger : BaseDagger<Projectiles.Summon.PlatinumDagger>
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Platinum Dagger");
        Description.SetDefault("The dagger will fight for you");
        base.SetStaticDefaults();
    }
}
