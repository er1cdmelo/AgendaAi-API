using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Domain.Entities
{
    public class Preferencia
    {
        public Preferencia()
        {
            IdPreferencia = 0;
            CdPreferencia = string.Empty;
            DsPreferencia = string.Empty;
            IdTipoPreferencia = 0;
            ValorPreferencia = string.Empty;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPreferencia { get; set; }
        public string CdPreferencia { get; set; }
        public string DsPreferencia { get; set; }
        public int IdTipoPreferencia { get; set; }
        public string ValorPreferencia { get; set; }
    }
}
