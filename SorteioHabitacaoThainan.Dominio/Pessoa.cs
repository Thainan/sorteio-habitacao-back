using System.ComponentModel.DataAnnotations.Schema;

namespace SorteioHabitacaoThainan.Dominio
{
    public enum EnumCota
    {
        GERAL = 1,
        IDOSO = 2,
        DEFICIENTEFISICO = 3
    };

    [Table("PESSOA")]
    public class Pessoa : Entity
    {
        [Column("NOME")]
        public string Nome { get; set; }

        [Column("CPF")]
        public string Cpf { get; set; }

        [Column("DATA_NASCIMENTO")]
        public DateTime DataNascimento { get; set; }

        [Column("RENDA")]
        public Decimal Renda { get; set; }

        [Column("ID_COTA")]
        public EnumCota Cota { get; set; }


        [Column("CID")]
        public string? CID { get; set; }

        [NotMapped]
        public bool cpfValido { get; set; }

        [NotMapped]
        public int idade { get; set; }

        [NotMapped]
        public bool cidOk { get; set; }

        //public Pessoa(int id, string nome, string cpf, DateTime dataNascimento, Decimal renda, EnumCota cota) : base(id)
        //{
        //    Nome = nome;
        //    Cpf = cpf;
        //    DataNascimento = dataNascimento;
        //    Renda = renda;
        //    Cota = cota;
        //    //CID = cid;
        //}
    }
}