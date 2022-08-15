using DataAccess.DbAccess;
using DataAccess.Models;

namespace DataAccess.Data
{
    public interface IUserData
    {
        public Task DeleteUser(int Id);
        public Task<IEnumerable<UserModel>> GetUsers();
        public  Task<UserModel> GetUser(int Id);
        public Task InsertUser(UserModel user);
        public Task UpdateUser(UserModel user);
    }
}
