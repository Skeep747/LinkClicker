using System.Diagnostics;
using System.Windows;

namespace LinkClicker
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Process.Start("http://google.com");
        }
    }
}
