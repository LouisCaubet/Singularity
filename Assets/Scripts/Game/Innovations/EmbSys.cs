using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Singularity.Game.Entities;

namespace Singularity.Game.Innovations {

    public class EmbSys : Innovation {

        // Constructor
        public EmbSys(Entity entity) {

            this.entity = entity;

            cost = 10;
            available = true;
            endDate = 0;
        }

        public void init() {
            childs = new Innovation[] { entity.innovations.DATA_ANALYSIS };
            unlockedEnterprise = new Unlockable[] { Knowledge.EMBEDDED_SYS_PROGRAMMING, entity.products.POSITION_SYS_IOT, entity.products.CLIENT_TRACKING_IOT };
            unlockedHome = new Unlockable[] { Knowledge.EMBEDDED_SYS_PROGRAMMING, entity.products.SMART_ENERGY_SYSTEM, entity.products.CAR_AUTOPILOT_TECHS };
        }

        // Fields
        private Innovation[] childs;
        private Unlockable[] unlockedEnterprise;
        private Unlockable[] unlockedHome;
        private Entity entity;

        private int cost;
        private bool available;
        private int endDate;

        public override void setUnavailable() {
            available = false;
        }
        public override bool isAvailable() {
            return available;
        }
        public override int getEndDate() {
            return endDate;
        }

        override public Innovation getChild(int index) {
            return childs[index];
        }

        override public int getChildCount() {
            return 1;
        }

        override public Innovation[] getChilds() {
            return childs;
        }

        override public int getCost() {
            return cost;
        }
        public override void setCost(int newcost) {
            cost = newcost;
            if (newcost == 0) {
                Events.InnovationAchievedEvent.Invoke(this);
            }
        }

        override public string getImagePath() {
            return "GUI/InnovationTree/InnovationLogoCircle";
        }

        override public string getName() {

            if (entity.innovations_done.Contains(entity.innovations.IOT_ENTERPRISE)) {
                return "EMBEDDED SYSTEMS (for enterprises)";
            }
            else if (entity.innovations_done.Contains(entity.innovations.IOT_HOME)) {
                return "EMBEDDED SYSTEMS (for home)";
            }
            return "EMBEDDED SYSTEMS";

        }

        override public string getScenario() {
            return "SCENARIO HERE";
        }

        override public string getToolTip() {
            throw new NotImplementedException();
        }

        override public Unlockable[] unlockedObjects() {
            if (entity.innovations_done.Contains(entity.innovations.IOT_ENTERPRISE)) {
                return unlockedEnterprise;
            }
            else {
                return unlockedHome;
            }
        }

        public override bool isStarted() {
            return entity.innovation_current == this;
        }

        public override bool isFinished() {
            return entity.innovations_done.Contains(this);
        }

    }

}


