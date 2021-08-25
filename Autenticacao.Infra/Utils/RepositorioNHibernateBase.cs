using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Autenticacao.Infra.Utils
{
    public class RepositorioNHibernateBase<T>
    {
        public ISession Session { get; }

        public RepositorioNHibernateBase(ISession session)
        {
            Session = session; 
        }

        public virtual IQueryable<T> Query()
        {
            return Session.Query<T>();
        }

        public virtual T Recuperar(long id)
        {
            return Session.Get<T>(id);
        }

        public T Recuperar(Expression<Func<T,bool>> expression)
        {
            return Query().SingleOrDefault(expression);
        }

        public T Salvar(T entidade)
        {
            Session.SaveOrUpdate(entidade);
            Session.Flush();
            return entidade;
        }

        public T Editar(T entidade)
        {
            Session.Update(entidade);
            return entidade;
        }

        public void Excluir(T entidade)
        {
            Session.Delete(entidade);
        }

        public void Excluir(IEnumerable<T> entidades)
        {
            foreach(T entidade in entidades)
            {
                Excluir(entidade);
            }
        }

        public void Inserir(T entidade)
        {
            Session.Save(entidade);
        }

        public void Inserir(IEnumerable<T> entidades)
        {
            foreach(T entidade in entidades)
            {
                Session.Save(entidade);
            }
        }
        /// <summary>
        /// Refaz a consulta atualizadno o cache do NHibernate
        /// Caso de uso; Quando é necessário enxergar por uma query do
        /// nhibernate alguma query realizada juntamente pelo dapper,
        /// ou o efeito de alguma trigger que foi disparada pela ação 
        /// </summary>
        /// <param name="entidade"></param>
        public void Refresh(T entidade)
        {
            Session.Refresh(entidade);
        }
    }
}
