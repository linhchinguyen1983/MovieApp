namespace MovieApi.Model.Dto
{
    public class LoginResponse
    {
        public bool Status {  get; set; }
        //public string Token {  get; set; }
        public Guid UserId {  get; set; }
    }
}
