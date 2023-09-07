using System.ComponentModel.DataAnnotations;

namespace APIPruebaLG.Models
{
    public class usuarios
    {
        [Key]
        public string codigoUsuario { get; set; }
        public short codigoDepartamento { get; set; }
        public short codigoCargo { get; set; }
        public string? nombres { get; set; }
        public string? apellidos { get; set; }
        public string email { get; set; }
        public bool estadoUsuario { get; set; }
        public string? usuarioCreacion { get; set; }
        public DateTime? fechaCreacion { get; set; }
        public string? equipoCreacion { get; set; }
        public string? usuarioModificacion { get; set; }
        public DateTime? fechaModificacion { get; set; }
        public string? equipoModificacion { get; set; }

    }
}
