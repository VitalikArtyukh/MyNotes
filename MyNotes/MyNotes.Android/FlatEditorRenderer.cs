using Android.Content;
using MyNotes.Controls;
using MyNotes.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(FlatEditor), typeof(FlatEditorRenderer))]
namespace MyNotes.Droid
{
    class FlatEditorRenderer : EditorRenderer
    {
        /// <summary>
        /// The context
        /// </summary>
        private Context _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="FlatEditorRenderer"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public FlatEditorRenderer(Context context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// Raises the <see cref="E:ElementChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="ElementChangedEventArgs{Editor}"/> instance containing the event data.</param>
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
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