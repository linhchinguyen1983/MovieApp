using MovieApi.Model.DomainModel;

namespace MovieApi.Repository
{
    public interface IUserRepository
    {
        /// <summary>
        /// Check username and password 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<User?> AuthenticateAsync(string username, string password);
        /// <summary>
        /// Add user to database
        /// </summary>
        /// <param name="user"></param>
        /// <returns>return true if user created success , false if created failed </returns>
        Task<User?> RegisterAsync(User user);

        /// <summary>
        /// Give user permisson to access api's feature
        /// </summary>
        /// <param name="permissions">list permisson of user</param>
        /// <returns>true if success , false if failed</returns>
        Task<bool> GivePermission(User user, List<string> permissions); 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<string> GenerateTokenAsync(User user);

        /// <summary>
        /// get user id from token
        /// </summary>
        /// <param name="token"></param>
        /// <returns> return user id</returns>
        public string? GetUserIdFromTokenAsync(string token);
    }
}
