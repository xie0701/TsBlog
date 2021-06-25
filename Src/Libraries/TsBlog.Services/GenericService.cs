using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TsBlog.Repositories;
using System.Linq.Expressions;

namespace TsBlog.Services
{
    public abstract class GenericService<T> : IService<T>,IDependency where T :class,new()
    {
        private readonly IRepository<T> _repository;

        protected GenericService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public T FindById(object pkValue)
        {
            return _repository.FindById(pkValue);
        }

        public IEnumerable<T> FindAll()
        {
            return _repository.FindAll();
        }

        public IEnumerable<T> FindListByClause(Expression<Func<T, bool>> predicate, string orderBy = "")
        {
            return _repository.FindListByClause(predicate, orderBy);
        }

        public T FindByClause(Expression<Func<T, bool>> predicate)
        {
            return _repository.FindByClause(predicate);
        }

        public long Insert(T entity)
        {
            return _repository.Insert(entity);
        }

        public bool Update(T entity)
        {
            return _repository.Update(entity);
        }

        public bool Update(T entity, Expression<Func<T, object>> columns)
        {
            return _repository.Update(entity, columns);
        }

        public bool Delete(T entity)
        {
            return _repository.Delete(entity);
        }

        public bool Delete(Expression<Func<T, bool>> @where)
        {
            return _repository.Delete(@where);
        }

        public bool DeleteById(object id)
        {
            return _repository.DeleteById(id);
        }

        public bool DeleteByIds(object[] ids)
        {
            return _repository.DeleteByIds(ids);
        }

        /// <summary>
        /// 根据条件查询分页数据
        /// </summary>
        /// <param name="predicate">条件</param>
        /// <param name="orderBy">排序</param>
        /// <param name="pageIndex">当前索引</param>
        /// <param name="pageSize">分布大小</param>
        /// <returns></returns>
        public IPagedList<T> FindPagedList(Expression<Func<T, bool>> predicate, string orderBy = "", int pageIndex = 1, int pageSize = 20)
        {
            return _repository.FindPagedList(predicate, orderBy, pageIndex, pageSize);
        }
    }
}
