using AppForTest.PlayerHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppForTest.ViewModels
{
    public class MetronomePageViewModel
    {
        private Metronome metronome = new Metronome();
        public int Bpm { get; set; }
        public MetronomePageViewModel()
        {
            metronome.Subdivision = 4;
            metronome.Timesignature = 4;
        }

        public void SetTimesignature(string action)
        {
            switch (action)
            {
                case "4/4":
                    metronome.Timesignature = 4;
                    break;
                case "8/4":
                    metronome.Timesignature = 8;
                    break;

            }
        }

        public void SetSubdivision(string action)
        {
            switch (action)
            {
                case "4th":
                    metronome.Subdivision = 4;
                    break;
                case "8th":
                    metronome.Subdivision = 8;
                    break;
            }
        }
        public void SetupAndStartMetronome(int beatsPerMin)
        {
            metronome.MetronomeSetup();
            int bpmInMilliseconds = metronome.BpmToMilliseconds(beatsPerMin);
            metronome.StartClicking(bpmInMilliseconds);
        }

        public void StopMetronome()
        {
            metronome.StopClicking();
        }
    }
}
