using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JsonOfferPage : ContentPage
    {
        public JsonOfferPage(string json)
        {
            InitializeComponent();
            jsonstring.BindingContext = json;
        }
    }
}