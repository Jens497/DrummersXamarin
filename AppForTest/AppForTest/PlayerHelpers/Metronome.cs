using System;
using System.Threading;

namespace AppForTest.PlayerHelpers
{
    public class Metronome
    {
        private System.Threading.Timer timer;
        private Plugin.SimpleAudioPlayer.ISimpleAudioPlayer player;
        private Plugin.SimpleAudioPlayer.ISimpleAudioPlayer playerFirst;

        public int Timesignature { get; set; }
        public int Subdivision { get; set; }


        private int nodesPerBar;
        private int nodeCounter;

        public Metronome()
        {
            nodeCounter = 1;
            //This is possible since currently the metronome only supports subsubdivision of 4th notes
            nodesPerBar = 4;
            this.timer = new System.Threading.Timer(new TimerCallback(this.TimerCallback));
            var newPlayer = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player = newPlayer;
            
            playerFirst = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            playerFirst.Load("FirstHitInBar.wav");
            //var assembly = typeof(App).GetTypeInfo().Assembly;
            //Stream audioStream = assembly.GetManifestResourceStream("AppForTest.Resources.raw.MetronomeSound.wav");

            player.Load("MetronomeSound.wav");
            //player.Play();
        }

        public void StartClicking(int milliseconds)
        {
            this.timer.Change(0, milliseconds);
        }

        public void StopClicking()
        {
            this.timer.Change(-1, -1);
        }

        private void TimerCallback(object state)
        {
            //this.player.SoundLocation = "Metro2.wav";
            //this.player.PlaySync();
            if (nodeCounter == 1)
            {
                player.Load("FirstMetronome.wav");
                Console.WriteLine("Playing first node of bar");
                player.Play();
            }
            else
            {
                player.Load("MetrononeForApp.wav");
                Console.WriteLine("Playing normal click");
                player.Play();
            }

            if (nodeCounter == nodesPerBar)
                nodeCounter = 1;
            else
                nodeCounter++;
        }

        public int BpmToMilliseconds(int bpm)
        {
            // 1 min
            int calculateAsMilliseconds = 60000;
            return calculateAsMilliseconds / bpm;
        }

        public void MetronomeSetup()
        {
            //Cant be done in same line because:
            //If both are = 4, then they will both be 1 and it will be 1+1 then nodesPerBar will be 8 even thought it should be 4
            nodesPerBar *= Timesignature / nodesPerBar;
            nodesPerBar *= Subdivision / nodesPerBar;
            Console.WriteLine("This is the nodes per bar after setting it up:");
            Console.WriteLine(nodesPerBar);
        }
    }
}
