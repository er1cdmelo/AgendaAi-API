using Application.Application.AppServices;
using Application.Data.Entities;
using Application.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Data.Repositories
{
    public class UsuarioRepository
    {
        private readonly AgendaContext _context;

        public UsuarioRepository(AgendaContext context)
        {
            _context = context;
        }

        public UsuarioRepository()
        {
            _context = new AgendaContext();
        }

        public Usuario BuscarPorId(int idUsuario)
        {
            // O nome da tabela de Usuarios é Usuario
            Usuario usuario = _context.Usuario.AsNoTracking().Include(u => u.Profissional).Include(u => u.Cliente)
                .FirstOrDefault(u => u.IdUsuario == idUsuario) ?? new Usuario();
            if(usuario.Cliente != null)
            {
                usuario.Cliente.Usuario = null;
            }
            if(usuario.Profissional != null)
            {
                usuario.Profissional.Usuario = null;
            }
            return usuario;
        }

        public Usuario BuscarPorEmail(string email)
        {
            Usuario usuario = _context.Usuario.AsNoTracking().Where(u => u.Email == email).Include(u => u.Profissional).Include(u => u.Cliente).FirstOrDefault() ?? new Usuario();
            if (usuario.Cliente != null)
            {
                usuario.Cliente.Usuario = null;
            }
            if (usuario.Profissional != null)
            {
                usuario.Profissional.Usuario = null;
            }
            return usuario;
        }

        public Usuario BuscarPorUsername(string username)
        {
            Usuario usuario = _context.Usuario.FirstOrDefault(u => u.Username == username) ?? new Usuario();
            return usuario;
        }

        public Usuario Cadastrar(Usuario usuario)
        {
            // Verifica se o email e o username já estão cadastrados
            var existeEmail = BuscarPorEmail(usuario.Email);
            if (!String.IsNullOrEmpty(existeEmail.Username))
            {
                throw new Exception("Email já cadastrado");
            }
            var existeUsername = BuscarPorUsername(usuario.Username);
            if(!String.IsNullOrEmpty(existeUsername.Username))
            {
                throw new Exception("Username já cadastrado");
            }

            usuario.Senha = PasswordAppServices.HashPassword(usuario.Senha);

            _context.Usuario.Add(usuario);
            _context.SaveChanges();
            return usuario;
        }

        public void Atualizar(Usuario usuario)
        {
            _context.Usuario.Update(usuario);
            _context.SaveChanges();
        }

        public void Deletar(Usuario usuario)
        {
            _context.Usuario.Remove(usuario);
            _context.SaveChanges();
        }

        public void Dispose ()
        {
            _context.Dispose();
        }
    }
}
