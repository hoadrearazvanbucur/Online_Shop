using Online_Shop.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Online_Shop.Services
{
    public class ProductServices
    {
        public ProductRepository productRepository;

        public ProductServices(string dataBase)
        {
            this.productRepository = new ProductRepository(dataBase);
        }

        public List<Pro>


    }
}
