using System.Collections.Generic;

namespace DojoSecrets.Models
{
    public class LogRegModel
    {
        public LoginUser Login {get;set;}
        public RegistrationUser Registration {get;set;}
    }
    public class DashboardViewModel
    {
        // public Secret NewSecret {get;set;}
        public IEnumerable<Secret> RecentSecrets {get;set;}
        public int ActiveUserId {get;set;}
    }
}