using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
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
using System.Xml;
using System.Xml.Serialization;
using Path = System.IO.Path;

namespace WPFMitSpeichern
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public IStore store;
        public Filme Filme;
        public MainWindow()
		{
            store = new FileBinStore();
			Filme = new Filme();
			InitializeComponent();
			Filme.FilmListe = new List<Film>();
			DataContext = Filme;
			UpdateLayout();
        }

        private void Speichern_Button_Click(object sender, RoutedEventArgs e)
        {
            store.Save(Filme);
        }

        private void Oeffnen_Button_Click(object sender, RoutedEventArgs e)
        {
            Filme = store.Load();
            DataContext = Filme;
            UpdateLayout();
        }

		// Wir löschen den ausgewählten Eintrag aus der Liste
		private void Delete_Entry_Button_Click(object sender, RoutedEventArgs e)
		{
			if(FilmeListBox.SelectedItem is Film film) {
				Filme.FilmListe.Remove(film);
				// Wir müssen der ListBox mitteilen, dass diese neu gerendert wird, ansonsten verändert sich unsere Liste zwar, aber es wird nicht angezeigt
				FilmeListBox.Items.Refresh();
			}
		}

		// Hier müssen wir ein neues Filmobjekt erstellen und es der Liste hinzufügen
		private void Add_Entry_Button_Click(object sender, RoutedEventArgs e)
		{
			Film film = new Film();
			FilmEditor.DataContext = film;
			Filme.FilmListe.Add(film);

			// Hier wechseln wir den Fokus auf den neu erstellten Eintrag
			FilmeListBox.SelectedItem = film;
			FilmeListBox.Items.Refresh();
		}

		private void Edit_Entry_Button_Click(object sender, RoutedEventArgs e)
		{
			if (FilmeListBox.SelectedItem is Film film)
			{
				FilmEditor.DataContext = film;
			}
		}

		// Komfortfunktion, damit man nicht immer auf den Button "Eintrag bearbeiten" klicken muss
		// Wenn wir diese Funktion verwenden, dann brauchen wir den Eintrag bearbeiten Button nicht mehr
		// Immer wenn etwas selektiert wird, dann wird ein Event geworfen und wir hören hier auf dieses Event und ändern den DataContext
		// von unserem FilmEditor grid auf den ausgewählten Film
		private void FilmeListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (FilmeListBox.SelectedItem is Film film)
			{
				FilmEditor.DataContext = film;
			}
		}
	}
}
