using SorteioHabitacaoThainan.Data.Repositories.Interfaces;
using SorteioHabitacaoThainan.Dominio;
using SorteioHabitacaoThainan.Service.Services.Interfaces;
using System.Linq.Expressions;
using SorteioHabitacaoThainan.Util;
using SorteioHabitacaoThainan.Dominio.Model;

namespace SorteioHabitacaoThainan.Service.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaService(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public Sorteio Sortear()
        {
            var sorteio = new Sorteio();

            sorteio.Geral = SortearGeral();
            sorteio.Idoso = SortearIdoso();
            sorteio.DeficienteFisico = SortearDeficienteFisico();

            sorteio.totalParticipantes = sorteio.Geral.Count() + sorteio.Idoso.Count() + sorteio.DeficienteFisico.Count();

            return sorteio;
        }

        public Sorteio ListaParticipante()
        {
            var sorteio = new Sorteio();

            sorteio.Geral = RetornaCotaGeralApto().ToList();
            sorteio.Idoso = RetornaCotaIdosoApto().ToList();
            sorteio.DeficienteFisico = RetornaCotaDeficienteFisicoApto().ToList();

            sorteio.totalParticipantes = sorteio.Geral.Count() + sorteio.Idoso.Count() + sorteio.DeficienteFisico.Count();

            return sorteio;
        }

        public IEnumerable<Pessoa> RetornaCotaGeralApto()
        {
            var list = _pessoaRepository.Obter(filtroGeral()).Result;

            var listValida = retornaGeralValido(list);

            return listValida.ToList();
        }

        public IEnumerable<Pessoa> RetornaCotaIdosoApto()
        {
            var list = _pessoaRepository.Obter(filtroIdoso()).Result;

            var listValida = retornaIdosolValido(list);

            return listValida.ToList();
        }

        public IEnumerable<Pessoa> RetornaCotaDeficienteFisicoApto()
        {
            var list = _pessoaRepository.Obter(filtroDeficienteFisico()).Result;

            var listValida = retornaDeficienteFisicoValido(list);

            return listValida.ToList();
        }


        #region SORTEIO
        public IEnumerable<Pessoa> SortearGeral()
        {
            var lista = RetornaCotaGeralApto();

            var rnd = new Random();

            return lista.OrderBy(item => rnd.Next()).Take(3);
        }

        public IEnumerable<Pessoa> SortearIdoso()
        {
            var lista = RetornaCotaIdosoApto();

            var rnd = new Random();

            return lista.OrderBy(item => rnd.Next()).Take(1);
        }

        public IEnumerable<Pessoa> SortearDeficienteFisico()
        {
            var lista = RetornaCotaDeficienteFisicoApto();

            var rnd = new Random();

            return lista.OrderBy(item => rnd.Next()).Take(1);
        }
        #endregion

        #region FILTROS

        Expression<Func<Pessoa, bool>> filtroGeral()
        {
            Expression<Func<Pessoa, bool>> filter =
            p =>
            (p.Renda >= 1045.00m && p.Renda <= 5225.00m)
            //&& StringUtil.validaCPF(p.Cpf) == true
            //&& StringUtil.retornaIdade(p.DataNascimento) > 15
            && p.Cota == EnumCota.GERAL;

            return filter;
        }

        Expression<Func<Pessoa, bool>> filtroIdoso()
        {
            Expression<Func<Pessoa, bool>> filter =
            p =>
            (p.Renda >= 1045.00m && p.Renda <= 5225.00m)
            //&& StringUtil.validaCPF(p.Cpf)
            //&& StringUtil.retornaIdade(p.DataNascimento) > 60
            && p.Cota == EnumCota.IDOSO;

            return filter;
        }

        Expression<Func<Pessoa, bool>> filtroDeficienteFisico()
        {
            Expression<Func<Pessoa, bool>> filter =
            p =>
            (p.Renda >= 1045.00m && p.Renda <= 5225.00m)
            //&& StringUtil.validaCPF(p.Cpf)
            //&& StringUtil.retornaIdade(p.DataNascimento) > 15
            && p.Cota == EnumCota.DEFICIENTEFISICO;
            //&& String.IsNullOrEmpty(p.CID);

            return filter;
        }

        IEnumerable<Pessoa> retornaGeralValido(IEnumerable<Pessoa> list)
        {
            var listNova = list.Select(p => new Pessoa
            {
                Id = p.Id,
                Nome = p.Nome,
                Cpf = StringUtil.mascararCpf(p.Cpf),
                DataNascimento = p.DataNascimento,
                Renda = p.Renda,
                Cota = p.Cota,
                cpfValido = StringUtil.validaCPF(p.Cpf),
                idade = StringUtil.retornaIdade(p.DataNascimento)

            }).Where(p => p.cpfValido && p.idade > 15);

            return listNova;
        }

        IEnumerable<Pessoa> retornaIdosolValido(IEnumerable<Pessoa> list)
        {
            var listNova = list.Select(p => new Pessoa
            {
                Id = p.Id,
                Nome = p.Nome,
                Cpf = StringUtil.mascararCpf(p.Cpf),
                DataNascimento = p.DataNascimento,
                Renda = p.Renda,
                Cota = p.Cota,
                cpfValido = StringUtil.validaCPF(p.Cpf),
                idade = StringUtil.retornaIdade(p.DataNascimento)

            }).Where(p => p.cpfValido && p.idade > 60);

            return listNova;
        }

        IEnumerable<Pessoa> retornaDeficienteFisicoValido(IEnumerable<Pessoa> list)
        {
            var listNova = list.Select(p => new Pessoa
            {
                Id = p.Id,
                Nome = p.Nome,
                Cpf = StringUtil.mascararCpf(p.Cpf),
                DataNascimento = p.DataNascimento,
                Renda = p.Renda,
                Cota = p.Cota,
                cpfValido = StringUtil.validaCPF(p.Cpf),
                idade = StringUtil.retornaIdade(p.DataNascimento),
                cidOk = !String.IsNullOrEmpty(p.CID)

            }).Where(p => p.cpfValido && p.cidOk);

            return listNova;
        }
        #endregion
    }
}
