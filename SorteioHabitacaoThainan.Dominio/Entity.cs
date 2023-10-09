using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace SorteioHabitacaoThainan.Dominio
{
    public abstract class Entity
    {
        [Column("ID")]
        public int Id { get; set; }
    }
}
