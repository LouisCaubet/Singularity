using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

using Singularity.Game;
using Singularity.Game.GameSystem;
using Singularity.Game.Entities;

namespace Singularity.GUI.ProjectView {

    public class ProjectStartButton : MonoBehaviour, IPointerClickHandler {

        public void OnPointerClick(PointerEventData eventData) {
            Player player = GameSystem.game.getPlayer();
            player.current_project = player.products.getByName(this.name);
            GameObject content = GameObject.Find("ProjectViewUI/ProjectsScrollView/Viewport/Content");
            content.GetComponent<ProjectContentManager>().draw();
        }

    }

}
