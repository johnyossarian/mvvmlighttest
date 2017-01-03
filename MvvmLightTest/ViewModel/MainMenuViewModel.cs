using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using MvvmLightTest.View;

namespace MvvmLightTest.ViewModel
{
    public class MainMenuViewModel : ViewModelBase
    {

        private UserControl currentContent;
        public UserControl CurrentContent
        {
            get
            {
                return currentContent;
            }
            set
            {
                if (value != currentContent)
                {
                    currentContent = value;
                    RaisePropertyChanged("CurrentContent");
                }
            }
        }


        public MainMenuViewModel()
        {
            MessengerInstance.Register<NotificationMessage<Type>>(this, SwitchViewContent);
            this.CurrentContent = new WelcomeControl();
        }

        public void SwitchViewContent(NotificationMessage<Type> msgType)
        {
            if (this.currentContent.GetType() != msgType.Content)
            {
                CurrentContent = (UserControl)Activator.CreateInstance(msgType.Content);
            }
        }
    }
}
