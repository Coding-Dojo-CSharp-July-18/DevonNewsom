using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DojoLeagueEF.Models
{
    public class Dojo
    {
        [Key]
        public int DojoId {get;set;}
        public string Name {get;set;}
        public string Location {get;set;}
        public string Description {get;set;}

        public IEnumerable<Ninja> Ninjas {get;set;}
    }
}