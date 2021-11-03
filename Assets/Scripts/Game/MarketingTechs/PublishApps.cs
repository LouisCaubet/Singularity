using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Singularity.Game.Entities;

namespace Singularity.Game.MarketingTechs {

    public class PublishApps : MarketingTech {

        private MarketingTech[] childs;
        private Unlockable[] requirements;
        private Unlockable[] unlocked;
        private Entity entity;

        private int cost;
        private bool available;

        public PublishApps (Entity entity) {

            this.entity = entity;

            cost = 10;
            available = true;
        }

        public void init() { 
            childs = new MarketingTech[] { };
            requirements = new Unlockable[] { Knowledge.CREATE_APPS };
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
            return "In 2017, mobile apps should generate about 75 billion dollars. Wanna take your part of it? This marketing tech will allow you to publish your apps on the most famous marketplaces, and you'll learn to optimize your SEO thanks to the ASO techniques."+
                "\n<color=orange>Requires</color>: <color=aqua>Create Apps Knowledge</color>\n" +
                "<color=orange>Unlocks</color> : <color=magenta>App Market, ASO techniques & more</color>\n"+
                "<color=navy>Click to research</color>";
        }

        public override string getImagePath() {
            return "GUI/MarketingTree/Logos/PublishAppsLogo";
        }

        public override string getName() {
            return "PUBLISH APPLICATIONS";
        }

        public override int getPosInRow() {
            return 1;
        }

        public override Unlockable[] getRequirements() {
            return requirements;
        }

        public override int getRow() {
            return 0;
        }

        public override Unlockable[] getUnlocked() {
            return unlocked;
        }

        public override bool isAvailable() {
            return available;
        }

        public override void setCost(int newcost) {
            this.cost = newcost;
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
