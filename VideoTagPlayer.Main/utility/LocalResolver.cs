using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoTagPlayer.DataLayer;
using VideoTagPlayer.Domain.model;

namespace VideoTagPlayer.Main.utility
{
    public class LocalResolver
    {
        private IVideoTagRepository VideoTagRepository;
        private FileLoader _fileLoader;
        //public Task _idResolveTask;
        private int _pathId;
        public List<Video> VideosDatabase;
        public List<Video> VideosLocal;
        public List<Video> ToRemove;

        public LocalResolver Init()
        {
            using (var db = new ContextFactory().CreateVideoTagContext())
            {
                db.Database.EnsureCreated();
                db.Database.Migrate();
            }
            VideoTagRepository = new ContextFactory().Createrepository();// new VideoTagRepository(new VideoTagContext());
            VideosLocal = new List<Video>();
            ToRemove = new List<Video>();
            _fileLoader = new FileLoader();
            _fileLoader.LoadFiles();
            // _idResolveTask = ResolvePathIdAsync(_fileLoader.LastPath);
            _pathId = ResolvePathIdAsync(_fileLoader.LastPath).Result;
            _ = GetFromDatabaseAsync().Result;
            GiveProperIds();
            UpdateDatabase();
            return this;
        }
        private async Task<VideoPath> GetPathFromDataBaseAsync(string path)
        {
            return await VideoTagRepository.GetByPathAsync(path);
        }

        public async Task<int> ResolvePathIdAsync(string path)
        {
            VideoPath videoPath = await GetPathFromDataBaseAsync(path);
            if (videoPath != null)
            {
                return videoPath.Id;
            }
            else
            {
                VideoPath to_add = new VideoPath() { Path = path };
                await VideoTagRepository.AddVideoPathAsync(to_add);
                return to_add.Id;
            }
        }
        private async Task<List<Video>> GetFromDatabaseAsync()
        {
            VideosDatabase = await VideoTagRepository.GetByPathIdAsync(_pathId) as List<Video>;
            return VideosDatabase;
        }
        private void GiveProperIds()
        {
            VideosDatabase.ForEach(x => x.Path = new FileInfo(_fileLoader.LastPath + "\\" + x.Name));
            List<System.IO.FileInfo> differenceLocalAndDatabase = _fileLoader.Files.Except(VideosDatabase.Select(x => x.Path)).ToList();
            List<string> differenceDatabaseAndLocal = VideosDatabase.Select(x => x.Path.Name).Except(_fileLoader.Files.Select(c => c.Name)).ToList();
            foreach (var path in differenceDatabaseAndLocal)
            {
                Video to_add = VideosDatabase.Find(x => x.Path.Name.Equals(path));
                if(to_add != null) ToRemove.Add(to_add);
            }

            foreach (var path in differenceLocalAndDatabase)
            {
                VideosLocal.Add(new model.Video(path) { PathId = _pathId});
            }
        }
        private void UpdateDatabase()
        {
            VideoTagRepository.AddRangeAsync(VideosLocal);
            // TODO remove videos from ToRemove
        }
    }
}
