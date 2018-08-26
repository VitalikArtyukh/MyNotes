using MyNotes.Models;
using MyNotes.Services;
using MyNotes.Views;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System.Collections.Generic;
using System.Linq;

namespace MyNotes.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public const string MyNotes = "Мої нотатки";

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
        /// Gets or sets the item tapped command.
        /// </summary>
        /// <value>
        /// The item tapped command.
        /// </value>
        public DelegateCommand<Note> ItemTappedCommand { get; set; }

        /// <summary>
        /// Gets or sets the add note command.
        /// </summary>
        /// <value>
        /// The add note command.
        /// </value>
        public DelegateCommand AddNoteCommand { get; set; }

        /// <summary>
        /// Gets or sets the delete note command.
        /// </summary>
        /// <value>
        /// The delete note command.
        /// </value>
        public DelegateCommand<Note> DeleteNoteCommand { get; set; }

        /// <summary>
        /// The notes list
        /// </summary>
        private List<Note> _notesList;
        public List<Note> NotesList
        {
            get => _notesList;
            set => SetProperty(ref _notesList, value);
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:MyNotes.ViewModels.MainPageViewModel" /> class.
        /// </summary>
        /// <param name="navigationService">The navigation service.</param>
        /// <param name="notesManager">The notes manager.</param>
        public MainPageViewModel(INavigationService navigationService, INotesManager<Note> notesManager, IPageDialogService dialogService) : base(navigationService)
        {
            _navigationService = navigationService;
            _notesManager = notesManager;
            _dialogService = dialogService;
            Title = MyNotes;
            ItemTappedCommand = new DelegateCommand<Note>(OnItemTapped);
            AddNoteCommand = new DelegateCommand(OnAddNote);
            DeleteNoteCommand = new DelegateCommand<Note>(OnDeleteNote);
        }

        /// <summary>
        /// Called when [add note].
        /// </summary>
        private async void OnAddNote()
        {
            var note = _notesManager.CreateNote();
            var navigationParams = new NavigationParameters { { nameof(Note), note } };
            await _navigationService.NavigateAsync(nameof(DetailedPage), navigationParams);
        }

        /// <summary>
        /// Navigates to detailed page.
        /// </summary>
        private async void OnItemTapped(Note note)
        {
            var navigationParams = new NavigationParameters { { nameof(Note), note } };
            await _navigationService.NavigateAsync(nameof(DetailedPage), navigationParams);
        }


        /// <summary>
        /// Called when [save note].
        /// </summary>
        private async void OnDeleteNote(Note note)
        {
            var answer = await _dialogService.DisplayAlertAsync(MyNotes, "Видалити нотатку?", "Так", "Ні");
            if (!answer) return;
            if (_notesManager.DeleteNote(note))
                NotesList = _notesManager.GetAllNotes().ToList();
        }

        /// <inheritdoc />
        /// <summary>
        /// Called when [navigated to].
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            NotesList = _notesManager.GetAllNotes().ToList();
        }
    }
}
