using Coderin.Base;
using Coderin.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coderin.BLL
{
    interface IRepository<T> where T : EntityBase
    {
        /// <summary>
        /// Entity Eklemek için kullanılır.
        /// </summary>
        /// <param name="item">EntityBase'ten türemek zorundadır.</param>
        bool Add(T item);

        /// <summary>
        /// Entity silmek için kullanılır.
        /// </summary>
        /// <param name="item">EntityBase'ten türemek zorundadır.</param>
        bool Remove(Guid id);

        /// <summary>
        /// Entity silmek için kullanılır.
        /// </summary>
        /// <param name="item">EntityBase'ten türemek zorundadır.</param>
        bool RemoveReal(Guid id);

        /// <summary>
        /// Entity Update için kullanılır.
        /// </summary>
        /// <param name="item">EntityBase'ten türemek zorundadır.</param>
        bool Update(T item);

        /// <summary>
        /// Geriye id'si verilen entity'yi döndürür.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get(Guid id);

        /// <summary>
        /// Lambda sorguları ile data getirmek için kullanılabilir.
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        IEnumerable<T> GetBy(Func<T, bool> exp);

        /// <summary>
        /// Verilen Expressionın varolup olmadığını kontrol eder.
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        bool Any(Func<T, bool> exp);

        /// <summary>
        /// Tüm aktif itemları getirir.
        /// </summary>
        /// <returns></returns>
        List<T> GetAll();
        /// <summary>
        /// Tüm itemları getirir.
        /// Silinenler dahil.
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAllOfItems();

        /// <summary>
        /// Tüm Silinenleri Getirir.
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetDeleteds();

        /// <summary>
        /// Tüm Pasifleri Getirir.
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetPassives();

        bool Save();
    }
}
