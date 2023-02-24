using System.ComponentModel.DataAnnotations;

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
            Employee employee = new Employee();
            //... Hämta från databasen ... 
            // .... kolla Kund.cs ....
            // .... låtsas svar från DB
            employee.password = "12345";
            employee.namn = "Johnny Flamingo"; 
            employee.mailadress = "master@mvc.com";
            employee.roll= "admin";
            employee.Id= 1; 

            // Men vad gör vi om den inte finns i databasen?

            return employee;
        }

    }
}
