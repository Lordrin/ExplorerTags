using Microsoft.WindowsAPICodePack.Shell;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VideoTagPlayer.Main.model;
using VideoTagPlayer.Main.utility;
using VideoTagPlayer.Main.videoPlayer;
using VideoTagPlayer.DataLayer;
using VideoTagPlayer.Main.dialogService;
using System.Windows;

namespace VideoTagPlayer.Main.viewModel
{
    public class ViewModelMain : ViewModelBase
    {
        public ICommand ClickedImage { get; set; }
        public ICommand LoadCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public string Message { get; set; }
        public ICommand NewTag { get; set; }
        //private FileLoader _fileLoader;
        private LocalResolver _resolver;
        private Video _selectedvideo;

        private ICommand openDialogCommand = null;
        public ICommand OpenDialogCommand
        {
            get { return this.openDialogCommand; }
            set { this.openDialogCommand = value; }
        }

        public Video SelectedVideo
        {
            get { return _selectedvideo; } 
            set { _selectedvideo = value;}
        }


        public ObservableCollection<PreviewImage> Images;
        public ObservableCollection<Video> Videos { get; set; }
        public ObservableCollection<string> Tags { get; set; }

        public ViewModelMain()
        {
            Images = new ObservableCollection<PreviewImage>();
            Videos = new ObservableCollection<Video>();
            Tags = new ObservableCollection<string>();

            ClickedImage = new Command(StartProcess);
            LoadCommand = new Command(LoadFromExplorer);
            NewTag = new Command(x => NewTagEntered(x));
            SaveCommand = new Command(async x => await SaveFilesAsync(x));
            this.openDialogCommand = new Command(OnOpenDialog);

            //_fileLoader = new FileLoader();
            _resolver = new LocalResolver().Init();
            _resolver.VideosDatabase.ForEach(x => Videos.Add(new Video(x)));
            // this.Videos = new ObservableCollection<Video>(_resolver.VideosDatabase.);
            // FillImages();

            foreach (Video video in Videos)
            {
                video.Tags = new List<Domain.model.Tag>() { Domain.model.Tag.finish, Domain.model.Tag.threeD };
                video.UpdateTags();
            }

        }

        private void OnOpenDialog(object parameter)
        {
            DialogViewModelBase vm = new DialogYesNoViewModel("Question", parameter as Video);
            DialogResult result = DialogService.OpenDialog(vm, parameter as Window);
        }

        public void NewTagEntered(object id)
        {
            var x = id;
        }

        private void LoadFromExplorer(object obj)
        {
            new OpenExplorerDialog().OpenDialog();
        }

        private void FillImages()
        {
            foreach (var path in _resolver.VideosDatabase)
            {
                Videos.Add(new Video(path));
                RaisePropertyChanged("Videos");
                Images.Add(Videos.Last().PreviewImage);
                RaisePropertyChanged("Images");
            }
        }

        private void StartProcess(object Id)
        {
            ProcessStarter.StartProcess(Videos.Where(c => c.Id == (int)Id).Select(x => x.Path).FirstOrDefault());
        }
        public async Task SaveFilesAsync(object id)
        {
            IVideoTagRepository videoTagRepository = new VideoTagRepository(new VideoTagContext());
            //var previous_videos = await videoTagRepository.GetByPathAsync(_fileLoader.LastPath);
            //var allSavedVideos = await videoTagRepository.GetByPathIdAsync(previous_videos.Id);
            // TODO
            // add to database
            // _fileLoader.Files
        }
    }
}
