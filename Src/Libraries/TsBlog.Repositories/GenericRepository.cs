using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using SqlSugar;

namespace TsBlog.Repositories
{
    #region 创建仓储
    //public class GenericRepository<T> : SimpleClient<T> where T : class, new()
    //{
    //    public GenericRepository(ISqlSugarClient context = null)
    //        : base(context)//注意这里要有默认值等于null
    //    {
    //        if (context == null)
    //        {
    //            base.Context = new SqlSugarClient(new ConnectionConfig()
    //            {
    //                DbType = SqlSugar.DbType.SqlServer,
    //                InitKeyType = InitKeyType.Attribute,
    //                IsAutoCloseConnection = true,
    //                ConnectionString = Config.ConnectionString
    //            });
    //        }
    //    }

    //    /// <summary>
    //    /// 扩展方法，自带方法不能满足的时候可以添加新方法
    //    /// </summary>
    //    /// <returns></returns>
    //    public List<T> CommQuery(string json)
    //    {
    //        //base.Context.Queryable<T>().ToList();可以拿到SqlSugarClient 做复杂操作
    //        return null;
    //    }

    //}
    #endregion

    public abstract class GenericRepository<T> : IDependency, IRepository<T> where T : class, new()
    {
        public T FindById(object pkValue)
        {
            using (var db = DbFactory.GetSqlSugarClient())
            {
                var entity = db.Queryable<T>().InSingle(pkValue);
                return entity;
            }
        }

        public IEnumerable<T> FindAll()
        {
            using (var db = DbFactory.GetSqlSugarClient())
            {
                var list = db.Queryable<T>().ToList();
                return list;
            }
        }

        public IEnumerable<T> FindListByClause(Expression<Func<T, bool>> predicate, string orderBy = "")
        {
            using (var db = DbFactory.GetSqlSugarClient())
            {
                var entities = db.Queryable<T>().Where(predicate).ToList();
                return entities;
            }
        }

        public T FindByClause(Expression<Func<T, bool>> predicate)
        {
            using (var db = DbFactory.GetSqlSugarClient())
            {
                var entity = db.Queryable<T>().First(predicate);
                return entity;
            }
        }

        public long Insert(T entity)
        {
            using (var db = DbFactory.GetSqlSugarClient())
            {
                var i = db.Insertable(entity).ExecuteReturnBigIdentity();
                return i;
            }
        }

        public bool Update(T entity)
        {
            using (var db = DbFactory.GetSqlSugarClient())
            {
                var i = db.Updateable(entity).ExecuteCommand();
                return i > 0;
            }
        }

        public bool Update(T entity, Expression<Func<T,object>> columns)
        {
            using (var db = DbFactory.GetSqlSugarClient())
            {
                var i = db.Updateable(entity).IgnoreColumns(columns).ExecuteCommand();
                return i > 0;
            }
        }

        public bool Delete(T entity)
        {
            using (var db = DbFactory.GetSqlSugarClient())
            {
                var i = db.Deleteable(entity).ExecuteCommand();
                return i > 0;
            }
        }

        public bool Delete(Expression<Func<T, bool>> @where)
        {
            using (var db = DbFactory.GetSqlSugarClient())
            {
                var i = db.Deleteable<T>(@where).ExecuteCommand();
                return i > 0;
            }
        }

        public bool DeleteById(object id)
        {
            using (var db = DbFactory.GetSqlSugarClient())
            {
                var i = db.Deleteable<T>(id).ExecuteCommand();
                return i > 0;
            }
        }

        public bool DeleteByIds(object[] ids)
        {
            using (var db = DbFactory.GetSqlSugarClient())
            {
                var i = db.Deleteable<T>().In(ids).ExecuteCommand();
                return i > 0;
            }
        }

        public IPagedList<T> FindPagedList(Expression<Func<T, bool>> predicate, string orderBy = "", int pageIndex = 1, int pageSize = 20)
        {
            using (var db = DbFactory.GetSqlSugarClient())
            {
                var totalCount = 0;
                var sql = db.Queryable<T>().OrderBy(orderBy).ToSql();
                var page = db.Queryable<T>().OrderBy(orderBy).ToPageList(pageIndex, pageSize, ref totalCount);
                var list = new PagedList<T>(page, pageIndex, pageSize, totalCount);
                return list;
            }
        }
    }
}
