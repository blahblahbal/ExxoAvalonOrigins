using Microsoft.Xna.Framework;

namespace ExxoAvalonOrigins.Items
        {
            spriteBatch.Draw(Main.itemTexture[item.type], position, frame, new Color(ExxoAvalonOrigins.gbvR, ExxoAvalonOrigins.gbvG, ExxoAvalonOrigins.gbvB), 0f, origin, scale, SpriteEffects.None, 0f);
            return false;
        }
        //public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        //{
        //    Vector2 iPos = item.position - Main.screenPosition;
        //    spriteBatch.Draw(Main.itemTexture[item.type], item.position - Main.screenPosition, new Rectangle((int)iPos.X, (int)iPos.Y, Main.itemTexture[item.type].Width, Main.itemTexture[item.type].Height), new Color(255, ExxoAvalonOrigins.royG, 0), 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        //    return false;
        //}
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Vector2 iPos = item.position - Main.screenPosition;
            spriteBatch.Draw(Main.itemTexture[item.type], item.position - Main.screenPosition, null, new Color(ExxoAvalonOrigins.gbvR, ExxoAvalonOrigins.gbvG, ExxoAvalonOrigins.gbvB), 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }
        //{
        //    Main.spriteBatch.Draw(Main.itemTexture[item.type], frame, new Rectangle((int)position.X, (int)position.Y, Main.itemTexture[item.type].Width, Main.itemTexture[item.type].Height), new Color(255, ExxoAvalonOrigins.royG, 0), 0, origin, SpriteEffects.None, scale);
        //    //base.PostDrawInInventory(spriteBatch, position, frame, new Color(255, ExxoAvalonOrigins.royG, 0), new Color(255, ExxoAvalonOrigins.royG, 0), origin, scale);
        //}
        //public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        //{
        //    Vector2 iPos = Main.item[whoAmI].position;

        //    Main.spriteBatch.Draw(Main.itemTexture[item.type], iPos, new Color(255, ExxoAvalonOrigins.royG, 0));
        //    //base.PostDrawInWorld(spriteBatch, new Color(255, ExxoAvalonOrigins.royG, 0), new Color(255, ExxoAvalonOrigins.royG, 0), rotation, scale, whoAmI);
        //}
    }