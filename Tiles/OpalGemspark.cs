using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Terraria.ObjectData;using Microsoft.Xna.Framework.Graphics;

namespace ExxoAvalonOrigins.Tiles{	public class OpalGemspark : ModTile	{		public override void SetDefaults()		{			AddMapEntry(new Color(165, 255, 127));			Main.tileSolid[Type] = true;			Main.tileLighted[Type] = true;			Main.tileShine2[Type] = true;			drop = mod.ItemType("OpalGemspark");		}        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)        {            r = Main.DiscoR / 255f * 1.5f;            g = Main.DiscoG / 255f * 1.5f;            b = Main.DiscoB / 255f * 1.5f;        }        //public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
        //{
        //    float num9 = 16;
        //    float num10 = 0;
        //    float num11 = 16;
        //    Vector2 zero = Vector2.Zero;
        //    Color color6 = default(Color);
        //    color6 = new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB, 255);
        //    if (!Main.tile[i, j].halfBrick())
        //    {
        //        if (Main.tile[i, j].inActive())
        //        {
        //            color6 = Main.tile[i, j].actColor(color6);
        //        }
        //        if (Main.tile[i, j].slope() == 0)
        //        {
        //            Main.spriteBatch.Draw(Main.tileTexture[(int)Main.tile[i, j].type], new Vector2((float)(j * 16 - (int)Main.screenPosition.X) - ((float)num9 - 16f) / 2f, (float)(i * 16 - (int)Main.screenPosition.Y + num10)) + zero, new Rectangle?(new Rectangle((int)Main.tile[i, j].frameX, (int)Main.tile[i, j].frameY, (int)num9, (int)num11)), color6, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
        //        }
        //        else if (Main.tile[i, j].slope() > 2)
        //        {
        //            if (Main.tile[i, j].slope() == 3)
        //            {
        //                for (int n = 0; n < 8; n++)
        //                {
        //                    int num90 = 2;
        //                    int num91 = n * 2;
        //                    int num92 = n * -2;
        //                    int num93 = 16 - n * 2;
        //                    if (Main.canDrawColorTile(j, i))
        //                    {
        //                        Main.spriteBatch.Draw(Main.tileAltTexture[(int)Main.tile[i, j].type, (int)Main.tile[i, j].color()], new Vector2((float)(j * 16 - (int)Main.screenPosition.X) - ((float)num9 - 16f) / 2f + (float)num91, (float)(i * 16 - (int)Main.screenPosition.Y + num10 + n * num90 + num92)) + zero, new Rectangle?(new Rectangle((int)Main.tile[i, j].frameX + num91, (int)(Main.tile[i, j].frameY + 16) - num93, num90, num93)), color6, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
        //                    }
        //                    else
        //                    {
        //                        Main.spriteBatch.Draw(Main.tileTexture[(int)Main.tile[i, j].type], new Vector2((float)(j * 16 - (int)Main.screenPosition.X) - ((float)num9 - 16f) / 2f + (float)num91, (float)(i * 16 - (int)Main.screenPosition.Y + num10 + n * num90 + num92)) + zero, new Rectangle?(new Rectangle((int)Main.tile[i, j].frameX + num91, (int)(Main.tile[i, j].frameY + 16) - num93, num90, num93)), color6, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                for (int num94 = 0; num94 < 8; num94++)
        //                {
        //                    int num95 = 2;
        //                    int num96 = 16 - num94 * num95 - num95;
        //                    int num97 = 16 - num94 * num95;
        //                    int num98 = num94 * -2;
        //                    if (Main.canDrawColorTile(j, i))
        //                    {
        //                        Main.spriteBatch.Draw(Main.tileAltTexture[(int)Main.tile[i, j].type, (int)Main.tile[i, j].color()], new Vector2((float)(j * 16 - (int)Main.screenPosition.X) - ((float)num9 - 16f) / 2f + (float)num96, (float)(i * 16 - (int)Main.screenPosition.Y + num10 + num94 * num95 + num98)) + zero, new Rectangle?(new Rectangle((int)Main.tile[i, j].frameX + num96, (int)(Main.tile[i, j].frameY + 16) - num97, num95, num97)), color6, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
        //                    }
        //                    else
        //                    {
        //                        Main.spriteBatch.Draw(Main.tileTexture[(int)Main.tile[i, j].type], new Vector2((float)(j * 16 - (int)Main.screenPosition.X) - ((float)num9 - 16f) / 2f + (float)num96, (float)(i * 16 - (int)Main.screenPosition.Y + num10 + num94 * num95 + num98)) + zero, new Rectangle?(new Rectangle((int)Main.tile[i, j].frameX + num96, (int)(Main.tile[i, j].frameY + 16) - num97, num95, num97)), color6, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
        //                    }
        //                }
        //            }
        //            if (Main.canDrawColorTile(j, i))
        //            {
        //                Main.spriteBatch.Draw(Main.tileAltTexture[(int)Main.tile[i, j].type, (int)Main.tile[i, j].color()], new Vector2((float)(j * 16 - (int)Main.screenPosition.X) - ((float)num9 - 16f) / 2f, (float)(i * 16 - (int)Main.screenPosition.Y + num10)) + zero, new Rectangle?(new Rectangle((int)Main.tile[i, j].frameX, (int)Main.tile[i, j].frameY, 16, 2)), color6, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
        //            }
        //            else
        //            {
        //                Main.spriteBatch.Draw(Main.tileTexture[(int)Main.tile[i, j].type], new Vector2((float)(j * 16 - (int)Main.screenPosition.X) - ((float)num9 - 16f) / 2f, (float)(i * 16 - (int)Main.screenPosition.Y + num10)) + zero, new Rectangle?(new Rectangle((int)Main.tile[i, j].frameX, (int)Main.tile[i, j].frameY, 16, 2)), color6, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
        //            }
        //        }
        //        else
        //        {
        //            if (Main.tile[i, j].slope() == 1)
        //            {
        //                for (int num99 = 0; num99 < 8; num99++)
        //                {
        //                    int num100 = 2;
        //                    int num101 = num99 * 2;
        //                    int height = 14 - num99 * num100;
        //                    Main.spriteBatch.Draw(Main.tileTexture[(int)Main.tile[i, j].type], new Vector2((float)(j * 16 - (int)Main.screenPosition.X) - ((float)num9 - 16f) / 2f + (float)num101, (float)(i * 16 - (int)Main.screenPosition.Y + num10 + num99 * num100)) + zero, new Rectangle?(new Rectangle((int)Main.tile[i, j].frameX + num101, (int)Main.tile[i, j].frameY, num100, height)), color6, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
        //                }
        //            }
        //            if (Main.tile[i, j].slope() == 2)
        //            {
        //                for (int num102 = 0; num102 < 8; num102++)
        //                {
        //                    int num103 = 2;
        //                    int num104 = 16 - num102 * num103 - num103;
        //                    int height2 = 14 - num102 * num103;
        //                    Main.spriteBatch.Draw(Main.tileTexture[(int)Main.tile[i, j].type], new Vector2((float)(j * 16 - (int)Main.screenPosition.X) - ((float)num9 - 16f) / 2f + (float)num104, (float)(i * 16 - (int)Main.screenPosition.Y + num10 + num102 * num103)) + zero, new Rectangle?(new Rectangle((int)Main.tile[i, j].frameX + num104, (int)Main.tile[i, j].frameY, num103, height2)), color6, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
        //                }
        //            }
        //            Main.spriteBatch.Draw(Main.tileTexture[(int)Main.tile[i, j].type], new Vector2((float)(j * 16 - (int)Main.screenPosition.X) - ((float)num9 - 16f) / 2f, (float)(i * 16 - (int)Main.screenPosition.Y + num10 + 14)) + zero, new Rectangle?(new Rectangle((int)Main.tile[i, j].frameX, (int)(Main.tile[i, j].frameY + 14), 16, 2)), color6, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
        //        }
        //    }
        //    return false;
        //}    }}