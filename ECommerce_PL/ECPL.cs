using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce_Entities;
using ECommerce_Exceptions;
using ECommerce_DataAcessLayer;
using ECommerce_BusinessLayer;

namespace ECommerce_PL
{
    class ECPL
    {
        static void Main(string[] args)
        {
            try
            {
                int choice;
                do
                {
                    PrintTypeofUser();
                    Console.WriteLine("Enter your choice");
                    choice = Int32.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            AdministratorPL();
                            Console.ReadLine();
                            Console.Clear();

                            break;

                        case 2:
                            CustomerPL();
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case 3:
                            return;
                        default:
                            Console.WriteLine("Invalid choice");
                            break;
                    }
                } while (choice != -1);

            }
            catch (ECExceptions ex)
            {
                Console.WriteLine(ex.Message);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void AdministratorPL()
        {
            try
            {
                int choice;
                do
                {
                        Administratorchoice();
                        Console.WriteLine("Enter your choice");
                        choice = Int32.Parse(Console.ReadLine());
                        switch (choice)
                        {
                            case 1:
                                AddProductPL();
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            case 2:
                                DisplayAllProductPL();
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            case 3:
                                UpdateProductPL();
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            case 4:
                                SearchProductPL();
                                Console.ReadLine();
                                Console.Clear();
                                break;

                            case 5:
                                DeleteProductPL();
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            case 6:
                                return;
                            default:
                                Console.WriteLine("Invalid choice");
                                break;


                        }
                    } while (choice != -1) ;
                }
                

            catch (ECExceptions ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        public static void CustomerPL()
        {
            try
            {
                int choice;
                do
                {
                    CustomerChoice();
                    Console.WriteLine("Enter your choice");
                    choice = Int32.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            DisplayAllProductPL();
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case 2:
                            SearchProductPL();
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case 3:
                            AddtoCartPL();
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case 4:
                            DisplayProductsinCartPL();
                            Console.ReadLine();
                            Console.Clear();
                            break;

                        case 5:
                            return;
                        default:
                            Console.WriteLine("Invalid choice");
                            break;
                    }
                } while (choice != -1);

            }
            catch (ECExceptions ex)
            {
                Console.WriteLine(ex.Message);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        //-------------Adding products---------//
        public static void AddProductPL()
        {
            ECEntities ec = new ECEntities();
            try
            {
                Console.Clear();
                Console.WriteLine("*******************************************************************************");
                Console.WriteLine("                                 Add product Details                           ");
                Console.WriteLine("********************************************************************************");
                Console.WriteLine("Enter the ID");
                ec.ProductID = Console.ReadLine();
                Console.WriteLine("Enter the Name ");
                ec.ProductName = Console.ReadLine();
                Console.WriteLine("Enter the Description ");
                ec.Description = Console.ReadLine();
                Console.WriteLine("Enter the quantity");
                ec.Quantity = Console.ReadLine();
                Console.WriteLine("Enter the price");
                ec.Price = Console.ReadLine();

                bool added = ECBL.AddProductBL(ec);
                if (added)
                    Console.WriteLine("Product added successfully");
                else
                    Console.WriteLine("Product not added ");
            }
            catch (ECExceptions ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



        //-----------Update products-----------//
        public static void UpdateProductPL()
        {
            string productid;
            try
            {
                Console.Clear();
                Console.WriteLine("*******************************************************************************");
                Console.WriteLine("                                 Update Product Details                       ");
                Console.WriteLine("******************************************************************************");
                Console.WriteLine("Enter the Product:(ID)");
                productid = Console.ReadLine();
                ECEntities product = ECBL.SearchProductBL(productid);
                if (product != null)
                {
                    Console.WriteLine("Enter the Name of product:");
                    product.ProductName = Console.ReadLine();
                    Console.WriteLine("Enter the Description:");
                    product.Description = Console.ReadLine();
                    Console.WriteLine("Enter the quantity:");
                    product.Quantity = Console.ReadLine();
                    Console.WriteLine("Enter the price:");
                    product.Price = Console.ReadLine();

                    bool updated = ECBL.UpdateProductBL(product);
                    if (updated)
                        Console.WriteLine("Product is updated");
                    else
                        Console.WriteLine("Product is not updated");
                }
                else
                    Console.WriteLine("Product ID not found");
            }
            catch (ECExceptions ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        //-------------Search products--------//
        public static void SearchProductPL()
        {
            string productid;
            ECEntities product;
            try
            {
                Console.Clear();
                Console.WriteLine("************************************************************************************");
                Console.WriteLine("                                 Search Product                          ");
                Console.WriteLine("************************************************************************************");
                Console.WriteLine("Enter the Product(ID):)");
                productid = Console.ReadLine();
                product = ECBL.SearchProductBL(productid);
                if (product != null)
                {
                    Console.WriteLine("Product is found");
                    Console.WriteLine("*********************************************************************************");
                    Console.WriteLine("ProductId:" + product.ProductID + "\n ProductName:" + product.ProductName + "\n Description" + product.Description + "\n Quantity" + product.Quantity + "\n Price" + product.Price);
                    Console.WriteLine("*********************************************************************************");

                }
                else
                    Console.WriteLine("Product not found");

            }
            catch (ECExceptions ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        //------------Display products----------//
        public static void DisplayAllProductPL()
        {
            List<ECEntities> products = new List<ECEntities>();
            try
            {
                Console.Clear();
                Console.WriteLine("************************************************************************************");
                Console.WriteLine("                                 Display All Products                          ");
                Console.WriteLine("************************************************************************************");
                products = ECBL.DisplayAllProductBL();
                Console.WriteLine("*********************************************************************************");
               foreach (ECEntities product in products)
                {
                  Console.WriteLine("ProductId:" + product.ProductID + "\n ProductName:" + product.ProductName + "\n  Description" + product.Description + "\n Quantity" + product.Quantity + "\n Price" + product.Price);
                }
           }
         catch (ECExceptions ex)
          {
               Console.WriteLine(ex.Message);
           }
        }


        //-------------Delete products----------//
        public static void DeleteProductPL()
        {
            try
            {
                Console.Clear();
                string productid;
                Console.WriteLine("************************************************************************************");
                Console.WriteLine("                                 Remove Product Details                           ");
                Console.WriteLine("************************************************************************************");
                Console.WriteLine("Enter product id:");
                productid = Console.ReadLine();

                bool removed = ECBL.RemoveProductBL(productid);
                if (removed)
                    Console.WriteLine("Product is removed successfully");
                else
                    Console.WriteLine("Details are not removed as ProductId is not found ");
            }

            catch (ECExceptions ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        //-----------Add products to cart-----------//
        public static void AddtoCartPL()
        {
            ECEntities ec = new ECEntities();
            try
            {
                Console.Clear();
                Console.WriteLine("*******************************************************************************");
                Console.WriteLine("                                 Add to Cart                          ");
                Console.WriteLine("********************************************************************************");
                Console.WriteLine("Enter the Name of the product:");
                ec.ProdName = Console.ReadLine();
                Console.WriteLine("Add to cart(Yes or No): ");
                ec.Addtocart = Console.ReadLine();
            
                bool added = ECBL.AddtoCartBL(ec);
                if (added)
                    Console.WriteLine("Product added to cart successfully");
                else
                    Console.WriteLine("Product not added ");
            }
            catch (ECExceptions ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }




        //---------------Display products in cart------------//
        public static void DisplayProductsinCartPL()
        {
            List<ECEntities> cart = new List<ECEntities>();
            try
            {
                Console.Clear();
                Console.WriteLine("************************************************************************************");
                Console.WriteLine("                                 Products in cart");
                Console.WriteLine("************************************************************************************");
                cart = ECBL.DisplayCartBL();
                Console.WriteLine("*********************************************************************************");
                foreach (ECEntities product in cart)
                {
                    Console.WriteLine("ProductName:" + product.ProdName+"AddedtoCart:"+product.Addtocart );
                }
            }
            catch (ECExceptions ex)
            {
                Console.WriteLine(ex.Message);
            }
        }




        public static void PrintTypeofUser()
        {
            Console.WriteLine("****************************************************************************");
            Console.WriteLine("                               E-Commerce                          ");
            Console.WriteLine("****************************************************************************");
            Console.WriteLine("1.Administrator");
            Console.WriteLine("2.Customer");
            Console.WriteLine("3.Exit");
        }


        public static void Administratorchoice()
        {
            Console.WriteLine("****************************************************************************");
            Console.WriteLine("                             WELCOME ADMINISTRATOR                           ");
            Console.WriteLine("****************************************************************************");
            Console.WriteLine("1.Add product");
            Console.WriteLine("2.Display products");
            Console.WriteLine("3.Update product");
            Console.WriteLine("4.Search product");
            Console.WriteLine("5.Delete product");
            Console.WriteLine("6.Exit");
        }

        public static void CustomerChoice()
        {
            Console.WriteLine("****************************************************************************");
            Console.WriteLine("                              WELCOME CUSTOMER                        ");
            Console.WriteLine("****************************************************************************");
            Console.WriteLine("1.Display products");
            Console.WriteLine("2.Search product");
            //Console.WriteLine("3.Buy a product");
            Console.WriteLine("3.Add to Cart");
            Console.WriteLine("4.Cart details");
            Console.WriteLine("5.Exit");
        }
    }
    
}
