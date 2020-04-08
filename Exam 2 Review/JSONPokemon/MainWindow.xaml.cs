using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace JSONPokemon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(@"https://pokeapi.co/api/v2/pokemon?limit=964").Result;
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;
                    var VARIABLE = JsonConvert.DeserializeObject<Results>(content);

                    foreach (var item in VARIABLE.results)
                    {
                        lstPokemon.Items.Add(item);
                    }

                }
            }
        }

        private void BtnGetMoreInfo_Click(object sender, RoutedEventArgs e)
        {
            GetMorePokemonInformation();
        }

        private void GetMorePokemonInformation()
        {
            var selectedItem = ((Result)lstPokemon.SelectedItem);
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(selectedItem.url).Result;
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;
                    var VARIABLE = JsonConvert.DeserializeObject<Pokemon>(content);

                    txtPokemonInfo.Text = VARIABLE.ToString(); ;
                }
            }
        }

        private void LstPokemon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetMorePokemonInformation();
        }
    }
}
