using System;
using System.Collections.Generic;

namespace EasyXNoteApp.Services
{
    public interface IDataService
    {
        // IEnumerable<string> GetUser();
        string GetUsers();
        string GetUserProfiles();
    }
}
