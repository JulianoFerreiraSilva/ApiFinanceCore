using ControleFinanceiro.Application.Authentication.DTO;
using ControleFinanceiro.Application.Common.Interfaces.Authentication;
using ControleFinanceiro.Infraestructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace ControleFinanceiro.Infraestructure.Authentication
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<Usuario> _userManager;

        public IdentityService(UserManager<Usuario> userManager)
        {
            _userManager = userManager;
        }

        private async Task<UsuarioTokenDto> CriaUsuarioTokenDtoAsync(Usuario usuario)
        {
            var roles = await _userManager.GetRolesAsync(usuario);

            return new UsuarioTokenDto
            {
                Id = usuario.Id,
                Roles = roles.ToList()
            };
        }

        public async Task<UsuarioTokenDto?> AutenticarAsync(string userName, string password)
        {
            var usuario = await _userManager.FindByNameAsync(userName);

            if (usuario is null)
                return null;

            var senhaValida = await _userManager.CheckPasswordAsync(usuario, password);

            if (!senhaValida)
                return null;

            var roles = await _userManager.GetRolesAsync(usuario);

            return await CriaUsuarioTokenDtoAsync(usuario);
        }

        public async Task<UsuarioTokenDto?> ObterPorIdAsync(Guid usuarioId)
        {
            var usuario = await _userManager.FindByIdAsync(usuarioId.ToString());

            if (usuario is null)
            {
                return null;
            }

            var roles = await _userManager.GetRolesAsync(usuario);

            return await CriaUsuarioTokenDtoAsync(usuario);
        }
    }
}
