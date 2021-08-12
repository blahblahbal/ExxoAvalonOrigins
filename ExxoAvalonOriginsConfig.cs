using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using Terraria.ModLoader;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader.IO;
using System.IO;
using Terraria.Utilities;
using System.Reflection;
using Terraria.IO;
using MonoMod.Cil;
using Mono.Cecil.Cil;
using Terraria;
using Mono.Cecil;
using Microsoft.Xna.Framework;
using System.Collections;
using System.ComponentModel;
using System.Runtime.Serialization;
using Terraria.ID;
using Terraria.ModLoader.Config;
using Terraria.ModLoader.Config.UI;
using Terraria.UI;
using Newtonsoft.Json;

namespace ExxoAvalonOrigins
{
	public class ExxoAvalonOriginsConfig : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ClientSide;

		// Key value for each twld path and if contagion or not
		[DefaultListValue(false)]
		[JsonProperty]
		private Dictionary<string, bool> worldContagionStatus = new Dictionary<string, bool>();

		// Methods to avoid public variable getting picked up by serialiser
		public Dictionary<string, bool> GetWorldContagionStatus() { return worldContagionStatus; }
		public void SetWorldContagionStatus(Dictionary<string, bool> newDict) { worldContagionStatus = newDict; }

		public static void Save(ModConfig config)
		{
			Directory.CreateDirectory(ConfigManager.ModConfigPath);
			string filename = config.mod.Name + "_" + config.Name + ".json";
			string path = Path.Combine(ConfigManager.ModConfigPath, filename);
			string json = JsonConvert.SerializeObject((object)config, ConfigManager.serializerSettings);
			File.WriteAllText(path, json);
		}
	}
}
