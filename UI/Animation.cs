using System;

namespace ExxoAvalonOrigins.UI
{
    internal static class Animation
    {
        public static float SinTime(double seconds)
        {
            return (1 + (float)Math.Sin(seconds)) * 0.5f;
        }
    }
}
