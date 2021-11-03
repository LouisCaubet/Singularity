using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Singularity.Game.Entities;

namespace Singularity.Game.MarketingTechs {

    public class InAppPurchases : MarketingTech {

        private MarketingTech[] childs;
        private Unlockable[] requirements;
        private Unlockable[] unlocked;
        private Entity entity;

        private int cost;
        private bool available;

        public InAppPurchases(Entity entity) {

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
            return "People mostly download free apps. But how to earn money from these? The answer seams obvious once you thought of it:" +
                " IN-APP PURCHASES. Distribute your app for free and take advantages of the SEO bonuses to get more downloads, and let" +
                " people spend money into your app later on.\n"+
                "<color=orange>Requires</color>: <color=aqua>Maths for Mobile Apps (Knowledge)</color>\n"+
                "<color=orange>Unlocks</color>: <color=magenta>In-App Purchases integration</color>\n"+
                "<color=navy>Click to research</color>";
        }

        public override string getImagePath() {
            return "GUI/MarketingTree/Logos/InAppPurchasesLogo";
        }

        public override string getName() {
            return "IN-APP PURCHASES";
        }

        public override int getPosInRow() {
            return 2;
        }

        public override Unlockable[] getRequirements() {
            return requirements;
        }

        public override int getRow() {
            return 1;
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
