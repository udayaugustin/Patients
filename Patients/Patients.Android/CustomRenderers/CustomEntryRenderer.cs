using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Text;
using Android.Views;
using Android.Widget;
using Google.Android.Material.TextField;
using Patients.Views;
using Xamarin.Forms;
using Xamarin.Forms.Material.Android;
using Xamarin.Forms.Platform.Android;
using Resource = Patients.Droid.Resource;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer), new[] { typeof(VisualMarker.MaterialVisual)})]
public class CustomEntryRenderer : MaterialEntryRenderer
{
    private readonly Context context;
    private TextInputLayout textInputLayout;

    public CustomEntryRenderer(Context context) : base(context)
    {
        this.context = context;
    }

    public ColorStateList ColorStateList { get; private set; }

    protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
    {
        base.OnElementChanged(e);
        if (e.NewElement != null)
        {
            Activity activity = Context as Activity;

            textInputLayout = (TextInputLayout)LayoutInflater.From(this.Context).Inflate( Resource.Layout.edit_text_layout, null, false);
            
            textInputLayout.SuffixText = "Uday";
            textInputLayout.ExpandedHintEnabled = false;
            textInputLayout.SetBackground(Context.GetDrawable(Patients.Droid.Resource.Drawable.text_input_layout_border));


            textInputLayout.EditText.SetBackgroundResource(Patients.Droid.Resource.Drawable.edit_text_border);

            textInputLayout.SuffixTextColor = ColorStateList.ValueOf(Android.Graphics.Color.Black);
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
                textInputLayout.SuffixText = ((CustomEntry)e.NewElement).SuffixText;
                int suffixColor = Context.GetColor(Patients.Droid.Resource.Color.colorSuffixtText);
                textInputLayout.SuffixTextColor = ColorStateList.ValueOf(new Android.Graphics.Color(suffixColor));
            }
            //var t = (MaterialFormsTextInputLayout)textInputLayout;
            //SetNativeControl(textInputLayout);
        }
    }

    //protected override void OnElementChanged(ElementChangedEventArgs<CustomEntry> e)
    //{
    //    base.OnElementChanged(e);

    //    if (e.NewElement != null)
    //    {
    //        LayoutInflater inflater = (LayoutInflater)this.context.GetSystemService(Context.LayoutInflaterService);
    //        Activity activity = Context as Activity;
    //        textInputLayout = (TextInputLayout)activity.LayoutInflater.Inflate(Patients.Droid.Resource.Layout.edit_text_layout, this, false);
    //        textInputLayout.SuffixTextView.Gravity = GravityFlags.Center;
    //        //textInputLayout.SuffixTextView.SetBackgroundColor(Android.Graphics.Color.Blue);

    //        //textInputLayout.SuffixTextView.SetPadding(10, 10, 10, 10);

    //        //textInputLayout.BoxBackgroundMode = TextInputLayout.BoxBackgroundOutline;
    //        //textInputLayout.BoxBackgroundColor = Patients.Droid.Resource.Color.colorSuffixtText;
    //        //textInputLayout.SetBoxCornerRadii(5, 5, 5, 5);

    //        if (e.NewElement.IsPassword)
    //        {
    //            textInputLayout.SuffixTextView.SetTextAppearance(Patients.Droid.Resource.Style.SuffixTextAppearance);
    //            textInputLayout.EditText.InputType = InputTypes.TextVariationPassword;
    //            textInputLayout.EndIconMode = TextInputLayout.EndIconPasswordToggle;
    //            textInputLayout.SuffixTextView
    //            .SetTypeface(Typeface.CreateFromAsset(Context.Assets, "font/fa_regular.otf"), TypefaceStyle.Normal);



    //        }
    //        else
    //        {
    //            textInputLayout.SuffixText = e.NewElement.SuffixText;
    //            int suffixColor = Context.GetColor(Patients.Droid.Resource.Color.colorSuffixtText);
    //            textInputLayout.SuffixTextColor = ColorStateList.ValueOf(new Android.Graphics.Color(suffixColor));
    //        }
    //        SetNativeControl(textInputLayout);



    //        //textInputLayout.EndIconDrawable = Context.GetDrawable(Patients.Droid.Resource.Drawable.fingerprint);

    //        //context.Resources.GetDrawable(Patients.Droid.Resource.Drawable.fingerprint);
    //        //textInputLayout.EndIconContentDescription = "This is a text";
    //        //textInputLayout.EndIconMode = TextInputLayout.EndIconCustom;


    //    }        
}