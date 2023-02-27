using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27._2
{
    public class UzivatelDAO
    {
        public Uzivatel? GetByID(int id)
        {
            Uzivatel? u = null;
            SqlConnection connection = Connection.getInstance();
            // 1. declare command object with parameter
            using (SqlCommand command = new SqlCommand("SELECT * FROM Uzivatel WHERE id = @Id", connection))
            {
                // 2. define parameters used in command 
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@Id";
                param.Value = id;

                // 3. add new parameter to command object
                command.Parameters.Add(param);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    u = new Uzivatel(
                        Convert.ToInt32(reader[0].ToString()),
                        reader[1].ToString(),
                        reader[2].ToString()
                        );
                }
                reader.Close();
            }
            return u;
        }

        public void Save(Uzivatel u)
        {
            SqlConnection conn = Connection.getInstance();

            SqlCommand command = null;

            if (u.Id < 1)
            {
                using (command = new SqlCommand("INSERT INTO Uzivatel (username, password) VALUES (@username, @password)", conn))
                {
                    command.Parameters.Add(new SqlParameter("@username", u.Username));
                    command.Parameters.Add(new SqlParameter("@password", u.Password));
                    command.ExecuteNonQuery();
                    command.CommandText = "Select @@Identity";
                    u.Id = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            else
            {
                using (command = new SqlCommand("UPDATE Uzivatel SET username = @username, password = @password " +
                    "WHERE id = @id", conn))
                {
                    command.Parameters.Add(new SqlParameter("@id", u.Id));
                    command.Parameters.Add(new SqlParameter("@username", u.Username));
                    command.Parameters.Add(new SqlParameter("@password", u.Password));
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
