using Autenticacao.Dominio.Usuarios.Entidades;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autenticacao.Infra.Usuarios.Mapeamentos
{
    public class UsuariosMap : ClassMap<Usuario>
    {
        public UsuariosMap()
        {
            Schema("DELTA");
            Table("GEN_USUARIO");
            Id(x => x.Codigo).Column("CODUSUARIO");
            Map(x => x.Nome).Column("DSCNOME");

            ReadOnly();
        }
    }
}
