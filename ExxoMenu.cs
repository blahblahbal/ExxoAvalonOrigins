using System;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins;

public class ExxoMenu : ModMenu
{
    public override Asset<Texture2D> Logo
    {
        get
        {
            if (DateTime.Now.Month == 4 && DateTime.Now.Day == 1)
            {
                return Mod.Assets.Request<Texture2D>("Sprites/EAOLogoAprilFools");
            }
            return Mod.Assets.Request<Texture2D>("Sprites/EAOLogo");
        }
    }
}
