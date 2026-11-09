using System.Windows.Controls;

namespace PR3
{
    public partial class ClientPage : Page
    {
        public ClientPage()
        {
            InitializeComponent();
            GreetingUser("Привет, Гость!");
        }

        public ClientPage(string name, string surname)
        {
            InitializeComponent();
            GreetingUser($"Привет, {name} {surname}!");
        }

        private void GreetingUser(string text)
        {
            tbName.Text = text;
        }
    }
}
