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
        Video GetById(int id);
        Video Add(Video restaurant);
        void Update(Video restaurant);
        void Delete(int id);

        Task<IList<Video>> GetAllAsync();
        Task<Video> GetByIdAsync(int id);
        Task<Video> GetByPathIdAsync(int id);
        Task<Video> AddAsync(Video review);
        Task UpdateAsync(Video review);
        Task DeleteAsync(int id);
        Task<VideoPath> GetByPathAsync(string path);
    }
}
