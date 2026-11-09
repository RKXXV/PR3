using System;
using System.Windows;

namespace PR3
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            frame.Navigate(new Auto());
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            frame.GoBack();
        }


        private void Frame_ContentRendered(object sender, EventArgs e)
        {
            if (frame.CanGoBack) btnBack.Visibility = Visibility.Visible;
            else btnBack.Visibility = Visibility.Hidden;
        }
    }
}
