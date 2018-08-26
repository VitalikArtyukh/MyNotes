using MyNotes.Controls;
using MyNotes.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(FlatEntry), typeof(FlatEntryRenderer))]
namespace MyNotes.iOS
{
    public class FlatEntryRenderer : EntryRenderer
    {
        /// <summary>
        /// Raises the <see cref="E:ElementChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="ElementChangedEventArgs{Entry}"/> instance containing the event data.</param>
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.BackgroundColor = UIColor.LightGray;
                Control.BorderStyle = UITextBorderStyle.Line;
            }
        }
    }
}