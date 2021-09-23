namespace ExxoAvalonOrigins.NPCs.Utils
{
    public static class CubicEase
    {
        // f(x) = x^{3}
        public static float In(float x)
        {
            return x * x * x;
        }

        // f(x) = \left(-x\right)^{3}+1
        public static float Out(float x)
        {
            return 1 + In(-x);
        }

        // f(x) = (4x^{3} x < 0.5) | (4\left(\left(x-1\right)^{3}\right)+1 x >= 0.5)
        public static float InOut(float x)
        {
            if (x < 0.5f)
            {
                return 4 * In(x);
            }
            else
            {
                return (4 * In(x - 1)) + 1;
            }
        }
    }
}
