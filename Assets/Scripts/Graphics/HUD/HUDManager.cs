using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Singularity.Game.GameSystem;

namespace Singularity.Graphics.HUD {

    public class HUDManager : MonoBehaviour {

        private static Texture PressKeyTexture;
        private static Texture PressKey2texture;
        private static Texture PressKey3texture;

        private static Font jupiter;

        private GameObject player;
        private Vector3 position;

        bool marketingAvailable;
        bool innovationAvailable;
        bool worldMapAvailable;

        static bool inBackground;

        // Use this for initialization
        void Start() {

            PressKeyTexture = Resources.Load<Texture>("3D/HUD/MarketingKeys");
            PressKey2texture = Resources.Load<Texture>("3D/HUD/InnovationKeys");
            PressKey3texture = Resources.Load<Texture>("3D/HUD/PressKey3");
            jupiter = Resources.Load<Font>("Fonts/Jupiter/Jupiter");
            player = GameObject.Find("Player");

            player.transform.localPosition = ClientData.position3D;
            player.transform.localRotation = ClientData.rotation3D;

            position = player.transform.localPosition;

            inBackground = false;

            // temporary, will have to be called from MainMenu
            GameSystem.startGame();

        }

        public static void setInForeground () {

            inBackground = false;

            // Enable Camera
            GameObject camera = GameObject.Find("Player/MainCamera");
            if (camera != null) {
                camera.GetComponent<AudioListener>().enabled = true;
            }

        }

        // Update is called once per frame
        void Update() {

            if (!inBackground) {

                // Update Position
                position = player.transform.localPosition;

                // Check if we need to enable some commands
                if (position.x > 456 && position.x < 505 && position.z > 27 && position.z < 81) {
                    // Player is in the marketing area
                    marketingAvailable = true;
                }
                else {
                    marketingAvailable = false;
                }

                if (position.x > 416 && position.x < 484 && position.z > -95 && position.z < -17) {
                    // Player is in the innovation area#
                    innovationAvailable = true;
                }
                else {
                    innovationAvailable = false;
                }

                if (position.x > 505 && position.x < 570 && position.z > -95 && position.z < -35) {
                    // Player is in the worldmap area
                    worldMapAvailable = true;
                }
                else {
                    worldMapAvailable = false;
                }

                if (Input.GetKeyDown(KeyCode.E)) {
                    if (innovationAvailable) {
                        openScene(SceneID.INNOVATION_TREE);
                    }
                    else if (marketingAvailable) {
                        openScene(SceneID.MARKETING_TREE);
                    }
                }
                else if (Input.GetKeyDown(KeyCode.M)) {
                    if (worldMapAvailable) {
                        openScene(SceneID.WORLD_MAP);
                    }
                }
                else if (Input.GetKeyDown(KeyCode.Q)) {
                    if (innovationAvailable) {
                        openScene(SceneID.PROJECT_VIEW);
                    }
                    else if (marketingAvailable) {
                        openScene(SceneID.PRODUCT_VIEW);
                    }
                }

            }

        }

        void OnGUI() {

            int x = Screen.width / 2;
            int y = 2 * Screen.height / 3;

            if (marketingAvailable) {
                UnityEngine.GUI.DrawTexture(new Rect(x-200, y, 400, 200), PressKeyTexture);
            }
            if (innovationAvailable) {
                UnityEngine.GUI.DrawTexture(new Rect(x-200, y, 400, 200), PressKey2texture);
            }
            if (worldMapAvailable) {
                UnityEngine.GUI.DrawTexture(new Rect(x-100, y, 200, 200), PressKey3texture);
            }

        }

        private void openScene (SceneID id) {

            // Save Player position data
            ClientData.position3D = player.transform.localPosition;
            ClientData.rotation3D = player.transform.localRotation;

            innovationAvailable = false;
            marketingAvailable = false;
            worldMapAvailable = false;

            inBackground = true;

            // Disable Audio Listener
            GameObject.Find("Player/MainCamera").GetComponent<AudioListener>().enabled = false;

            // Load and Open new scene
            SceneManager.LoadScene((int) id, LoadSceneMode.Additive); // Additive keeps the current scene in background

        }

    }

}