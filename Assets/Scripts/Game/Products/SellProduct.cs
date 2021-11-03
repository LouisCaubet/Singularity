using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Singularity.Game.Products {

    /// <summary>
    /// Object containing data about an object being sold by player.
    /// </summary>
    public class SellProduct {

        private Product product;
        private ArrayList areas;
        private double price;
        private string name;

        private ArrayList applied;

        private int sales;

        private int soldSince;


        public SellProduct(Product product, GeographicArea[] areas, double price, string name, MarketingTech[] applied) {

            this.areas = new ArrayList(areas);
            this.applied = new ArrayList(applied);

            this.product = product;
            this.price = price;
            this.name = name;

            this.soldSince = GameSystem.GameSystem.game.getTime();

        }

        public SellProduct(Product product, GeographicArea[] areas, double price, string name) : 
            this(product, areas, price, name, new MarketingTech[] { }) { }


        public void rename(string name) {
            this.name = name;
        }
        public void setPrice(double price) {
            this.price = price;
        }
        public void addMarketingTech(MarketingTech tech) {
            applied.Add(tech);
        }
        public void removeMarketingTech(MarketingTech toremove) {
            applied.Remove(toremove);
        }
        public void addArea(GeographicArea area) {
            areas.Add(area);
        }
        public void removeArea(GeographicArea toremove) {
            areas.Remove(toremove);
        }

        public void addSales(int sales) {
            this.sales += sales;
        }

        // GETTERS
        public Product getProduct() { return product; }
        public ArrayList getAreas() { return areas; }
        public ArrayList getMarketingTechApplied() { return applied; }

        public double getPrice() { return price; }
        public string getName() { return name; }
        public int getSoldSince() { return soldSince; }
        public int getSales() { return sales; }

    }

}
