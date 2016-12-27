﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Input;
using System.Windows.Controls;
using System;
using System.Linq;
using System.Windows;
using WebcamControl;
using Microsoft.Expression.Encoder.Devices;
using NLog;

namespace MvvmLightTest.ViewModel
{
    class RightMenuBarViewModel : ViewModelBase
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public ICommand ProductSearchCommand { get; set; }

        private bool? isCameraPresent;
        public bool? IsCameraPresent
        {
            get
            {
                return isCameraPresent;
            }
            private set
            {
                if (value != isCameraPresent)
                {
                    isCameraPresent = value;
                    RaisePropertyChanged("CameraVisibility");
                }
            }
        }

        public Visibility CameraVisibility
        {
            get
            {
                return isCameraPresent != null ? ((bool)isCameraPresent ? Visibility.Visible : Visibility.Collapsed) : Visibility.Hidden;
            }
        }

        public Webcam WebCamera { get; set; }

        public RightMenuBarViewModel()
        {

            initWebCamera();
            ProductSearchCommand = new RelayCommand<object>(SwitchContent);
            //camKioskCamera.VideoDevice = cameraDevice.Name;
            
        }

        public void initWebCamera()
        {
            try
            {
                WebCamera = new Webcam();
                WebCamera.VideoDevice = EncoderDevices.FindDevices(EncoderDeviceType.Video).FirstOrDefault();
                WebCamera.StartPreview();
                IsCameraPresent = true;
            }
            catch (Exception e)
            {
                logger.Error(e);
                IsCameraPresent = false;

            }
        }

        public void SwitchContent(object obj)
        {
            MessengerInstance.Send<NotificationMessage<Type>>(new NotificationMessage<Type>((Type)obj,"SwitchContent"));
        }
    }
}