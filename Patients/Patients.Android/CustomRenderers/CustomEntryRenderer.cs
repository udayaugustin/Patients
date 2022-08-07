using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Text;
using Android.Views;
using Google.Android.Material.TextField;
using Patients.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
public class CustomEntryRenderer : ViewRenderer<CustomEntry, TextInputLayout>
{
    private TextInputLayout textInputLayout;

    public CustomEntryRenderer(Context context) : base(context)
    {
    }

    public ColorStateList ColorStateList { get; private set; }

    protected override void OnElementChanged(ElementChangedEventArgs<CustomEntry> e)
    {
        base.OnElementChanged(e);

        if (e.NewElement != null)
        {
            Activity activity = Context as Activity;
            textInputLayout = (TextInputLayout)activity.LayoutInflater.Inflate(Patients.Droid.Resource.Layout.edit_text_layout, this, false);
            textInputLayout.SuffixTextView.Gravity = GravityFlags.Center;            

            if (e.NewElement.IsPassword)
            {
                textInputLayout.SuffixTextView.SetTextAppearance(Patients.Droid.Resource.Style.SuffixTextAppearance);
                textInputLayout.EditText.InputType = InputTypes.TextVariationPassword;
                textInputLayout.EndIconMode = TextInputLayout.EndIconPasswordToggle;
                textInputLayout.SuffixTextView
                .SetTypeface(Typeface.CreateFromAsset(Context.Assets, "font/fa_regular.otf"), TypefaceStyle.Normal);
            }
            else
            {
                textInputLayout.SuffixText = e.NewElement.SuffixText;
                int suffixColor = Context.GetColor(Patients.Droid.Resource.Color.colorSuffixtText);
                textInputLayout.SuffixTextColor = ColorStateList.ValueOf(new Android.Graphics.Color(suffixColor));
            }
            SetNativeControl(textInputLayout);          
        }
    }
}