using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls;

public class ContagionGrassWall : ModWall
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(106, 116, 59));
        soundType = SoundID.Grass;
        soundStyle = 1;
        WallID.Sets.Conversion.Grass[Type] = true;
        dustType = ModContent.DustType<Dusts.ContagionDust>();
    }
}