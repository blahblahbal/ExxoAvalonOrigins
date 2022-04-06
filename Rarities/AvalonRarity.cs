using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Rarities;

public class AvalonRarity : ModRarity
{
    public override Color RarityColor
    {
        get
        {
            List<Color> colors = new List<Color>
            {
                new Color(71, 142, 147),
                new Color(255, 242, 0)
            };
            int num = (int)(Main.GlobalTimeWrappedHourly / 2f % colors.Count);
            Color teal = colors[num];
            Color yellow = colors[(num + 1) % colors.Count];
            return Color.Lerp(teal, yellow, (Main.GlobalTimeWrappedHourly % 2f > 1f) ? 1f : (Main.GlobalTimeWrappedHourly % 1f));
        }
    }

    public override int GetPrefixedRarity(int offset, float valueMult)
    {
        return Type; // no 'lower' tier to go to, so return the type of this rarity.
    }
}
