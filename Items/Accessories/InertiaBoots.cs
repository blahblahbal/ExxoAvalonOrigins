using Microsoft.Xna.Framework;
            {
                player.velocity.Y = player.velocity.Y - 0.3f * player.gravDir;
                if (player.gravDir == 1f)
                {
                    if (player.velocity.Y > 0f)
                    {
                        player.velocity.Y = player.velocity.Y - 1f;
                    }
                    else if (player.velocity.Y > -Player.jumpSpeed)
                    {
                        player.velocity.Y = player.velocity.Y - 0.2f;
                    }
                    if (player.velocity.Y < -Player.jumpSpeed * 3f)
                    {
                        player.velocity.Y = -Player.jumpSpeed * 3f;
                    }
                }
                else
                {
                    if (player.velocity.Y < 0f)
                    {
                        player.velocity.Y = player.velocity.Y + 1f;
                    }
                    else if (player.velocity.Y < Player.jumpSpeed)
                    {
                        player.velocity.Y = player.velocity.Y + 0.2f;
                    }
                    if (player.velocity.Y > Player.jumpSpeed * 3f)
                    {
                        player.velocity.Y = Player.jumpSpeed * 3f;
                    }
                }
            }