using GalaSoft.MvvmLight;
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
    public class RightMenuBarViewModel : ViewModelBase
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private Object cameraLock = new Object();

        public ICommand SwitchContentCommand { get; set; }

        public Webcam WebCamera { get; set; }

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

        public RightMenuBarViewModel()
        {
            initWebCamera();
            SwitchContentCommand = new RelayCommand<object>(SwitchContent);
        }

        public void initWebCamera()
        {
            try
            {
                EncoderDevice encoder = EncoderDevices.FindDevices(EncoderDeviceType.Video).FirstOrDefault();
                if (encoder != null)
                {
                    this.WebCamera = new Webcam();
                    this.WebCamera.VideoDevice = encoder;
                    this.WebCamera.StartPreview();
                    IsCameraPresent = true;
                }
            }
            catch (Exception e)
            {
                if(this.WebCamera != null)
                {
                    if(this.WebCamera.VideoDevice != null)
                    {
                        this.WebCamera.VideoDevice.Dispose();
                    }
                    this.WebCamera.Dispose();
                    this.WebCamera = null;
                }
                logger.Error(e);
                IsCameraPresent = false;
            }
        }

        public void SwitchContent(object obj)
        {
            MessengerInstance.Send<NotificationMessage<Type>>(new NotificationMessage<Type>((Type)obj,"SwitchContent"));
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.WebCamera != null)
                {
                    this.WebCamera.Dispose();
                    this.WebCamera = null;
                }
            }
        }
    }
}
