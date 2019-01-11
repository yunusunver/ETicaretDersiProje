using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETicaretDersiProje.Eticaret.Business.Abstract;
using ETicaretDersiProje.Eticaret.Entities.Concrete;
using ETicaretDersiProje.Eticaret.MvcWebUI.Filters;

namespace ETicaretDersiProje.Eticaret.MvcWebUI.Controllers
{
    public class CartController : Controller
    {
        private IProductService _productService;

        public CartController(IProductService productService)
        {
            _productService = productService;
        }
        [Auth]
        // GET: Cart
        public ActionResult Index()
        {
           
            List<Cart> cart=new List<Cart>();
            cart = (List<Cart>)Session["sepet"];
            if (Session["sepet"]!=null)
            {
                Session["total"] = cart.Sum(x => x.Total);
            }
            
            return View();
        }
        [Auth]
        public ActionResult AddCart(int id)
        {
            var product=_productService.GetbyId(id);
            if (Session["sepet"]==null)
            {
                if (product.DiscountAvailable==true)
                {
                    List<Cart> cart = new List<Cart>();
                    cart.Add(new Cart { Product = product, Quantity = 1, Total = product.UnitPrice - (product.UnitPrice * product.Discount / 100) });
                    Session["sepet"] = cart;
                }
                else
                {
                    List<Cart> cart = new List<Cart>();
                    cart.Add(new Cart { Product = product, Quantity = 1, Total = product.UnitPrice });
                    Session["sepet"] = cart;
                }
              
            }
            else
            {
                if (product.DiscountAvailable==false)
                {
                    List<Cart> cart = (List<Cart>) Session["sepet"];
                    int index = isExist(id);
                    if (index!=-1)
                    {
                        cart[index].Quantity++;
                        cart[index].Total = product.UnitPrice * cart[index].Quantity;
                    }
                    else
                    {
                        cart.Add(new Cart{Product = product,Quantity = 1,Total = product.UnitPrice  });
                    }

                    Session["sepet"] = cart;
                }
                else
                {
                    List<Cart> cart = (List<Cart>)Session["sepet"];
                    int index = isExist(id);
                    if (index != -1)
                    {
                        cart[index].Quantity++;
                        cart[index].Total = (product.UnitPrice - (product.UnitPrice * product.Discount / 100)) * cart[index].Quantity;
                    }
                    else
                    {
                        cart.Add(new Cart { Product = product, Quantity = 1, Total = product.UnitPrice - (product.UnitPrice * product.Discount / 100) });
                    }

                    Session["sepet"] = cart;
                }
            }

            return RedirectToAction("Index");
        }
        
        public ActionResult Remove(int id)
        {
            var product = _productService.GetbyId(id);
            List<Cart> cart = (List<Cart>) Session["sepet"];
            int index = isExist(id);
            

            if (cart.Where(x=>x.Product.ProductID==id).Count(x => x.Quantity>1)>0)
            {
                if (cart[index].Quantity==1)
                {
                    cart.RemoveAt(index);
                }

                if (product.DiscountAvailable==false)
                {
                    cart[index].Total = (product.UnitPrice * cart[index].Quantity) - product.UnitPrice;
                    cart[index].Quantity--;
                }
                else
                {
                    cart[index].Total = ((product.UnitPrice - (product.UnitPrice * product.Discount / 100)) * cart[index].Quantity) - (product.UnitPrice - (product.UnitPrice * product.Discount / 100));
                    cart[index].Quantity--;
                }
                
            }
            else
            {
                cart.RemoveAt(index);
            }
            Session["sepet"] = cart;
            return RedirectToAction("Index");
        }
       
        private int isExist(int id)
        {
            List<Cart> cart = (List<Cart>) Session["sepet"];
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.ProductID.Equals(id))
                {
                    return i;
                }
            }

            return -1;
        }
    }
}