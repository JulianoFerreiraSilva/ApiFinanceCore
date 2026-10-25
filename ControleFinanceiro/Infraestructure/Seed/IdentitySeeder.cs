using ControleFinanceiro.Infraestructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace ControleFinanceiro.Infraestructure.Seed
{
    public class IdentitySeeder
    {
        public static async Task SeedAsync(UserManager<Usuario> userManager, 
            RoleManager<IdentityRole<Guid>> roleManager, IConfiguration configuration)
        {
            var userName = configuration["Seed:Admin:UserName"];
            var password = configuration["Seed:Admin:Password"];

            if(string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
            {
                throw new InvalidOperationException("As credenciais do usuário administrador não foram configuradas.");
            }

            const string roleName = "Administrador";

            if(!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole<Guid>(roleName));
            }

            var usuario = await userManager.FindByNameAsync(userName);

            if(usuario is null)
            {
                usuario = new Usuario
                {
                    UserName = userName,
                    Email = userName
                };

                var resultado = await userManager.CreateAsync(usuario, password);

                if (!resultado.Succeeded)
                {
                    var erros = string.Join("; ", resultado.Errors.Select(e => e.Description));

                    throw new InvalidOperationException($"Não foi possivel criar o usuário administrador: {erros}");
                }
            }

            if(!await userManager.IsInRoleAsync(usuario, roleName))
            {
                await userManager.AddToRoleAsync(usuario, roleName);
            }
        }
    }
}
