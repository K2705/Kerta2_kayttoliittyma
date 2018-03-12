using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AudioVideoPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonBrowse_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog open = new Microsoft.Win32.OpenFileDialog();
            open.Filter = "*Media files|*.mp4;*.mp3;*.avi";

            Nullable<bool> result = open.ShowDialog();
            if (result == true)
            {
                TextBoxPath.Text = open.FileName;
            }
        }

        private void ButtonPlay_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxPath.Text.Length > 0)
            {
                PlayWindow.Source = new Uri(TextBoxPath.Text);
                PlayWindow.Play();
            }
        }

        private void ButtonStop_Click(object sender, RoutedEventArgs e)
        {
            PlayWindow.Stop();
        }
    }
}
