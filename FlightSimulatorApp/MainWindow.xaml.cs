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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Sockets;
using FlightSimulatorApp.Models;
using FlightSimulatorApp.ViewModels;
using FlightSimulatorApp.Views;


namespace FlightSimulatorApp
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
    {
        private FlightSimulatorViewModel vm;
		private ConnectWindow cw;
        private ManualControls manualControls;
        private Dashboard dashboard;
        private ConnectionMenu connectionMenu;
		public MainWindow()
		{
            InitializeComponent();
            vm = new FlightSimulatorViewModel(new FlightSimulatorModel(new MyTelnetClient()));
			DataContext = vm;
            connectionMenu = new ConnectionMenu();
            connectionMenu.DataContext = vm;
            //manualControls = new ManualControls();
            //dashboard = new Dashboard();
            //manualControls.DataContext = vm;
            //dashboard.DataContext = vm;

            //Joystick.MyEvent += SetXY;
            cw = new ConnectWindow(vm);
        }

        //private void SetXY(double x, double y)
        //{
        //    if (x > 1)
        //    {
        //        x = 1;
        //    } 
        //    else if (x < -1)
        //    {
        //        x = -1;
        //    }

        //    if (y > 1)
        //    {
        //        y = 1;
        //    }
        //    else if (y < -1)
        //    {
        //        y = -1;
        //    }
        //    vm.VM_Rudder = x;
        //    vm.VM_Elevator = y;
        //    RudderValue.Text = x.ToString();
        //    ElevatorValue.Text = y.ToString();
        //}

		private void Throttle_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{

		}

		private void Joystick_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        //      private void AileronSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        //      {
        //          AileronValue.Text = AileronSlider.Value.ToString("F" );
        //          Console.WriteLine(AileronSlider.Value.ToString());
        //          Console.WriteLine(sender.ToString());
        //      }

        //      private void ThrottleSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        //      {
        //          ThrottleValue.Text = ThrottleSlider.Value.ToString("F");
        //      }


        private void connect_Click(object sender, RoutedEventArgs e)
        {
            //connectWindow.Show();
            //this.vm.VM_ConnectWindow();
            cw.Show();
        }

        private void disconnect_Click(object sender, RoutedEventArgs e)
        {
            vm.VM_Disconnect();
        }
    }
}
