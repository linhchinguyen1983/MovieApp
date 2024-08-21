namespace MovieApi.Model.Dto
{
    public class CommentDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.Now;
        public DateTime? LastUpdate { get; set; }

    }
}
