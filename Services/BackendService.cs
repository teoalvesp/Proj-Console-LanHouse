public static class BackendService
{

    public static bool ValidateLogin(string user, string password)
    {
        if (user == "adm" && password == "123")
        {
            return true;
        }
        return false;
    }



}