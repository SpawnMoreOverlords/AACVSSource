using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FinalYearProject
{
    class Enemy
    {
        //********************************************************************
        //Enemy Variables:
        public Animation EnemyAnimation; // Animation representing the enemy
        public Vector2 Position; // The position of the enemy ship relative to the top left corner of thescreen
        public bool Active; // The state of the Enemy Ship
        public int Health; // The hit points of the enemy, if this goes to zero the enemy dies
        public int Damage; // The amount of damage the enemy inflicts on the player ship
        public int Value; // The amount of score the enemy will give to the player
        public float enemyMoveSpeed; // The speed at which the enemy moves
        // The rate at which the enemies appear
       // public TimeSpan enemySpawnTime;
      //  public TimeSpan previousSpawnTime;
        //********************************************************************


        //********************************************************************
        //Enemy methods: 
        public int Width // Get the width of the enemy ship
        {
            get { return EnemyAnimation.FrameWidth; }
        }

        public int Height  // Get the height of the enemy ship
        {
            get { return EnemyAnimation.FrameHeight; }
        }        

        public void Initialize(Animation animation, Vector2 position, float speed)
        {
            // Load the enemy ship texture
            EnemyAnimation = animation;

            // Set the position of the enemy
            Position = position;

            // We initialize the enemy to be active so it will be update in the game
            Active = true;


            // Set the health of the enemy
            Health = 10;

            // Set the amount of damage the enemy can do
            Damage = 10;

            // Set how fast the enemy moves
            Random rand = new Random();
            //enemyMoveSpeed = 2f + (float)rand.NextDouble();
            enemyMoveSpeed = speed + (float)rand.NextDouble();

            // Set the score value of the enemy
            Value = 100;

        }

        public void Update(GameTime gameTime, Vector2 direction)
        {/*
            // The enemy always moves to the left so decrement it's xposition
            Position.X -= enemyMoveSpeed; */            

            //move enemy towards the player!
            this.Position += direction * enemyMoveSpeed;

            // Update the position of the Animation
            EnemyAnimation.Position = Position;
            
            // Update Animation
            EnemyAnimation.Update(gameTime);

            // If the enemy is past the screen or its health reaches 0 then deactivateit
            if (Position.X < -Width || Health <= 0)
            {
                // By setting the Active flag to false, the game will remove this objet fromthe 
                // active game list
                Active = false;
            }
        } //end update

        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw the animation
            EnemyAnimation.Draw(spriteBatch);
        }//end draw

    }//end class!
}
