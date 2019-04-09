using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDomain.Entities
{
  public   class Sondage
    {

        public int SondageID { get; set; }
        //2 cles etrangeres
        public int EventID { get; set; }
        public int UserID { get; set; }
        public String Titre { get; set; }
        public String Contenu { get; set; }
        public DateTime DateExpiration { get; set; }
        public String Resultat { get; set; }
        public virtual ICollection<User> UsersSon { get; set; }



    }
}
