using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    [Table("Property_Trace")]
    public partial class PropertyTrace
    {
        [Column("Id_Property_Trace", TypeName = "bigint")]
        [Key]
        public long IdPropertyTrace { get; set; }

        [Column("Date_Sale", TypeName = "date")]
        public DateTime DateSale { get; set; }

        [Column("Name", TypeName = "varchar(200)")]
        public string Name { get; set; }

        [Column("Name", TypeName = "decimal")]
        public decimal Value { get; set; }

        [Column("Name", TypeName = "decimal")]
        public decimal Tax { get; set; }

        [Column("Id_Property", TypeName = "bigint")]
        public long IdProperty { get; set; }

        [ForeignKey("IdProperty")]
        public virtual Property Property { get; set; }
    }
}
