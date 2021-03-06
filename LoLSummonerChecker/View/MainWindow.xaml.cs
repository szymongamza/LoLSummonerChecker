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
using LoLSummonerChecker.Controller;
using LoLSummonerChecker.View;
using LoLSummonerChecker.View.ViewModel;

namespace LoLSummonerChecker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ControllerMain controller;
        ViewModelMain viewModel;

        public MainWindow()
        {
            controller = new ControllerMain();
            viewModel = new ViewModelMain();
            InitializeComponent();

            this.DataContext = viewModel;
        }

        private void ButtonSignUp_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(viewModel.Region))
                return;
            if (string.IsNullOrEmpty(viewModel.SummonerName))
                return;
            if(controller.GetSummoner(viewModel.SummonerName))
            {
                WindowProfile profile = new();
                profile.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Not found");
            }
        }
    }
}
