using Prism;
using Prism.Ioc;
using MyNotes.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Unity;
using MyNotes.Services;
using MyNotes.Models;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MyNotes
{
    public partial class App : PrismApplication
    {
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        /// <inheritdoc />
        /// <summary>
        /// Called when the PrismApplication has completed it's initialization process.
        /// </summary>
        protected override async void OnInitialized()
        {
            InitializeComponent();
            await NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(MainPage)}");
        }

        /// <inheritdoc />
        /// <summary>
        /// Used to register types with the container that will be used by your application.
        /// </summary>
        /// <param name="containerRegistry"></param>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            #region Types      
            containerRegistry.RegisterSingleton<INotesManager<Note>, NotesManager<Note>>();
            containerRegistry.RegisterSingleton<IRepository<Note>, NotesRepository<Note>>();
            #endregion

            #region Navigation   
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterForNavigation<DetailedPage>();
            #endregion
        }
    }
}
