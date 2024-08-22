namespace MovieApi.Model.Dto
{
    public class NewsRequestDto
    {
        public string Image { get; set; }
        public DateTime? CreateAt { get; set; }  = DateTime.Now;
    }
}
