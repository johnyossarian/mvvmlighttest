using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System;
using MvvmLightTest.View;
using MvvmLightTest.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace MvvmLightTest.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ICommand SwitchViewCommand { get; private set; }
        public ICommand SwitchDialogueCommand { get; private set; }

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

        private UserControl currentDialogueView;
        public UserControl CurrentDialogueView
        {
            get
            {
                return currentDialogueView;
            }
            set
            {
                if (value != currentDialogueView)
                {
                    currentDialogueView = value;
                    RaisePropertyChanged("CurrentDialogue");
                }
            }
        }

        private Window dialogueWindow { get; set; }

        public MainViewModel()
        {
            this.SwitchViewCommand = new RelayCommand<object>(SwitchView);
            this.SwitchDialogueCommand = new RelayCommand<object>(SwitchDialogue);
            MessengerInstance.Register<NotificationMessage<DialogueWindowMessage>>(this, OnSwitchDialogueMessage);
            this.CurrentView = new MainMenuControl();
        }

        public void SwitchView(object obj)
        {
            if(this.currentView.GetType() != (Type)obj)
            {
                this.CurrentView = (UserControl)Activator.CreateInstance((Type)obj);
            }
        }

        public void OnSwitchDialogueMessage(NotificationMessage<DialogueWindowMessage> dm)
        {
            this.SwitchDialogue((object)dm.Content.UserControlType);
        }

        public void SwitchDialogue(object obj)
        {
            if (this.currentDialogueView != null && this.currentDialogueView.GetType() == (Type)obj)
            {
                CurrentDialogueView = null;
                if (dialogueWindow != null)
                {
                    dialogueWindow.Hide();
                    dialogueWindow.Close();
                    dialogueWindow = null;
                }
            }
            else
            {
                this.CurrentDialogueView = (UserControl)Activator.CreateInstance((Type)obj);
                dialogueWindow = new DialogueWindow();
                dialogueWindow.Show();
            }
        }
    }
}