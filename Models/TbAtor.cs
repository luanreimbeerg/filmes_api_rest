using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace filmes_api_rest.Models
{
    [Table("tb_ator")]
    public partial class TbAtor
    {
        public TbAtor()
        {
            TbFilmeAtor = new HashSet<TbFilmeAtor>();
        }

        [Key]
        [Column("id_ator")]
        public int IdAtor { get; set; }
        [Column("nm_ator", TypeName = "varchar(100)")]
        public string NmAtor { get; set; }
        [Column("vl_altura", TypeName = "decimal(10,2)")]
        public decimal? VlAltura { get; set; }
        [Column("dt_nascimento", TypeName = "date")]
        public DateTime? DtNascimento { get; set; }

        [InverseProperty("IdAtorNavigation")]
        public virtual ICollection<TbFilmeAtor> TbFilmeAtor { get; set; }
    }
}
