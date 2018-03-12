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

namespace PasswordChecker
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

        private void PasswordInputBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            int[] charCounts = new int[5];
            charCounts[0] = PasswordInputBox.Password.Length;
            charCounts[1] = PasswordInputBox.Password.Count(char.IsUpper);
            charCounts[2] = PasswordInputBox.Password.Count(char.IsLower);
            charCounts[3] = PasswordInputBox.Password.Count(char.IsNumber);
            charCounts[4] = charCounts[0] - (charCounts[1] + charCounts[2] + charCounts[3]);

            ResultCharcount.Text = "Characters: " + charCounts[0];
            ResultUpper.Text = "Uppercase letters: " + charCounts[1];
            ResultLower.Text = "Lowercase letters: " + charCounts[2];
            ResultNumbers.Text = "Numbers: " + charCounts[3];
            ResultSpecial.Text = "Special characters: " + charCounts[4];

            int catCount = 0;
            for (int i = 1; i < charCounts.Length; i++)
            {
                if (charCounts[i] > 0) catCount++;
            }

            if (charCounts[0] == 0)
            {
                ResultLabel.Content = "Enter password";
                ResultLabel.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFDEDEDE"));
            }
            else if (charCounts[0] > 15 && catCount == 4)
            {
                ResultLabel.Content = "Good";
                ResultLabel.Background = new SolidColorBrush(Colors.LightGreen);
            }
            else if (charCounts[0] >= 12 && catCount >= 3)
            {
                ResultLabel.Content = "Moderate";
                ResultLabel.Background = new SolidColorBrush(Colors.LightBlue);
            }
            else if (charCounts[0] >= 8 && catCount >= 2)
            {
                ResultLabel.Content = "Fair";
                ResultLabel.Background = new SolidColorBrush(Colors.Yellow);
            }
            else
            {
                ResultLabel.Content = "Bad";
                ResultLabel.Background = new SolidColorBrush(Colors.Salmon);
            }
        }
    }
}
