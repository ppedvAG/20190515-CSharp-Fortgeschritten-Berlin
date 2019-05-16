using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace WPF_Filme
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FilmList FilmListeLokal { get; set; } = new FilmList();
        public MainWindow(ISave save)
        {
            InitializeComponent();
            FilmListe.DataContext = FilmListeLokal;
        }


        private async void Send_Request_Button_Click(object sender, RoutedEventArgs e)
        {
            
            string titel = titelSearch.Text;
            string year = yearSearch.Text;
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync($"http://www.omdbapi.com/?apikey=e448232e&t={titel}&y={year}");

            string responseBody = await response.Content.ReadAsStringAsync();

            Film film = JsonConvert.DeserializeObject<Film>(responseBody);
            FilmEditor.DataContext = film;
            FilmListeLokal.Filme.Add(film);
            FilmListe.Items.Refresh();
            MessageBox.Show(responseBody);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            save.Save(film);
        }
    }
}
