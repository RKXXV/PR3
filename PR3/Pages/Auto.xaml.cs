using PR3.Services;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace PR3
{
    public partial class Auto : Page
    {
        int click;

        public Auto()
        {
            InitializeComponent();
        }

        private void GenerateCaptcha()
        {
            tblCaptcha.Visibility = Visibility.Visible;
            tbCaptcha.Visibility = Visibility.Visible;

            string captchaText = CaptchaGenerator.GenerateCaptchaText(6);
            tblCaptcha.Text = captchaText;
            tblCaptcha.TextDecorations = TextDecorations.Strikethrough;
        }

        private void LoadPage(User user)
        {
            click = 0;
            NavigationService.Navigate(new ClientPage(user.Name, user.Surname));

        }

        private void BtnEnterGuest_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClientPage());
        }

        private void BtnEnter_Click(object sender, RoutedEventArgs e)
        {
            click++;
            string login = tbLogin.Text.Trim();
            string hashPassword = Hash.HashPassword(tbPassword.Text.Trim());

            User user;

            using (SoftForgeDBEntities context = new SoftForgeDBEntities())
            {
                user = context.User.Where(x => x.Login == login && x.Password == hashPassword).FirstOrDefault();
            }

            if (click == 1)
            {
                if (user != null)
                {
                    LoadPage(user);
                }
                else
                {
                    MessageBox.Show("Вы ввели логин или пароль неверно!");
                    tbLogin.Text = "";
                    tbPassword.Text = "";
                    GenerateCaptcha();
                }
            }
            else
            {
                if (user != null && tbCaptcha.Text == tblCaptcha.Text)
                {
                    LoadPage(user);
                }
                else
                {
                    MessageBox.Show("Введите двнные заново!");
                }
            }
        }
    }
}
