using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Singularity.Game.Entities;

namespace Singularity.Game.MarketingTechs {

    public class Upselling : MarketingTech {

        private MarketingTech[] childs;
        private Unlockable[] requirements;
        private Unlockable[] unlocked;
        private Entity entity;

        private int cost;
        private bool available;

        public Upselling(Entity entity) {

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
            return "Make your clients spend even more money in your products by releasing a \"Pro\" version." +
                " You can also release a \"Lite\" version to get people addicted, and make them buy another \"Pro\" product.\n" +
                "<color=orange>Requires:</color> <color=aqua>Something</color>\n" +
                "<color=orange>Appliable to</color>: <color=magenta>Any of your products</color>\n" +
                "<color=orange>Expectation: </color><color=magenta> +20 % sales, +40 % profit</color>\n" +
                "<color=navy>Click to research</color>" ;
        }

        public override string getImagePath() {
            return "GUI/MarketingTree/Logos/UpsellingLogo";
        }

        public override string getName() {
            return "UPSELLING";
        }

        public override int getPosInRow() {
            return 0;
        }

        public override Unlockable[] getRequirements() {
            return requirements;
        }

        public override int getRow() {
            return 4;
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
