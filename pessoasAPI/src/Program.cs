using pessoasAPI.src.Data;
using Microsoft.EntityFrameworkCore;

namespace pessoasAPI.src;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddDbContext<PessoaEnderecoDb>(options =>
        {
            options.UseInMemoryDatabase("PessoaEnderecoDb");
        });

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}