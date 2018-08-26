using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyNotes.Converters
{
    /// <inheritdoc cref="ItemTappedEventArgsConverter" />
    /// <summary>
    /// </summary>
    /// <seealso cref="T:Xamarin.Forms.IValueConverter" />
    /// <seealso cref="T:Xamarin.Forms.Xaml.IMarkupExtension" />
    public class ItemTappedEventArgsConverter : IValueConverter, IMarkupExtension
    {
        /// <inheritdoc />
        /// <summary>
        /// Implement this method to convert <paramref name="value" /> to <paramref name="targetType" /> by using <paramref name="parameter" /> and <paramref name="culture" />.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="targetType">The type to which to convert the value.</param>
        /// <param name="parameter">A parameter to use during the conversion.</param>
        /// <param name="culture">The culture to use during the conversion.</param>
        /// <returns>
        /// To be added.
        /// </returns>
        /// <exception cref="T:System.ArgumentException">Expected value to be of type ItemTappedEventArgs - value</exception>
        /// <remarks>
        /// To be added.
        /// </remarks>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is ItemTappedEventArgs itemTappedEventArgs))
            {
                throw new ArgumentException("Expected value to be of type ItemTappedEventArgs", nameof(value));
            }
            return itemTappedEventArgs.Item;
        }

        /// <inheritdoc />
        /// <summary>
        /// Implement this method to convert <paramref name="value" /> back from <paramref name="targetType" /> by using <paramref name="parameter" /> and <paramref name="culture" />.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="targetType">The type to which to convert the value.</param>
        /// <param name="parameter">A parameter to use during the conversion.</param>
        /// <param name="culture">The culture to use during the conversion.</param>
        /// <returns>
        /// To be added.
        /// </returns>
        /// <remarks>
        /// To be added.
        /// </remarks>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        /// <inheritdoc />
        /// <summary> 
        /// Returns the object created from the markup extension.
        /// </summary>
        /// <param name="serviceProvider">The service that provides the value.</param>
        /// <returns>
        /// The object
        /// </returns>
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
