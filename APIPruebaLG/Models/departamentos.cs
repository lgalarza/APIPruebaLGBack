using System.ComponentModel.DataAnnotations;

namespace APIPruebaLG.Models
{
    public class departamentos
    {
        [Key]
        public short codigoDepartamento { get; set; }
        public string nombreDepartamento { get; set; }
        public bool estadoDepartamento { get; set; }
    }
}
