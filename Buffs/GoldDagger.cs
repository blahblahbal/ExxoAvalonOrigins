namespace ExxoAvalonOrigins.Buffs;

public class GoldDagger : BaseDagger<Projectiles.Summon.GoldDagger>
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Gold Dagger");
        Description.SetDefault("The dagger will fight for you");
        base.SetStaticDefaults();
    }
}
