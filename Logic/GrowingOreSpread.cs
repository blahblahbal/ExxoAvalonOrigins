using Terraria;

namespace ExxoAvalonOrigins.Logic
{
    public class GrowingOreSpread
    {
        public static bool GrowingOre(int i, int j, int growingType)
        {
            int num = 40;
            int num2 = 130;
            int num3 = 35;
            int num4 = 85;
            if ((double)j < Main.rockLayer)
            {
                num /= 2;
                num2 /= 2;
                num3 = (int)((double)num3 * 1.5);
                num4 = (int)((double)num4 * 1.5);
            }
            int num5 = 0;
            for (int k = i - num3; k < i + num3; k++)
            {
                for (int l = j - num3; l < j + num3; l++)
                {
                    if (WorldGen.InWorld(k, l) && Main.tile[k, l].active() && Main.tile[k, l].type == growingType)
                    {
                        num5++;
                    }
                }
            }
            if (num5 > num)
            {
                return false;
            }
            num5 = 0;
            for (int m = i - num4; m < i + num4; m++)
            {
                for (int n = j - num4; n < j + num4; n++)
                {
                    if (WorldGen.InWorld(m, n) && Main.tile[m, n].active() && Main.tile[m, n].type == growingType)
                    {
                        num5++;
                    }
                }
            }
            if (num5 > num2)
            {
                return false;
            }
            return true;
        }

        /*private static bool nearbyGrowingOre(int i, int j, int growingType)
        {
			float num = 0f;
			int num2 = 5;
			if (i <= num2 + 5 || i >= Main.maxTilesX - num2 - 5)
			{
				return false;
			}
			if (j <= num2 + 5 || j >= Main.maxTilesY - num2 - 5)
			{
				return false;
			}
			for (int k = i - num2; k <= i + num2; k++)
			{
				for (int l = j - num2; l <= j + num2; l++)
				{
					if (Main.tile[k, l].active() && (Main.tile[k, l].type == growingType/* || Main.tile[k, l].type == 346*//*))
					{
						num += 1f;
						if (num >= 4f)
						{
							return true;
						}
					}
				}
			}
			if (num > 0f && (float)WorldGen.genRand.Next(5) < num)
			{
				return true;
			}
			return false;
		}*/
    }
}
