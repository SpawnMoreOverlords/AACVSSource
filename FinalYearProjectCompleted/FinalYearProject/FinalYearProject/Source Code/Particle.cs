using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FinalYearProject
{
    public class Particle
    {
        public Texture2D Texture { get; set; }        // The texture that will be drawn to represent the particle
        public Vector2 Position { get; set; }        // The current position of the particle        
        public Vector2 Velocity;        // The speed of the particle at the current instance
        public float Angle { get; set; }            // The current angle of rotation of the particle
        public float AngularVelocity { get; set; }    // The speed that the angle is changing
        public Color Color { get; set; }            // The color of the particle
        public float Size { get; set; }                // The size of the particle
        public int TTL { get; set; }                // The 'time to live' of the particle

        public Particle(Texture2D texture, Vector2 position, Vector2 velocity,
            float angle, float angularVelocity, Color color, float size, int ttl)
        {
            this.Texture = texture;
            this.Position = position;
            this.Velocity = velocity;
            this.Angle = angle;
            this.AngularVelocity = angularVelocity;
            this.Color = color;
            this.Size = size;
            this.TTL = ttl;
        }

        /*Update both the position and angle by the velocity and angular velocities respectively.
         * Decrement the TTL (time to live) variable to move it one step closer to expiring.
         * */
        public void Update()
        {
            TTL--;
            Position += Velocity;
            Angle += AngularVelocity;
        }

        //draw the particle's texture with all of the necessary properties
        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, Texture.Width, Texture.Height);
            Vector2 origin = new Vector2(Texture.Width / 2, Texture.Height / 2);

            spriteBatch.Draw(Texture, Position, sourceRectangle, Color,
                Angle, origin, Size, SpriteEffects.None, 0f);

            /*We start off by doing a couple of quick calculations for the source rectangle 
             * (which we want to cover the entire texture) and the origin, which is the 
             * center of rotation, we want to be at the center of the texture. 
             * We then draw the texture scaled, rotated, colored, and placed according to the 
             * information of the particle. Notice that we don't call spriteBatch.Begin() or
             * spriteBatch.End() here, because we are going to be drawing a lot of these
             * all at one time. We will call Begin() and End() later when we are writing
             * the drawing code for the entire particle engine.*/
        }



    }
}
