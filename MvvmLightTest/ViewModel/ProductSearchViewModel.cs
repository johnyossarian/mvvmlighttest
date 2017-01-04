using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using System.Windows.Controls;
using MvvmLightTest.Database;
using System.Linq;
using System.Collections.Generic;


namespace MvvmLightTest.ViewModel
{
    public class ProductSearchViewModel : ViewModelBase
    {
        public ICommand ProductSearchCommand { get; private set; }

        public ICommand ClearTextBox { get; private set; }

        public ProductSearchViewModel()
        {
            ProductSearchCommand = new RelayCommand<string>(ProductSearch);
            ClearTextBox = new RelayCommand<TextBox>((textBox) => { textBox.Clear(); textBox.Focus(); });
        }

        public void ProductSearch(string searchText)
        {
            using (DbContext db = new DbContext())
            {
                List<Product> products = (from p in db.Products
                                          where p.Name.ToLower().Contains((searchText ?? string.Empty))
                                          select p).ToList();
            }
        }

    }
}
