using Autenticacao.Dominio.Usuarios.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Autenticacao.Dominio.Usuarios.Repositorios
{
    public interface IUsuariosRepositorio
    {
        IQueryable<Usuario> Query();
        Usuario Recuperar(Expression<Func<Usuario, bool>> expression);
    }
}
