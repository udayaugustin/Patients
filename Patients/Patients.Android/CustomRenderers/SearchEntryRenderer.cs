using Android.Content;
using Android.Graphics.Drawables;
using Android.Widget;
using Patients.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomSearchBar), typeof(SearchBarCustomRenderer))]
public class SearchBarCustomRenderer : SearchBarRenderer
{
    public SearchBarCustomRenderer(Context context) : base(context)
    {
    }
    protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
    {
        base.OnElementChanged(e);

        if (Control != null)
        {
            GradientDrawable gd = new GradientDrawable();

            gd.SetColor(Android.Graphics.Color.Transparent);
            Control.SetBackground(gd);
            int searchIconId = Context.Resources.GetIdentifier("android:id/search_mag_icon", null, null);
            ImageView searchViewIcon = Control.FindViewById<ImageView>(searchIconId);
            searchViewIcon.SetImageDrawable(null);
        }
    }
}