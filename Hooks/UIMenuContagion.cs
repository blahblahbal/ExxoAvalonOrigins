using Microsoft.Xna.Framework.Graphics;
using MonoMod.RuntimeDetour.HookGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

namespace ExxoAvalonOrigins.Hooks
{
	public class UIMenuContagion {
		public static void ILDrawSelf(ILContext il)
        {
			var c = new ILCursor(il);

			// Move il cursor into positon
			if (!c.TryGotoNext(i => i.MatchLdsfld<WorldGen>(nameof(WorldGen.crimson))))
				return;
			if (!c.TryGotoNext(i => i.MatchCall(out _)))
				return;
			if (!c.TryGotoNext(i => i.MatchLdarg(0)))
				return;
			c.Emit(OpCodes.Ldloc, 4);
			c.EmitDelegate<Func<Color, Color>>((color) =>
			{
				if (ExxoAvalonOriginsWorld.contaigon)
				{
					Color contagionBarColor = new Color(188, 158, 113);
					return contagionBarColor;
				}
				else
				{
					return color;
				}
			});
			c.Emit(OpCodes.Stloc, 4);
			if (!c.TryGotoNext(i => i.MatchLdloc(5)))
				return;
			if (!c.TryGotoPrev(i => i.MatchLdarg(1)))
				return;
			if (!c.TryGotoNext(i => i.MatchLdfld(out _)))
				return;
			c.Index++;
			c.Index += 0;
			c.EmitDelegate<Func<Texture2D, Texture2D>>((corruptTexture) =>
			{
				if (ExxoAvalonOriginsWorld.contaigon)
                {
					return ExxoAvalonOrigins.mod.GetTexture("Sprites/Outer_Contagion");
				}
				else
                {
					return corruptTexture;
                }
			});
		}

		public static Texture2D OnGetIcon(On.Terraria.GameContent.UI.Elements.UIWorldListItem.orig_GetIcon orig, UIWorldListItem self)
		{
			WorldFileData data = self.GetFieldValue<WorldFileData>("_data");
			var path = Path.ChangeExtension(data.Path, ".twld");

			ExxoAvalonOriginsConfig config = ModContent.GetInstance<ExxoAvalonOriginsConfig>();
			Dictionary<string, bool> newDict = config.GetWorldContagionStatus();

			if (!config.GetWorldContagionStatus().ContainsKey(path))
			{
				if (!FileUtilities.Exists(path, data.IsCloudSave))
				{
					return orig(self);
				}

				//Stream stream = (data.IsCloudSave ? ((Stream)new MemoryStream(Terraria.Social.SocialAPI.Cloud.Read(path))) : ((Stream)new FileStream(path, FileMode.Open)));
				byte[] buf = FileUtilities.ReadAllBytes(path, data.IsCloudSave);
				if (buf[0] != 31 || buf[1] != 139)
				{
					return orig(self);
				}

				var stream = new MemoryStream(buf);
				var tag = TagIO.FromStream(stream);

				if (tag.ContainsKey("modData"))
				{
					foreach (TagCompound modDataTag in tag.GetList<TagCompound>("modData").Skip(2))
					{
						if (modDataTag.Get<string>("mod") == ExxoAvalonOrigins.mod.Name)
						{
							TagCompound dataTag = modDataTag.Get<TagCompound>("data");
							newDict[path] = dataTag.Get<bool>("ExxoAvalonOrigins:Contagion");
							break;
						}
					}
					if (!config.GetWorldContagionStatus().ContainsKey(path))
					{
						newDict[path] = false;
					}
					config.SetWorldContagionStatus(newDict);
					ExxoAvalonOriginsConfig.Save(config);
				}
			}

			if (config.GetWorldContagionStatus().ContainsKey(path) && config.GetWorldContagionStatus()[path])
			{
				if (data.IsHardMode)
				{
					return ExxoAvalonOrigins.mod.GetTexture("Sprites/IconHallowContagion");
				}
				else
				{
					return ExxoAvalonOrigins.mod.GetTexture("Sprites/IconContagion");
				}
			}
			else
			{
				return orig(self);
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

