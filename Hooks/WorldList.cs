using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader.IO;
using System.IO;
using Terraria.Utilities;
using Terraria.ModLoader.Exceptions;
using Terraria.ModLoader.Default;
using System.Reflection;
using Terraria.IO;

namespace ExxoAvalonOrigins.Hooks
{
	public class WorldList
	{
		public static Texture2D OnGetIcon(On.Terraria.GameContent.UI.Elements.UIWorldListItem.orig_GetIcon orig, UIWorldListItem self)
		{
			WorldFileData data = self.GetFieldValue<WorldFileData>("_data");
			var path = Path.ChangeExtension(data.Path, ".twld");
			//WorldIO.customDataFail = null;
			if (!FileUtilities.Exists(path, data.IsCloudSave))
			{
				return orig(self);
			}

			byte[] buf = FileUtilities.ReadAllBytes(path, data.IsCloudSave);
			if (buf[0] != 31 || buf[1] != 139)
			{
				return orig(self);
			}

			TagCompound tag = TagIO.FromStream(new MemoryStream(buf));
			try
			{
				LoadModData(tag.GetList<TagCompound>("modData"));
			}
			catch (CustomModDataException ex2)
			{
				throw ex2;
			}

			bool contagion = false;
			if (tag.ContainsKey("modData"))
			{
				foreach(TagCompound modDataTag in tag.GetList<TagCompound>("modData"))
                {
					if (modDataTag.ContainsKey("data"))
                    {
						TagCompound dataTag = modDataTag.Get<TagCompound>("data");
						if (dataTag.ContainsKey("ExxoAvalonOrigins:Contagion"))
                        {
							contagion = dataTag.Get<bool>("ExxoAvalonOrigins:Contagion");
						}
					}
                }
			}

			if (contagion)
			{
				return ExxoAvalonOrigins.mod.GetTexture("Sprites/IconContagion");
			}
			else
			{
				return orig(self);
			}
		}

		private static void LoadModData(IList<TagCompound> list)
		{
			foreach (TagCompound tag in list)
			{
				Mod mod = ModLoader.GetMod(tag.GetString("mod"));
				ModWorld modWorld = mod?.GetModWorld(tag.GetString("name"));
				if (modWorld != null)
				{
					try
					{
						if (tag.ContainsKey("legacyData"))
						{
							modWorld.LoadLegacy(new BinaryReader(new MemoryStream(tag.GetByteArray("legacyData"))));
						}
						else
						{
							modWorld.Load(tag.GetCompound("data"));
						}
					}
					catch (Exception e)
					{
						throw new CustomModDataException(mod, "Error in reading custom world data for " + mod.Name, e);
					}
				}
			}
		}
	}
	public static class ReflectionExtensions
	{
		public static T GetFieldValue<T>(this object obj, string name)
		{
			// Set the flags so that private and public fields from instances will be found
			var bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
			var field = obj.GetType().GetField(name, bindingFlags);
			return (T)field?.GetValue(obj);
		}
	}
}

