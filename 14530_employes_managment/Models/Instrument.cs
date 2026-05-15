using System.ComponentModel.DataAnnotations;

namespace _14530_employes_managment.Models
{
    // Entidade instruments
    public class Instrument : UserActivity
    {
        public int id { get; set; }

        public required string TypeInstrument { get; set; }

        public required string InstrumentName { get; set; }

        public bool? UseStrings { get; set; }
    }
}
