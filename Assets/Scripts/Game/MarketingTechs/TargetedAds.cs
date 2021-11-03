using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Singularity.Game.Entities;

namespace Singularity.Game.MarketingTechs {

    public class TargetedAds : MarketingTech {

        private MarketingTech[] childs;
        private Unlockable[] requirements;
        private Unlockable[] unlocked;
        private Entity entity;

        private int cost;
        private bool available;

        public TargetedAds(Entity entity) {

            this.entity = entity;

            cost = 10;
            available = true;
        }

        public void init() {
            childs = new MarketingTech[] { };
            requirements = new Unlockable[] { };
            unlocked = new Unlockable[] { };
        }

        public override int getChildCount() {
            return childs.Length;
        }

        public override MarketingTech[] getChilds() {
            return childs;
        }

        public override int getCost() {
            return cost;
        }

        public override string getDescription() {
            return "Your ads results are bad, because only few people see ads which interest them. So you have to " +
                "find a way to show ads that interest their viewers : TARGETED ADS. Use your new Big Data Knowledge " +
                "to aim your ads at interested people, to increase their effectiveness, your " +
                "popularity and sales.\n" +
                "<color=orange>Requires: </color><color=aqua>Advanced Databases (Knowledge)</color>\n" +
                "<color=orange>Expectation: </color><color=magenta>+20% popularity and +15% sales</color>\n" +
                "<color=navy>Click to research</color>";
        }

        public override string getImagePath() {
            return "GUI/MarketingTree/Logos/TargetedAdsLogo";
        }

        public override string getName() {
            return "TARGETED ADS";
        }

        public override int getPosInRow() {
            return 2;
        }

        public override Unlockable[] getRequirements() {
            return requirements;
        }

        public override int getRow() {
            return 3;
        }

        public override Unlockable[] getUnlocked() {
            return unlocked;
        }

        public override bool isAvailable() {
            return available;
        }

        public override void setCost(int newcost) {
            cost = newcost;
            if (newcost == 0) {
                Events.MarketingTechAchievedEvent.Invoke(this);
            }
        }

        public override void setUnavailable() {
            available = false;
        }

        public override bool isStarted() {
            return entity.marketingtech_current == this;
        }

        public override bool isFinished() {
            return entity.marketingtech_done.Contains(this);
        }

    }

}
