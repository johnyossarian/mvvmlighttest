using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using System.Windows.Controls;
using System;

namespace MvvmLightTest.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        public ICommand SwitchViewCommand { get; private set; }

        private bool isCameraPresent;
        public bool IsCameraPresent {
            get
            {
                return isCameraPresent;
            }
            set
            {
                if (value != isCameraPresent)
                {
                    isCameraPresent = value;
                    RaisePropertyChanged("IsCameraPresent");
                }
            }
        }

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

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            this.SwitchViewCommand = new RelayCommand<object>(SwitchView);
            this.CurrentView = new MainMenuControl();
            this.CurrentView.DataContext = this;

        }

        public void SwitchView(object obj)
        {
            this.currentView = (UserControl)Activator.CreateInstance((Type)obj);
        }
    }
}