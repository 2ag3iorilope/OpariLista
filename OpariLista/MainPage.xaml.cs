using System.Diagnostics;

namespace OpariLista
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        private List<Produktua> _productos;
        private List<string> _selectedItems;
        private Produktua _lastSelectedItem;

        public MainPage()
        {
            InitializeComponent();
        
            LoadData();
            _selectedItems = new List<string>();

        }

        private void LoadData()
        {

            _productos = new List<Produktua>
        {
            new Produktua { Izena = "Erlojua" , ImageName = "erlojua.png"},
            new Produktua { Izena = "Aurikularrak" ,ImageName = "aurikularrak.png"},
            new Produktua { Izena = "Bozgoragailuak",ImageName = "bozgoragailua.png" },
            new Produktua { Izena = "Eramangarria",ImageName = "portatila.png" },
            new Produktua { Izena = "Bizikleta Elektrikoa",ImageName = "bizielektriko.png" }
        };

            listView.ItemsSource = _productos;
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            if (_lastSelectedItem != null)
            {
                if (!_selectedItems.Contains(_lastSelectedItem.Izena))
                {
                    _selectedItems.Add(_lastSelectedItem.Izena);

                    //Bi opari baino gehiago badaude lehen oparia kendu eta berria gehitu
                    if (_selectedItems.Count > 2)
                    {
                        _selectedItems.RemoveAt(0);
                    }

                    // Testua eguneratu
                    OpariakLabel.Text = string.Join(" + ", _selectedItems.Select(item => $"Oparia: {item}"));
                }
            }
        }
        private void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is Produktua selectedItem)
            {
                // Eguneratu argazkia
                selectedImage.Source = ImageSource.FromFile(selectedItem.ImageName);

                //Gorde aukeratutakoa botoi bidez gehitzeko
                _lastSelectedItem = selectedItem;
            }
        }
        private void DeleteOnClicked(object sender, EventArgs e)
        {
            if (_selectedItems.Count > 0)
            {
               //Zerrenda hustu
                _selectedItems.Clear();

                // Label-eko textua eguneratu
                OpariakLabel.Text = "Opariak garbitu dira berriro aukeratu";
            }
        }
        private void OnExitClicked(object sender, EventArgs e)
        {
            Application.Current!.Quit();
        }

    }

}
public class Produktua
{
    public string Izena { get; set; }
    public string ImageName { get; set; }
}
