using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Singularity.Game.Entities;

namespace Singularity.Game.Innovations {

    // Second Row
    public class AdvertisingAlgorithms : Innovation {

        // Constructor
        public AdvertisingAlgorithms(Entity entity) {

            this.entity = entity;

            cost = 10; // TODO set real cost here
            available = true;
            endDate = 0;
        }

        public void init () {
            childs = new Innovation[] { entity.innovations.SOCIAL_NETWORKING, entity.innovations.DATA_MINING };
            unlocked = new Unlockable[] { Knowledge.ADV_DATABASES, entity.products.ADVERTISING_SERVICE };
        }

        // Fields
        private Innovation[] childs;
        private Unlockable[] unlocked;
        private Entity entity;

        private int cost; // in days
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
            return 2;
        }

        override public Innovation[] getChilds() {
            return childs;
        }

        override public int getCost() {
            return cost;
        }
        override public void setCost(int newcost) {
            this.cost = newcost;
            if (newcost == 0) {
                Events.InnovationAchievedEvent.Invoke(this);
            }
        }

        override public string getImagePath() {
            return "GUI/InnovationTree/InnovationLogoCircle";
        }

        override public string getName() {
            return "ADVERTISING ALGORITHMS";
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


