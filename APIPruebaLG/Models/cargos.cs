using System.ComponentModel.DataAnnotations;

namespace APIPruebaLG.Models
{
    public class cargos
    {
        [Key]
        public short codigoCargo { get; set; }
        [Key]
        public short codigoDepartamento { get; set; }
        public string descripcionCargo { get; set; }
        public bool estadoCargo { get; set; }
    }
}
