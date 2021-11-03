using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


namespace Singularity.GUI {

    public class TooltipScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

        private GameObject tooltip;
        private Vector3 offset;

        public void OnPointerEnter(PointerEventData eventData) {
            tooltip.SetActive(true);
        }

        public void OnPointerExit(PointerEventData eventData) {
            tooltip.SetActive(false);
        }

        public void setTooltip(GameObject tooltip) {
            // Debug.Log("SetTooltip called");
            this.tooltip = tooltip;
            Vector2 size = tooltip.GetComponent<RectTransform>().sizeDelta;
            offset = new Vector3(size.x/2+10, -size.y/2+10);
            tooltip.SetActive(false);
        }

        public void setOffset(Vector3 offset) {
            this.offset = offset;
        }

        public GameObject getTooltip() {
            return tooltip;
        }

        // Update is called once per frame
        protected virtual void Update() {
            if (tooltip.activeSelf) {
                tooltip.transform.position = Input.mousePosition;
                tooltip.transform.localPosition += offset;
            }
        }
        
        protected virtual void OnDestroy() {
            GameObject.Destroy(tooltip);
        }

    }

}
