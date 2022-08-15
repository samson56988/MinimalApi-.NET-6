using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DbAccess;
using DataAccess.Models;

namespace DataAccess.Data
{
    public class UserData:IUserData
    {
        private readonly ISqlDataAccess _db;

        public UserData(ISqlDataAccess db)
        {
            _db = db;
        }


        public Task<IEnumerable<UserModel>> GetUsers() =>
            _db.LoadData<UserModel, dynamic>(storedprocedure: "dbo.spUser_GetAll", new { });

        public async Task<UserModel> GetUser(int Id)
        {

            var result = await _db.LoadData<UserModel, dynamic>(storedprocedure: "dbo.spUser_Get",
                new { Id = Id });
            return result.FirstOrDefault();
        }

        public Task InsertUser(UserModel user) =>
            _db.SaveData(storedProcedure: "dbo.spUser_Add", new { user.FirstName, user.Lastname });

        public Task UpdateUser(UserModel user) =>
            _db.SaveData(storedProcedure:"dbo.spUser_Update", user);

        public Task DeleteUser(int Id) =>
            _db.SaveData(storedProcedure:"dbo.spUser_Delete",new {Id = Id});

       
    }
}
