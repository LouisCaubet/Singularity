using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Singularity.Game;
using Singularity.Game.GameSystem;


namespace Singularity.GUI.InnovationTree {

    public class InnovationButtonScript : MonoBehaviour, IPointerClickHandler {

        public void OnPointerClick(PointerEventData eventData) {

            Innovation called = GameSystem.game.getPlayer().innovations.getByName(this.name);
            // Show window with details about this innovation
            ClientData.activeDetailsWindow = new InnovationDetailsWindow(called);

        }

    }

}
