using Android.Content;
using Android.Util;
using MyNotes.Controls;
using MyNotes.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Button = Xamarin.Forms.Button;

[assembly: ExportRenderer(typeof(FlatButton), typeof(FlatButtonRenderer))]
namespace MyNotes.Droid
{
    using Application = global::Android.App.Application;
    using ButtonRenderer = Xamarin.Forms.Platform.Android.AppCompat.ButtonRenderer;

    internal class FlatButtonRenderer : ButtonRenderer
    {
        public FlatButtonRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            if (this.Control == null) return;
            TypedValue value = new TypedValue();
            Application.Context.Theme.ResolveAttribute(Resource.Attribute.selectableItemBackground, value, true);
            this.Control.SetBackgroundResource(value.ResourceId);
        }
    }
}