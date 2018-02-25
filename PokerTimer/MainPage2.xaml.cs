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
using PokerTimer.DataModels;
using WinRTXamlToolkit.Controls.DataVisualization.Charting;
using PokerTimer.ViewModels;

namespace PokerTimer
{
    public sealed partial class MainPage2 : Page
    {
        public MainPage2()
        {
            this.InitializeComponent();
            _controller = new MainController(Tournament.LoadData());
            var model = _controller.GetMain();
            DataContext = model;
            //(Pie.Series[0] as PieSeries).ItemsSource = model.TimePortions; doesn't update, adds legend and tooltip

            //updates but is very ugly just a line could overlay over a circle?
            //also nicer if I could bind directly and not call UpdateProgress
            //model.PropertyChanged += (obj, args) =>
            //{
            //    if (args.PropertyName == "PercentTimePassed")
            //        RoundProgress.UpdateProgress(model.PercentTimePassed);
            //};
        }

        private MainController _controller;
        
        private void AudioPlayer_MediaEnded(object sender, RoutedEventArgs e)
        {
            AudioPlayer.Position = new TimeSpan(0,0,1);
            AudioPlayer.Play();
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            //todo: navigate to a page where rounds can be configured
        }

        private void RestartTournament_Click(object sender, RoutedEventArgs e)
        {
            _controller.ResetTournament();
        }

        private void RestartRound_Click(object sender, RoutedEventArgs e)
        {
            _controller.ResetPeriod();
        }

        private void NextRound_Click(object sender, RoutedEventArgs e)
        {
            _controller.AdvancePeriod();
        }

        private void PauseResume_Click(object sender, RoutedEventArgs e)
        {
            _controller.TogglePause();
        }
    }
}
