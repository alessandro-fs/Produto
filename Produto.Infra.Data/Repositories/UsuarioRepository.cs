﻿using Produto.Domain.Entities;
using Produto.Domain.Interfaces.Repositories;
using System.Linq;

namespace Produto.Infra.Data.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public Usuario Login(string login, string senha)
        {
            return Db.Usuarios.Where(x => x.Login.Equals(login) && x.Senha.Equals(senha)).FirstOrDefault();
        }

        public Usuario BuscarPorFacebookId(string facebookId)
        {
            return Db.Usuarios.Where(x => x.FacebookId.Equals(facebookId)).FirstOrDefault();
        }

        public bool LoginExiste(string login)
        {
            return Db.Usuarios.Where(x => x.Login.ToUpper().Equals(login.ToUpper())).FirstOrDefault().Login.Length > 0 ? true : false;
        }
    }
}
