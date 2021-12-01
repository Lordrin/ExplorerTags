using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VideoTagPlayer.Domain.model;

namespace VideoTagPlayer.DataLayer
{
    public interface IVideoTagRepository
    {
        IEnumerable<Video> GetAll();

        Task<IList<Video>> GetAllVideoAsync();
        Task<IList<VideoPath>> GetAllVideoPathAsync();
        Task<Video> GetByIdAsync(int id);
        Task<IList<Video>> GetByPathIdAsync(int id);
        Task<IList<Video>> GetVideosByPathIdAsync(int pathId);
        Task<Video> AddAsync(Video video);
        Task<IList<Video>> AddRangeAsync(IEnumerable<Video> video);
        Task<VideoPath> AddVideoPathAsync(VideoPath videoPath);
        Task UpdateAsync(Video video);
        Task DeleteAsync(int id);
        Task<VideoPath> GetByPathAsync(string path);
    }
}
