namespace HumanResources.Data
{
    public class DatabaseServiceFactory
    {
        public static IHumanResourcesDB getDatabaseService()
        {
            return new DatabaseService();
        }
    }
}