﻿using System;
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
using System.Windows.Shapes;

namespace Project_Polished_Version
{
    /// <summary>
    /// Interaction logic for App_Intro_Window.xaml
    /// </summary>
    public partial class App_Intro_Window : Window
    {
        public App_Intro_Window()
        {
            InitializeComponent();
        }

        private void GetStartedButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow nextWindow = new MainWindow(); // Replace with your window class name
            nextWindow.Show();

            // Optionally, you can hide the current window if needed:
            this.Hide(); // Hides the current window
        }
    }
}
