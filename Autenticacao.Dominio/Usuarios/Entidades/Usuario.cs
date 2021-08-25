using System;
using System.Collections.Generic;
using System.Text;

namespace Autenticacao.Dominio.Usuarios.Entidades
{
    public class Usuario
    {
        public virtual long Codigo { get; protected set; }
        public virtual string Nome { get; protected set; }
               
    }
}
