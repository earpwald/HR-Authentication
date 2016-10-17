using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResources.Data
{
    public interface IHumanResourcesDB
    {
        UserModel GetUserByUsername(string username);
        void GenerateLoginAttempt(string username, bool success);
        void SaveDataModel(Object model);
    }
}
