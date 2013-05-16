using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace FinalYearProject
{
    class BackgroundVis
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D texture;
        private Color backgroundColor;

        public Color BackgroundColor
        {
            get { return backgroundColor; }
            set { backgroundColor = value; }
        }

        //Width and Height of texture
        int Width = 0, Height = 1, y = 0;

        //This is where we store our audio Frequencies and Sample data
        //Frequencies are an array of 256 float values from 0f to 1f
        //Samples are an array of 256 float values from -1f to 1f
        VisualizationData visData = new VisualizationData();

        public BackgroundVis(GraphicsDeviceManager graphicsMan, GraphicsDevice graphicsDev)
        {
            backgroundColor = new Color(10, 10, 10);

            this.graphics = graphicsMan;
            //Content.RootDirectory = "Content"; //not sure about this???
            this.spriteBatch = new SpriteBatch(graphicsDev);
            
            //Create 1x1 white texture
            texture = new Texture2D(graphicsDev, 1, 1);
            texture.SetData<Color>(new Color[] { Color.White });

            Width = graphicsDev.Viewport.Width / visData.Frequencies.Count;

            //Load song *add your song in here aswell as the content libary*
            //mySong = Content.Load<Song>(@"Add song asset name here");

            //instead of a static load song - try and load song dynamically: 
            //mySong = Song.FromUri("audio name", new Uri(@"C:\Users\Steve\Desktop\FeedMeGreatBicicle.mp3"));

            //Enable visualization data
            MediaPlayer.IsVisualizationEnabled = true;
        }

        public void UnloadContent()
        {
            //Unload texture from memory
            texture.Dispose();
        }

        public void Update()
        {
            //Set the new Visualization data every update
            MediaPlayer.GetVisualizationData(visData);
        }

        public void Draw(GraphicsDevice graphicsDev, double movementCap)
        {
            graphicsDev.Clear(backgroundColor);

            spriteBatch.Begin();
            //Change visData.Samples to visData.Frequencies to suit your needs
            //i will count how many times we have drawn so we know how how far away to draw the next
            int i = 0;
            foreach (float value in visData.Frequencies)
            {
                //We change the y location of where we want to draw the texture based on value which is the data from our song visualization data
                //-value displays a reversed frequency - so that the y value moves in a positive plane. 
                //if visData.Frequencys then this will show the power / amplitutde of each frequency. (frequency spectrum display.)
                //if visData.Samples a waveform will be displayed. 
                y = (graphicsDev.Viewport.Height / 3) + (int)((-value * graphicsDev.Viewport.Height)*movementCap); //movementCap = limits or increased the amount of movement in the y axis. 
                
                //Draw texture (a rectangle) --> position.x = i*width, position.y = y, width, height, colour. 
                spriteBatch.Draw(texture, new Rectangle(i * Width, y, Width, Height), Color.Purple);
/*
                //repeat for 3 other colours and different movement caps:
                y = (graphicsDev.Viewport.Height / 2) + (int)((value * graphicsDev.Viewport.Height) * 0.2);
                spriteBatch.Draw(texture, new Rectangle(i * Width, y, Width, Height), Color.Green);
                y = (graphicsDev.Viewport.Height / 2) + (int)((value * graphicsDev.Viewport.Height) * 0.3);
                spriteBatch.Draw(texture, new Rectangle(i * Width, y, Width, Height), Color.Blue);
                y = (graphicsDev.Viewport.Height / 2) + (int)((value * graphicsDev.Viewport.Height) * 0.4);
                spriteBatch.Draw(texture, new Rectangle(i * Width, y, Width, Height), Color.Snow);
 */ 
                i++;
            }

            int x = 0;
            foreach (float value in visData.Samples)
            {
                //We change the y location of where we want to draw the texture based on value which is the data from our song visualization data
                //-value displays a reversed frequency - so that the y value moves in a positive plane. 
                //if visData.Frequencys then this will show the power / amplitutde of each frequency. (frequency spectrum display.)
                //if visData.Samples a waveform will be displayed. 
                y = (int)((graphicsDev.Viewport.Height / 1.5))+ (int)((-value * graphicsDev.Viewport.Height) * movementCap); //movementCap = limits or increased the amount of movement in the y axis. 

                //Draw texture (a rectangle) --> position.x = i*width, position.y = y, width, height, colour. 
                spriteBatch.Draw(texture, new Rectangle(x * Width, y, Width, Height), Color.Purple);
                /*
                                //repeat for 3 other colours and different movement caps:
                                y = (graphicsDev.Viewport.Height / 2) + (int)((value * graphicsDev.Viewport.Height) * 0.2);
                                spriteBatch.Draw(texture, new Rectangle(i * Width, y, Width, Height), Color.Green);
                                y = (graphicsDev.Viewport.Height / 2) + (int)((value * graphicsDev.Viewport.Height) * 0.3);
                                spriteBatch.Draw(texture, new Rectangle(i * Width, y, Width, Height), Color.Blue);
                                y = (graphicsDev.Viewport.Height / 2) + (int)((value * graphicsDev.Viewport.Height) * 0.4);
                                spriteBatch.Draw(texture, new Rectangle(i * Width, y, Width, Height), Color.Snow);
                 */
                x++;
            }
            spriteBatch.End();
        }

        public void Draw2(GraphicsDevice graphicsDev, double movementCap, Color[] colourArray)
        {
            graphicsDev.Clear(backgroundColor);

            spriteBatch.Begin();
            int x, y, width, height;

            for (int f = 0; f < visData.Frequencies.Count; f++)
            {
                x = graphicsDev.Viewport.Width * f / visData.Frequencies.Count;
                y = (int)(graphicsDev.Viewport.Height / 2 - visData.Frequencies[f] * graphicsDev.Viewport.Height / 2);
                width = 1;
                height = (int)(visData.Frequencies[f] * graphicsDev.Viewport.Height / 2);
                spriteBatch.Draw(texture, new Rectangle(x, y, width, height), colourArray[0]);
            }

            for (int s = 0; s < visData.Samples.Count; s++)
            {
                x = graphicsDev.Viewport.Width * s / visData.Samples.Count;
                width = 1;
                if (visData.Samples[s] > 0.0f)
                {
                    y = (int)(0.75f * graphicsDev.Viewport.Height - visData.Samples[s] * graphicsDev.Viewport.Height / 4);
                    height = (int)(visData.Samples[s] * graphicsDev.Viewport.Height / 4);
                }
                else
                {
                    y = (int)(0.75f * graphicsDev.Viewport.Height);
                    height = (int)(-1.0f * visData.Samples[s] * graphicsDev.Viewport.Height / 4);
                }
                spriteBatch.Draw(texture, new Rectangle(x, y, width, height), colourArray[1]);
            }
            spriteBatch.End();
        }

        public void colourFade(bool[] increasing, int[] x)
        {
            //increment / decrement colours for a low responce
            if (increasing[0] && (x[0] + 1 > 153))
                increasing[0] = false;
            else if (!increasing[0] && (x[0] - 1 < 15)) //10%
                increasing[0] = true;

            if (increasing[0])
            {
                x[0] += 1;
            }
            else
            {
                x[0] -= 1;
            }

            //increment / decrement colours for a medium responce
            if (increasing[1] && (x[1] + 1 > 237))
                increasing[1] = false;
            else if (!increasing[1] && (x[1] - 1 < 156)) //goes down to 66% fade
                increasing[1] = true;

            if (increasing[1])
            {
                x[1] += 1;
            }
            else
            {
                x[1] -= 1;
            }
            if (increasing[2] && (x[4] + 1 > 152))
                increasing[2] = false;
            else if (!increasing[2] && (x[4] - 1 < 100)) //goes down to 66% fade
                increasing[2] = true;

            if (increasing[2])
            {
                x[4] += 1;
            }
            else
            {
                x[4] -= 1;
            }

            //increment / decrement colours for a high responce
            if (increasing[3] && (x[2] + 1 > 208))
                increasing[3] = false;
            else if (!increasing[3] && (x[2] - 1 < 187)) //goes down ToString 90% fade
                increasing[3] = true;

            if (increasing[3])
            {
                x[2] += 1;
            }
            else
            {
                x[2] -= 1;
            }
            if (increasing[4] && (x[3] + 1 > 110))
                increasing[4] = false;
            else if (!increasing[4] && (x[3] - 1 < 99)) //goes down ToString 90% fade
                increasing[4] = true;

            if (increasing[4])
            {
                x[3] += 1;
            }
            else
            {
                x[3] -= 1;
            }
        }

    }
}
