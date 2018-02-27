using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TravelPackage.Models;

namespace TravelPackage.Controllers
{
    public class HomeController : Controller
    {
        private TravelDBContainer db = new TravelDBContainer();

        public ActionResult Index(int? option)
        {
            if ( option == 1 ) return View(db.tpAreas.ToList().OrderBy(d => d.Sort));

            //string currentUrl = Request.Url.AbsoluteUri;
            //int iPreChars = 7; // http://
            //int iRemainingChars = 0;
            //string sPartUri = currentUrl.Substring(iPreChars).ToLower();

            ////check sites
            //string s1 = "";
            //int is1 = 0;
            //string sTemp = "";
            //// check bohol website
            //s1 = "www.boholtravelpackages.com";
            //is1 = s1.Length;
            //iRemainingChars = ((sPartUri.Length - is1) >= 0) ? is1 : sPartUri.Length;
            //sTemp = sPartUri.Substring(0, iRemainingChars);
            //if (sTemp == s1)
            //    return RedirectToAction("Destination", new { id = 2, AreaName = "Bohol" });

            //ViewBag.UriArea = sTemp;
            //// check if localhost
            //s1 = "localhost";
            //is1 = s1.Length;
            //iRemainingChars = ((sPartUri.Length - is1) >= 0) ? is1 : sPartUri.Length;
            //sTemp = sPartUri.Substring(0, iRemainingChars);
            //if (sTemp == s1)
            //    return RedirectToAction("Destination", new { id = 2, AreaName = "Bohol" });
            ViewBag.Projects = db.tpProducts.ToList();
            return View(db.tpAreas.ToList().OrderBy(d => d.Sort));
        }

        public ActionResult Destination(int? id, string AreaName)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tpAreas tpAreas = db.tpAreas.Find(id);
            if (tpAreas == null)
            {
                return HttpNotFound();
            }

            ViewBag.Destination = AreaName;
            ViewBag.Description = tpAreas.PageRemarks;

            var featured = db.tpProdCats.Where(d => d.tpCategory.SysCode == "FEATURED").Select(s=>s.tpProductsId);
            var data = db.tpProducts.Where(d => d.tpAreasId == id && featured.Contains(d.Id) ).OrderBy(d => d.Sort).ToList();

            var addons = db.tpProdCats.Where(d => d.tpCategory.SysCode == "ADDON").Select(s => s.tpProductsId);
            ViewBag.Addons = db.tpProducts.Where(d => d.tpAreasId == id && addons.Contains(d.Id)).OrderBy(d => d.Sort).ToList();

            ViewBag.metaTitle = AreaName + " Tour Packages | Vacation | Travel - " + DateTime.Now.Year.ToString() + "-" + (DateTime.Now.Year+1).ToString() + " Philippines";
            ViewBag.metaDescription = "Vacation, Adventure Tour, Travel and Holiday Packages to " + AreaName;

            return View(data);
        }

        public ActionResult Product(int? id, string ProductName)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tpProducts product = db.tpProducts.Find(id);
            if ( product == null)
            {
                return HttpNotFound();
            }

            WebInquiryForm wif = new WebInquiryForm();
            if (Session["INQUIRYOBJ"] != null )
            {
                wif = (WebInquiryForm)Session["INQUIRYOBJ"];
            }
            else
            {
                wif.items = new List<WebInquiryItems>();
            }
            wif.ProductId = (int)id;
            wif.JobStart = DateTime.Today;

            ViewBag.Inquiry = wif;
            ViewBag.DestId = product.tpAreasId;
            ViewBag.DestName = product.tpArea.Name;
            ViewBag.ProdImages = db.tpProductImages.Where(d => d.tpProductsId == id).OrderBy(s=>s.Sort).ToList();
            ViewBag.ProdDesc = db.tpProductDescs.Where(d => d.tpProductsId == id).OrderBy(s => s.Sort).ToList();
            ViewBag.ProdRate = db.tpProdRates.Where(d => d.tpProductsId == id).OrderBy(s => s.Sort).Include(d=>d.tpUom).ToList();

            // categories and tags/keywords
            var sCat = db.tpProdCats.Where(d => d.tpProductsId == id).Select(d => d.tpCategoryId);
            ViewBag.ProductCategories = db.tpCategories.Where(d => sCat.Contains(d.Id)).ToList();
            ViewBag.ProductKeywords = db.tpKeywords.Where(d => d.tpProductsId == id).ToList();

            //Related links: nearby | similar | affiliates
            var featured = db.tpCategories.Where(d => d.SysCode == "FEATURED").Select(d=>d.Id);
            var featuredProducts = db.tpProdCats.Where(d => featured.Contains(d.tpCategoryId)).Select(d=>d.tpProductsId).ToList();
            ViewBag.NearbyAds = db.tpProducts.Where(d => d.tpAreasId == product.tpAreasId).Where(d=> featuredProducts.Contains(d.Id)).ToList();

            var similarCat = db.tpProdCats.Where(d => sCat.Contains(d.tpCategoryId)).Select(d=>d.tpProductsId).ToList();
            ViewBag.SimilarAds = db.tpProducts.Where(d => similarCat.Contains(d.Id)).Where(d=> d.tpAreasId != product.tpAreasId).ToList();

            //Backlinks
            ViewBag.Backlinks = db.tpBacklinks.Where(d=>d.LinkType=="PRODUCT").ToList();


