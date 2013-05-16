using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FinalYearProject
{
    class Projectile
    {
        //********************************************************************
        //Projectile Variables: 
        public Texture2D Texture; // Image representing the Projectile
        public Vector2 Position; // Position of the Projectile relative to the upper left side of the screen
        public bool Active; // State of the Projectile
        public int Damage; // The amount of damage the projectile can inflict to an enemy
        Viewport viewport; // Represents the viewable boundary of the game
        public float projectileMoveSpeed; // Determines how fast the projectile moves
        //********************************************************************


        //********************************************************************
        //Projectile Methods:
        public int Width // Get the width of the projectile ship
        {
            get { return Texture.Width; }
        }

        public int Height // Get the height of the projectile ship
        {
            get { return Texture.Height; }
        }
                
        public float Rotation { get; set; } //Projectile rotation
        public Vector2 Direction { get; set; } //projectile direction


        public void Initialize(Viewport viewport, Texture2D texture, Vector2 position, Vector2 direction, float rotation, float velocity)
        {
            Texture = texture;
            Position = position;
            this.viewport = viewport;
            this.Direction = direction;
            this.Rotation = rotation;

            Active = true;

            Damage = 10; //enemy HP is currently 10 too. (1 hit kill).

            projectileMoveSpeed = velocity;
        }

        public void Update()
        {
            // Projectiles always move to the right
            //Position.X += projectileMoveSpeed;

            //projectile moves in a direction:
            this.Position += Direction * projectileMoveSpeed;



            // Deactivate the bullet if it goes out of screen
            if (Position.X + Texture.Width / 2 > viewport.Width)
                Active = false;

            if (Position.Y + Texture.Height / 2 > viewport.Height)
                Active = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, null, Color.White, this.Rotation,
            new Vector2(Width / 2, Height / 2), 1f, SpriteEffects.None, 0f);
        }

    }
}
