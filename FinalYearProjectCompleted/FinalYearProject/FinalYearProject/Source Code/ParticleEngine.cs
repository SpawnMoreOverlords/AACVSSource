using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FinalYearProject
{
    public class ParticleEngine
    {
        //variables:
        private Random random;
        
        private List<Particle> particles; //particles is a variable that contains all of the particles that are currently active in the particle engine
        private List<Texture2D> textures; //textures contains all of the textures available for use in the particle engine.
        int explosionTotal = 300;

        public Vector2 currentTrailVeloicty;
        public Vector2 currentExplosionVeloicty;

        public Color currentColour;

        //constrauctor
        public ParticleEngine(List<Texture2D> textures, Vector2 location)
        {
            this.EmitterLocation = location;
            this.textures = textures;
            this.particles = new List<Particle>();
            random = new Random();

            currentTrailVeloicty = new Vector2();
            //set default particle velocity
            //currentTrailVeloicty.X = 0.1f; currentTrailVeloicty.Y = 0.1f;

            currentExplosionVeloicty = new Vector2();
            //set default particle velocity
            //currentExplosionVeloicty.X = 1.5f; currentExplosionVeloicty.Y = 1.5f; 

            /*
             * Once again, our constructor only needs to prepare the instance variables for use. 
             * In the code below, a couple of the parameters are assigned by the user, and a couple 
             * are created with default values. We want the user to tell us what textures we can use,
             * as well as the default location of the emitter, but the list of particles is for the
             * particle engine to manage, and the user should not have to worry about them. Also, 
             * random is given a default new random number generator. 
             */
        }

        public Vector2 EmitterLocation { get; set; } //allows the user to change the location that the particles are originating at
        
        //My particle adaptation for ship trail and explosions - which takes paramters (is this a good idea.. not sure!)
        //perhaps i should simplfy the code a little - break it up into more classes?! -- DEPENDS HOW MANY TIMES I WILL MAKE DIFFERENT PARTICLE EFFECTS
        //WILL I NEED MORE THAN JUST A SHIP TRAIL AND ENEMY EXPLOSIONS... DIFFERENT TYPE OF ENEMY EXPLOSIONS!? Probably... >.<
        private Particle GenerateNewParticle(float velocity1, float velocity2, int staticttl, int randttl, Color color, float size)
        {
            Texture2D texture = textures[random.Next(textures.Count)];
            Vector2 position = EmitterLocation;

            Vector2 velocity = new Vector2(
                    velocity1 * (float)(random.NextDouble() * 2 - 1), /*edit the 1f values (both of them equally) to create an explosion effect :D!*/
                    velocity2 * (float)(random.NextDouble() * 2 - 1)); /*play around with the float() random values and the * + - values.. changes the shape.*/
            
            float angle = 0;
            float angularVelocity = 0.1f * (float)(random.NextDouble() * 2 - 1);
            //Color color = new Color(255 - random.Next(1,200), 85 - random.Next(1,45), 0 + random.Next(1,10)); //orange colours
            //float size = (float)0.1;
            int ttl = staticttl + random.Next(randttl);

            //RETURN THE EFFECT:
            return new Particle(texture, position, velocity, angle, angularVelocity, color, size, ttl);

        }

        //add new particles as needed, allow each of the particles to update themselves, and remove dead particles. 
        //update
        public void Update(Boolean playerMoving)
        {

            int total;
        
            if (playerMoving) //if the player is moving then generate particles:
            { total = 100; /*regulates the amount of particles created per update.*/ } 
            else { total = 0; /*stop producing particles if the player isnt moving :))*/ }

            for (int i = 0; i < total; i++)
            {
                //Color color = new Color(255 - random.Next(1, 200), 85 - random.Next(1, 45), 0 + random.Next(1, 10)); //orange colours
                particles.Add(GenerateNewParticle(currentTrailVeloicty.X, currentTrailVeloicty.Y, 10, 20, currentColour, 0.1f)); //takes parameter to change how the particle engine functions 
                //particles[i].Velocity = currentVeloicty;
            }

            for (int particle = 0; particle < particles.Count; particle++)
            {
                //particles[particle].Velocity += currentVeloicty;
                //particles[particle].Velocity.X = currentVeloicty.X; //update each individual particles velocity dynamically.
                //particles[particle].Velocity.Y = currentVeloicty.Y; //update each individual particles velocity dynamically.
                particles[particle].Update();

                if (particles[particle].TTL <= 0)
                {
                    particles.RemoveAt(particle);
                    particle--;
                }
            }
            //In this code, we start off by adding 10 new particles each time. We then go through the list 
            //of particles and tell them to update themselves. If any of them have "died" 
            //(their time to live has reached 0), the particle is removed.
        }

        public int UpdateExplosion()
        {
            //would be cool to make an array of colours to feed into the explosions so that the explosions slowly change colour.
            for (int i = 0; i < explosionTotal; i++)
            {
                //Color color = new Color(0, 191, 255);
                //Color color = new Color(255 - random.Next(1, 200), 150 - random.Next(1, 45), 150 + random.Next(1, 10)); //pink / grey colours
                /*TEMP RANDOM COLOURS*/ //Color color = new Color(random.Next(1, 250), random.Next(1, 250), random.Next(1, 250));
                particles.Add(GenerateNewParticle(currentExplosionVeloicty.X, currentExplosionVeloicty.Y, 10, 100, currentColour, 0.11f)); //takes parameter to change how the particle engine functions               
            }
            explosionTotal -= 150; //this will regulate how many particles are spawned each update. (e.g. if half of the particles are -= each time it 'explode' twice)
            //e.g. if the explosionTotal is 100, and I minus 50 each time it will be able to generate particles for 2 cycles.

            for (int particle = 0; particle < particles.Count; particle++)
            {
                //particles[particle].Velocity += currentExplosionVeloicty;
                //particles[particle].Velocity.Y = currentVeloicty.Y;
                //particles[particle].Velocity.X = currentVeloicty.X;
                particles[particle].Update();
                if (particles[particle].TTL <= 0)
                {
                    particles.RemoveAt(particle);
                    particle--;
                }
            }
            //In this code, we start off by adding 10 new particles each time. We then go through the list 
            //of particles and tell them to update themselves. If any of them have "died" 
            //(their time to live has reached 0), the particle is removed.

            return explosionTotal; //if explosion total is less than 0 it has stopped creating new particles and should be removed from the array in Game1.cs
            // EXTRA ************&&&&&&&&&&&&&&&& COULD WORK ON RETURNING AN ARRAY OF origionalExplosionTotal and ExplosionTotal... 
            //Then dynamically caluclating how long the explosion should live based on how big it is in the first place in Game1.cs 
            //instead of using the current static number of 10000.. which is fine when the explosion is 100 big, but will need to be changed
            //to different value if the explosion is smaller or bigger. especially for e.g if the explosionTotal starts at 10000.

        }

        //very simple method of this class, since it is mostly just going to tell the paricles to draw themselves.
        public void Draw(SpriteBatch spriteBatch)
        {            
            for (int index = 0; index < particles.Count; index++)
            {
                particles[index].Draw(spriteBatch);
            }            
        }

    }
}
