using System.Collections.Generic;
using System.IO;
using Terraria.ModLoader.Config;
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
