using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Singularity.Game.Entities;

namespace Singularity.Game.Innovations {

    // FIRST INNOVATION (Tutorial)
    public class NeuralNetwork : Innovation {

        // Constructor
        public NeuralNetwork (Entity entity) {

            this.entity = entity;

            cost = 10;
            available = true;
            endDate = 0;
        }

        // Init
        public void init() {
            childs = new Innovation[] { entity.innovations.IOT, entity.innovations.ALGORITHMS };
            unlocked = new Unlockable[] { Knowledge.CREATE_APPS, entity.products.APP_FACE_RECON };
        }

        // private fields
        private Innovation[] childs;
        private Unlockable[] unlocked;
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
            return 2;
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
            return "NEURAL NETWORKS";
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


