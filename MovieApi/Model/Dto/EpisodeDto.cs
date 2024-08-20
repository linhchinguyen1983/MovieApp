using System;
using System.ComponentModel.DataAnnotations;

namespace MovieApi.Model.Dto
{
    public class EpisodeDto
    {
        public Guid Id { get; set; }  // Khóa chính

        public int EpisodeNumber { get; set; }  // Số tập trong mùa

        public DateTime? ReleaseDate { get; set; }  // Ngày phát hành của tập phim

        public int? Duration { get; set; }  // Thời lượng của tập phim

        public string Description { get; set; }  // Mô tả ngắn về tập phim

        public string Source { get; set; }  // Đường dẫn hoặc URL đến nguồn của tập phim
    }
}
