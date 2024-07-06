using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    //class : referans tip olabilir demek
    //Ientity: IEntity olabilir veya implemente eden bir class olabilir.
    //new(): newlenebilir olmalı. Bunu eklememizin sebebi IEntityRepository<T> içerisindeki t yerine IEntity yazmamızı engellemektir.
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        //Expression yapısı lamda tarzı yapıyı kullanabilmemizi sağlıyor
        List<T> GetAll(Expression<Func<T, bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
