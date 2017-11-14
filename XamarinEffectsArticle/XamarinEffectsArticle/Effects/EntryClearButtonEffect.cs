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

        public static void OnShowClearButtonChanged(BindableObject view, object oldValue, object newValue)
        {
            view.SetValue(ShowClearButtonProperty, newValue);

            Entry entry = (Entry)view;

            if (((bool)newValue) == true)
                entry.Effects.Add(new EntryClearButtonEffect());
        }
    }
}
