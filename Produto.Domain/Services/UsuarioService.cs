﻿using Produto.Domain.Entities;
using Produto.Domain.Interfaces.Repositories;
using Produto.Domain.Interfaces.Services;

namespace Produto.Domain.Services
{
    public class UsuarioService : ServiceBase<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
            : base(usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;

        }

        public Usuario BuscarPorFacebookId(string facebookId)
        {
            return _usuarioRepository.BuscarPorFacebookId(facebookId);
        }

        public Usuario Login(string login, string senha)
        {
            return _usuarioRepository.Login(login, senha);
        }

        public bool LoginExiste(string login)
        {
            return _usuarioRepository.LoginExiste(login);
        }
        //---
        //ORQUESTRA, EXECUTA SERVIÇOS DE ALGUM LUGAR PARA ALGUM LUGAR
    }
}
