using Android.Content;
using MyNotes.Controls;
using MyNotes.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(FlatEntry), typeof(FlatEntryRenderer))]
namespace MyNotes.Droid
{
    class FlatEntryRenderer : EntryRenderer
    {
        /// <summary>
        /// The context
        /// </summary>
        private Context _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="FlatEntryRenderer"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public FlatEntryRenderer(Context context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// Raises the <see cref="E:ElementChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="ElementChangedEventArgs{Entry}"/> instance containing the event data.</param>
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.Background = Android.App.Application.Context.GetDrawable(Resource.Drawable.bg_rounded_corners);
                float pixels = 10 * _context.Resources.DisplayMetrics.Density;
                Control.SetPadding((int)pixels, (int)pixels, (int)pixels, (int)pixels);
            }
        }
    }
}