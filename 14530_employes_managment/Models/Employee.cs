namespace _14530_employes_managment.Models
{
    public class Employee: UserActivity
    {
        public int id {  get; set; }

        public required string EmpNo { get; set; }

        public required string FirstName { get; set; }

        public required string MiddleName { get; set; }

        public required string LastName { get; set; }

        public string FullName => $"{FirstName} {MiddleName} {LastName}";

        public int PhoneNumber { get; set; }    

        public required string EmailAddress { get; set; }

        public required string Country { get; set; }

        public DateTime DateOfBirth { get; set; }

        public required string Address { get; set; }

        public required string Department { get; set; }
        public required string Designation { get; set; }



    }
}
