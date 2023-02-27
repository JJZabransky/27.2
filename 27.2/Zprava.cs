using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27._2
{
    public class Zprava
    {
        private int id;
        private string komu;
        private string predmet;
        DateTime cas = new DateTime();

        public int Id { get { return id; } set { id = value; } }
        public string Komu { get { return komu; } set { komu = value; } }
        public string Predmet { get { return predmet; } set { predmet = value; } }
        public DateTime Cas { get { return cas; } set { cas = value; } }

        public Zprava(int id, string komu, string predmet, DateTime cas) 
        {
            this.id = id;
            this.komu = komu;
            this.predmet = predmet;
            this.cas = cas;
        }
    }
}
