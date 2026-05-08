namespace _14530_employes_managment.Models
{
    // Classe base de auditoria reutilizada por entidades que precisam de rastreio.
    public class UserActivity
    {
        public string? CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }

        public string? ModifiedById { get; set; }
        public DateTime ModifiedOn { get; set; }

    }
}
