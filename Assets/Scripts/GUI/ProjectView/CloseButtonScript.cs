using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


namespace Singularity.GUI.ProjectView {

    public class CloseButtonScript : MonoBehaviour, IPointerClickHandler {

        public void OnPointerClick(PointerEventData eventData) {
            Graphics.HUD.HUDManager.setInForeground();
            SceneManager.UnloadSceneAsync(SceneManager.GetSceneByBuildIndex((int)SceneID.PROJECT_VIEW));
        }

        // Update is called once per frame
        void Update() {

            if (Input.GetKeyDown(KeyCode.Escape)) {
                OnPointerClick(null);
            }

        }
    }

}
