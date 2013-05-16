//Animation.cs
//Using declarations
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FinalYearProject
{
    class Animation
    {
        // The image representing the collection of images used for animation
        Texture2D spriteStrip;

        // The scale used to display the sprite strip
        private float scale;

        public float Scale
        {
            get { return scale; }
            set { scale = value; }
        }

        // The time since we last updated the frame
        int elapsedTime;

        // The time we display a frame until the next one
        int frameTime;

        // The number of frames that the animation contains
        int frameCount;

        // The index of the current frame we are displaying
        int currentFrame;

        // The color of the frame we will be displaying
        Color color;

        // The area of the image strip we want to display
        Rectangle sourceRect = new Rectangle();

        // The area where we want to display the image strip in the game
        Rectangle destinationRect = new Rectangle();

        // Width of a given frame
        public int FrameWidth;

        // Height of a given frame
        public int FrameHeight;

        // The state of the Animation
        public bool Active;

        // Determines if the animation will keep playing or deactivate after one run
        public bool Looping;

        // Width of a given frame
        public Vector2 Position;

        public Vector2 Direction { get; set; }
        public float Rotation { get; set; }

        public void Initialize(Texture2D texture, Vector2 position,
                                int frameWidth, int frameHeight, int frameCount,
                                int frametime, Color color, float scale, bool looping)
        {
            // Keep a local copy of the values passed in
            //ME: Assign parameter variables to the local variables :).
            this.color = color;
            this.FrameWidth = frameWidth;
            this.FrameHeight = frameHeight;
            this.frameCount = frameCount;
            this.frameTime = frametime;
            this.scale = scale;

            this.Looping = looping;
            this.Position = position;
            this.spriteStrip = texture;

            //Set the time to zero
            elapsedTime = 0;
            currentFrame = 0;

            //Set the animation to active by default
            Active = true;
        }

        public void Update(GameTime gameTime)
        {
            //Do not update the game if we are not active
            if (Active == false)
                return;

            //Update the elapsed time
            elapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;

            //If the elapsed time is larger than the frame time
            //we need to switch frames!
            if (elapsedTime > frameTime) //if the elapsed time is greater than the time alloted to each frame:
            {
                //Move to next frame :)
                currentFrame++;

                //If the currentFrame is equal to the frameCount reset the currentFrame to zero.
                if (currentFrame == frameCount)
                {
                    currentFrame = 0;
                    // If we are not looping deactivate the animation
                    if (Looping == false)
                        Active = false;
                }

                // Reset the elapsed time to zero
                elapsedTime = 0;
            }

            // Grab the correct frame in the image strip by multiplying the currentFrame index by the frame width
            sourceRect = new Rectangle(currentFrame * FrameWidth, 0, FrameWidth, FrameHeight);

            // Grab the correct frame in the image strip by multiplying the currentFrame index by the frame width
            destinationRect = new Rectangle((int)Position.X - (int)(FrameWidth * scale) / 2,
            (int)Position.Y - (int)(FrameHeight * scale) / 2,
            (int)(FrameWidth * scale),
            (int)(FrameHeight * scale));

            /*All of the information about which pixels of the sprite sheet need to be drawn is stored in the 
             * sourceRect and destinationRect objects. This is what the Draw() method will consume to draw the 
             * right frame to the screen. Let’s complete the Draw() method and our work in this class will be done.
             * */
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Only draw the animation when we are active
            if (Active)
            {
                spriteBatch.Draw(spriteStrip, destinationRect, sourceRect, color);
            }


        }

    }
}
