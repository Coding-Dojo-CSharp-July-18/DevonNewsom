using System.Collections.Generic;

namespace DojoLeagueEF.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Ninja> AllNinjas {get;set;}
        public IEnumerable<Dojo> AllDojos {get;set;}
    }
}