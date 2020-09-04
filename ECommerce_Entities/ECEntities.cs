using System;

namespace ECommerce_Entities
{
    [Serializable]
    public class ECEntities
    {
        //Product Entity

        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string Quantity { get; set; }
        public string Price { get; set; }

        
        //Cart Entity
        public string ProdName { get; set; }
        public string Addtocart { get; set; }
    }


}
