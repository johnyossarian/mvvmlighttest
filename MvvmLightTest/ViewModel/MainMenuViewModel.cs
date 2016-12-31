using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using MvvmLightTest.View;

namespace MvvmLightTest.ViewModel
{
    public class MainMenuViewModel : ViewModelBase
    {
        public ICommand SwitchContentCommand { get; private set; }

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
                    RaisePropertyChanged("CurrentView");
                }
            }
        }


        public MainMenuViewModel()
        {
            this.CurrentContent = new WelcomeControl();
        }
    }
}
