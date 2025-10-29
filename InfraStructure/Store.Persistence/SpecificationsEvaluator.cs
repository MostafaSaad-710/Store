using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Store.Domain.Contracts;
using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Persistence
{
    public static class SpecificationsEvaluator
    {
        //Generate Dynamic Query
        public static IQueryable<TEntity> GetQuery<TKey ,TEntity>(IQueryable<TEntity> inputQuery,Ispecifications<TKey,TEntity> spec) where TEntity : BaseEntity<TKey>
        {
            var query = inputQuery; //_context.Products

            //chek Criteria to filter

            if (spec.Criteria is not null)
            {
                query = query.Where(spec.Criteria); //_context.Products.where(p => p.id = 12)
            }


            // ckeck expression whitch to order by with
            if(spec.OrderBy is not null)
            {
                query = query.OrderBy(spec.OrderBy);
            }
            else if(spec.OrderByDescending is not null)
            {
                query = query.OrderByDescending(spec.OrderByDescending);
            }

                //_context.Products.where(p => p.id = 12).inclode(p => p.Brand)
                //_context.Products.where(p => p.id = 12).inclode(p => p.Brand).include(p => p.Type)
                query = spec.Includes.Aggregate(query, (query, IncludeExpression) => query.Include(IncludeExpression));


            return query;

        }

    }
}
