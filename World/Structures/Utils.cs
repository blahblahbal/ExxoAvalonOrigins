using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ExxoAvalonOrigins.World.Structures
{
    public class Utils
    {
        /// <summary>
        /// Loads structure as 2D int array from a given manifest path to an embedded resource
        /// </summary>
        /// <param name="path">The local embedded file manifest path.
        /// <example>
        /// For example:
        /// <code>"HellCastle.txt"
        /// </code>
        /// where the internal path of the file is .\HellCastle.txt
        /// </example>
        /// </param>
        public static int[,] GetStructure(string path)
        {
            var assembly = Assembly.GetExecutingAssembly();

            // Loading file into list
            List<int[]> structureList = new List<int[]>();
            using (Stream stream = assembly.GetManifestResourceStream("ExxoAvalonOrigins.World.Structures." + path))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    while (reader.Peek() >= 0)
                    {
                        structureList.Add(reader.ReadLine().TrimEnd(',').Trim(new Char[] { '{', '}' }).Split(',').Select(int.Parse).ToArray());
                    }
                }
            }
            
            // Converting list to 2d array
            int[,] structureArray = new int[structureList.Count, structureList[0].Length];
            for (int i = 0; i < structureList.Count; i++)
            {
                for (int j = 0; j < structureList[0].Length; j++)
                {
                    structureArray[i, j] = structureList[i][j];
                }
            }

            return structureArray;
        }
    }
}
