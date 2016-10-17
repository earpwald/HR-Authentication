using HumanResources.Data;

namespace HumanResources.MVC.Authentication
{
    public class AuthenticationService : IAuthenticate
    {
        private IHumanResourcesDB _databaseService = DatabaseServiceFactory.getDatabaseService();

        public bool Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(username))
            {
                return false;
            }

            var user = _databaseService.GetUserByUsername(username);
            user.IncrementLoginAttempts();

            var successful = user.HasNotReachedLoginMax() && user.AuthenticateUserPassword(password);

            if (successful)
            {
                user.ResetLoginAttempts();
                _databaseService.SaveDataModel(user.GetDataModel());
            }

            _databaseService.GenerateLoginAttempt(username, successful);

            return successful;
        }
    }
}