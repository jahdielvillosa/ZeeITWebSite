﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Routing;
using System.Xml;
using System.Xml.Linq;
using System.Globalization;

using System.Data;
using System.Data.Entity;
using TravelPackage.Models;

namespace TravelPackage
{
    public class SitemapNode
    {
        public SitemapFrequency? Frequency { get; set; }
        public DateTime? LastModified { get; set; }
        public double? Priority { get; set; }
        public string Url { get; set; }
    }

    public enum SitemapFrequency
    {
        Never,
        Yearly,
        Monthly,
        Weekly,
        Daily,
        Hourly,
        Always
    }

    public class SiteMap
    {
        private TravelDBContainer db = new TravelDBContainer();

        public string GetSitemapDocument(IEnumerable<SitemapNode> sitemapNodes)
        {
            XNamespace xmlns = "http://www.sitemaps.org/schemas/sitemap/0.9";
            XElement root = new XElement(xmlns + "urlset");

            foreach (SitemapNode sitemapNode in sitemapNodes)
            {
                XElement urlElement = new XElement(
                    xmlns + "url",
                    new XElement(xmlns + "loc", Uri.EscapeUriString(sitemapNode.Url)),
                    sitemapNode.LastModified == null ? null : new XElement(
                        xmlns + "lastmod",
                        sitemapNode.LastModified.Value.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:sszzz")),
                    sitemapNode.Frequency == null ? null : new XElement(
                        xmlns + "changefreq",
                        sitemapNode.Frequency.Value.ToString().ToLowerInvariant()),
                    sitemapNode.Priority == null ? null : new XElement(
                        xmlns + "priority",
                        sitemapNode.Priority.Value.ToString("F1", CultureInfo.InvariantCulture)));
                root.Add(urlElement);
            }

            XDocument document = new XDocument(root);
            return document.ToString();
        }

        public List<string> GetItemRoot()
        {
            List<string> items = new List<string>();
            items.Add("Index");
            items.Add("About");
            items.Add("Contact");
            items.Add("TravelDestinations");
            items.Add("TravelTourPackages");
            items.Add("TravelTourImages");
            items.Add("TravelTourCategories");
            items.Add("TravelTourTags");
            items.Add("TravelTourBacklinks");

            return items;
        }

        public List<string> GetDestinations()
        {
            var data = db.tpAreas.OrderBy(s => s.Sort).ToList();
            List<string> items = new List<string>();
            foreach( var tmp in data)
            {
                items.Add("TravelPackages/" + tmp.Id + "/" + tmp.Name);
            }
            return items;
        }

        public List<string> GetProducts()
        {
            var data = db.tpProducts.OrderBy(s => s.Sort).ToList();
            List<string> items = new List<string>();
            foreach (var tmp in data)
            {
                items.Add("TourPackages/" + tmp.Id + "/" + tmp.Name);
            }
            return items;

        }


        public IReadOnlyCollection<SitemapNode> GetSitemapNodes(string _website)
        {
            List<SitemapNode> nodes = new List<SitemapNode>();


            //root items
            List<string> itemroot = this.GetItemRoot();
            foreach (var item in itemroot)
            {
                nodes.Add(
                    new SitemapNode()
                    {
                        Url = string.Format(_website + "{0}",item),
                        LastModified = System.DateTime.Now,
                        Frequency = SitemapFrequency.Weekly,
                        Priority = 1
                    });
            }

            //package Areas
            List<string> itemAreas = this.GetDestinations();
            foreach (var item in itemAreas)
            {
                nodes.Add(
                    new SitemapNode()
                    {
                        Url = string.Format(_website + "{0}", item),
                        LastModified = System.DateTime.Now,
                        Frequency = SitemapFrequency.Weekly,
                        Priority = 1
                    });
            }

            //Products
            List<string> itemProduct = this.GetProducts();
            foreach (var item in itemProduct)
            {
                nodes.Add(
                    new SitemapNode()
                    {
                        Url = string.Format(_website + "{0}", item),
                        LastModified = System.DateTime.Now,
                        Frequency = SitemapFrequency.Weekly,
                        Priority = 1
                    });
            }

            return nodes;
        }
      
    }

}