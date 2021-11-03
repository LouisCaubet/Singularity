using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Singularity.GUI.ProjectView {

    public class AvailableProjectsButton : MonoBehaviour, IPointerClickHandler {

        public void OnPointerClick(PointerEventData eventData) {
            ProjectContentManager manager = GameObject.Find("ProjectViewUI/ProjectsScrollView/Viewport/Content").GetComponent<ProjectContentManager>();
            manager.drawAvailable = true;
            manager.draw();
        }

    }

}
