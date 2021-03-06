using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Domain.Models
{
    [Table("Owner")]
    public class Owner
    {
        [Column("Id_Owner", TypeName = "bigint")]
        [Key]
        public long IdOwner { get; set; }

        [Column("Identification", TypeName = "varchar(50)")]
        public string Identification { get; set; }

        [Column("Name", TypeName = "varchar(200)")]
        public string Name { get; set; }

        [Column("Address", TypeName = "varchar(100)")]
        public string Address { get; set; }

        [Column("Photo", TypeName = "varchar(150)")]
        public string Photo { get; set; }

        [Column("Birthday", TypeName = "date")]
        public DateTime? Birthday { get; set; }
    }
}
