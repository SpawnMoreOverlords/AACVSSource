using System;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;
using System.Reflection;

namespace FinalYearProject
{
    class Sound
    {

        //Sound effect / music variables:
        // The sound that is played when a laser is fired
        public SoundEffect laserSound;

        // The sound used when the player or an enemy dies
        public SoundEffect explosionSound;

        //powerup
        public SoundEffect powerup;

        //game over
        public SoundEffect gameOver;

        //success (you win)
        public SoundEffect success;

        //current song name:
        private String currentSongName = "Nothing playing";
        public String CurrentSongName
        {
            get { return currentSongName; }
        }

        // The music played during gameplay
        public Song gameplayMusic1; public String gameplayMusic1Name = "Est&sen - Dark Dubstep";
        public Song gameplayMusic2; public String gameplayMusic2Name = "Est&sen - Zup Troll";
        public Song gameplayMusic3; public String gameplayMusic3Name = "Feed Me Great Bicicle(Tojrov remix)";
        public Song gameplayMusic4; public String gameplayMusic4Name = "Est&sen - Liquid DnB";
        public Song gameOverMusic; public String gameOverMusicName = "27 - A Moment of Courtesy";

        public void loadAudioFiles(ContentManager content)
        {
            //Load the music and sound effects into the cpu
            // Load the music
            gameplayMusic1 = content.Load<Song>("EffectsAndMusic/Est&sen - Dark Dubstep");
            gameplayMusic2 = content.Load<Song>("EffectsAndMusic/Est&sen - Zup Troll");
            gameplayMusic3 = content.Load<Song>("EffectsAndMusic/Feed Me Great Bicicle(Tojrov remix)");
            gameplayMusic4 = content.Load<Song>("EffectsAndMusic/Est&sen - Liquid DnB");
            gameOverMusic = content.Load<Song>("EffectsAndMusic/27 - A Moment of Courtesy");
             

            // Load the laser and explosion sound effect
            laserSound = content.Load<SoundEffect>("EffectsAndMusic/laser_sound_effect");
            explosionSound = content.Load<SoundEffect>("EffectsAndMusic/explosion_sound_effect2");
            gameOver = content.Load<SoundEffect>("EffectsAndMusic/game_over");
            powerup = content.Load<SoundEffect>("EffectsAndMusic/powerup");
            success = content.Load<SoundEffect>("EffectsAndMusic/success");
        }

        //Play default music
        public void PlayMusic(Song song, bool repeating)
        {
            // catch any exceptions as music will play when the game is not tethered
            try
            {
                // Play the music
                MediaPlayer.Play(song);

                //get current song name:
                getCurrentSongName();

                // Loop the currently playing song
                MediaPlayer.IsRepeating = repeating;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
        }

        //Play user selected music!:
        public void playSongFromURI(String audioName, String URI)
        {
            // catch any exceptions as music will play when the game is not tethered
            try
            {
                /*Enable functionality to play songs that have path names with spaces in
                using reflection to get access to this internal constructor:
                "internal Song(string name, string filename, int duration);"
                */
                var ctor = typeof(Song).GetConstructor(
                BindingFlags.NonPublic | BindingFlags.Instance, null,
                new[] { typeof(string), typeof(string), typeof(int) }, null);
                //(This method doesnt fill in the duration property)
                //But it allows users to choose almost any of their music, so it's a well worthwhile
                //trade off in my opinion:
                Song song = (Song)ctor.Invoke(new object[] { audioName, @URI, 0 });

                currentSongName = audioName;

                // Play the music
                MediaPlayer.Play(song);

                // Loop the currently playing song
                MediaPlayer.IsRepeating = false;
            }
            //if there is an exception:
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                MediaPlayer.Stop(); //stop playing all music
                currentSongName = "Error: Cannot open this song."; //set current song name = nothing playing    
            }  
        }

        //Get current song name:
        private void getCurrentSongName()
        {
            currentSongName = null;

            if (MediaPlayer.State == MediaState.Playing)
            {
                currentSongName = MediaPlayer.Queue.ActiveSong.Name;

                string[] words = currentSongName.Split('\\');

                currentSongName = words[1];
            }
            else
                currentSongName = "Nothing playing";                
        }

        //stop playing music
        public void stopPlayingMusic()
        {
            MediaPlayer.Stop();
            currentSongName = "Nothing playing";   
        }

        //get media players current state
        public MediaState getMediaPlayerState()
        {
            return MediaPlayer.State;
        }

    }
}
