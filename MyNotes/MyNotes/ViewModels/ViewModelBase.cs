using Prism.Mvvm;
using Prism.Navigation;

namespace MyNotes.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible
    {
        /// <summary>
        /// Gets the navigation service.
        /// </summary>
        /// <value>
        /// The navigation service.
        /// </value>
        protected INavigationService NavigationService { get; private set; }

        /// <summary>
        /// The title
        /// </summary>
        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModelBase"/> class.
        /// </summary>
        /// <param name="navigationService">The navigation service.</param>
        protected ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        /// <inheritdoc />
        /// <summary>
        /// Called when [navigated from].
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        public virtual void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        /// <inheritdoc />
        /// <summary>
        /// Called when [navigated to].
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        public virtual void OnNavigatedTo(NavigationParameters parameters)
        {

        }

        /// <inheritdoc />
        /// <summary>
        /// Called when [navigating to].
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        public virtual void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        /// <summary>
        /// Destroys this instance.
        /// </summary>
        public virtual void Destroy()
        {

        }
    }
}
