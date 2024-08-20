using System;

namespace MovieApi.Model.Dto
{
    public class UpdateEpisodeDto
    {
        public int EpisodeNumber { get; set; }  // Số tập trong mùa

        public DateTime? ReleaseDate { get; set; }  // Ngày phát hành của tập phim (tùy chọn)

        public int? Duration { get; set; }  // Thời lượng của tập phim (tùy chọn)

        public string Description { get; set; }  // Mô tả ngắn về tập phim (tùy chọn)

        public string Source { get; set; }  // Đường dẫn hoặc URL đến nguồn của tập phim (tùy chọn)
    }
}
