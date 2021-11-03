using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using Singularity.Game;

namespace Singularity {

    public class Events {

        // INSTANCES
        public static UnityEvent DayChangeEvent = new UnityEvent();

        // Innovation & Marketing
        public static InnovationDoneEvent InnovationAchievedEvent = new InnovationDoneEvent();
        public static MarketingDoneEvent MarketingTechAchievedEvent = new MarketingDoneEvent();

        // R&D
        public static ProductResearchedEvent ProductResearched = new ProductResearchedEvent();

        // EVENT CLASSES
        [System.Serializable]
        public class InnovationDoneEvent : UnityEvent<Innovation> { /* Nothing to declare */ }

        [System.Serializable]
        public class MarketingDoneEvent : UnityEvent<MarketingTech> { /* Nothing to declare */ }

        [System.Serializable]
        public class ProductResearchedEvent : UnityEvent<Product> { /* Nothing to do here */}

    }
}