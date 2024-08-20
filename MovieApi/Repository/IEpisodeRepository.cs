using MovieApi.Model.DomainModel;

namespace MovieApi.Repository
{
    public interface IEpisodeRepository
    {
        public Task<List<Episode>> GetAllEpisodeAsync(Guid movieId);

        public Task<Episode?> AddEpisodeAsync(Episode episode);  // Thêm một tập phim mới

        public Task<Episode?> GetEpisodeByIdAsync(Guid episodeId, Guid movieId);  // Lấy tập phim theo ID

        public Task<bool> DeleteEpisodeAsync(Guid id);  // Xóa tập phim theo ID

        public Task<Episode>? UpdateEpisodeAsync(Guid id, Episode episode);  // Cập nhật tập phim theo ID
    }
}
