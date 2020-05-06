using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BestBuyBestPractices
{
    class DapperProductRepository : IProductRepository
    {
       private readonly IDbConnection _connection;
            public DapperProductRepository(IDbConnection connection)
            {
                _connection = connection;
            }
             public IEnumerable<Product> GetAllProducts()
             {
            return _connection.Query<Product>("SELECT * FROM PRODUCTS;");
             }

              public void CreateProduct(string name, int price, int categoryID)
              {
            _connection.Execute("INSERT INTO PRODUCT (Name, price, categoryID) VALUES (@newproductName, @newPrice, @newCatID );",

                new { newProductName = name, newPrice = price, newCatID = categoryID });
              }
    }
    
}
