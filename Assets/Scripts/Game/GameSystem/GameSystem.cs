using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

using Singularity.Game.Entities;

namespace Singularity.Game {

    public enum GeographicArea {
        NORTH_AMERICA,
        CENTRAL_AMERICA,
        SOUTH_AMERICA,
        EUROPE,
        RUSSIA,
        ASIA,
        NEAR_EAST,
        NORTH_AFRICA,
        CENTRAL_AFRICA,
        SOUTH_AFRICA,
        AUSTRALIA
    }

}

namespace Singularity.Game.GameSystem {

    public class GameSystem {

        private static string[] monthes = new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

        private Player player;
        private int time; // the game timer

        public int money { get; set; }

        public static GameSystem game;

        // called on game start
        public GameSystem() {

            player = new Player();
            // GameMaths.init();
            time = 0;
            money = 2500;

            // event listeners
            Events.InnovationAchievedEvent.AddListener(onInnovationDone);
            Events.MarketingTechAchievedEvent.AddListener(onMarketingTechDone);
            Events.ProductResearched.AddListener(onProductResearchDone);


        }

        public void onDayChange() {
            time++;
        }

        // Event Listeners
        public void onInnovationDone(Innovation i) {

            player.innovations_done.Add(i);
            player.innovation_current = null;

            foreach (Unlockable unlocked in i.unlockedObjects()) {
                if(unlocked is Knowledge) {
                    player.knowledgeMastered.Add(unlocked as Knowledge);
                }
                else if(unlocked is Product) {
                    player.availableToDevelopment.Add(unlocked as Product);
                }
            }

        }
        public void onMarketingTechDone(MarketingTech tech) {

            player.marketingtech_done.Add(tech);
            player.marketingtech_current = null;

        }
        public void onProductResearchDone(Product p) {

            player.current_project = null;
            player.availableToDevelopment.Remove(p);
            player.availableToSale.Add(p);

        }


        // TOOLS
        public int getTime() {
            return time;
        }

        public string getDateDMY(int time) {

            int[] date = getDate(time);
            return date[0] + " " + monthes[date[1]] + " " + date[2];

        }

        public string getDateString (int time) {
            int[] date = getDate(time);
            return date[0] + "." + date[1] + "." + date[2];
        }

        public int[] getDate(int time) { // Day.Month.Year // DD.MM.YYYY

            int timeCopy = time;

            int year = 2017;
            int month = 0;

            // Compute year
            while (timeCopy >= 365) {
                year++;
                timeCopy -= 365;
            }

            // Month
            if (timeCopy >= 334) {
                month = 11;
                timeCopy -= 334;
            }
            else if (timeCopy >= 304) {
                month = 10;
                timeCopy -= 304;
            }
            else if (timeCopy >= 273) {
                month = 9;
                timeCopy -= 273;
            }
            else if (timeCopy >= 243) {
                month = 8;
                timeCopy -= 243;
            }
            else if (timeCopy >= 212) {
                month = 7;
                timeCopy -= 212;
            }
            else if (timeCopy >= 181) {
                month = 6;
                timeCopy -= 181;
            }
            else if (timeCopy >= 151) {
                month = 5;
                timeCopy -= 151;
            }
            else if (timeCopy >= 120) {
                month = 4;
                timeCopy -= 120;
            }
            else if (timeCopy >= 90) {
                month = 3;
                timeCopy -= 90;
            }
            else if (timeCopy >= 59) {
                month = 2;
                timeCopy -= 59;
            }
            else if (timeCopy >= 31) {
                month = 1;
                timeCopy -= 31;
            }
            else month = 0;

            return new int[] { timeCopy, month, year };

        }


        public static string formatNumber (double number) {
            
            if (number < 1000) {
                return "" + number;
            }

            if (number < 10000) {
                double k = Math.Round((double) number / 100) / 10;
                return k + "k";
            }

            double rounded = Math.Round((double) number / 1000);
            return rounded + "k";

        }

        public static string formatNumber (int number) {
            return formatNumber((double) number);
        }

        public Player getPlayer() { 
            return player;
        }

        // CALLED ON GAME START
        public static void startGame () {
            game = new GameSystem();
        }


    }

}
