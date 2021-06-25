using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TsBlog.Domain.Entities;
using TsBlog.Repositories;

namespace TsBlog.Services
{
    public interface IPostService : IDependency, IService<Post>
    {
        IEnumerable<Post> FindHomePagePosts(int limit = 20);

        /// <summary>
        /// 根据ID查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //Post FindById(int id);

        /// <summary>
        /// 查询所有数据，注：大量数据请慎用
        /// </summary>
        /// <returns></returns>
        //IEnumerable<Post> FindAll();

        /// <summary>
        /// 写入实体数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        //long Insert(Post entity);

        /// <summary>
        /// 更新实体数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        //bool Update(Post entity);

        /// <summary>
        /// 根据实体删除一条数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        //bool Delete(Post entity);

        /// <summary>
        /// 根据ID删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //bool DeleteById(object id);

        /// <summary>
        /// 根据指定的ID集合删除数据（批量删除）
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        //bool DeleteByIds(object[] ids);
    }
}
