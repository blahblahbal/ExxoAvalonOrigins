using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.PlayerDrawLayers;

public class SpectrumArmorLayer : PlayerDrawLayer
{
    public override Position GetDefaultPosition()
    {
        return new AfterParent(Terraria.DataStructures.PlayerDrawLayers.Head);
    }
    protected override void Draw(ref PlayerDrawSet drawInfo)
    {
        if (drawInfo.shadow != 0f)
        {
            return;
        }
        Player p = drawInfo.drawPlayer;
        Color rb = new Color(Items.Armor.SpectrumHelmet.R, Items.Armor.SpectrumHelmet.G, Items.Armor.SpectrumHelmet.B, drawInfo.colorArmorBody.A);
        SpriteEffects spriteEffects = SpriteEffects.None;
        if (p.gravDir == 1f)
        {
            if (p.direction == 1)
            {
                spriteEffects = SpriteEffects.None;
            }
            else
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
            if (!p.dead)
            {
                p.legPosition.Y = 0f;
                p.headPosition.Y = 0f;
                p.bodyPosition.Y = 0f;
            }
        }
        else
        {
            if (p.direction == 1)
            {
                spriteEffects = SpriteEffects.FlipVertically;
            }
            else
            {
                spriteEffects = (SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically);
            }
            if (!p.dead)
            {
                p.legPosition.Y = 6f;
                p.headPosition.Y = 6f;
                p.bodyPosition.Y = 6f;
            }
        }
        Vector2 vector2 = new Vector2(p.legFrame.Width * 0.5f, p.legFrame.Height * 0.75f);
        Vector2 origin = new Vector2(p.legFrame.Width * 0.5f, p.legFrame.Height * 0.5f);
        Vector2 vector3 = new Vector2(p.legFrame.Width * 0.5f, p.legFrame.Height * 0.4f);
        if (p.head == ExxoAvalonOrigins.Mod.GetEquipSlot("SpectrumHelmet", EquipType.Head))
        {

            var value = default(DrawData);
            value = new DrawData(ExxoAvalonOriginsModPlayer.spectrumArmorTextures[0].Value, new Vector2((int)(drawInfo.Position.X - Main.screenPosition.X - p.bodyFrame.Width / 2 + p.width / 2), (int)(drawInfo.Position.Y - Main.screenPosition.Y + p.height - p.bodyFrame.Height + 4f)) + p.headPosition + vector3, new Rectangle?(p.bodyFrame), rb, p.headRotation, vector3, 1f, spriteEffects, 0);
            drawInfo.DrawDataCache.Add(value);
        }
        if (p.body == ExxoAvalonOrigins.Mod.GetEquipSlot("SpectrumBreastplate", EquipType.Body))
        {
            Rectangle bodyFrame2 = p.bodyFrame;
            int num55 = 0;
            bodyFrame2.X += num55;
            bodyFrame2.Width -= num55;
            var value = default(DrawData);
            value = new DrawData(ExxoAvalonOriginsModPlayer.spectrumArmorTextures[1].Value, new Vector2((int)(drawInfo.Position.X - Main.screenPosition.X - p.bodyFrame.Width / 2 + p.width / 2) + num55, (int)(drawInfo.Position.Y - Main.screenPosition.Y + p.height - p.bodyFrame.Height + 4f)) + p.bodyPosition + new Vector2(p.bodyFrame.Width / 2, p.bodyFrame.Height / 2), new Rectangle?(bodyFrame2), rb, p.bodyRotation, origin, 1f, spriteEffects, 0);
            drawInfo.DrawDataCache.Add(value);
        }
        if (p.legs == ExxoAvalonOrigins.Mod.GetEquipSlot("SpectrumGreaves", EquipType.Legs))
        {
            var value = new DrawData(ExxoAvalonOriginsModPlayer.spectrumArmorTextures[2].Value, new Vector2((int)(drawInfo.Position.X - Main.screenPosition.X - p.legFrame.Width / 2 + p.width / 2), (int)(drawInfo.Position.Y - Main.screenPosition.Y + p.height - p.legFrame.Height + 4f)) + p.legPosition + vector2, new Rectangle?(p.legFrame), rb, p.legRotation, vector2, 1f, spriteEffects, 0);
            drawInfo.DrawDataCache.Add(value);
        }
    }
}
