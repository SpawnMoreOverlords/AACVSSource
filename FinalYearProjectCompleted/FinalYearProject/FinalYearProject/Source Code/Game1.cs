using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace FinalYearProject
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        AudioAnalysisXNAClass audioAnalysis;
        
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Input myInput; //my input class - handels input and some small calculations. 
        Sound mySound;
        Player player1; // Declaring the player1 object.
        Animation playerAnimation = new Animation();  //declate animation publically
        CollisionDetection collisionDetection;

        //projectile variables:
        Texture2D[] projectileTextures;
        List<Projectile> projectiles;
        //end projectile variables.

        //ENEMY VARIABLES:
        // Enemies
        Texture2D enemyTexture;
        List<Enemy> enemies;

        // The rate at which the enemies appear -- I think this should stay here - The game is in charge of spawning enemies. 
        TimeSpan enemySpawnTime; //THIS HAS MOVED TO THE ENEMY CLASS. (OR TRY TO!?!?!? )
        TimeSpan previousSpawnTime; //Hard because enemies are created and destroyed - so each individual enemy doesnt have a "respawn" time and therefore doesnt need to know its spawn time. 

        // A random number generator
        Random random;
        //END EMENY VARIABLES

        //Explosion variables: //Dont need this anymore??
        List<Texture2D> textures = new List<Texture2D>();

        //create an instance of the particle engine :D!
        ParticleEngine particleEngineTrail;
        Vector2 minParticleTrailVelocity; Vector2 midParticleTrailVelocity; Vector2 maxParticleTrailVelocity; //min, mid and max velocity that particles for trails can travel at.
        //create another global instance of the particle engine for explosions:
        ParticleEngine explosion;
        Vector2 minParticleExplosionVelocity; Vector2 midParticleExplosionVelocity; Vector2 maxParticleExplosionVelocity; //min, mid and max velocity that particles for explosions can travel at.
        List<ParticleEngine> particleEngineExplosions = new List<ParticleEngine>();

        //SpriteFont variable to display graphical text on the screen
        int score; //score.
        int highscore;
        int killcount;
        int highkillcount;
        String currentSongName;
        // The font used to display UI elements
        SpriteFont font;

        //Background visulisation class def:
        BackgroundVis backgroundVis;
        Color[] backVisColourArray = new Color[2]; //Background vis array to use
        //3 possible arrays of colours for background vis, parameters for the audio analysis class.
        //These can also be used for the single colour audio analysis, by simply sending 2 element from each array. (If the colour required is the same).
        Color[] audioVisColourArray1; Color[] audioVisColourArray2; Color[] audioVisColourArray3;
        int[] x;
        bool[] increasing;
        Color backgroundColour1; Color backgroundColour2; Color backgroundColour3; Color backgroundColour4; Color backgroundColour5; Color backgroundColour6;
   
        String inputText; //The input string for user defined music selection!
        String powerLevel; //String to display current power level
        String enemyLevel; //String to display current enemy level.
        int enemyHealth; //int to store enemies current hit points
        int enemyScoreValue; //in to keep track of the enemies worth for scoring. 

        float minFireRateInterval;
        float midFireRateInterval;
        float maxFireRateInterval;
        float minSpawnTimeInterval;
        float midSpawnTimeInterval;
        float maxSpawnTimeInterval;

        //Player power up bools:
        bool[] powerup;
        bool displayStatistics; //bool for displaying statistics
        bool win; //boolean to player the success sound effect once only per win. 

        public Game1()
        {
            //full screen mode
            graphics = new GraphicsDeviceManager(this);

            graphics.PreferredBackBufferWidth = 1050; //600
            graphics.PreferredBackBufferHeight = 1680; //800 safer values??
            graphics.PreferMultiSampling = false;
            graphics.IsFullScreen = true;
            //end full screen code

            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            //Initalise the AudioAnalysisXNAClass object.
            audioAnalysis = new AudioAnalysisXNAClass(); 

            player1 = new Player(); // Initialize the player class :)
            myInput = new Input(); // Initialize the input class
            mySound = new Sound(); //Initialize the sound class

            collisionDetection = new CollisionDetection();

            //Show the mouse:
            this.IsMouseVisible = true;

            //projectile stuff:
            projectiles = new List<Projectile>();
            //end projectile stuff

            //ENEMY STUFF:
            //Initialize the enemies list
            enemies = new List<Enemy> ();

            // Set the time keepers to zero
            previousSpawnTime = TimeSpan.Zero;

            // Used to determine how fast enemy respawns
            //enemySpawnTime = TimeSpan.FromSeconds(0.4f); //works for 126 bpm track (sometimes)... -0.07619 lag
            //enemySpawnTime = TimeSpan.FromSeconds(0.28614333f); //works  for 18-bpm track: 0.33333333 - 0.04719 (lag time)

            // Initialize our random number generator
            random = new Random();
            //END ENEMY

            //At the start of the game the players score is zero:
            score = 0;
            highscore = 0;
            killcount = 0;
            highkillcount = 0;

            //background visulisation:
            backgroundVis = new BackgroundVis(graphics, GraphicsDevice); //Only one song can be played at a time using XNA Media player 
            //- therefore I do not need ot send the audio file to the background vis, only the current media player data (each update)

            inputText = ""; //initalise inputText to null for parsing.  

            x = new int[5];
            increasing = new bool[5]; //variables for RGB colour values, that will increase and decrease to create a colour fade effect
            for (int i = 0; i < 5; i++) //variables that determin if the above variables should be increasing or decreasing.
            {
                x[i] = 0;
                increasing[i] = true;
            }

            //initalise colour arrays for audio analysis use:
            audioVisColourArray1 = new Color[2]; //array of 2 colours
            audioVisColourArray2 = new Color[2]; //array of 2 colours
            audioVisColourArray3 = new Color[2]; //array of 2 colours
            //Colours for a low responce
            audioVisColourArray1[0] = new Color(0, 153, 153);
            audioVisColourArray1[1] = new Color(153, 153, 0);
            //Colours for a medium responce
            audioVisColourArray2[0] = new Color(152, 237, 0);
            audioVisColourArray2[1] = new Color(0, 237, 152);
            //Colours for a high responce
            audioVisColourArray3[0] = new Color(208, 0, 110);
            audioVisColourArray3[1] = new Color(110, 0, 208);

            //background colours for low, medium and high responce.
            backgroundColour1 = new Color(0, 0, 0);
            backgroundColour2 = new Color(3, 3, 3);
            backgroundColour3 = new Color(6, 6, 6);
            backgroundColour4 = new Color(9, 9, 9);
            backgroundColour5 = new Color(12, 12, 12);
            backgroundColour6 = new Color(40, 40, 40);

            //player powerup bools - by default are all false
            powerup = new bool[10];
            for (int i = 0; i < 10; i++)
                powerup[i] = false;

            powerLevel = "0";
            enemyLevel = "0";
            enemyHealth = 10; //10 by default. 
            enemyScoreValue = 100; //100 by default

            minFireRateInterval = 0.05f;
            midFireRateInterval = 0.15f;
            maxFireRateInterval = 1000f;
            minSpawnTimeInterval = 0.25f;
            midSpawnTimeInterval = 0.45f;
            maxSpawnTimeInterval = 1000f;

            displayStatistics = false; //display statistics = false by default
            win = true; 

            //particle trail velocities:
            minParticleTrailVelocity = new Vector2(0.7f, 0.7f); //*4
            midParticleTrailVelocity = new Vector2(2.0f, 2.0f);
            maxParticleTrailVelocity = new Vector2(4.0f, 4.0f);
            //particle explosion velocities:
            minParticleExplosionVelocity = new Vector2(1.5f, 1.5f); //*14
            midParticleExplosionVelocity = new Vector2(7.0f, 7.0f);
            maxParticleExplosionVelocity = new Vector2(14.0f, 14.0f);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        /* CONTENT DOES NOT NEED TO BE LOADED IN ORDER. IT MUST BE ->DRAWN<- Draw() in order! */
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load the player resources -- Instanciates the animation of the player:
            Texture2D playerTexture = Content.Load<Texture2D>("player1sprite_6frames_mrk2");
            playerAnimation.Initialize(playerTexture, Vector2.Zero, 25, 25, 6, 60, Color.White, 1f, true);

            Vector2 playerPosition = new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X, GraphicsDevice.Viewport.TitleSafeArea.Y
            + GraphicsDevice.Viewport.TitleSafeArea.Height / 2);
            player1.Initialize(playerAnimation, playerPosition);
            //end player resources

            //projectile texture
            projectileTextures = new Texture2D[4];  
            projectileTextures[0] = Content.Load<Texture2D>("laser1");
            projectileTextures[1] = Content.Load<Texture2D>("laser2");
            projectileTextures[2] = Content.Load<Texture2D>("laser3");
            projectileTextures[3] = Content.Load<Texture2D>("laser4");
            //end projectile stuff

            //LOAD ENEMY
            enemyTexture = Content.Load<Texture2D>("enemySprite_20frames");

            //load explosion texture to graphics card
            //explosionTexture = Content.Load<Texture2D>("explosion");

            //asign textures to the particle engine
            textures.Add(Content.Load<Texture2D>("particles/circleparticle"));
            textures.Add(Content.Load<Texture2D>("particles/starparticle"));
            textures.Add(Content.Load<Texture2D>("particles/diamondparticle"));
            particleEngineTrail = new ParticleEngine(textures, new Vector2(400, 240));
            
            //end particle engine            

            //Load all sound files
            mySound.loadAudioFiles(Content);

            //Load the font file
            font = Content.Load<SpriteFont>("gameFont");            
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // Nothing requires unloading yet - This may be implemented when i have multiple game screens - 
            //Such as a menu screen, high score, game screen, etc. -- Generally automatic garbage collection will deal with deal objects.
            backgroundVis.UnloadContent();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            //FIRST: Update visulisation data.
            audioAnalysis.Update(); 

            ////////////////////////////////////////////////////////////////////
            /* SECOND: Update the average amplitutde for each frequency band, // 
            // using the current visulisation data.                           */ 
            ////////////////////////////////////////////////////////////////////
            //Update the average amplitude for the low frequency band.
            audioAnalysis.updateAverageLowFrequencyData();
            //Update the average amplitude for the mid frequency band.
            audioAnalysis.updateAverageMidFrequencyData();
            //Update the average amplitude for the high frequency band.
            audioAnalysis.updateAverageHighFrequencyData();

            /* //"Fireworks mode"
            manuallySetValues(); //Manually set all of the average frequency values
            getAverageAmplitudes(); //Print all of the average frequency values to the console.
            */

            //get currently playing song's name:
            currentSongName = mySound.CurrentSongName;

            // Exit game if ESC key is pressed:
            if (myInput.currentKeyboardState.IsKeyDown(Keys.Escape)) { this.Exit(); }

            // Pressing enter will restart the game and update the high score. 
            if (myInput.currentKeyboardState.IsKeyDown(Keys.Enter))
            {
                prepareForNewGame();
                mySound.stopPlayingMusic(); //Stop playing the game over music. 
            }

            if (myInput.currentKeyboardState.IsKeyDown(Keys.F1)) { displayStatistics = true; } //Display audio analysis statistics if F1 is pressed
            if (myInput.currentKeyboardState.IsKeyDown(Keys.F2)) { displayStatistics = false; } //Hide audio analysis statistics if F2 is pressed
            
            songSelection();

            updateBackVisColours();
            
            //First update the visulisation data for dynamic variables:
            backgroundVis.Update(); //background visulisation:

            //audioAnalysis returns normalized values between -1 and 1. You then times that return value by the maxiumun value you wish the player to move :).
            player1.playerMoveSpeed = audioAnalysis.getFloat_6StepLowFrq(1.0f, 9.0f, 0.1f, 0.2f, 0.3f, 0.4f, 0.54f); //players minimun movespeed is the same as enemies. 

            //Update the mouse position, and calculate new rotation / direction of projectiles.
            myInput.UpdateMouseAndDirectionRotation(player1, playerAnimation);     

            //update the state of the keyboard
            myInput.UpdateKeyboard();

            // Update the collision
            collisionDetection.UpdateCollision(player1, enemies, mySound, projectiles);                

            //Update the player
            if (player1.Active) //Only updat the player if it's still active (e.g. not dead).
            {
                player1.UpdatePlayer(gameTime, myInput, mySound, GraphicsDevice, projectileTextures, projectiles, powerup);
            }



            // Update the projectiles
            UpdateProjectiles();

            enemySpawnTime = audioAnalysis.getTimeSpan_3StepLowFrq(minSpawnTimeInterval, midSpawnTimeInterval, maxSpawnTimeInterval, 0.4f, 0.54f);
            // Update the enemies
            UpdateEnemies(gameTime);     
            
            // Update the explosions
            UpdateExplosions(gameTime);

            /*PARTICLE STUFF YAY :D!*/
            //Allow the particle engine to update itself:
            //particleEngine.EmitterLocation = new Vector2(Mouse.GetState().X, Mouse.GetState().Y); //particles spawn at mouse location.
            //spawn particles at player location instead:
            particleEngineTrail.EmitterLocation = player1.Position;
            //before updating the particles though the particle engine, update the veloicty dynamically:
            particleEngineTrail.currentTrailVeloicty = audioAnalysis.getVector2_3StepLowFrq(minParticleTrailVelocity, midParticleTrailVelocity, maxParticleTrailVelocity, 0.4f, 0.54f);
            //Send the particle engine for trails the AAC chosen colour for the current sample. The AAC receives parameters of 3 single colour values. (Same as the background vis)
            particleEngineTrail.currentColour = audioAnalysis.getColour_3StepLowFrq(audioVisColourArray1[1], audioVisColourArray2[1], audioVisColourArray3[1], 0.4f, 0.54f);
            particleEngineTrail.Update(player1.playerMoving); //update trail 
            //Set lazer fire-rate
            player1.fireTime = audioAnalysis.getTimeSpan_3StepLowFrq(minFireRateInterval, midFireRateInterval, maxFireRateInterval, 0.4f, 0.54f);
            backVisColourArray = audioAnalysis.getColourArray_3StepLowFrq(audioVisColourArray1, audioVisColourArray2, audioVisColourArray3, 0.4f, 0.54f);
            
            //leave this alone.
            base.Update(gameTime);
        }

        public void songSelection()
        {
                        //let user choose songs whilst the player is active:
            if (player1.Active)
            {
                //Default playlist: (1 = easy song, 2 = medium, 3 and 4 = hard).
                if (myInput.currentKeyboardState.IsKeyDown(Keys.D1) && currentSongName != mySound.gameplayMusic1Name)
                {                    
                    prepareForNewGame();
                    mySound.PlayMusic(mySound.gameplayMusic1, false);
                    currentSongName = mySound.CurrentSongName;
                }
                if (myInput.currentKeyboardState.IsKeyDown(Keys.D2) && currentSongName != mySound.gameplayMusic2Name)
                {
                    prepareForNewGame();
                    mySound.PlayMusic(mySound.gameplayMusic2, false);
                    currentSongName = mySound.CurrentSongName;
                }
                if (myInput.currentKeyboardState.IsKeyDown(Keys.D3) && currentSongName != mySound.gameplayMusic3Name)
                {
                    prepareForNewGame();
                    mySound.PlayMusic(mySound.gameplayMusic3, false);
                    currentSongName = mySound.CurrentSongName;
                }
                if (myInput.currentKeyboardState.IsKeyDown(Keys.D4) && currentSongName != mySound.gameplayMusic4Name)
                {
                    prepareForNewGame();
                    mySound.PlayMusic(mySound.gameplayMusic4, false); //play default song 4
                    currentSongName = mySound.CurrentSongName; //update current song name
                }

                //user select song:
                if (myInput.currentKeyboardState.IsKeyDown(Keys.D5))
                {
                    //Exit full screen mode  
                    graphics.ToggleFullScreen();

                    //initalise user input for playing a song from their own media:     
                    mySound.stopPlayingMusic(); //Stop the current song

                    prepareForNewGame();

                    //NEW IMPROVED WINDOWS DIALOGUE METHOD:
                    inputText = OpenFile.getFileName(); //Use a static open dialoge method. 
                    string[] words = inputText.Split('\\');                    
                    string songName = words[words.Count()-1];                    

                    //Return to full screen
                    graphics.ToggleFullScreen();

                    /*
                    //wait 2 seconds whilst full screen is reattained, before playing the song. 
                    Thread.Sleep(2000); // Sleep the current thread for 2 seconds.

                    //Then play the song. 
                    mySound.playSongFromURI("Sweep", "C:\\Users\\Steve\\Desktop\\sweep.mp3");
                    currentSongName = mySound.CurrentSongName;
                     */

                    /*
                    mySound.playSongFromURI("Sweep", "C:\\Users\\Steve\\Desktop\\sweep.mp3");
                    currentSongName = mySound.CurrentSongName;

                    // TODO: Add your drawing code here
                    spriteBatch.Begin();
                    spriteBatch.DrawString(font, "SUCCESS! YOU ROCK! Press the Enter Key to return to the menu!",
                    new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X + 425, GraphicsDevice.Viewport.TitleSafeArea.Y + 625), Color.DarkRed);
                    spriteBatch.End();

                    //wait for the duration of the sample, whilst full screen is reattained, before playing the song. 
                    Thread.Sleep(2000); // Sleep the current thread for 2 seconds.
                     * */

                    //Then play the song. 
                    mySound.playSongFromURI(songName, inputText);
                    currentSongName = mySound.CurrentSongName;
                }
            }
        }

        //Move this to the background vis class!?
        public void updateBackVisColours()
        {
            backgroundVis.colourFade(increasing, x);

            //update all colour arrays with new colours:
            //Colours for a low responce
            audioVisColourArray1[0] = new Color(0, x[0], x[0]);
            audioVisColourArray1[1] = new Color(x[0], x[0], 0);
            //Colours for a medium responce
            audioVisColourArray2[0] = new Color(x[4], x[1], 0);
            audioVisColourArray2[1] = new Color(0, x[1], x[4]);
            //Colours for a high responce
            audioVisColourArray3[0] = new Color(x[2], 0, x[3]);
            audioVisColourArray3[1] = new Color(x[3], 0, x[2]);            
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// EDIT THE DRAW CALL TO LAYER TEXTURES DIFFERENTLY ******************************
        protected override void Draw(GameTime gameTime)
        {
            //Draw items in the order that they should be layered. e.g.
            //Items drawn first will be covered by items drawn second and so on. 
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            //draw the background image first:
            //spriteBatch.Draw(backgroundImg, mainFrame, Color.White);

            // Draw the Enemies - ontop of background, but below projectiles and player.
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].Draw(spriteBatch);
            }

            //Draw particles here (ontop of enemies, but below projectiles and player) =].
            if (player1.Active) //dont draw the player's particle trail, projectiles or player if they're dead
            {
                //if the track has finished, and the player has a score greater than 0. 
                //(Because the track will be stopped when the player is choosing a song)
                if (mySound.getMediaPlayerState() == MediaState.Stopped && score > 0)
                {
                    for (int i = 0; i < enemies.Count; i++)
                        enemies[i].Active = false; //Blow up all left over enemies, giving the player the extra score!

                    if (win) { mySound.success.Play(); win = false; } //Player success sound effect once per win.

                    spriteBatch.DrawString(font, "SUCCESS! YOU ROCK! Press the Enter Key to return to the menu!",
                    new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X + 425, GraphicsDevice.Viewport.TitleSafeArea.Y + 625), Color.DarkRed);                    
                }

                particleEngineTrail.Draw(spriteBatch);

                // Draw the Projectiles (Ontop of background but below the player)
                for (int i = 0; i < projectiles.Count; i++)
                {
                    projectiles[i].Draw(spriteBatch);
                    //projectiles[i].Rotation = GetRotation(mousePosition);
                }

                // The player draws itself (Unless it's dead (e.g. active == false))
                player1.Draw(spriteBatch);
            }

            for (int i = 0; i < particleEngineExplosions.Count; i++)
            {
                //particleEngineExplosion[i].EmitterLocation = enemies[i].Position;
                //particleEngineExplosion[i].Draw(spriteBatch);
                particleEngineExplosions[i].Draw(spriteBatch);
            }

            //Draw the score and HP:
            // Draw the high score
            spriteBatch.DrawString(font, "Best Score: " + highscore,
                new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X, GraphicsDevice.Viewport.TitleSafeArea.Y), Color.Yellow);
            //Draw the best enemy kill count
            spriteBatch.DrawString(font, "Best Enemy Kill Count: " + highkillcount,
                new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X, GraphicsDevice.Viewport.TitleSafeArea.Y + 20), Color.Yellow);
            // Draw the score
            spriteBatch.DrawString(font, "Score: " + score, 
                new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X, GraphicsDevice.Viewport.TitleSafeArea.Y + 40), Color.White);
            //Draw the enemy kill count
            spriteBatch.DrawString(font, "Enemy Kill Count: " + killcount,
                new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X, GraphicsDevice.Viewport.TitleSafeArea.Y + 60), Color.White);

            //Draw the enemy level:
            spriteBatch.DrawString(font, "Enemy Level: " + enemyLevel,
                new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X, GraphicsDevice.Viewport.TitleSafeArea.Y + 100), Color.Gray);
            //Draw the enemies score value:
            spriteBatch.DrawString(font, "Enemy Score Value:" + enemyScoreValue,
                new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X, GraphicsDevice.Viewport.TitleSafeArea.Y + 120), Color.Gray);
            //Draw the enemy HP
            spriteBatch.DrawString(font, "Enemy HP:" + enemyHealth,
                new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X, GraphicsDevice.Viewport.TitleSafeArea.Y + 140), Color.Gray);

            //Draw the player power level:
            spriteBatch.DrawString(font, "Player Power Level: " + powerLevel,
                new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X, GraphicsDevice.Viewport.TitleSafeArea.Y + 180), Color.PowderBlue);
            // Draw the player health
            if (player1.Health <= 100 && player1.Health >= 70)
            spriteBatch.DrawString(font, "Player Health: " + player1.Health, 
                new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X, GraphicsDevice.Viewport.TitleSafeArea.Y + 200), Color.Green);
            else if (player1.Health < 70 && player1.Health >= 40)
            spriteBatch.DrawString(font, "Player Health: " + player1.Health,
                new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X, GraphicsDevice.Viewport.TitleSafeArea.Y + 200), Color.Yellow);
            else if (player1.Health < 40)
                spriteBatch.DrawString(font, "Player Health: " + player1.Health,
                    new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X, GraphicsDevice.Viewport.TitleSafeArea.Y + 200), Color.Red);

            
            if (displayStatistics)
            {
                //Audio Statistics:
                spriteBatch.DrawString(font, "AUDIO STATISTICS:",
                    new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X, GraphicsDevice.Viewport.TitleSafeArea.Y + 240), Color.White);
                //Media player state:
                spriteBatch.DrawString(font, "Media Player State: " + mySound.getMediaPlayerState(),
                    new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X, GraphicsDevice.Viewport.TitleSafeArea.Y + 260), Color.White);
                //Draw the low freqency current average
                spriteBatch.DrawString(font, "Low Frq Amplitude Avg: " + audioAnalysis.LowFrBandAverage,
                    new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X, GraphicsDevice.Viewport.TitleSafeArea.Y + 280), Color.White);
                //Draw the mid freqency current average
                spriteBatch.DrawString(font, "Mid Frq Amplitude Avg: " + audioAnalysis.MidFrBandAverage,
                    new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X, GraphicsDevice.Viewport.TitleSafeArea.Y + 300), Color.White);
                //Draw the high freqency current average
                spriteBatch.DrawString(font, "High Frq Amplitude Avg: " + audioAnalysis.HighFrBandAverage,
                    new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X, GraphicsDevice.Viewport.TitleSafeArea.Y + 320), Color.White);
                //Draw background colour:
                spriteBatch.DrawString(font, "getColour_6StepHighFrq(...) -> Background Colour (High Frq): " + 
                    audioAnalysis.getColour_6StepHighFrq(backgroundColour1, backgroundColour2, backgroundColour3, backgroundColour4, backgroundColour5, backgroundColour6,
                0.2f, 0.25f, 0.3f, 0.35f, 0.4f),
                    new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X, GraphicsDevice.Viewport.TitleSafeArea.Y + 340), Color.White);
                //Draw Trail / Explosion Colour
                spriteBatch.DrawString(font, "getColour_3StepLowFrq(...) -> Trail / Explosion Colour (Low Frq): " + audioAnalysis.getColour_3StepLowFrq(audioVisColourArray1[1], audioVisColourArray2[1], audioVisColourArray3[1], 0.4f, 0.54f),
                    new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X, GraphicsDevice.Viewport.TitleSafeArea.Y + 360), Color.White);
                
                //Draw background vis colours
                Color[] tempArray = new Color[2];
                tempArray = audioAnalysis.getColourArray_3StepLowFrq(audioVisColourArray1, audioVisColourArray2, audioVisColourArray3, 0.4f, 0.54f);
                spriteBatch.DrawString(font, "getColourArray_3StepLowFrq(...) -> Background Vis Colours (Low Frq):",
                    new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X, GraphicsDevice.Viewport.TitleSafeArea.Y + 380), Color.White);
                spriteBatch.DrawString(font, "Top: " + tempArray[0],
                    new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X, GraphicsDevice.Viewport.TitleSafeArea.Y + 400), Color.White);
                spriteBatch.DrawString(font, "Bottom: " + tempArray[1],
                    new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X, GraphicsDevice.Viewport.TitleSafeArea.Y + 420), Color.White);
                
                //Draw the particle trail speed
                spriteBatch.DrawString(font, "getVector2_3StepLowFrq(...) -> Particle Trail Velocity: " + audioAnalysis.getVector2_3StepLowFrq(minParticleTrailVelocity, midParticleTrailVelocity, maxParticleTrailVelocity, 0.4f, 0.54f),
                    new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X, GraphicsDevice.Viewport.TitleSafeArea.Y + 440), Color.White);
                //Draw the particle explosion speed
                spriteBatch.DrawString(font, "getVector2_3StepLowFrq(...) -> Particle Explosion Velocity: " + audioAnalysis.getVector2_3StepLowFrq(minParticleExplosionVelocity, midParticleExplosionVelocity, maxParticleExplosionVelocity, 0.4f, 0.54f),
                    new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X, GraphicsDevice.Viewport.TitleSafeArea.Y + 460), Color.White);
                //Draw the player movement speed
                spriteBatch.DrawString(font, "getFloat_6StepLowFrq(...) -> Player Movement Speed: " + audioAnalysis.getFloat_6StepLowFrq(1.0f, 9.0f, 0.1f, 0.2f, 0.3f, 0.4f, 0.54f),
                    new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X, GraphicsDevice.Viewport.TitleSafeArea.Y + 480), Color.White);
                //Draw the player fire rate
                spriteBatch.DrawString(font, "getTimeSpan_3StepLowFrq(...) -> Player Fire Rate: " + audioAnalysis.getTimeSpan_3StepLowFrq(minFireRateInterval, midFireRateInterval, maxFireRateInterval, 0.4f, 0.54f),
                    new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X, GraphicsDevice.Viewport.TitleSafeArea.Y + 500), Color.White);                
                //Draw the enemy movement speed
                spriteBatch.DrawString(font, "getFloat_2StepLowFrq(...) -> Enemy Movement Speed: " + audioAnalysis.getFloat_2StepLowFrq(0.9f, 4.5f, 0.45f),
                    new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X, GraphicsDevice.Viewport.TitleSafeArea.Y + 520), Color.White);
                //Draw the enemy spawn rate
                spriteBatch.DrawString(font, "getTimeSpan_3StepLowFrq(...) -> Enemy Spawn Rate: " + audioAnalysis.getTimeSpan_3StepLowFrq(minSpawnTimeInterval, midSpawnTimeInterval, maxSpawnTimeInterval, 0.4f, 0.54f),
                    new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X, GraphicsDevice.Viewport.TitleSafeArea.Y + 540), Color.White);
                //draw the enemy scale
                spriteBatch.DrawString(font, "getFloat_6StepMidFrq(...) -> Enemy Animation Scale: " + audioAnalysis.getFloat_6StepMidFrq(0.75f, 2f, 0.2f, 0.3f, 0.4f, 0.5f, 0.64f),
                    new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X, GraphicsDevice.Viewport.TitleSafeArea.Y + 560), Color.White);
                //Extra functions not used in the game, but avaliable:
                spriteBatch.DrawString(font, "Other function Examples:",
                    new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X, GraphicsDevice.Viewport.TitleSafeArea.Y + 600), Color.SlateGray);
                //draw estimated intensity - to show off the getString capabilities. 
                spriteBatch.DrawString(font, "getString_6StepLowFrq(...) -> Estimated Game Intensity: " + audioAnalysis.getString_6StepLowFrq("Very low", "Low", "Low-Medium", "Medium", "High", "Insane", 0.1f, 0.2f, 0.3f, 0.4f, 0.54f),
                    new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X, GraphicsDevice.Viewport.TitleSafeArea.Y + 620), Color.SlateGray);
                //draw estimated intensity - to show off the getInt capabilities. 
                spriteBatch.DrawString(font, "getInt_6StepLowFrq(1 to 6) -> Estimated Game Intensity: " + audioAnalysis.getInt_6StepLowFrq(1, 6, 0.1f, 0.2f, 0.3f, 0.4f, 0.54f),
                    new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X, GraphicsDevice.Viewport.TitleSafeArea.Y + 640), Color.SlateGray);
                //draw true / false - to show off the getBool capabilities  
                spriteBatch.DrawString(font, "getBool_2StepLowFrq(...) -> Return true above 0.54f: " + audioAnalysis.getBool_2StepLowFrq(0.54f),
                    new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X, GraphicsDevice.Viewport.TitleSafeArea.Y + 660), Color.SlateGray);
            }
            

            // Draw the current song name
            spriteBatch.DrawString(font, "Song Name: " + currentSongName,
                new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X+425, GraphicsDevice.Viewport.TitleSafeArea.Y), Color.Purple);
            //if the media player is currently not playing a song, display how to choose from the default play list:
            if (currentSongName == "Nothing playing" || currentSongName == "Error: Cannot open this song.")
            {
                spriteBatch.DrawString(font, "Pick a song by pressing 1, 2, 3, 4 or 5 on your keyboard.",
                    new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X + 425, GraphicsDevice.Viewport.TitleSafeArea.Y + 300), Color.Purple);
                spriteBatch.DrawString(font, "Selecting 1 to 4 will pick one of the default songs.",
                    new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X + 425, GraphicsDevice.Viewport.TitleSafeArea.Y + 320), Color.Purple);
                spriteBatch.DrawString(font, "Difficulty: 1 = easy, 2 = medium, 3 = hard, 4 = harder.",
                    new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X + 425, GraphicsDevice.Viewport.TitleSafeArea.Y + 340), Color.Purple);
                spriteBatch.DrawString(font, "Selecting 5 will allow you to choose from your own media library!",
                    new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X + 425, GraphicsDevice.Viewport.TitleSafeArea.Y + 380), Color.Red);
                spriteBatch.DrawString(font, "(When your song finishes press the Enter key to return to the menu.)",
                    new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X + 425, GraphicsDevice.Viewport.TitleSafeArea.Y + 420), Color.WhiteSmoke);
                spriteBatch.DrawString(font, "(Press ESC to exit, and F1 / F2 to toggle displaying audio analysis statistics.)",
                    new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X + 425, GraphicsDevice.Viewport.TitleSafeArea.Y + 440), Color.WhiteSmoke);
            }
            
            if (!player1.Active) //if the player is dead, draw the game over text:
            spriteBatch.DrawString(font, "GAME OVER! Press the Enter Key to Retry!",
                new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X + 425, GraphicsDevice.Viewport.TitleSafeArea.Y + 625), Color.DarkRed);

            //background visulisation:
            backgroundVis.BackgroundColor = audioAnalysis.getColour_6StepHighFrq(backgroundColour1, backgroundColour2, backgroundColour3, backgroundColour4, backgroundColour5, backgroundColour6,
                0.2f, 0.25f, 0.3f, 0.35f, 0.4f); //update the background colour
            backgroundVis.Draw2(GraphicsDevice, 0.1, backVisColourArray); //draw the visulisations

            //Test string:            
            //String text = "This is a properly implemented word wrapped sentence in XNA using SpriteFont.MeasureString. A B C D E F G H I J K L M N O P Q R S T U V W X Y Z a b c d e f g h i j k l m n o p q r s t u v w x y z";
            //spriteBatch.DrawString(font, parseText(text), new Vector2(textBox.X, textBox.Y), Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        //Update projectile!
        private void UpdateProjectiles()
        {          
            // Update the Projectiles
            for (int i = projectiles.Count - 1; i >= 0; i--)
            {
                projectiles[i].Update();

                if (projectiles[i].Active == false)
                {
                    projectiles.RemoveAt(i);
                }
            }
        }

        //UPDATE ENEMIES - Handled by the game as this includes creating new instances of the enemy class - so cannot be self contained within the enemy class. 
        private void UpdateEnemies(GameTime gameTime)
        {
            //Spawn a new enemy enemy every 0.5 seconds --> According to the enemySpawnTime variable! 
            //Player must also be active, if the player is dead enmies will stop spawning. 
            if (gameTime.TotalGameTime - previousSpawnTime > enemySpawnTime && player1.Active)
            {
                previousSpawnTime = gameTime.TotalGameTime;                

                // Add an Enemy if the game isnt over. 
                AddEnemy();                    
            }
            
            // Update the Enemies
            for (int i = enemies.Count - 1; i >= 0; i--)
            {
                //dynamically change enemy movement speed:
                enemies[i].enemyMoveSpeed = audioAnalysis.getFloat_2StepLowFrq(0.9f, 4.5f, 0.45f); //getFloat_6StepLowFrq(0.9f, 4.5f, 999f, 999f, 999f, 999f, 0.45f)

                enemies[i].EnemyAnimation.Scale = audioAnalysis.getFloat_6StepMidFrq(0.75f, 2f, 0.2f, 0.3f, 0.4f, 0.5f, 0.64f);

                //update enemy //(Could check for enemy collision detection and make them move away)
                enemies[i].Update(gameTime, player1.GetDirection(enemies[i].Position, player1.Position));

                if (enemies[i].Active == false)
                {
                    //Add 1 to the kill count
                    killcount += 1;
                    if (player1.Active) { setupPowerups(); } //if the player isnt dead.

                    /* Instead of adding an explosion animation when an enemy dies - I will try adding a particle effect */
                    AddExplosion(enemies[i].Position); //sends enemies position to the AddExplosion function!

                    //play explosion sound effect here - i think ;).
                    mySound.explosionSound.Play(0.25f, 0.0f, 0.0f);

                    //Add to the player's score
                    score += enemies[i].Value;

                    //particleEngineExplosion[i].EmitterLocation = enemies[i].Position;                    
                    enemies.RemoveAt(i);                   
                }
            }
        }//END UPDATE

        //ADD ENEMY
        private void AddEnemy()
        {
            // Create the animation object
            Animation enemyAnimation = new Animation();

            // Initialize the animation with the correct animation information
            enemyAnimation.Initialize(enemyTexture, Vector2.Zero, 25, 25, 20, 30, Color.White, 1f, true);

            //Randomly generate enemys anywhere on the sceen within the viewport boundries:
            Vector2 position = new Vector2(random.Next(0, GraphicsDevice.Viewport.Width - enemyAnimation.FrameWidth), random.Next(0, GraphicsDevice.Viewport.Height - enemyAnimation.FrameHeight));
            //Create a new collision detection method in the collision detection class to make sure enemies dont spawn on the player. 
            //Vector2 position = new Vector2(100,100);
            position = collisionDetection.checkAndCorrectSpawnCollision(player1, enemyTexture, position, GraphicsDevice, enemyAnimation); //check spawn position isnt ontop of the player, and if it is move the spawn position.
            // Create an enemy
            Enemy enemy = new Enemy();

                enemy.Initialize(enemyAnimation, position, 1f);

            // Add the enemy to the active enemies list
            enemies.Add(enemy);
        }//END ADD ENEMY

        //Add explosion: -- This almost must be handled by the game - as this method creates new objects of the particleEngine...
        private void AddExplosion(Vector2 position)
        {
            //Use the pre-loaded particle textures to create a particle explosion at enemies location.  
            explosion = new ParticleEngine(textures, position); //assigns the explosion to the global variable explosion. 
            particleEngineExplosions.Add(explosion);
        }

        //UPDATE EXPLOSIONS -- This could be moved to the particleEngine class <---- ???? **********************************************
        private void UpdateExplosions(GameTime gameTime)
        {
            //For all current particle Engine Explosions:
            for (int i = particleEngineExplosions.Count - 1; i >= 0; i--)
            {

                //before updating the particles though the particle engine, update the veloicty dynamically:
                particleEngineExplosions[i].currentExplosionVeloicty = audioAnalysis.getVector2_3StepLowFrq(minParticleExplosionVelocity, midParticleExplosionVelocity, maxParticleExplosionVelocity, 0.4f, 0.54f);
                //particleEngineExplosions[i].currentExplosionVeloicty = audioAnalysis.getVector2_6StepLowFrq(minParticleExplosionVelocity, minParticleExplosionVelocity, minParticleExplosionVelocity, minParticleExplosionVelocity, midParticleExplosionVelocity, maxParticleExplosionVelocity,
                //    999f, 999f, 999f, 0.4f, 0.54f);
                //Send the particle engine for explosions the AAC chosen colour for the current sample. The AAC receives parameters of 3 single colour values. (Same as the background vis)
                particleEngineExplosions[i].currentColour = audioAnalysis.getColour_3StepLowFrq(audioVisColourArray1[1], audioVisColourArray2[1], audioVisColourArray3[1], 0.4f, 0.54f);

                //check if the explosion effect should be removed from the list, because it has finished and the particles have diminished.
                if (particleEngineExplosions[i].UpdateExplosion() <= -100000) //this gives each explosion enough time to update so that all particles die naturally.
                {                                                            //this number should be tuned to increase performence
                    particleEngineExplosions.RemoveAt(i);
                }
            }
        }

        private void updateHighScoreKillcount()
        {
            if (score > highscore)
            { highscore = score; }
            
            if (killcount > highkillcount)
            { highkillcount = killcount; }

            score = 0;
            killcount = 0;
        }

        private void setupPowerups()
        {
            if (killcount >= 100 && killcount < 199) { enemyHealth = enemiesLevelUp(20); enemyScoreValue = setEnemiesScoreValue(200); enemyLevel = "1"; }//DOUBLE ENEMY HP and Score Value
            if (killcount >= 100 && powerup[0] == false) //Power up!
            {
                //Play "POWER UP" sound effect
                mySound.powerup.Play();
                //Power up the player.
                powerup[0] = true;
                powerLevel = "1";                  
            }
            else if (killcount >= 200 && killcount < 299) { enemyHealth = enemiesLevelUp(30); enemyScoreValue = setEnemiesScoreValue(320); enemyLevel = "2"; }//TRIPLE ENEMY HP and more than triple score value.
            if (killcount >= 200 && powerup[1] == false) //Power up!
            {
                //Play "POWER UP" sound effect
                mySound.powerup.Play();
                //Power up the player.
                powerup[1] = true;
                powerLevel = "2";
            }
            else if (killcount >= 300 && killcount < 399) { enemyHealth = enemiesLevelUp(40); enemyScoreValue = setEnemiesScoreValue(450); enemyLevel = "3"; }//QUADRUPLE ENEMY HP
            if (killcount >= 300 && powerup[2] == false) //Power up!
            {
                //Play "POWER UP" sound effect
                mySound.powerup.Play();
                //Power up the player.
                powerup[2] = true;
                powerLevel = "3";
            }
            else if (killcount >= 500 && killcount < 599) { enemyHealth = enemiesLevelUp(50); enemyScoreValue = setEnemiesScoreValue(600); enemyLevel = "4"; }//QUINTUPLE ENEMY HP
            if (killcount >= 500 && powerup[3] == false) //Power up!
            {
                //Play "POWER UP" sound effect
                mySound.powerup.Play();
                //Power up the player.
                powerup[3] = true;
                powerLevel = "MAX";
                //Buff the fire rate for ultimate level powerup:
                minFireRateInterval = 0.03f;
                midFireRateInterval = 0.90f;
            }
            else if (killcount >= 600 && killcount < 699) { enemyHealth = enemiesLevelUp(60); enemyScoreValue = setEnemiesScoreValue(800); enemyLevel = "5"; }
            else if (killcount >= 700 && killcount < 799) { enemyHealth = enemiesLevelUp(70); enemyScoreValue = setEnemiesScoreValue(1200); enemyLevel = "6"; }
            else if (killcount >= 800 && killcount < 899) { enemyHealth = enemiesLevelUp(80); enemyScoreValue = setEnemiesScoreValue(1500); enemyLevel = "7"; }
            else if (killcount >= 900 && killcount < 999) { enemyHealth = enemiesLevelUp(90); enemyScoreValue = setEnemiesScoreValue(2000); enemyLevel = "8"; }
            else if (killcount >= 1000 && killcount < 1999) { enemyHealth = enemiesLevelUp(100); enemyScoreValue = setEnemiesScoreValue(2500); enemyLevel = "9"; }
            else if (killcount >= 2000) { enemyHealth = enemiesLevelUp(150); enemyScoreValue = setEnemiesScoreValue(5000); enemyLevel = "MAX"; }
        }

        public void prepareForNewGame()
        {
            enemies.Clear(); //Remove all enemies from the list.            
            
            //set all powerups to false by default
            for (int i = 0; i < 10; i++)
            {
                powerup[i] = false;
            } powerLevel = "0";

            enemyLevel = "0"; //reset enemy level
            enemyHealth = enemiesLevelUp(10); //reset enemy health back to default. 
            enemyScoreValue = setEnemiesScoreValue(100); //reset enemy score value back to default

            win = true; //set win back to true, ready for the player to win.. hopefully ;). 

            player1.Active = true; player1.Health = 100;
            updateHighScoreKillcount(); //update high score and high kill count, then clear score and killcount to zero.
        }

        public int enemiesLevelUp(int health)
        {
            for (int i = 0; i < enemies.Count; i++)
                enemies[i].Health = health;

            return health;
        }

        public int setEnemiesScoreValue(int value)
        {
            for (int i = 0; i < enemies.Count; i++)
                enemies[i].Value = value;

            return value;
        }


        /// <summary>
        /// Some extra user guide stuff below:
        /// </summary>

        public void manuallySetValues()
        {
            /*Override the "audioAnalysis.updateAverageLowFrequencyData()" method,
            setting the low frequency average amplitude manually to 0.9f*/
            audioAnalysis.LowFrBandAverage = 0.9f;

            /*Override the "audioAnalysis.updateAverageMidFrequencyData()" method,
            setting the mid frequency average amplitude manually to 0.1337f*/
            audioAnalysis.MidFrBandAverage = 0.1337f;

            /*Override the "audioAnalysis.updateAverageHighFrequencyData()" method,
            setting the high frequency average amplitude manually to 0.0f*/
            audioAnalysis.HighFrBandAverage = 0.0f;
        }

        public void getAverageAmplitudes()
        {
            float averageLowFrequencyAmplitude;
            float averageMidFrequencyAmplitude;
            float averageHighFrequencyAmplitude;

            /*Get the current average low frequency amplitude from the audio analysis class
            and store it inside the "averageLowFrequencyAmplitude" variable */
            averageLowFrequencyAmplitude = audioAnalysis.LowFrBandAverage;
            /*Get the current average mid frequency amplitude from the audio analysis class
            and store it inside the "averageMidFrequencyAmplitude" variable */
            averageMidFrequencyAmplitude = audioAnalysis.MidFrBandAverage;
            /*Get the current average low frequency amplitude from the audio analysis class
            and store it inside the "averageLowFrequencyAmplitude" variable */
            averageHighFrequencyAmplitude = audioAnalysis.HighFrBandAverage;

            Console.WriteLine("Low Frq Average: " + averageLowFrequencyAmplitude);
            Console.WriteLine("Mid Frq Average: " + averageMidFrequencyAmplitude);
            Console.WriteLine("High Frq Average: " + averageHighFrequencyAmplitude);
        }

        public double getAudioDynamicDoubleMidFrequency(double minDouble, double maxDouble,
            float min)
        {
            /*If the min parameter is exceeded by the get value of the average amplitude 
            of the mid frequency band return the maxDouble. Otherwise return minDouble.*/
            if (audioAnalysis.MidFrBandAverage > min)
                return maxDouble;

            return minDouble;   
        }
    }
}
