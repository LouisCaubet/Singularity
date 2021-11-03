using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using Singularity.Game;
using Singularity.Game.Entities;
using Singularity.Game.GameSystem;


namespace Singularity.GUI.MarketingTree {

    public class ContentManager : MonoBehaviour {

        // Scale
        public static float scaleFactor = 1f;

        // Import Sprites
        private static Sprite line;

        public static Dictionary<MarketingTech, MarketingChoose> choosers;
        public static ArrayList marketingTechsDrawn;

        // Here, we draw the marketing tree
        void Start() {

            Player player = GameSystem.game.getPlayer();

            float standardWidth = 1366;
            scaleFactor = Screen.width / standardWidth;

            line = Resources.Load<Sprite>("GUI/MarketingTree/line_white");
            choosers = new Dictionary<MarketingTech, MarketingChoose>();
            marketingTechsDrawn = new ArrayList();

            // First, find up to which row we must draw
            int rowsToDraw = 0;
            if (player.marketingtech_done.Count > 0) {
                foreach (MarketingTech tech in player.marketingtech_done) {
                    if (tech.getRow() > rowsToDraw) {
                        rowsToDraw = tech.getRow();
                    }
                }
                
            }
            rowsToDraw += 1;

            // FOR DEBUG PURPOSES ONLY
            rowsToDraw = 5;

            // Compute positions in Y for choosers
            float height = 2 * this.GetComponent<RectTransform>().sizeDelta.y / 3;
            float[] positionsY = new float[] { -height / 3, -height+height/4, -height - height/6 };

            float posX = 250;

            ArrayList posToConnect = new ArrayList();
            ArrayList connectorPos = new ArrayList();

            for (int i = 0; i < rowsToDraw; i++) {

                ArrayList newPosToConnect = new ArrayList();
                ArrayList newConnectorPos = new ArrayList();

                foreach (MarketingTech tech in player.marketingTechs.getByRow(i)) {

                    MarketingChoose chooser = new MarketingChoose(tech);
                    GameObject GO = chooser.getGameObject();
                    GO.transform.SetParent(this.transform);

                    Vector3 pos = new Vector3(posX, positionsY[tech.getPosInRow()]);
                    GO.transform.localPosition = pos;

                    for (int y=0; y<posToConnect.Count; y++) {
                        if ( Mathf.Abs(((int) posToConnect[y]) - tech.getPosInRow()) <= 1) {
                            Vector3 startPos = (Vector3)connectorPos[y] + new Vector3(GO.GetComponent<RectTransform>().sizeDelta.x / 3, 0);
                            createLine(startPos, pos - new Vector3(GO.GetComponent<RectTransform>().sizeDelta.x / 3, 0));
                        }
                    }

                    choosers.Add(tech, chooser);
                    marketingTechsDrawn.Add(tech);

                    //if (Player.marketingtech_done.Contains(tech)) {
                        newPosToConnect.Add(tech.getPosInRow());
                        newConnectorPos.Add(pos);
                    //}

                }

                posToConnect = newPosToConnect;
                connectorPos = newConnectorPos;

                posX = posX + 350;

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
            image.sprite = line;


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

        void Update () {

            if (Input.GetKeyDown(KeyCode.Escape)) {
                // GameObject.Find("Main Camera").GetComponent<AudioListener>().enabled = false;
                Graphics.HUD.HUDManager.setInForeground();
                // SceneManager.LoadScene((int)SceneID.OFFICE_3D);
                SceneManager.UnloadSceneAsync(SceneManager.GetSceneByBuildIndex((int) SceneID.MARKETING_TREE));
            }

        }


    }
}
