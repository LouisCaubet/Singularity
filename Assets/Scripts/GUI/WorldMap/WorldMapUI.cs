using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Singularity.GUI.WorldMap {

    public class WorldMapUI : MonoBehaviour {

        // Field keeping Info component
        private GameObject infoComponent;
        private InfoComponent editor;

        // Must be called on init of World Map
        // Use this for initialization
        void Start() {

            infoComponent = GameObject.Find("WorldMapUI/CurrentInfo");

            if (infoComponent == null) {
                Debug.Log("Could not find CurrentInfo !", this);
            }

            infoComponent.SetActive(false);

            editor = new InfoComponent();
        }


        public GameObject getInfoComponent() {
            return infoComponent;
        }

        public InfoComponent getInfoEditor() {
            return editor;
        }

        void Update () {

            if (Input.GetKeyDown(KeyCode.Escape)) {
                GameObject.Find("MainCamera").GetComponent<AudioListener>().enabled = false;
                Graphics.HUD.HUDManager.setInForeground();

                SceneManager.UnloadSceneAsync(SceneManager.GetSceneByBuildIndex((int) SceneID.WORLD_MAP));
                
            }

        }

        public static void loadDetailedInfoScene() {

            // Disable Audio Listener
            // GameObject.Find("MainCamera").GetComponent<AudioListener>().enabled = false;

            // Load Detailed Info Scene
            SceneManager.LoadScene((int)SceneID.DETAILED_INFO, LoadSceneMode.Additive);

        }

    }
}
