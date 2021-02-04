using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;


namespace PaljuOnne
{
    public partial class MainPage : ContentPage
    {
        List<string> contacts, mail, number, congratulations;

        private void leftRight_Toggled(object sender, ToggledEventArgs e)
        {
            if (leftRight.IsToggled == true)
            {
                congrat.Text = "Поздравить по SMS";
            }
            else
            {
                congrat.Text = "Поздравить по E-mail";
            }
        }

        public MainPage()
        {
            contacts = new List<string>() { "Sander", "Pavel", "Slava", "Sasha" };
            number = new List<string>() { "56481577", "45967322", "65749732", "69236594" };
            mail = new List<string> { "sanderdemih@gmail.com", "pavel123@gmail.com", "zilin@gmail.com", "sasha_and_petrenko@mail.ru" };
            congratulations = new List<string> { "С днём рождения!", "Не надевай корону!", "С рождением дня!", "Носи маски!", "Радуйся жизни!", "Соблюдай дистанцию!", "Не голодай!", "Не пропускай уроки Марины Владимировной!" };
            InitializeComponent();
            contactPicker.ItemsSource = contacts;
            contactPicker.SelectedIndexChanged += ContactPicker_SelectedIndexChanged;
            congratulate.Clicked += Congratulate_Clicked;
        }

        private void ContactPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            maill.Text = mail[contactPicker.SelectedIndex];
            num.Text = number[contactPicker.SelectedIndex];
        }

        private async void Congratulate_Clicked(object sender, EventArgs e)
        {
            Random ranGreet = new Random();
            int rand = ranGreet.Next(5);
            if (leftRight.IsToggled == true)
            {
                congrat.Text = "Поздравить по SMS";
                await Sms.ComposeAsync(new SmsMessage { Body = congratulations[rand], Recipients = new List<string> { number[contactPicker.SelectedIndex] } });
            }
            else
            {
                congrat.Text = "Поздравить по E-mail";
                await Email.ComposeAsync("Поздравление", congratulations[rand], mail[contactPicker.SelectedIndex]);
            }
        }
    }
}
