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

namespace PokerTimer
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            _controller = new MainController(Tournament.LoadData());
            DataContext = _controller.GetMain();
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
