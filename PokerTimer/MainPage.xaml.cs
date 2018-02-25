using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using PokerTimer.DataModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PokerTimer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
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
            AudioPlayer.Position = new TimeSpan(0, 0, 1);
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
