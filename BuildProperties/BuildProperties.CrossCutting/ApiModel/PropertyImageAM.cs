using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BuildProperties.CrossCutting.ApiModel
{
    public class PropertyImageAM
    {
        public long IdPropertyImage { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        public long IdProperty { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        public string Files { get; set; }

        public long IdState { get; set; }

        public PropertyAM Property { get; set; }
    }
}
