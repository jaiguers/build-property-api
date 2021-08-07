using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BuildProperties.CrossCutting.ApiModel
{
    public class OwnerAM
    {
        public long IdOwner { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        public string Identification { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        public string Photo { get; set; }
        public DateTime? Birthday { get; set; }
    }
}
