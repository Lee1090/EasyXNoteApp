using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyXNoteApp.Models
{
    public class UserProfile
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}