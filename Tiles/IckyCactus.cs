using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles;

public class IckyCactus : ModCactus
{
    public override Texture2D GetTexture() => ModContent.Request<Texture2D>("ExxoAvalonOrigins/Tiles/IckyCactus");
}