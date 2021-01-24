using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework.Models
{
    [Table("PLANTILLA")]
    public class EmpleadoPlantilla
    {
        [Key]
        [Column("HOSPITAL_COD")]
        public int CodigoHospital { get; set; }
        [Column("SALA_COD")]
        public int CodigoSala { get; set; }
        [Column("EMPLEADO_NO")]
        public int CodigoEmpleado { get; set; }
        [Column("APELLIDO")]
        public string Apellido { get; set; }
        [Column("FUNCION")]
        public string Funcion { get; set; }
        [Column("T")]
        public string Turno { get; set; }
        [Column("SALARIO")]
        public int Salario { get; set; }

    }
}