            ViewBag.metaTitle = product.Name + " - " + product.tpArea.Name + " Travel|Tour Packages - " + DateTime.Now.Year.ToString() + "-" + (DateTime.Now.Year + 1).ToString() + ")";
            ViewBag.metaDescription = product.Name + " Vacation, Adventure Tour, Travel and Holiday Packages to " + product.tpArea.Name;
            ViewBag.subTitle = product.tpArea.Name + " Travel and Tour Packages - " + DateTime.Now.Year.ToString() + "-" + (DateTime.Now.Year + 1).ToString();
            return View(product);
        }

        [HttpPost]
        public ActionResult Product([Bind( Include = "ProductId, LeadGuest, ContactNo, Email, NoOfAdult, NoOfChild, JobStart, Message, Status")] WebInquiryForm wif, string btnSubmit)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    //add product for inquiry/book 
                    if (wif.items == null) wif.items = new List<WebInquiryItems>();
                    wif.items.Add(new WebInquiryItems
                    {
                        ProductId = wif.ProductId,
                        dtStart = wif.JobStart,
                        Message = wif.Message
                    });
                    wif.Message = ""; //clean message value for next inquiry

                    if (btnSubmit == "Request a Quote") wif.Status = "QUOTE";
                    if (btnSubmit == "Book this Product") wif.Status = "BOOK";

                    Session["INQUIRYOBJ"] = wif; //update session web inquiry object
                }

                return RedirectToAction("RequestProduct");
            }
            catch (Exception e)
            {
                ViewBag.errormsg = e.Message.Trim(); //for debugging purposes only
                return RedirectToAction("RequestProduct");
            }
        }

        public ActionResult AddRequestProduct(int? id)
        {
            if (Session["INQUIRYOBJ"] == null) return RedirectToAction("Index");

            WebInquiryForm wif = (WebInquiryForm)Session["INQUIRYOBJ"];
            //prepare item to add
            tpInqServices item = new tpInqServices
            {
                tpInquiryId = wif.Id,
                tpProductsId = (int)id,
                dtSvcStart = wif.JobStart,
                Message = "Addon"
            };
            db.tpInqServices.Add(item);
            db.SaveChanges();

            if (wif.Status == "QUOTE")
            {
                return RedirectToAction("RequestQuote", new { id = wif.areaId });
            }

            if (wif.Status == "BOOK")
            {
                return RedirectToAction("RequestBook", new { bookingId = wif.Id });
            }

            return RedirectToAction("index");

        }

        public ActionResult RequestProduct()
        {
            WebInquiryForm wif = (WebInquiryForm)Session["INQUIRYOBJ"];

            //add to database
            Models.tpInquiry tpInq = new tpInquiry
            {
                dtInquiry = DateTime.Now,
                LeadGuest = wif.LeadGuest,
                ContactNo = wif.ContactNo,
                Email = wif.Email,
                NoOfAdult = wif.NoOfAdult,
                NoOfChild = wif.NoOfChild,
                Status = wif.Status
            };
            db.tpInquiries.Add(tpInq);
            db.SaveChanges();

            var item01 = wif.items.FirstOrDefault();
            if (item01 != null)
            {
                Models.tpInqServices tpSvc = new tpInqServices
                {
                    tpInquiryId = tpInq.Id,
                    tpProductsId = item01.ProductId,
                    dtSvcStart = item01.dtStart,
                    Message = item01.Message
                };
                db.tpInqServices.Add(tpSvc);
                db.SaveChanges();
            }

            wif.Id = tpInq.Id;

            //retrieve product for view display purposes
            var product = db.tpProducts.Find(wif.ProductId);
            ViewBag.product = product;

            wif.areaId = product.tpAreasId; //update areaID for use in addon
            Session["INQUIRYOBJ"] = wif; //update session inquiry


            if (wif.Status == "QUOTE")
            {
                return RedirectToAction("RequestQuote", new { id = product.tpAreasId } );
            }

            if (wif.Status == "BOOK")
            {
                return RedirectToAction("RequestBook", new { bookingId = tpInq.Id });
            }

            return View(wif);

        }

        public ActionResult RequestQuote(int? id)
        {
            WebInquiryForm wif = (WebInquiryForm)Session["INQUIRYOBJ"];

            var addons = db.tpProdCats.Where(d => d.tpCategory.SysCode == "ADDON").Select(s => s.tpProductsId);
            ViewBag.Addons = db.tpProducts.Where(d => d.tpAreasId == id && addons.Contains(d.Id)).OrderBy(d => d.Sort).ToList();
            ViewBag.Added = db.tpInqServices.Where(d => d.tpInquiryId == wif.Id);

            return View();
        }

        public ActionResult RequestBook(int? bookingId)
        {
            //var addons = db.tpProdCats.Where(d => d.tpCategory.SysCode == "ADDON").Select(s => s.tpProductsId);
            //ViewBag.Addons = db.tpProducts.Where(d => d.tpAreasId == id && addons.Contains(d.Id)).OrderBy(d => d.Sort).ToList();

            ViewBag.BookingRef = (int) bookingId;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult LinkSite()
        {
            return View();
        }

        #region Dynamic SiteMap 
        //[Route("sitemap.xml")]
        public ActionResult SitemapXml()
        {
            string currentUrl = Request.Url.AbsoluteUri;
            int iTmp = currentUrl.IndexOf('/',7);
            string newurl = currentUrl.Substring(0, iTmp+1);

            SiteMap sm = new SiteMap();
            var sitemapNodes = sm.GetSitemapNodes(newurl);
            string xml = sm.GetSitemapDocument(sitemapNodes);
            return this.Content(xml, "text/xml", System.Text.Encoding.UTF8);
        }

        #endregion



    }
}