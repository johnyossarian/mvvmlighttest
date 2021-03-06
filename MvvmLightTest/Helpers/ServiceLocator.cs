/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:MvvmLightTest"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using MvvmLightTest.ViewModel;
using MvvmLightTest.Devices;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace MvvmLightTest
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class Locator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public Locator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}
            
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<MainMenuViewModel>();
            SimpleIoc.Default.Register<OperatorMenuViewModel>();
            SimpleIoc.Default.Register<RightMenuBarViewModel>();
            SimpleIoc.Default.Register<ProductSearchViewModel>();
            SimpleIoc.Default.Register<ManageLoyaltyCardViewModel>();
            SimpleIoc.Default.Register<DebugMenuBarViewModel>();
            SimpleIoc.Default.Register<LoyaltyCardDirectorViewModel>();
            SimpleIoc.Default.Register<WelcomeViewModel>();

            SimpleIoc.Default.Register<>
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public MainMenuViewModel MainMenu
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainMenuViewModel>();
            }
        }

        public OperatorMenuViewModel OperatorMenu
        {
            get
            {
                return ServiceLocator.Current.GetInstance<OperatorMenuViewModel>();
            }
        }

        public RightMenuBarViewModel RightMenuBar
        {
            get
            {
                if(SimpleIoc.Default.IsRegistered<RightMenuBarViewModel>())
                {
                    SimpleIoc.Default.Unregister<RightMenuBarViewModel>();
                    SimpleIoc.Default.Register<RightMenuBarViewModel>();
                }
                return ServiceLocator.Current.GetInstance<RightMenuBarViewModel>();
            }
        }

        public ProductSearchViewModel ProductSearch
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ProductSearchViewModel>();
            }
        }

        public ManageLoyaltyCardViewModel ManageLoyaltyCard
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ManageLoyaltyCardViewModel>();
            }
        }

        public DebugMenuBarViewModel DebugMenuBar
        {
            get
            {
                return ServiceLocator.Current.GetInstance<DebugMenuBarViewModel>();
            }
        }

        public LoyaltyCardDirectorViewModel LoyaltyCardDirector
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoyaltyCardDirectorViewModel>();
            }
        }

        public WelcomeViewModel Welcome
        {
            get
            {
                return ServiceLocator.Current.GetInstance<WelcomeViewModel>();
            }
        }


        public static void Cleanup()
        {
            
        }
    }
}