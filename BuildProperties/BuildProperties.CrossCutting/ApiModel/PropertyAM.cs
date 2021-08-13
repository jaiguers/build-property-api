using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BuildProperties.CrossCutting.ApiModel
{
    public class PropertyAM
    {
        public long IdProperty { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        public decimal Price { get; set; }

        public string InternalCode { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        public int Year { get; set; }
        public long IdOwner { get; set; }
        public long IdState { get; set; }

        public OwnerAM Owner { get; set; }

        public List<PropertyImageAM> PropertyImage { get; set; }
        public List<PropertyTraceAM> PropertyTrace { get; set; }
    }
}
