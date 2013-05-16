using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FinalYearProject
{
    class CollisionDetection
    {

        Random random = new Random();

        //Collision detection!
        public void UpdateCollision(Player player1, List<Enemy> enemies, Sound mySound, List<Projectile> projectiles)
        {
            // Use the Rectangle's built-in intersect function to 
            // determine if two objects are overlapping
            Rectangle rectangle1;
            Rectangle rectangle2;

            // Only create the rectangle once for the player
            rectangle1 = new Rectangle((int)player1.Position.X,
            (int)player1.Position.Y,
            player1.Width,
            player1.Height);

            // Do the collision between the player and the enemies
            for (int i = 0; i < enemies.Count; i++)
            {
                rectangle2 = new Rectangle((int)enemies[i].Position.X,
                (int)enemies[i].Position.Y,
                enemies[i].Width,
                enemies[i].Height);

                // Determine if the two objects collided with each
                // other
                if (rectangle1.Intersects(rectangle2))
                {
                    // Subtract the health from the player based on
                    // the enemy damage
                    player1.Health -= enemies[i].Damage;

                    // Since the enemy collided with the player
                    // destroy it
                    enemies[i].Health = 0;

                    // If the player health is less than or equal to zero (And they are currently alive):
                    if (player1.Health <= 0 && player1.Active)
                    {
                        player1.Active = false; //player is dead.
                        //stop spawning enemies:
                        for (int loop = 0; loop < enemies.Count; loop++) { enemies[loop].Active = false; }                           
                        //play GAMEOVER wav.
                        mySound.gameOver.Play(0.25f, 0.0f, 0.0f); //play sound effect at 25% volume. 
                        //play game over music.
                        mySound.PlayMusic(mySound.gameOverMusic, true);                        
                    }
                }      

            }


            //PROJECTILE COLLISION!
            // Projectile vs Enemy Collision
            for (int i = 0; i < projectiles.Count; i++)
            {
                for (int j = 0; j < enemies.Count; j++)
                {
                    // Create the rectangles we need to determine if we collided with each other
                    rectangle1 = new Rectangle((int)projectiles[i].Position.X -
                    projectiles[i].Width / 2, (int)projectiles[i].Position.Y -
                    projectiles[i].Height / 2, projectiles[i].Width, projectiles[i].Height);

                    rectangle2 = new Rectangle((int)enemies[j].Position.X - enemies[j].Width / 2,
                    (int)enemies[j].Position.Y - enemies[j].Height / 2,
                    enemies[j].Width, enemies[j].Height);

                    // Determine if the two objects collided with each other
                    if (rectangle1.Intersects(rectangle2))
                    {
                        enemies[j].Health -= projectiles[i].Damage;
                        projectiles[i].Active = false;
                    }
                }
            }

        }//End collision detection.

        public Vector2 checkAndCorrectSpawnCollision(Player player1, Texture2D enemyTexture, Vector2 position, GraphicsDevice graphicsDev, Animation enemyAnimation)
        {
            // Use the Rectangle's built-in intersect function to 
            // determine if two objects are overlapping
            Rectangle rectangle1;
            Rectangle rectangle2;

            // Only create the rectangle once for the player
            rectangle1 = new Rectangle((int)player1.Position.X,
            (int)player1.Position.Y,
            player1.Width,
            player1.Height);

            rectangle2 = new Rectangle((int)position.X,
            (int)position.Y,
            enemyTexture.Width,
            enemyTexture.Height);

            // Determine if the two objects collided with each
            // other
            if (rectangle1.Intersects(rectangle2))
            {
                //Randomly respawn the enemy to a new location - The chance of it being ontop of the player again is extremely low. 
                position = new Vector2(random.Next(0, graphicsDev.Viewport.Width - enemyAnimation.FrameWidth), random.Next(0, graphicsDev.Viewport.Height - enemyAnimation.FrameHeight));
            }

            return position;
        }//end checkAndCorrectSpawnCollision
        
    }
}

