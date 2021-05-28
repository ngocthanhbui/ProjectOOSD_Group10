using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("In this example we assume that the audio will automatically play music when open app " +
                "\n(in real app we will have the variable audiostatus to check that)" +
                "\n=============================\n");
            Console.WriteLine("First Time(when open app): turn off music when audio is play music");
            bool audiostatus = true;
            MusicManager.getInstance().PlayMusic(false, audiostatus);
            Console.WriteLine("\nSecond Time: turn on music when audio is off");
            audiostatus = false;
            MusicManager.getInstance().PlayMusic(true, audiostatus);
            Console.WriteLine("\nThird Time: turn on music when audio is play music)");
            audiostatus = true;
            MusicManager.getInstance().PlayMusic(true, audiostatus);
            Console.WriteLine("\n\nWe just use one instance to manage music sound.");
        } 
    }

    public class MusicManager
    {
        private static MusicManager instance;

        //private bool audioSource; //=true: isplaying, =false:is not playing (audioSource.isPlaying in Unity)
        private MusicManager()
        {
            Console.WriteLine("Singleton(): Initializing Instance");
        }

        public static MusicManager getInstance()
        {
            if (instance == null)
            {
                Console.WriteLine("getInstance(): First time getInstance was invoked!");
                instance = new MusicManager();
            }
            return instance;
        }

        public void PlayMusic(bool play, bool audioSource)
        {
            if (play == true)
            {
                if (audioSource == false)// audio is not playing
                {
                    //audioSource.Play();
                    Console.WriteLine("Music turn on ");
                }  
                else
                {
                    Console.WriteLine("Music already playing ");
                }    
            }
            else
            {
                if (audioSource == true) // audio is playing
                {
                    //audioSource.Stop();
                    Console.WriteLine("Music turn off");
                }
                else
                {
                    Console.WriteLine("Music already off ");
                }
            }
        }
    }
}
