using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects {
    public class ArticuloDTO {
        [Display(Name = "Id del Artículo")]
        public int Id { get; set; }
        [Display(Name = "Nombre del Artículo")]
        public string Nombre { get; set; }
        [Display(Name = "Descripción del Artículo")]
        public string Descripcion { get; set; }
        
    }
}
