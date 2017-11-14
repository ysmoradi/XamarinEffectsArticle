using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinEffectsArticle.Effects
{
    public class EntryClearButtonEffect : RoutingEffect
    {
        public EntryClearButtonEffect()
            : base("MyApp.EntryClearButtonEffect")
        {
        }

        public static readonly BindableProperty ShowClearButtonProperty = BindableProperty.CreateAttached(
                propertyName: "ShowClearButton",
                returnType: typeof(bool),
                declaringType: typeof(Entry),
                defaultValue: false,
                propertyChanged: OnShowClearButtonChanged);

        public static bool? GetShowClearButton(BindableObject view)
        {
            return (bool?)view.GetValue(ShowClearButtonProperty);
        }

        public static async void OnShowClearButtonChanged(BindableObject view, object oldValue, object newValue)
        {
            view.SetValue(ShowClearButtonProperty, newValue);

            await Task.Yield();

            // Global style in App.xaml declares ShowClearButton's default value is True.
            // An Entry might set ShowClearButton to False for its own.
            // We wait a little for final value of ShowClearButton of this element using await Task.Yield();
            // <Entry effects:EntryClearButtonEffect.ShowClearButton="False" /> >> Effect will not be applied to this.
            // <Entry /> Effect will be applied to this.

            bool showClearButtonValue = (bool)view.GetValue(ShowClearButtonProperty);

            Entry entry = (Entry)view;

            if (showClearButtonValue == true)
                entry.Effects.Add(new EntryClearButtonEffect()); // For our MainPage.xaml which has 3 Entry elements, this code will be executed only twice.
        }
    }
}
