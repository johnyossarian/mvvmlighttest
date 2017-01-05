using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Input;
using MvvmLightTest.Model;


namespace MvvmLightTest.ViewModel
{
    public class WelcomeViewModel : ViewModelBase
    {
        public ICommand DialogueWindowCommand { get; private set; }

        public WelcomeViewModel()
        {
            DialogueWindowCommand = new RelayCommand<object>(DialogueWindow);
        }

        public void DialogueWindow(object obj)
        {
            MessengerInstance.Send<NotificationMessage<DialogueWindowMessage>>(new NotificationMessage<DialogueWindowMessage>(new DialogueWindowMessage { UserControlType = (Type)obj }, "SwitchDialogueWindow"));
        }
    }
}
