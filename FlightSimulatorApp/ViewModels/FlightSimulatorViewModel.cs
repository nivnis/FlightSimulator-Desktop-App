﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FlightSimulatorApp.Models;

namespace FlightSimulatorApp.ViewModels
{
    public class FlightSimulatorViewModel : BaseNotify
    {
        private FlightSimulatorModel flightSimulatorModel;
        private string ip, port;
        private bool errorWindowEmptyFlag = true;
        

        public FlightSimulatorViewModel(FlightSimulatorModel model)
        {
            flightSimulatorModel = model;
            flightSimulatorModel.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e) {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }

        public string VM_Ip { 
            set 
            {
                this.ip = value;
            }
        }
        public string VM_Port
        {
            set
            {
                this.port = value.ToString();
            }
        }

        public string VM_Status
        {
            get
            {          
                return flightSimulatorModel.Status;
            }
        }

        public string VM_Err
        {
            set
            {
                flightSimulatorModel.clearError();
                errorWindowEmptyFlag = true;
            }
            get
            {
                errorWindowEmptyFlag = false;
                return flightSimulatorModel.Err;              
            }
        }

        public bool VM_isErrorWindowEmpty
        {
            get
            {
                if(this.flightSimulatorModel.Err != null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
                
            }
        }





        public void VM_Connect()
        {
            flightSimulatorModel.Connect(ip, int.Parse(port));
            //await Task.Run(() => flightSimulatorModel.Connect(ip, int.Parse(port)));
            //flightSimulatorModel.Connect(ip, int.Parse(port));
            //if (ip == null || port == null)
            //{
            //    MessageBox
            //}
        }

        public void VM_Disconnect()
        {
            flightSimulatorModel.Disconnect();
        }

       
    }
}
