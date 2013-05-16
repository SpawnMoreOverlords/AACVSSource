using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FinalYearProject
{

    class Player
    {
        //********************************************************************
        //Player Variables:
        public Animation PlayerAnimation; //animation representing the player
        public Vector2 Position; //player position     
        //public float Speed;
        public bool Active; //State of the player (Dead or Alive)
        public int Health;  //Amount of hit points that the player has
        public float playerMoveSpeed; // A movement speed for the player
        public TimeSpan fireTime; // The rate of fire of the player laser
        public TimeSpan previousFireTime;
        public Boolean playerMoving;  //Variable to track if the player is currently moving or not:
        //********************************************************************

        //********************************************************************
        //Player methods:    
        public void Initialize(Animation animation, Vector2 position)
        {
            PlayerAnimation = animation;
            //Set the starting position of the player around the middle of the screen and to the back
            this.Position = position;
            //set the player to be active
            Active = true;
            //Set HP
            Health = 100;
        }

        public void Update(GameTime gameTime)
        {
            PlayerAnimation.Position = Position;
            PlayerAnimation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            PlayerAnimation.Draw(spriteBatch);
        }

        //**** EXTRA METHODS
        public int Width //Get the width of the player ship -AKA the width of 1 animation frame. 
        {
            get { return PlayerAnimation.FrameWidth; }
        }

        public int Height //Get the height of the palyer ship -AKA the width of 1 animation frame. 
        {
            get { return PlayerAnimation.FrameHeight; }
        }

        //Get direction for projectile
        public Vector2 GetDirection(Vector2 positionOfObject, Vector2 directionToPointAt)
        {
            Vector2 direction = directionToPointAt - positionOfObject;
            direction.Normalize();

            return direction;
        }

        //Get rotation for projectile.
        public float GetRotation(Vector2 direction)
        {
            return (float)Math.Atan2((float)direction.Y, (float)direction.X);
        }

        public void UpdatePlayer(GameTime gameTime, Input myInput, Sound mySound, GraphicsDevice graphicsDev,  
            Texture2D[] projectileTextures, List<Projectile> projectiles, bool[] powerup)
        {
            //player is by default stationary.. unless a movement key is activated:
            playerMoving = false;

            //call the update method in this instance of the class "Player", sending parameter gameTime.
            Update(gameTime);


            //Use the keyboard / Dpad
            if (myInput.currentKeyboardState.IsKeyDown(Keys.A))
            {
                Position.X -= playerMoveSpeed; //Moves the player x amount of space left according to the movespeed amount.
                playerMoving = true; //the player is moving!
            }
            if (myInput.currentKeyboardState.IsKeyDown(Keys.D))
            {
                Position.X += playerMoveSpeed;
                playerMoving = true; //the player is moving!
            }
            if (myInput.currentKeyboardState.IsKeyDown(Keys.W))
            {
                Position.Y -= playerMoveSpeed;
                playerMoving = true; //the player is moving!
            }
            if (myInput.currentKeyboardState.IsKeyDown(Keys.S))
            {
                Position.Y += playerMoveSpeed;
                playerMoving = true; //the player is moving!
            }

            // Make sure that the player does not go out of bounds
            Position.X = MathHelper.Clamp(Position.X, Width / 2, graphicsDev.Viewport.Width - Width / 2);
            Position.Y = MathHelper.Clamp(Position.Y, Height / 2, graphicsDev.Viewport.Height - Height / 2);
            //Checks the player width and height against the player position and  the width / height of the canvas :).

            //On the keyboard, it checks whether the up, down, left, or right arrow is being pressed, and if it is, 
            //changes the player Position value an appropriate amount based on which key is being held. The player always moves a fixed speed this way.

            //On the gamepad, it checks how far the left thumbstick is being held and then multiplies it by the player speed, 
            //changing the player Position by the final calculated value. With the thumbsticks, the player can choose how fast to move.

            //FIRE PROJECTILES IF!!!: EDIT THIS ON MOUSE CLICK HERE?
            //if (myInput.currentMouseState.LeftButton == ButtonState.Pressed)
            {
                // Fire only every interval we set as the fireTime
                if (gameTime.TotalGameTime - previousFireTime > fireTime)
                {
                    // Reset our current time
                    previousFireTime = gameTime.TotalGameTime;

                    // Add the projectile, but add it to the middle of the player (Power level 0)
                    Projectile projectile = new Projectile();
                    projectile.Initialize(graphicsDev.Viewport, projectileTextures[0], Position, GetDirection(Position, myInput.mousePosition), GetRotation(myInput.mousePosition - Position), 20.0f);
                    projectiles.Add(projectile);

                    Vector2 skew; 
                    if (powerup[0]) //if power level is Max:
                    {
                        skew.X = 0; skew.Y = 0;
                        Projectile projectile2 = new Projectile();
                        projectile2.Initialize(graphicsDev.Viewport, projectileTextures[3], Position + skew, GetDirection(Position, myInput.mousePosition), GetRotation(myInput.mousePosition - Position), 12.5f);
                        projectiles.Add(projectile2);
                    }
                    if (powerup[1]) //if power level is 1:
                    {
                        skew.X = 35; skew.Y = 35;
                        Projectile projectile2 = new Projectile();
                        projectile2.Initialize(graphicsDev.Viewport, projectileTextures[1], Position + skew, GetDirection(Position, myInput.mousePosition), GetRotation(myInput.mousePosition - Position), 17.0f);
                        projectiles.Add(projectile2);
                    }
                    if (powerup[2]) //if power level is 2:
                    {
                        skew.X = -35; skew.Y = -35;
                        Projectile projectile2 = new Projectile();
                        projectile2.Initialize(graphicsDev.Viewport, projectileTextures[2], Position + skew, GetDirection(Position, myInput.mousePosition), GetRotation(myInput.mousePosition - Position), 17.0f);
                        projectiles.Add(projectile2);
                    }
                    if (powerup[3]) //if power level is 3:
                    {
                        skew.X = 0; skew.Y = 0;
                        Projectile projectile2 = new Projectile();
                        projectile2.Initialize(graphicsDev.Viewport, projectileTextures[0], Position + skew, GetDirection(Position, myInput.mousePosition), GetRotation(myInput.mousePosition - Position), -20.0f);
                        projectiles.Add(projectile2);
                    }

                    //play the laser sound effect ^.^
                    mySound.laserSound.Play(0.25f, 0.0f, 0.0f);
                }
            }

        }//End UpdatePlayer

    }
}
