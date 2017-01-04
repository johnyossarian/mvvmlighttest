﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MvvmLightTest.View
{
    /// <summary>
    /// Interaction logic for ProductSearchControl.xaml
    /// </summary>
    public partial class ProductSearchControl : UserControl
    {
        public ProductSearchControl()
        {
            InitializeComponent();
            
            this.kbScreenKeyboard.KeyboardReturn += KbScreenKeyboard_KeyboardReturn;
        }

        private void KbScreenKeyboard_KeyboardReturn(object sender, WpfKb.Controls.KeypadReturn e)
        {
            tbSearchText.Focus();
        }
    }
}
