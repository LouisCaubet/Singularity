using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Singularity.Game.Entities;

namespace Singularity.Game.Innovations {

    public class Datacenters : Innovation {

        // Constructor
        public Datacenters(Entity entity) {

            this.entity = entity;

            childs = new Innovation[2];
            childsInit = false;

            cost = 10;
            available = true;
            endDate = 0;
        }

        public void init() {
            unlocked = null;
        }

        // Fields
        private Innovation[] childs;
        private Unlockable[] unlocked;
        private Entity entity;

        private bool childsInit;
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

        private void initChild() {

        }

        override public Innovation getChild(int index) {

            if (!childsInit) {
                initChild();
            }

            return childs[index];
        }

        override public int getChildCount() {
            return 2;
        }

        override public Innovation[] getChilds() {

            if (!childsInit) {
                initChild();
            }

            return childs;
        }

        override public int getCost() {
            return cost;
        }
        override public void setCost(int newcost) {
            cost = newcost;
            if (newcost == 0) {
                Events.InnovationAchievedEvent.Invoke(this);
            }
        }

        override public string getImagePath() {
            return "GUI/InnovationTree/InnovationLogoCircle";
        }

        override public string getName() {

            return "DATACENTERS";

        }

        override public string getScenario() {
            return "SCENARIO HERE";
        }

        override public string getToolTip() {
            throw new NotImplementedException();
        }

        override public Unlockable[] unlockedObjects() {
            return unlocked;
        }

        public override bool isStarted() {
            return entity.innovation_current == this;
        }

        public override bool isFinished() {
            return entity.innovations_done.Contains(this);
        }

    }

}


