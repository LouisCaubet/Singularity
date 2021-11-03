using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Singularity.Game.GameSystem {

    public class GameMaths {

        // PRICES & SALES

        public static double computePriceEffect(double price, double recommended, double influence) {

            int range = (int) Math.Pow(10, Math.Ceiling(Math.Log10(recommended)));
            double priceEffectNotBiased = 2 / 1 + Math.Exp(-(5 / range) * (price - recommended));

            // PRICE EFFECT NOT BIASED
            // returns a value between 0 and 2 - 
            // ]0;1] if price > recommended
            // [1;2[ if price < recommended
            // SEE PriceEffect.ggb for details

            // Add a bias of influence to the price effect
            return priceEffectNotBiased * (influence + 1);

        }

        public static double computeSales(int potential, double priceEffect, double popularity) {
            double sales = (popularity * potential) * priceEffect;
            if (sales > potential) {
                sales = potential;
            }
            return sales;
        }


        // INFLUENCE & POPULARITY
        private static Dictionary<string, Influence> influences = new Dictionary<string, Influence>();
        private static Dictionary<string, Popularity> popularities = new Dictionary<string, Popularity>();

        public static Influence getInfluence (string country) {
            return influences[country];
        }

        public static Popularity getPopularity (string country) {
            return popularities[country];
        }

        public class Influence {

            double influence;
            int timeSinceUpdate;

            public Influence (double influenceBias) {
                influence = influenceBias;
                timeSinceUpdate = 0;
                Events.DayChangeEvent.AddListener(timeEvolution);
            }

            // Adjusts influence relative to these actions

            public void productSold (bool monopol, double weight) {

                // Power must be in ]0;1[. 
                double newInfluenceNoBias;
                
                if (monopol) {
                    newInfluenceNoBias = Math.Pow(influence, 0.5);
                }
                else {
                    newInfluenceNoBias = Math.Pow(influence, 0.625);
                }

                // Bias by weight
                influence = influence + (newInfluenceNoBias - influence) * weight;

                timeSinceUpdate = 0;

            }

            public void concurrentSold (bool playerHasAlready, double weight) {

                double influenceLoss;

                if (playerHasAlready) { // small loss of influence
                    influenceLoss = Math.Pow(influence, 3 / 2.5);
                }
                else { // bigger loss of influence
                    influenceLoss = Math.Pow(influence, 3 / 2);
                }

                influence -= influenceLoss;

                timeSinceUpdate = 0;

            }

            public void customInfluenceModification (double bias) {

                double coeff = -Math.Pow(Math.Abs(bias), 1 / 2) + 1;
                influence += coeff * bias;

                checkInfluenceRange();

                timeSinceUpdate = 0;

            }

            private void checkInfluenceRange() {

                if (influence < 0) influence = 0;
                if (influence > 1) influence = 1;

            }

            public void timeEvolution() {

                timeSinceUpdate++;
                influence -= (-Math.Exp(-0.001 * timeSinceUpdate) + 1) * influence;

            }

        }

        public class Popularity {

            double popularity;
            int time;

            public Popularity(double startValue) {
                popularity = startValue;
                Events.DayChangeEvent.AddListener(timeEvolution);
            }

            public void timeEvolution () {
                popularity += Math.Exp((1 / 3000) * time) - Math.Exp((1 / 3000) * (time-1));
            }

            public void customImpact(double impact) {
                popularity += impact;
            }

        }



        // INITIALISATION
        public static void init() {

            string[] countries = { "NorthAmerica", "SouthAmerica", "CentralAmerica", "Europe", "Russia", "NorthAfrica", "CentralAfrica", "SouthAfrica", "NearEast", "Asia", "Australia" };
            foreach (string country in countries) {
                influences.Add(country, new Influence(0.05));
                popularities.Add(country, new Popularity(0.05));
            }

        }

    }
}
 