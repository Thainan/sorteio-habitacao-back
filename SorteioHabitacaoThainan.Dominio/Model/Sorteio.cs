using SorteioHabitacaoThainan.Dominio;

namespace SorteioHabitacaoThainan.Dominio.Model
{
    public class Sorteio
    {
        public IEnumerable<Pessoa> Geral { get; set; }
        public IEnumerable<Pessoa> Idoso { get; set; }
        public IEnumerable<Pessoa> DeficienteFisico { get; set; }

        public int totalParticipantes { get; set; }
    }
}
