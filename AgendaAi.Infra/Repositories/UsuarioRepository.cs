﻿using Application.Models;

namespace Application.Data.Repositories
{
    public class UsuarioRepository
    {
        private readonly AgendaContext _context;

        public UsuarioRepository(AgendaContext context)
        {
            _context = context;
        }
        public Usuario BuscarPorId(Guid idUsuario)
        {
            // O nome da tabela de Usuarios é Usuario
            Usuario usuario = _context.Usuario.FirstOrDefault(u => u.IdPessoa == idUsuario) ?? new Usuario();
            return usuario;
        }

        public Usuario BuscarPorEmail(string email)
        {
            Usuario usuario = _context.Usuario.FirstOrDefault(u => u.Email == email) ?? new Usuario();
            return usuario;
        }

        public Usuario BuscarPorUsername(string username)
        {
            Usuario usuario = _context.Usuario.FirstOrDefault(u => u.Username == username) ?? new Usuario();
            return usuario;
        }

        public void Cadastrar(Usuario usuario)
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

            _context.Usuario.Add(usuario);
            _context.SaveChanges();
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
    }
}
