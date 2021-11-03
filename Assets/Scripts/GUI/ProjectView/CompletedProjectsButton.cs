using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Singularity.GUI.ProjectView {

    public class CompletedProjectsButton : MonoBehaviour, IPointerClickHandler {

        public void OnPointerClick(PointerEventData eventData) {
            ProjectContentManager manager = GameObject.Find("ProjectViewUI/ProjectsScrollView/Viewport/Content").GetComponent<ProjectContentManager>();
            manager.drawAvailable = false;
            manager.draw();
        }
    }

}
