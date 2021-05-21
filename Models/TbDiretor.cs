using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace filmes_api_rest.Models
{
    [Table("tb_diretor")]
    public partial class TbDiretor
    {
        [Key]
        [Column("id_diretor")]
        public int IdDiretor { get; set; }
        [Column("nm_diretor", TypeName = "varchar(100)")]
        public string NmDiretor { get; set; }
        [Column("dt_nascimento", TypeName = "date")]
        public DateTime? DtNascimento { get; set; }
        [Column("id_filme")]
        public int? IdFilme { get; set; }

        [ForeignKey(nameof(IdFilme))]
        [InverseProperty(nameof(TbFilme.TbDiretor))]
        public virtual TbFilme IdFilmeNavigation { get; set; }
    }
}
