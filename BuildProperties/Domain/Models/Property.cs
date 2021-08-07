using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Domain.Models
{
    [Table("Property")]
    public partial class Property
    {
        [Column("Id_Property", TypeName = "bigint")]
        [Key]
        public long IdProperty { get; set; }

        [Column("Name", TypeName = "varchar(250)")]
        public string Name { get; set; }

        [Column("Address", TypeName = "varchar(100)")]
        public string Address { get; set; }

        [Column("Price", TypeName = "decimal")]
        public decimal Price { get; set; }

        [Column("Internal_Code", TypeName = "varchar(10)")]
        public string InternalCode { get; set; }

        [Column("Year", TypeName = "int")]
        public int Year { get; set; }

        [Column("Id_Owner", TypeName = "bigint")]
        public long IdOwner { get; set; }

        [Column("Id_State", TypeName = "bigint")]
        public long IdState { get; set; }

        [ForeignKey("IdState")]
        public virtual State State { get; set; }
    }
}
