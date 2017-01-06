using System.Windows.Controls;
using System.Windows.Media;


namespace MvvmLightTest.View
{
    /// <summary>
    /// Interaction logic for DebugMenuBarControl.xaml
    /// </summary>
    public partial class DebugMenuBarControl : UserControl
    {
        public DebugMenuBarControl()
        {
            InitializeComponent();
            if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            {
                this.Background = Brushes.Transparent;
            }
        }
    }
}
