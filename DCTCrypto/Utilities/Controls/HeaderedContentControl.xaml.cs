using System.Windows;
using System.Windows.Controls;

namespace DCTCrypto.Utilities.Controls
{
    public partial class HeaderedContentControl : UserControl
    {
        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register(
                nameof(Header),
                typeof(string),
                typeof(HeaderedContentControl),
                new PropertyMetadata(default(string)));

        public static readonly DependencyProperty ValueProperty =
           DependencyProperty.Register(
               nameof(Value),
               typeof(string),
               typeof(HeaderedContentControl),
               new PropertyMetadata(default(string)));

        public HeaderedContentControl()
        {
            InitializeComponent();
        }

        public string Header
        {
            get => (string)GetValue(HeaderProperty);
            set => SetValue(HeaderProperty, value);
        }
        public string Value
        {
            get => (string)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }
    }
}
