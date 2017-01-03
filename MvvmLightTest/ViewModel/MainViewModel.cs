using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using System.Windows.Controls;
using System;
using MvvmLightTest.View;

namespace MvvmLightTest.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ICommand SwitchViewCommand { get; private set; }
        
        private UserControl currentView;
        public UserControl CurrentView
        {
            get
            {
                return currentView;
            }
            set
            {
                if (value != currentView)
                {
                    currentView = value;
                    RaisePropertyChanged("CurrentView");
                }
            }
        }
        
        public MainViewModel()
        {
            this.SwitchViewCommand = new RelayCommand<object>(SwitchView);
            this.CurrentView = new MainMenuControl();
        }

        public void SwitchView(object obj)
        {
            if(this.currentView.GetType() != (Type)obj)
            {
                CurrentView = (UserControl)Activator.CreateInstance((Type)obj);
            }
        }
    }
}