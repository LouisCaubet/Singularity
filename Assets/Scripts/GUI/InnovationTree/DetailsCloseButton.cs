using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Singularity.GUI.InnovationTree {

    public class DetailsCloseButton : MonoBehaviour, IPointerClickHandler {

        public void OnPointerClick(PointerEventData eventData) {

            GameObject detailsWindow = GameObject.Find("InnovationTreeUI/DetailsWindow");

            GameObject.Destroy(detailsWindow);

        }


    }

}
