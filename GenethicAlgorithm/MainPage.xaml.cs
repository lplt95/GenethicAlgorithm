using System;
using System.Globalization;
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
using GenethicAlgorithm.Methods;
using Windows.UI.Popups;
using Windows.ApplicationModel.Resources;

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
            GeneratePopulation();
            while(loopCount < 1000)
            {
                bool isFinished = false;
                var selectedList = Selection.SelectChrome(chromeArray);
                var newGeneration = Crossover.CrossoverChrome(selectedList);
                if(CalculateMutation())
                {
                    int whichChrome = SelectChrome(newGeneration);
                    Mutation.Mute(newGeneration, whichChrome);
                }
                isFinished = CheckForEnd(newGeneration);
                if (isFinished)
                    break;
                else
                    loopCount++;                
            }
            ShowResults();
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

        private void btStart_Click(object sender, RoutedEventArgs e)
        {
            bool pop, count, coef;
            pop = Int32.TryParse(txPopCount.Text, out population);
            count = Int32.TryParse(txGenCount.Text, out genCount);
            coef = Double.TryParse(txMuteCoef.Text, out muteCoef);
            if(!pop || !count || !coef)
            {
                throw new WrongFormatException();
            }
            StartProcedure();
        }
        private async void BeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            string fieldType = CheckFieldType(sender.Name);
            args.Cancel = IsCancelled(args.NewText, fieldType);
            if (args.Cancel)
            {
                string error = "Musisz wprowadzić liczbę";
                await new MessageDialog(error).ShowAsync();
            }
        }
        private bool IsCancelled(string textToCheck, string fieldType)
        {
            bool isCancelled = false;
            if (fieldType == "int")
            {
                isCancelled = textToCheck.Any(c => !char.IsDigit(c)) ? true : false;
            }
            else if (fieldType == "double")
            {
                if (textToCheck.Any(c => char.IsLetter(c)))
                {
                    isCancelled = true;
                    return isCancelled;
                }
                var decimalSign = NumberFormatInfo.CurrentInfo.NumberDecimalSeparator.ToCharArray();
                bool containsDecimal = textToCheck.Any(c => c == decimalSign[0]);
                if (containsDecimal)
                {
                    bool oneDot = textToCheck.Count(c => c == decimalSign[0]) != 1 ? false : true;
                    bool areDigits = textToCheck.Replace(decimalSign[0], '0').Any(c => char.IsDigit(c));
                    if (!oneDot || !areDigits) isCancelled = true;
                }
                else
                {
                    bool containsDigits = textToCheck.Any(c => !char.IsDigit(c));
                    if (containsDigits) isCancelled = true;
                }
            }
            else
            {
                throw new UnsupportedFormatException();
            }
            return isCancelled;
        }
        private string CheckFieldType(string fieldName)
        {
            var resourceLoader = new ResourceLoader();
            string type = resourceLoader.GetString(fieldName);
            return type;
        }
        private bool CalculateMutation()
        {
            bool mute = false;
            return mute;
        }
        private int SelectChrome(Chromosome[] listToSelect)
        {
            int whichChrome = new Random().Next(listToSelect.Length);
            return whichChrome;
        }
        private bool CheckForEnd(Chromosome[] chromeList)
        {
            bool isFinished = false;
            return isFinished;
        }
    }
}
