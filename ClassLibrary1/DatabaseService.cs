using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResources.Data
{
    public class DatabaseService : IHumanResourcesDB
    {
        private HumanResourceDataEntities _db = new HumanResourceDataEntities();

        public UserModel GetUserByUsername(string username)
        {
            var foundUserList = from user in _db.Users
                            where user.Username == username
                            select user;

            return new UserModel(foundUserList.First());
        }

        public void SaveDataModel(Object model)
        {
            _db.Entry(model).State = System.Data.EntityState.Modified;
            _db.SaveChanges();
        }

        public void GenerateLoginAttempt(string username, bool success)
        {
            LoginHistory loginAttempt = new LoginHistory
            {
                LoginAttemptTime = DateTime.Now,
                Username = username,
                Successful = success
            };

            _db.LoginHistories.Add(loginAttempt);
            _db.SaveChanges();
        }
    }
}
