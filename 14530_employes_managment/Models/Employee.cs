using System.ComponentModel.DataAnnotations;

namespace _14530_employes_managment.Models
{
    // Entidade principal do projeto: representa um empregado persistido na base de dados.
    public class Employee: UserActivity
    {
        public int id {  get; set; }

        public required string EmpNo { get; set; }

        public required string FirstName { get; set; }

        public required string MiddleName { get; set; }

        public required string LastName { get; set; }

        // Nome completo calculado sem guardar uma coluna extra na base de dados.
        public string FullName => $"{FirstName} {MiddleName} {LastName}";

        public int PhoneNumber { get; set; }    

        public required string EmailAddress { get; set; }

        public required string Country { get; set; }


        public DateTime DateOfBirth { get; set; }

        public required string Address { get; set; }

        public Department Department { get; set; }

        public required string Designation { get; set; }



    }
}
