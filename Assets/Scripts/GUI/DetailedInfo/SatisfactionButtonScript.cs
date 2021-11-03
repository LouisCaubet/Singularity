using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Singularity.GUI.DetailedInfo {

    public class SatisfactionButtonScript : MonoBehaviour, IPointerClickHandler {

        public void OnPointerClick(PointerEventData eventData) {

            // Get graph GameObject
            GameObject grapher = GameObject.Find("/AreaDetailsUI/Graph");
            if (grapher == null) {
                Debug.Log("Could not find object Graph in AreaDetailsUI!", this);
            }

            GraphMaker maker = grapher.GetComponent<GraphMaker>();
            if (maker == null) {
                Debug.Log("Could not find component GraphMaker in Graph!", this);
            }

            // Draw Graph
            maker.drawSatisfactionGraph();

        }

        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }
    }
}
