using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using ECommerce_Entities;
using ECommerce_Exceptions;
using ECommerce_DataAcessLayer;

namespace ECommerce_BusinessLayer
{
    public class ECBL
    {
        public static bool Validate(ECEntities ec)
        {
            StringBuilder sb = new StringBuilder();

            bool validate = true;
            try
            {

                if (!validate)
                {
                    throw new ECExceptions(sb.ToString());
                }

            }
            catch (ECExceptions ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                throw ex;
            }
            return validate;
        }


        //Add product--Admin//
        public static bool AddProductBL(ECEntities ec)
        {

            bool added = false;
            try
            {
                if (Validate(ec))
                {
                    ECDAL ed = new ECDAL();
                    added = ed.AddProductDAL(ec);
                }
            }
            catch (ECExceptions ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return added;
        }


        //Update product---Admin//
        public static bool UpdateProductBL(ECEntities product)
        {
            bool updated = false;
            try
            {
                if (Validate(product))
                {
                    ECDAL ed = new ECDAL();
                    updated = ed.UpdateProductDAL(product);
                }
            }
            catch (ECExceptions ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return updated;
        }


        //Search product---Admin//
        public static ECEntities SearchProductBL(string ec)
        {
            ECEntities product = new ECEntities();
            try
            {
                ECDAL ed = new ECDAL();
                product = ed.SearchProductDAL(ec);
            }
            catch (ECExceptions ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return product;
        }


        //Display products--Admin//
        public static List<ECEntities> DisplayAllProductBL()
        {
            List<ECEntities> productList = new List<ECEntities>();
            try
            {
                ECDAL ec = new ECDAL();
                productList = ec.DisplayAllDAL();

            }
            catch (ECExceptions ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return productList;
        }


        //Delete product--Admin//
        public static bool RemoveProductBL(string ec)
        {
            bool removed = false;
            try
            {
                ECDAL ed = new ECDAL();
                removed = ed.RemoveProductDAL(ec);

            }
            catch (ECExceptions ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return removed;
        }


        //Add to cart//
        public static bool AddtoCartBL(ECEntities ec)
        {

            bool added = false;
            try
            {
                if (Validate(ec))
                {
                    ECDAL ed = new ECDAL();
                    added = ed.AddtoCartDAL(ec);
                }
            }
            catch (ECExceptions ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return added;
        }



        //--------Display products in cart---------//
        public static List<ECEntities> DisplayCartBL()
        {
            List<ECEntities> cartList = new List<ECEntities>();
            try
            {
                ECDAL ec = new ECDAL();
                cartList = ec.DisplayCartDAL();

            }
            catch (ECExceptions ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return cartList;
        }

    }
}
