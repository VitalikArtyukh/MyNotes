using MyNotes.Models;
using MyNotes.Services;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

namespace MyNotes.ViewModels
{
    public class DetailedPageViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets the navigation service.
        /// </summary>
        /// <value>
        /// The navigation service.
        /// </value>
        private INavigationService _navigationService { get; }

        /// <summary>
        /// The notes manager
        /// </summary>
        private readonly INotesManager<Note> _notesManager;

        /// <summary>
        /// The dialog service
        /// </summary>
        private readonly IPageDialogService _dialogService;

        /// <summary>
        /// The note
        /// </summary>
        private Note _note;
        public Note Note
        {
            get => _note;
            set => SetProperty(ref _note, value);
        }

        /// <summary>
        /// Gets or sets the save note command.
        /// </summary>
        /// <value>
        /// The save note command.
        /// </value>
        public DelegateCommand SaveNoteCommand { get; set; }

        /// <summary>
        /// Gets or sets the delete note command.
        /// </summary>
        /// <value>
        /// The delete note command.
        /// </value>
        public DelegateCommand DeleteNoteCommand { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:MyNotes.ViewModels.DetailedPageViewModel" /> class.
        /// </summary>
        /// <param name="navigationService">The navigation service.</param>
        public DetailedPageViewModel(INavigationService navigationService, INotesManager<Note> notesManager, IPageDialogService dialogService) : base(navigationService)
        {
            _navigationService = navigationService;
            _notesManager = notesManager;
            _dialogService = dialogService;
            SaveNoteCommand = new DelegateCommand(OnSaveNote);
            DeleteNoteCommand = new DelegateCommand(OnDeleteNote);
        }

        /// <summary>
        /// Called when [navigating to].
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);
            Note = (Note)parameters[nameof(Note)];
        }

        /// <summary>
        /// Called when [save note].
        /// </summary>
        private async void OnSaveNote()
        {
            _notesManager.UpdateNote(Note);
            await _navigationService.GoBackAsync();
        }

        /// <summary>
        /// Called when [save note].
        /// </summary>
        private async void OnDeleteNote()
        {
            var answer = await _dialogService.DisplayAlertAsync(MainPageViewModel.MyNotes, "Видалити нотатку?", "Так", "Ні");
            if (!answer) return;
            if (_notesManager.DeleteNote(Note))
                await _navigationService.GoBackAsync();
        }

    }
}
