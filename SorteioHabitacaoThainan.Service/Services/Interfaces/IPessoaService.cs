using SorteioHabitacaoThainan.Dominio;
using SorteioHabitacaoThainan.Dominio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteioHabitacaoThainan.Service.Services.Interfaces
{
    public interface IPessoaService
    {
        Sorteio Sortear();
        Sorteio ListaParticipante();

    }
}
