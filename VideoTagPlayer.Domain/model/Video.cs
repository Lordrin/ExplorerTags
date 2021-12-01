using System.Collections.Generic;
using System.IO;

namespace VideoTagPlayer.Domain.model
{
    public class Video
    {
        public int Id { get; set; }
        public FileInfo Path { get; set; }
        public string Name { get; set; }
        public List<Tag> Tags { get; set; }
        public int PathId { get; set; }
        public List<string> TagsWithDescriptionList { get; set; }

    }
}
