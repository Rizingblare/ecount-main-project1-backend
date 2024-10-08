﻿using System.Collections.Generic;

namespace Command
{
    public class SelectProductDac : BaseCommand<SelectRequestDto, CommandResultWithBody<List<Product>>>
    {
        public override void ExecuteCore()
        {
            (var sql, var parameters) = QueryBuilderFactory
                .Select(Request.Fields)
                .From(Request.TableName)
                .Where(Request.WhereConditions)
                .OrderBy(Request.OrderByConditions)
                .Limit(Request.Limit)
                .Offset(Request.Offset)
                .Build();

            var dbManager = new DbManager();
            Result.Body = dbManager.Query<Product>(sql, parameters, ProductResultMapper.Map);
        }
    }
}
