namespace ExxoAvalonOrigins.Buffs;

public class AdamantiteDagger : BaseDagger<Projectiles.Summon.AdamantiteDagger>
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Adamantite Dagger");
        Description.SetDefault("The dagger will fight for you");
        base.SetStaticDefaults();
    }
}
