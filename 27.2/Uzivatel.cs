using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27._2
{
    public class Uzivatel
    {
        private int id;
        private string username;
        private string password;

        public int Id { get { return id; } set { id = value; } }
        public string Username { get { return username; } set { username = value; } }
        public string Password { get { return password; } set { password = value; } }

        public Uzivatel(int id, string username, string password) 
        {
            this.id = id;
            this.username = username;
            this.password = password;
        }
    }
}
