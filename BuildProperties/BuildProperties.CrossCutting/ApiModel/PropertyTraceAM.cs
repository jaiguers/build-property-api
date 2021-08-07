using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BuildProperties.CrossCutting.ApiModel
{
    public class PropertyTraceAM
    {
        public long IdPropertyTrace { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        public DateTime DateSale { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        public decimal Value { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        public decimal Tax { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        public long IdProperty { get; set; }
    }
}
