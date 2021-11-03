using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Singularity.Game.Entities;

namespace Singularity.Game.MarketingTechs {

    public class TrialVersions : MarketingTech {

        private MarketingTech[] childs;
        private Unlockable[] requirements;
        private Unlockable[] unlocked;
        private Entity entity;

        private int cost;
        private bool available;

        public TrialVersions(Entity entity) {

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
            return "Nobody wants to buy something without knowing if it's good. That's why we publish Trial Versions. " +
                "This research will also allow you " + 
                "to distribute education versions, which are also going to increase your sales.\n" +
                "<color=orange>Requires: </color><color=aqua>Something</color>\n" +
                "<color=orange>Unlocks: </color><color=magenta>Trial and Education Versions</color>\n" + 
                "<color=orange>Expectation: </color><color=magenta>+10% sales and popularity, +20 influence</color>\n" +
                "<color=navy>Click to research</color>";
        }

        public override string getImagePath() {
            return "GUI/MarketingTree/Logos/TrialVersionsLogo";
        }

        public override string getName() {
            return "TRIAL VERSIONS";
        }

        public override int getPosInRow() {
            return 2;
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
