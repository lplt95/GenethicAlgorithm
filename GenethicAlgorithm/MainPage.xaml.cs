using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using GenethicAlgorithm.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GenethicAlgorithm
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private int genCount;
        private int population;
        private double muteCoef;
        private int loopCount = 0;
        private Chromosome[] chromeArray;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void StartProcedure()
        {
            chromeArray = new Chromosome[population];
            while(loopCount < 1000)
            {
                bool isFinished = false;
                //TODO: enter the logic
                if (isFinished)
                    break;
                else
                    loopCount++;                
            }
        }
        private void ShowResults()
        {

        }
        private void GeneratePopulation()
        {
            for(int i = 0; i < population; i++)
            {
                chromeArray[i] = new Chromosome(genCount);
            }
        }
    }
}
