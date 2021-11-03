using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Singularity.GUI.DetailedInfo {

    public class CloseButtonScript : MonoBehaviour, IPointerClickHandler {

        public void OnPointerClick(PointerEventData eventData) {

            // SceneManager.LoadScene((int)SceneID.WORLD_MAP);
            SceneManager.UnloadSceneAsync(SceneManager.GetSceneByBuildIndex((int) SceneID.DETAILED_INFO));
        }

        // Use this for initialization
        void Start () {
		
	    }
	
	    // Update is called once per frame
	    void Update () {

            // Also allow closing by pressing ESC
            if (Input.GetKeyDown(KeyCode.Escape)) {
                OnPointerClick(null);
            }
		
	    }
    }

}

