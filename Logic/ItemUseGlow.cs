using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Logic
{
    public class ItemUseGlow : GlobalItem
    {
        public Texture2D glowTexture = null;
        public int glowOffsetY = 0;
        public int glowOffsetX = 0;
        public override bool InstancePerEntity => true;
        public override bool CloneNewInstances => true;
    }
    public class PlayerUseGlow : ModPlayer
    {
        public static readonly PlayerLayer ItemUseGlow = new PlayerLayer("ExxoAvalonOrigins", "ItemUseGlow", PlayerLayer.HeldItem, delegate (PlayerDrawInfo drawInfo)
        {
            if (drawInfo.shadow != 0)
                return;

            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("ExxoAvalonOrigins");
            if (!drawPlayer.HeldItem.IsAir)
            {
                Item item = drawPlayer.HeldItem;
                Texture2D texture = item.GetGlobalItem<ItemUseGlow>().glowTexture;
                Vector2 zero2 = Vector2.Zero;


                if (texture != null && drawPlayer.itemAnimation > 0)
                {
                    Vector2 value2 = drawInfo.itemLocation;
                    if (item.useStyle == ItemUseStyleID.HoldingOut)
                    {
                        bool flag14 = Item.staff[item.type];
                        if (flag14)
                        {
                            float num104 = drawPlayer.itemRotation + 0.785f * (float)drawPlayer.direction;
                            int num105 = 0;
                            int num106 = 0;
                            Vector2 zero3 = new Vector2(0f, (float)Main.itemTexture[item.type].Height);

                            if (drawPlayer.gravDir == -1f)
                            {
                                if (drawPlayer.direction == -1)
                                {
                                    num104 += 1.57f;
                                    zero3 = new Vector2((float)Main.itemTexture[item.type].Width, 0f);
                                    num105 -= Main.itemTexture[item.type].Width;
                                }
                                else
                                {
                                    num104 -= 1.57f;
                                    zero3 = Vector2.Zero;
                                }
                            }
                            else if (drawPlayer.direction == -1)
                            {
                                zero3 = new Vector2((float)Main.itemTexture[item.type].Width, (float)Main.itemTexture[item.type].Height);
                                num105 -= Main.itemTexture[item.type].Width;
                            }


                            DrawData value = new DrawData(texture, new Vector2((float)((int)(value2.X - Main.screenPosition.X + zero3.X + (float)num105)), (float)((int)(value2.Y - Main.screenPosition.Y + (float)num106))), new Microsoft.Xna.Framework.Rectangle?(new Rectangle(0, 0, Main.itemTexture[item.type].Width, Main.itemTexture[item.type].Height)), Color.White, num104, zero3, item.scale, drawInfo.spriteEffects, 0);
                            Main.playerDrawData.Add(value);

                        }
                        else
                        {
                            Vector2 vector10 = new Vector2((float)(Main.itemTexture[item.type].Width / 2), (float)(Main.itemTexture[item.type].Height / 2));

                            //Vector2 vector11 = this.DrawPlayerItemPos(drawPlayer.gravDir, item.type);
                            Vector2 vector11 = new Vector2(10, texture.Height / 2);
                            if (item.GetGlobalItem<ItemUseGlow>().glowOffsetX != 0)
                            {
                                vector11.X = item.GetGlobalItem<ItemUseGlow>().glowOffsetX;
                            }
                            vector11.Y += item.GetGlobalItem<ItemUseGlow>().glowOffsetY * drawPlayer.gravDir;
                            int num107 = (int)vector11.X;
                            vector10.Y = vector11.Y;
                            Vector2 origin5 = new Vector2((float)(-(float)num107), (float)(Main.itemTexture[item.type].Height / 2));
                            if (drawPlayer.direction == -1)
                            {
                                origin5 = new Vector2((float)(Main.itemTexture[item.type].Width + num107), (float)(Main.itemTexture[item.type].Height / 2));
                            }

                            //value = new DrawData(Main.itemTexture[item.type], new Vector2((float)((int)(value2.X - Main.screenPosition.X + vector10.X)), (float)((int)(value2.Y - Main.screenPosition.Y + vector10.Y))), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.itemTexture[item.type].Width, Main.itemTexture[item.type].Height)), item.GetAlpha(color37), drawPlayer.itemRotation, origin5, item.scale, effect, 0);
                            //Main.playerDrawData.Add(value);


                            DrawData value = new DrawData(texture, new Vector2((float)((int)(value2.X - Main.screenPosition.X + vector10.X)), (float)((int)(value2.Y - Main.screenPosition.Y + vector10.Y))), new Microsoft.Xna.Framework.Rectangle?(new Rectangle(0, 0, Main.itemTexture[item.type].Width, Main.itemTexture[item.type].Height)), Color.White, drawPlayer.itemRotation, origin5, item.scale, drawInfo.spriteEffects, 0);
                            Main.playerDrawData.Add(value);


                        }
                    }
                    else
                    {


                        DrawData value = new DrawData(texture,
                            new Vector2((float)((int)(value2.X - Main.screenPosition.X)),
                            (float)((int)(value2.Y - Main.screenPosition.Y))), new Rectangle?(new Rectangle(0, 0, texture.Width, texture.Height)),
                            Color.White,
                            drawPlayer.itemRotation,
                             new Vector2(texture.Width * 0.5f - texture.Width * 0.5f * (float)drawPlayer.direction, drawPlayer.gravDir == -1 ? 0f : texture.Height),
                            item.scale,
                            drawInfo.spriteEffects,
                            0);

                        Main.playerDrawData.Add(value);

                    }
                }
            }
        });
        public override void ModifyDrawLayers(List<PlayerLayer> layers)
        {
            int itemLayer = layers.FindIndex(PlayerLayer => PlayerLayer.Name.Equals("HeldItem"));
            if (itemLayer != -1)
            {
                ItemUseGlow.visible = true;
                layers.Insert(itemLayer + 1, ItemUseGlow);
            }

        }
    }
}
