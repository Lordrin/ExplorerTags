using Microsoft.WindowsAPICodePack.Shell;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using VideoTagPlayer.Main.utility;

namespace VideoTagPlayer.Main.model
{
    public class Video : VideoTagPlayer.Domain.model.Video
    {
        //contains:
        //public int Id { get; set; }
        //public FileInfo Path { get; set; }
        //public string Name { get; set; }
        //public List<Tag> Tags { get; set; }
        public PreviewImage PreviewImage { get; set; }
        public ObservableCollection<string> TagsDescription { get; set; }

        public Video()
        {
            this.Tags = new List<Domain.model.Tag>();
            this.PreviewImage = new PreviewImage(ShellFile.FromFilePath(Path.FullName.ToString()).Thumbnail.BitmapSource);
            TagsDescription = new ObservableCollection<string>();
            UpdateTags();
        }
        public Video(FileInfo path)
        {
            this.Path = path;
            this.Name = path.Name; 
            this.Tags = new List<Domain.model.Tag>();
            if (this.PreviewImage == null)
            {
                this.PreviewImage = new PreviewImage(ShellFile.FromFilePath(Path.FullName.ToString()).Thumbnail.BitmapSource);
            }
            TagsDescription = new ObservableCollection<string>();
            UpdateTags();

        }
        public Video(VideoTagPlayer.Domain.model.Video video)
        {
            this.Tags = video.Tags;
            this.Name = video.Name;
            this.Id = video.Id;
            this.Path = video.Path;
            this.PathId = video.PathId;
            this.PreviewImage = new PreviewImage(ShellFile.FromFilePath(Path.FullName.ToString()).Thumbnail.BitmapSource);
            TagsDescription = new ObservableCollection<string>();
            UpdateTags();
        }
        public void UpdateTags()
        {
            this.Tags.ForEach(c => 
            {
                TagsDescription.Add(ExtensionCustom.GetEnumDescription(c));
                TagsWithDescriptionList.Add(ExtensionCustom.GetEnumDescription(c));
            });

        }
    }
}
