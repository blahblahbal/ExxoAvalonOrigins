namespace ExxoAvalonOrigins.Buffs;

public class BismuthDagger : BaseDagger<Projectiles.Summon.BismuthDagger>
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Bismuth Dagger");
        Description.SetDefault("The dagger will fight for you");
        base.SetStaticDefaults();
    }
}
