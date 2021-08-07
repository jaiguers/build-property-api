using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Domain.Models
{
    [Table("State")]
    public class State
    {
        [Column("Id_State", TypeName = "bigint")]
        [Key]
        public long IdState { get; set; }

        [Column("Description", TypeName = "varchar")]
        public string Description { get; set; }
    }
}
