using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Xml;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinTest.Models;

namespace XamarinTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        // Project without Database. This is an example.
        // Some property for store offers and dict for transfer the Json object by id on new page.
        public List<Offer> offersList { get; set; }
        Dictionary<string,JObject> ByIdOfferJson { get; set; }
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            // Exclude Error when user push back button on device. 
            // Clear all data property for navigate page from JsonOfferPage
            offersList = new List<Offer>();
            ByIdOfferJson = new Dictionary<string, JObject>();

            // await Data List and Dict from url was been full
            dynamic c = await GetDataFromService();

            // IdList for MainPage.xaml
            // Take only Id from Offer in offersList
            IdList.ItemsSource = offersList
                .OrderBy(d => d.Id)
                .ToList();
        }

        // Id select event on the main page
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem!=null)
            {
                Offer newPageL = (Offer)e.SelectedItem;
                string jOffer = ByIdOfferJson[newPageL.Id].ToString();
                // send string object by id for new page
                await Navigation.PushAsync(new JsonOfferPage(jOffer));
            }
        }

        // Get Data from Url
        public async Task<List<Offer>> GetDataFromService()
        {
            string url = "https://yastatic.net/market-export/_/partner/help/YML.xml";
            offersList = new List<Offer>();
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    HttpContent responseContent = response.Content;
                    var xml = await responseContent.ReadAsByteArrayAsync();
                    XmlDocument doc = new XmlDocument();

                    // UTF-8 Encoding
                    using (MemoryStream oStream = new MemoryStream(xml))
                    {
                        doc.Load(oStream);
                    }

                    string json = JsonConvert.SerializeXmlNode(doc);
                    JObject jsonObject = JObject.Parse(json);
                    var searchOffers = jsonObject["yml_catalog"]["shop"]["offers"]["offer"];

                    foreach (var item in searchOffers)
                    {
                        Offer offer = new Offer();
                        offer.Id = (string)item["@id"];
                        offer.Type = (string)item["@type"];
                        offer.Bid = (string)item["@bid"];
                        offer.Available = (string)item["@available"]; 
                        offer.Url = (string)item["url"];
                        offer.Price = (string)item["price"];
                        offer.CurrencyId = (string)item["currencyId"];
                        offer.Picture = (string)item["picture"];

                        var cID = item["categoryId"] as JObject;
                        foreach (var c in cID)
                        {
                            if (c.Key == "@type")
                            {
                                offer.CategoryId.Type = c.Value.ToString();
                            }
                            else
                            {
                                offer.CategoryId.Text = c.Value.ToString();
                            }
                        }

                        offersList.Add(offer);
                        var i = item as JObject;
                        var j = (string)item["@id"];
                        ByIdOfferJson.Add(j, i);
                    }
                }
                return offersList;
            };
        }
    }
}
