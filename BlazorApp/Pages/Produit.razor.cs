using BlazorApp.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace BlazorApp.Pages
{
    public partial class Produit
    {
        public List<Produitt> Produits { get; set; }
        [Inject]
        public HttpClient Client { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Produits = new List<Produitt>();

            using(HttpResponseMessage message = await Client.GetAsync("Produit") )
            {
                string json = await message.Content.ReadAsStringAsync();
                Produits = JsonConvert.DeserializeObject<List<Produitt>>(json);
                StateHasChanged();
            }
        }
    }
}
