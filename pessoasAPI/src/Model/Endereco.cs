namespace pessoasAPI.src.Model
{
    public class Endereco
    {
        public int Id { get; set; }
        public required string Bairro { get; set; }
        public required string Cidade { get; set; }
        public required string Estado { get; set; }
        public required string Rua { get; set; }
        public required string Numero { get; set; }
        public int PessoaId { get; set; }
    }
}