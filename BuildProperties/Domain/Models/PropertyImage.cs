using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    [Table("Property_Image")]
    public partial class PropertyImage
    {
        [Column("Id_Property_Image", TypeName = "bigint")]
        [Key]
        public long IdPropertyImage { get; set; }

        [Column("Id_Property", TypeName = "bigint")]
        public long IdProperty { get; set; }

        [Column("Files", TypeName = "varchar(150)")]
        public string Files { get; set; }

        [Column("Id_State", TypeName = "bigint")]
        public long IdState { get; set; }

        [ForeignKey("IdState")]
        public virtual State State { get; set; }

        [ForeignKey("IdProperty")]
        public virtual Property Property { get; set; }
    }
}
