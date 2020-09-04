using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ECommerce_Entities;
using ECommerce_Exceptions;

namespace ECommerce_DataAcessLayer
{
    public class ECDAL
    {
        List<ECEntities> ProductList = new List<ECEntities>();

        static List<ECEntities> CustomerList = new List<ECEntities>();

        List<ECEntities> CartList = new List<ECEntities>();


        public static string fileName = "ProductDetails.txt";


        //Add product---Admin//
        public bool AddProductDAL(ECEntities plan)
        {


            bool added = false;
            try
            {
                ProductList.Add(plan);
                Serialization();
                added = true;
            }
            catch (SystemException cex)
            {
                throw new ECExceptions(cex.Message);
            }
            return added;
        }


        //Update product---admin//
        public bool UpdateProductDAL(ECEntities ec)
        {
            
            bool updated = false;
            try
            {
                for (int i = 0; i < ProductList.Count; i++)
                {
                    if (ProductList[i].ProductID == ec.ProductID)
                    {
                        ProductList[i].ProductName = ec.ProductName;
                        ProductList[i].Description = ec.Description;
                        ProductList[i].Quantity = ec.Quantity;
                        ProductList[i].Price = ec.Price;
                        updated = true;
                    }
                }
               Serialization();
            }
            catch (SystemException cex)
            {
                throw new ECExceptions(cex.Message);
            }
            return updated;
        }


        //Search product--Admin//
        public ECEntities SearchProductDAL(String id)
        {
            Deserialization();
            ECEntities product = new ECEntities();
            try
            {
                product = ProductList.Find(ec => ec.ProductID == id);
            }
            catch (SystemException cex)
            {
                throw new ECExceptions(cex.Message);
            }
            return product;

        }


        //Display product---Admin//
        public List<ECEntities> DisplayAllDAL()
        {
            try
            {
                Deserialization();

                return ProductList;
            }
            catch (SystemException cex)
            {
                throw new ECExceptions(cex.Message);
            }
        }


        //Delete product--Admin//
        public bool RemoveProductDAL(String id)
        {
            bool removed = false;
            ProductList.Clear();
            Deserialization();
            ECEntities product = new ECEntities();
            try
            {
                product = ProductList.Find(ec => ec.ProductID == id);
                if (product != null)
                {
                    ProductList.Remove(product);
                    removed = true;
                    Serialization();
                }


            }
            catch (SystemException cex)
            {
                throw new ECExceptions(cex.Message);
            }

            return removed;
        }


        //Add to cart//
        public bool AddtoCartDAL(ECEntities product)
        {


            bool added = false;
            try
            {
                CartList.Add(product);
                Serialization();
                added = true;
            }
            catch (SystemException cex)
            {
                throw new ECExceptions(cex.Message);
            }
            return added;
        }


        //-------Display products in cart-----//
        public List<ECEntities> DisplayCartDAL()
        {
            try
            {
                Deserialization();

                return CartList;
            }
            catch (SystemException cex)
            {
                throw new ECExceptions(cex.Message);
            }
        }



        public void Serialization()
        {

            try
            {
                FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fileStream, ProductList);
                fileStream.Close();
                ProductList.Clear();
            }
            catch (SystemException cex)
            {
                throw new ECExceptions(cex.Message);
            }
        }


        public void Deserialization()
        {
            try
            {
                FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                List<ECEntities> EList = binaryFormatter.Deserialize(fileStream) as List<ECEntities>;
                ProductList.Clear();
                foreach (ECEntities ed in EList)
                    ProductList.Add(ed);
                fileStream.Close();
            }
            catch (SystemException cex)
            {
                throw new ECExceptions(cex.Message);
            }
        }



    }
}
