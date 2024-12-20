namespace pessoasAPI.src.Model;

public class Pessoa 
{
    public int Id { get; set; }
    public required string Nome { get; set; }
    public int Idade { get; set; }
    public required string Email { get; set; }
    public List<Endereco> Enderecos { get; set; } = [];
}