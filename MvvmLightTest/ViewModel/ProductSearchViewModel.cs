using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;


namespace MvvmLightTest.ViewModel
{
    public class ProductSearchViewModel : ViewModelBase
    {
        public ICommand ProductSearchCommand { get; private set; }

        public ProductSearchViewModel()
        {
            ProductSearchCommand = new RelayCommand<object>(ProductSearch);
        }

        public void ProductSearch(object obj)
        {
            
        }
    }
}
