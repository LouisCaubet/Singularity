using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using Singularity.Game;
using Singularity.Game.Entities;
using Singularity.Game.GameSystem;

namespace Singularity.GUI.InnovationTree {

    public class ContentManager : MonoBehaviour {

        public static Sprite line_sprite;

        public static float scaleFactor = 1f;

        ArrayList innovationsToDraw;
        public Dictionary<string, InnovationChoose> choosers;

        // Here we have to build the interface
        void Start() {

            line_sprite = Resources.Load<Sprite>("GUI/InnovationTree/link_green");

            float standardWidth = 1024;
            scaleFactor = Screen.width / standardWidth;

            choosers = new Dictionary<string, InnovationChoose>();

            // innovationsToDraw = Player.innovations_done;

            // FOR DEBUG PURPOSES ONLY
            Player.Innovations innovations = GameSystem.game.getPlayer().innovations;
            innovationsToDraw = new ArrayList(new Innovation[] { innovations.NEURAL_NETWORK, innovations.ALGORITHMS, innovations.SEARCH_ENGINE, innovations.SOCIAL_NETWORKING, innovations.DATA_ANALYSIS });

            float startY = -this.GetComponent<RectTransform>().sizeDelta.y / 2;

            if (innovationsToDraw.Count == 0) { // No innovation discovered - draw only NeuralNetworks

                InnovationChoose innChoose = new InnovationChoose(null);
                GameObject GO = innChoose.getGameObject();
                GO.transform.SetParent(transform, false);
                GO.GetComponent<RectTransform>().localPosition = new Vector3(250, startY);

            }
            else {

                Vector3 position = new Vector3(250, startY);
                Vector3 connectionPosition = new Vector3(0, 0);
                Innovation lastInnovation = null;
                foreach (Innovation innovation in innovationsToDraw) {

                    InnovationChoose innChoose = new InnovationChoose(lastInnovation);
                    GameObject chooser = innChoose.getGameObject();

                    // Place chooser
                    chooser.transform.SetParent(transform);
                    chooser.transform.localPosition = position;

                    float moveX, moveY;

                    int lastInnovationChildCount = 1;
                    if (lastInnovation != null) {
                        lastInnovationChildCount = lastInnovation.getChildCount();
                    }

                    // Compute next position
                    if (innovation.getChildCount() == 1) {

                        if (lastInnovationChildCount == 1) { // Rectangular to Rectangular
                            moveX = 500;
                            moveY = 0;
                        }
                        else { // TRIANGLE TO RECTANGULAR
                            moveX = (252 + 200 + 150);
                            if (innChoose.isTopInnovation(innovation)) {
                                moveY = (68.5f + 41); //* scaleFactor;
                            }
                            else {
                                moveY = (-71.1f - 41); //* scaleFactor;
                            }

                        }

                    }
                    else {

                        if (lastInnovationChildCount == 1) { // Rect to Tri
                            moveX = (150 + 200 + 252);
                            moveY = 0;
                        }
                        else { // Triangle to triangle
                            moveX = (505 + 200);
                            if (innChoose.isTopInnovation(innovation)) {
                                moveY = (68.5f + 135); //* scaleFactor;
                            }
                            else {
                                moveY = (-71.1f - 135); // * scaleFactor;
                            }
                        }

                    }


                    position = position + new Vector3(moveX, moveY);

                    if (lastInnovation != null) { // Tells us if we must draw a link between two choosers

                        // Get Left Connector of this chooser
                        Vector3 leftConnection = new Vector3(-chooser.GetComponent<RectTransform>().sizeDelta.x / 4, 0) * chooser.transform.localScale.x + chooser.transform.localPosition;

                        // Create Line
                        createLine(connectionPosition, leftConnection);

                    }

                    // Find new connectorpos

                    if (lastInnovationChildCount == 1) {
                        connectionPosition = chooser.transform.localPosition;
                        connectionPosition.x = connectionPosition.x + (chooser.GetComponent<RectTransform>().sizeDelta.x / 4);
                    }
                    else {

                        if (innChoose.isTopInnovation(innovation)) {
                            connectionPosition = new Vector3(61.2f * chooser.transform.localScale.x, 68.5f * chooser.transform.localScale.x) + chooser.transform.localPosition;
                        }
                        else {
                            connectionPosition = new Vector3(61.2f * chooser.transform.localScale.x, -71.1f * chooser.transform.localScale.x) + chooser.transform.localPosition;
                        }

                    }



                    // Save current into lastInnovation
                    lastInnovation = innovation;


                }

                // Draw last innovation
                // Debug.Log((innovationsToDraw[innovationsToDraw.Count - 1] as Innovation).getName());
                InnovationChoose innovationChoose = new InnovationChoose(innovationsToDraw[innovationsToDraw.Count - 1] as Innovation);
                GameObject lastInnChooser = innovationChoose.getGameObject();

                // Place chooser
                lastInnChooser.transform.SetParent(transform);
                lastInnChooser.transform.localPosition = position;

                // Get Left Connector of this chooser
                Vector3 leftConn = lastInnChooser.transform.localPosition;
                leftConn.x = leftConn.x - (lastInnChooser.GetComponent<RectTransform>().sizeDelta.x) / 2 + 10;

                // Create Line
                createLine(connectionPosition, leftConn);

            }

        }

        void createLine(Vector3 a, Vector3 b) {

            Vector3 differenceVector = b - a;

            // New Object with Line Image
            GameObject GO = new GameObject();
            GO.name = "lineConnector";
            GO.transform.SetParent(this.transform, false);
            GO.transform.SetAsFirstSibling();
            Image image = GO.AddComponent<Image>();
            image.sprite = line_sprite;


            // Adjust image to link both points
            RectTransform imageRect = image.rectTransform;
            imageRect.sizeDelta = new Vector2(differenceVector.magnitude * 1.25f, 20);
            imageRect.pivot = new Vector2(0, 0.5f);


            float angle = Mathf.Atan2(differenceVector.y * 1.25f, differenceVector.x * 1.25f) * Mathf.Rad2Deg;
            imageRect.rotation = Quaternion.Euler(0, 0, angle);

            imageRect.localPosition = a;


            // Scale to match screen size
            // imageRect.sizeDelta = new Vector2(imageRect.sizeDelta.x * scaleFactor, imageRect.sizeDelta.y) ;
            // imageRect.localScale = new Vector3(1, scaleFactor);

            // Set color
            image.color = Color.white;

        }

        // Update is called once per frame
        void Update() {

            // Check if player pressed ESC
            if (Input.GetKeyDown(KeyCode.Escape)) {
                // GameObject.Find("Main Camera").GetComponent<AudioListener>().enabled = false;
                Graphics.HUD.HUDManager.setInForeground();
                SceneManager.UnloadSceneAsync(SceneManager.GetSceneByBuildIndex((int) SceneID.INNOVATION_TREE));
            }

        }
    }
}
