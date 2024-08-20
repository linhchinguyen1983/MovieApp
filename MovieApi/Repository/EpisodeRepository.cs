using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.Model.DomainModel;

namespace MovieApi.Repository
{
    public class EpisodeRepository : IEpisodeRepository
    {
        private readonly MovieDbContext _movieDbContext;
        public EpisodeRepository(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

        public async Task<Episode?> AddEpisodeAsync(Episode episode)
        {
            try
            {
                var newEpisode = await _movieDbContext.AddAsync(episode);
                await _movieDbContext.SaveChangesAsync();
                return newEpisode.Entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public async Task<bool> DeleteEpisodeAsync(Guid id)
        {
            var episode = await _movieDbContext.Episodes.FindAsync(id);
            if (episode != null)
            {
                _movieDbContext.Episodes.Remove(episode);
                await _movieDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }


        public async Task<List<Episode>> GetAllEpisodeAsync(Guid movieId)
        {
            var episodes = await(from e in _movieDbContext.Episodes
                                 where e.MovieId == movieId
                                 select
                                 new Episode
                                 {
                                     Id = e.Id,
                                     EpisodeNumber = e.EpisodeNumber,
                                     ReleaseDate = e.ReleaseDate,
                                     Duration = e.Duration,
                                     Description = e.Description,
                                     Source = e.Source,
                                     MovieId = movieId
                                 }).ToListAsync();
            return episodes;
        }

        public async Task<Episode?> GetEpisodeByIdAsync(Guid episodeId, Guid movieId)
        {
            return await _movieDbContext.Episodes
                .Where(e => e.MovieId == movieId && e.Id == episodeId)
                .FirstOrDefaultAsync();
        }

        public async Task<Episode>? UpdateEpisodeAsync(Guid id, Episode episode)
        {
            try
            {
                var updateEp = await _movieDbContext.Episodes.FindAsync(id);
                updateEp.EpisodeNumber = episode.EpisodeNumber;
                updateEp.ReleaseDate = episode.ReleaseDate;
                updateEp.Duration = episode.Duration;
                updateEp.Description = episode.Description;
                updateEp.Source = episode.Source;
                await _movieDbContext.SaveChangesAsync();
                return updateEp;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
