using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TsBlog.Domain.Entities;

namespace TsBlog.Repositories
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public IEnumerable<Post> FindHomePagePosts(int limit = 20)
        {
            using (var db = DbFactory.GetSqlSugarClient())
            {
                var list = db.Queryable<Post>().OrderBy(x => x.Id, SqlSugar.OrderByType.Desc).Take(limit).ToList();
                return list;
            }
        }

        //public Post FindById(int id)
        //{
        //    #region ADO.NET操作数据库
        //    //var ds = MySqlHelper.Query("Select * From tb_post WHERE Id = @Id", new MySqlParameter("@Id", id));
        //    //var entity = ds.Tables[0].ToList<Post>().FirstOrDefault();
        //    //return entity;
        //    #endregion

        //    #region SqlSugar操作数据库
        //    using (var db = DbFactory.GetSqlSugarClient())
        //    {
        //        var entity = db.Queryable<Post>().Single(x => x.Id == id);
        //        return entity;
        //    }
        //    #endregion
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //public IEnumerable<Post> FindAll()
        //{
        //    #region ADO.NET操作数据库
        //    //var ds = MySqlHelper.Query("Select * from tb_post");
        //    //return ds.Tables[0].ToList<Post>();
        //    #endregion

        //    #region SqlSugar操作数据库
        //    using (var db = DbFactory.GetSqlSugarClient())
        //    {
        //        var list = db.Queryable<Post>().ToList();
        //        return list;
        //    }
        //    #endregion
        //}

        //public int Insert(Post entity)
        //{
        //    using (var db = DbFactory.GetSqlSugarClient())
        //    {
        //        var i = db.Insertable(entity).ExecuteReturnBigIdentity();
        //        return (int)i;
        //    }
        //}

        //public bool Update(Post entity)
        //{
        //    using (var db = DbFactory.GetSqlSugarClient())
        //    {
        //        var i = db.Updateable(entity).ExecuteCommand();
        //        return i > 0;
        //    }
        //}

        //public bool Delete(Post entity)
        //{
        //    using (var db = DbFactory.GetSqlSugarClient())
        //    {
        //        var i = db.Deleteable(entity).ExecuteCommand();
        //        return i > 0;
        //    }
        //}

        //public bool DeleteById(object id)
        //{
        //    using (var db = DbFactory.GetSqlSugarClient())
        //    {
        //        var i = db.Deleteable<Post>(id).ExecuteCommand();
        //        return i > 0;
        //    }
        //}

        //public bool DeleteByIds(object[] ids)
        //{
        //    using (var db = DbFactory.GetSqlSugarClient())
        //    {
        //        var i = db.Deleteable<Post>().In(ids).ExecuteCommand();
        //        return i > 0;
        //    }
        //}
    }
}
