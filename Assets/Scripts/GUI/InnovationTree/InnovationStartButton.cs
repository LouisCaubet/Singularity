using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Singularity.Game;
using Singularity.Game.GameSystem;
using Singularity.Game.Entities;


namespace Singularity.GUI.InnovationTree {

    /// <summary>
    /// Handler for the "Start Research" button (Innovation Details Display)
    /// </summary>
    public class InnovationStartButton : MonoBehaviour, IPointerClickHandler {

        /// <summary>
        /// Handles click on button, calling methods to start research and show it up.
        /// </summary>
        /// <param name="eventData">The EventData given by Unity</param>
        public void OnPointerClick(PointerEventData eventData) {

            if (this.transform.Find("Text").gameObject.GetComponent<Text>().text == "Start Research") {

                string innovation = this.transform.parent.Find("TitleGO").gameObject.GetComponent<Text>().text;
                Player player = GameSystem.game.getPlayer();
                player.innovation_current = player.innovations.getByName(innovation);

                // Update InnovationDetailsWindow
                ClientData.activeDetailsWindow.startInnovation();

                // Update Innovation Tree
                ContentManager tree = GameObject.Find("InnovationTreeUI/ScrollView/Viewport/Content").GetComponent<ContentManager>();
                InnovationChoose chooser = tree.choosers[innovation];
                chooser.setInnovationRunning();
    
            }

        }

    }
}
