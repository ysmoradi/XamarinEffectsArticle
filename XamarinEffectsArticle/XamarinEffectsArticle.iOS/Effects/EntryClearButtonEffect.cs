using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamarinEffectsArticle.iOS.Effects;

[assembly: ExportEffect(typeof(EntryClearButtonEffect), "EntryClearButtonEffect")]
[assembly: ResolutionGroupName("MyApp")]

namespace XamarinEffectsArticle.iOS.Effects
{
    public class EntryClearButtonEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            ((UITextField)Control).ClearButtonMode = UITextFieldViewMode.WhileEditing;
        }

        protected override void OnDetached()
        {
            
        }
    }
}