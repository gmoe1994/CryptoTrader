using CryptoTrader.App.Core.Models;

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace CryptoTrader.App.Views
{
    public sealed partial class PortfolioDetailControl : UserControl
    {
        public CryptoDto ListDetailsMenuItem
        {
            get { return GetValue(ListDetailsMenuItemProperty) as CryptoDto; }
            set { SetValue(ListDetailsMenuItemProperty, value); }
        }

        public static readonly DependencyProperty ListDetailsMenuItemProperty = DependencyProperty.Register("ListDetailsMenuItem", typeof(CryptoDto), typeof(PortfolioDetailControl), new PropertyMetadata(null, OnListDetailsMenuItemPropertyChanged));

        public PortfolioDetailControl()
        {
            InitializeComponent();
        }

        private static void OnListDetailsMenuItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as PortfolioDetailControl;
            control.ForegroundElement.ChangeView(0, 0, 1);
        }
    }
}
