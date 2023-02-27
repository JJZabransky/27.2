using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27._2
{
    public class ZpravaDAO
    {
        public void Delete(Zprava z)
        {
            SqlConnection conn = Connection.getInstance();

            using (SqlCommand command = new SqlCommand("DELETE FROM Zprava WHERE id = @id", conn))
            {
                command.Parameters.Add(new SqlParameter("@id", z.Id));
                command.ExecuteNonQuery();
                z.Id = 0;
            }
        }
        public void Save(Zprava z)
        {
            SqlConnection conn = Connection.getInstance();

            SqlCommand command = null;

            if (z.Id < 1)
            {
                using (command = new SqlCommand("INSERT INTO Zprava (komu, predmet, cas) VALUES (@komu, @predmet, @cas)", conn))
                {
                    command.Parameters.Add(new SqlParameter("@komu", z.Komu));
                    command.Parameters.Add(new SqlParameter("@predmet", z.Predmet));
                    command.Parameters.Add(new SqlParameter("@cas", z.Cas));
                    command.ExecuteNonQuery();
                    //zjistim id posledniho vlozeneho zaznamu
                    command.CommandText = "Select @@Identity";
                    z.Id = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            else
            {
                using (command = new SqlCommand("UPDATE Zprava SET komu = @komu, predmet = @predmet, cas = @cas" +
                    "WHERE id = @id", conn))
                {
                    command.Parameters.Add(new SqlParameter("@id", z.Id));
                    command.Parameters.Add(new SqlParameter("@jmeno", z.Komu));
                    command.Parameters.Add(new SqlParameter("@prijmeni", z.Predmet));
                    command.Parameters.Add(new SqlParameter("@cas", z.Cas));
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
