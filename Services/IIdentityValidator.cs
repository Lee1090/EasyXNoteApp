namespace EasyXNoteApp.Services
{
    public interface IIdentityValidator
    {
        bool IsValidUser(string userName, string password);
    }
}