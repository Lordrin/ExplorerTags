using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoTagPlayer.Domain.model;

namespace VideoTagPlayer.DataLayer
{
    public class VideoTagRepository : IVideoTagRepository
    {
        private readonly VideoTagContext _context;

        public VideoTagRepository(VideoTagContext context)
        {
            _context = context;
        }

        public async Task<IList<Video>> GetAllVideoAsync()
        {
            return await _context.Videos.ToListAsync();
        }

        public async Task<Video> GetByIdAsync(int id)
        {
            return await _context.Videos.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<VideoPath> GetByPathAsync(string path)
        {
            return await _context.VideoPaths.FirstOrDefaultAsync(r => r.Path.Equals(path));
        }

        public async Task<IList<Video>> GetVideosByPathIdAsync(int pathId)
        {
            return await _context.Videos.Where(r => r.PathId.Equals(pathId)).ToListAsync();
        }

        public async Task<Video> AddAsync(Video review)
        {
            _context.Videos.Add(review);

            await _context.SaveChangesAsync();

            return review;
        }

        public async Task UpdateAsync(Video video)
        {
            //Review might not be tracked (attached) by the entity framework -> get original from DB and copy values
            var original = _context.Videos.Find(video.Id);
            var entry = _context.Entry(original);
            entry.CurrentValues.SetValues(video);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entityToDelete = _context.Videos.Find(id);
            _context.Videos.Remove(entityToDelete);

            await _context.SaveChangesAsync();
        }

        public IEnumerable<Video> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IList<VideoPath>> GetAllVideoPathAsync()
        {
            return await _context.VideoPaths.ToListAsync();
        }

        public async Task<IList<Video>> GetByPathIdAsync(int pathId)
        {
            return await _context.Videos.Where(r => r.PathId == pathId).ToListAsync();
        }

        public async Task<VideoPath> AddVideoPathAsync(VideoPath videoPath)
        {
            _context.VideoPaths.Add(videoPath);

            await _context.SaveChangesAsync();

            return videoPath;
        }

        public async Task<IList<Video>> AddRangeAsync(IEnumerable<Video> videos)
        {
            _context.Videos.AddRange(videos);
            await _context.SaveChangesAsync();
            return videos as List<Video>;
        }
    }
}
