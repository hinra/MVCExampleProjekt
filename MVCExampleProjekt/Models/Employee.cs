using MVCExampleProjekt.Other;
using System.ComponentModel.DataAnnotations;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace MVCExampleProjekt.Models
{
    public class Employee
    {


       
        public int Id { get; set; }

        public string namn { get; set; }
        [Required(ErrorMessage = "Ange valid mailadress") ]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail har felaktigt format")]
        [Display(Name = "Din mailadress")]
        public string mailadress { get; set; }


        [Required(ErrorMessage = "Ange lösenord")]
        [Display(Name = "Ditt lösenord")]
        public string password { get; set; }

        
        public string roll { get; set; }

        public static Employee GetEmployeeByMail(string mail)
        {
           
            MySqlConnection conn = new MySqlConnection(DatabaseVariables.conStr);
            MySqlCommand MyCom = new MySqlCommand("Select * from Employee where mailadress = @ADDR", conn);
            MyCom.Parameters.AddWithValue("@ADDR", mail);
            conn.Open();

            MySqlDataReader reader = MyCom.ExecuteReader();


            Employee employee = new Employee();
            if (reader.Read())
            {
                employee.Id = reader.GetInt32("id");
                employee.namn = reader.GetString("namn");
                employee.mailadress = reader.GetString("mailadress");
                employee.roll = reader.GetString("roll");

            }
            else
            {
                // Men vad gör vi om den inte finns i databasen?
            }

            MyCom.Dispose();
            conn.Close();

            return employee;

           

           
        }

    }
}
