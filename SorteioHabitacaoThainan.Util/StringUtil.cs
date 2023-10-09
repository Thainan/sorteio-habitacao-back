using System.Security.Cryptography;

namespace SorteioHabitacaoThainan.Util
{
    public static class StringUtil
    {
        public static string mascararCpf(string cpf)
        {
            var cpfNovo = "";

            cpfNovo = cpf.Substring(0, 3) + ".XXX.XXX-X" + cpf[13];

            return cpfNovo;
        }

        public static int retornaIdade(DateTime dataNascimento)
        {
            int idade;
            var dataAtual = DateTime.Now;

            idade = dataAtual.Year - dataNascimento.Year;

            return idade;
        }

        public static bool validaCPF(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();

            var valido = cpf.EndsWith(digito);
            return valido;
        }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> list)
        {
            Random r = new Random(DateTime.Now.Millisecond);

            T[] array = list.ToArray();
            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = r.Next(i + 1);
                T tmp = array[j];
                array[j] = array[i];
                array[i] = tmp;
            }
            foreach (var item in array)
            {
                yield return item;
            }
        }
    }
}