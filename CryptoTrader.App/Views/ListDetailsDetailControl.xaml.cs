using CryptoTrader.App.Core.Models;

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace CryptoTrader.App.Views
{
    public sealed partial class ListDetailsDetailControl : UserControl
    {
        public CryptoDto ListDetailsMenuItem
        {
            get { return GetValue(ListDetailsMenuItemProperty) as CryptoDto; }
            set { SetValue(ListDetailsMenuItemProperty, value); }
        }

        public static readonly DependencyProperty ListDetailsMenuItemProperty = DependencyProperty.Register("ListDetailsMenuItem", typeof(CryptoDto), typeof(ListDetailsDetailControl), new PropertyMetadata(null, OnListDetailsMenuItemPropertyChanged));

        public ListDetailsDetailControl()
        {
            InitializeComponent();
        }

        private static void OnListDetailsMenuItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as ListDetailsDetailControl;
            control.ForegroundElement.ChangeView(0, 0, 1);
        }
    }
}
