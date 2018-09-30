using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;

namespace LinkClicker
{
    public partial class MainWindow
    {
        private readonly Stack<string> _links;

        public MainWindow()
        {
            InitializeComponent();
            _links = new Stack<string>(File.ReadAllText("links.txt").Replace("\r", "").Split('\n').Reverse());
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start(_links.Pop());
            }
            catch (Exception)
            {
                MessageBox.Show("Ссылки закончились! А если нет то проверь правильность ссылки =)");
            }
        }

        private void MainWindow_OnClosing(object sender, CancelEventArgs e)
        {
            var str = string.Empty;
            str = _links.ToArray().Aggregate(str, (current, s) => current + (s + "\r\n"));
            File.WriteAllText("links.txt", str);
        }
    }
}
