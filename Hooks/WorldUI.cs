using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.Utilities;

namespace ExxoAvalonOrigins.Hooks
{
    public class WorldUI
    {
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
                if (ExxoAvalonOriginsWorld.contagion)
                {
                    Color contagionBarColor = new Color(175, 148, 199);
                    return contagionBarColor;
                }
                else
                {
                    return color;
                }
            });
            c.Emit(OpCodes.Stloc, 4);
            if (!c.TryGotoNext(i => i.MatchLdcI4(-4020137)))
                return;
            if (!c.TryGotoNext(i => i.MatchCall(out _)))
                return;
            if (!c.TryGotoNext(i => i.MatchLdarg(0)))
                return;
            c.Emit(OpCodes.Ldloc, 4);
            c.EmitDelegate<Func<Color, Color>>((color) =>
            {
                if (ExxoAvalonOriginsWorld.jungleMenuSelection == ExxoAvalonOriginsWorld.JungleVariant.tropics)
                {
                    Color contagionSecondBarColor = new Color(87, 87, 194);
                    return contagionSecondBarColor;
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
            c.EmitDelegate<Func<Texture2D, Texture2D>>((corruptTexture) =>
            {
                if (ExxoAvalonOriginsWorld.contagion)
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
            Dictionary<string, ExxoAvalonOriginsConfig.WorldDataValues> tempDict = config.GetWorldData();

            if (!tempDict.ContainsKey(path))
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
                bool containsMod = false;

                if (tag.ContainsKey("modData"))
                {
                    foreach (TagCompound modDataTag in tag.GetList<TagCompound>("modData").Skip(2))
                    {
                        if (modDataTag.Get<string>("mod") == ExxoAvalonOrigins.mod.Name)
                        {
                            TagCompound dataTag = modDataTag.Get<TagCompound>("data");
                            ExxoAvalonOriginsConfig.WorldDataValues worldData;

                            worldData.contagion = dataTag.Get<bool>("ExxoAvalonOrigins:Contagion");
                            worldData.jungleType = dataTag.Get<int>("ExxoAvalonOrigins:JungleType");
                            worldData.superHardmode = dataTag.Get<bool>("ExxoAvalonOrigins:SuperHardMode");
                            tempDict[path] = worldData;

                            containsMod = true;

                            break;
                        }
                    }

                    if (!containsMod)
                    {
                        ExxoAvalonOriginsConfig.WorldDataValues worldData;

                        worldData.contagion = false;
                        worldData.jungleType = (int)ExxoAvalonOriginsWorld.JungleVariant.jungle;
                        worldData.superHardmode = false;
                        tempDict[path] = worldData;
                    }

                    config.SetWorldData(tempDict);
                    ExxoAvalonOriginsConfig.Save(config);
                }
            }

            if (tempDict.ContainsKey(path))
            {
                string iconPath = "Sprites/Icon";
                iconPath += data.IsHardMode ? "Hallow" : "";
                iconPath += tempDict[path].contagion ? "Contagion" : (data.HasCrimson ? "Crimson" : "Corruption");
                iconPath += (ExxoAvalonOriginsWorld.JungleVariant)tempDict[path].jungleType == ExxoAvalonOriginsWorld.JungleVariant.tropics ? "Tropics" : "Jungle";
                iconPath += tempDict[path].superHardmode ? "SHM" : "";
                return ExxoAvalonOrigins.mod.GetTexture(iconPath);
            }
            else
            {
                return orig(self);
            }
        }

        public static void OnEraseWorld(On.Terraria.Main.orig_EraseWorld orig, int i)
        {
            ExxoAvalonOriginsConfig config = ModContent.GetInstance<ExxoAvalonOriginsConfig>();
            Dictionary<string, ExxoAvalonOriginsConfig.WorldDataValues> tempDict = config.GetWorldData();
            var path = Path.ChangeExtension(Main.WorldList[i].Path, ".twld");

            if (tempDict.ContainsKey(path))
            {
                tempDict.Remove(path);
                config.SetWorldData(tempDict);
                ExxoAvalonOriginsConfig.Save(config);
            }
            orig(i);
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
