using System.ComponentModel.DataAnnotations;

namespace DojoLeagueEF.Models
{
    public class Ninja
    {
        [Key]
        public int NinjaId {get;set;}
        public int DojoId {get;set;}
        public string Name {get;set;}
        public int Level {get;set;}
        public string Description {get;set;}
        public Dojo MyDojo {get;set;}

    }
}