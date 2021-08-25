using Autenticacao.Dominio.Usuarios.Entidades;
using Autenticacao.Dominio.Usuarios.Repositorios;
using Autenticacao.Infra.Utils;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autenticacao.Infra.Usuarios.Repositorios
{
    public class UsuariosRepositorio : RepositorioNHibernateBase<Usuario>, IUsuariosRepositorio
    {
        public UsuariosRepositorio(ISession session) : base(session)
        {

        }
    }
}
