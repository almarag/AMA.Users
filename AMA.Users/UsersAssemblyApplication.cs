namespace AMA.Users
{
    using System.Reflection;

    public class UsersAssemblyApplication
    {
        public Assembly GetAssembly()
        {
            return typeof(UsersAssemblyApplication).GetTypeInfo().Assembly;
        }
    }
}
