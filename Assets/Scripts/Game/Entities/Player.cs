using Singularity.Game;
using Singularity.Game.Innovations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Singularity.Game.Entities {

    /// <summary>
    /// Class to store player-information, like progression, or scene parameters
    /// </summary>
    public class Player : Entity {

        public Player () : base () {

        }

        /// <summary>
        /// Called on day change. See Events for details
        /// </summary>
        public void onDayChange() {
            innovation_current.reduceCost();
            marketingtech_current.reduceCost();
        }

        /// <summary>
        /// Inits some Player stuff. Must be called once on game start
        /// </summary>
        public void init() { // MUST BE CALLED ONCE ON GAME START
            Events.DayChangeEvent.AddListener(onDayChange);
        }

    }
}
