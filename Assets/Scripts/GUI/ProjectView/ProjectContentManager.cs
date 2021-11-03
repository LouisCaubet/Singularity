using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Singularity.Game;
using Singularity.Game.GameSystem;
using Singularity.Game.Entities;

namespace Singularity.GUI.ProjectView {

    public class ProjectContentManager : MonoBehaviour {

        private static Sprite listHeader_sprite;
        private static Font jupiter_font;

        public bool drawAvailable { get; set; }

        public void draw () {

            Player player = GameSystem.game.getPlayer();

            // Delete
            for (int i=0; i<this.transform.childCount; i++) {
                GameObject.Destroy(this.transform.GetChild(i).gameObject);
            }

            // Find projects to draw
            ArrayList toDraw;
            if (drawAvailable) {
                toDraw = player.availableToDevelopment;
            }
            else {
                toDraw = player.availableToSale;
            }

            // FOR DEBUG
            Entity.Products products = player.products;
            toDraw = new ArrayList(new Product[] { products.APP_FACE_RECON, products.CREATE_SEARCH_ENGINE, products.CLIENT_TRACKING_IOT, products.CAR_AUTOPILOT_TECHS, products.M2M_COMMUNICATION_SYS, products.SMART_HOME_APPS, products.CLIENT_DATA_COLLECTION, products.POSITION_SYS_IOT, products.IOT_FRAMEWORK, products.REQUIREMENT_ANALYSIS_IOT, products.SMART_DATA_SOFTWARE, products.SMART_ENERGY_SYSTEM, products.SMART_HOME_CINEMA, products.SMART_KITCHEN });
            player.current_project = products.ADVERTISING_SERVICE;


            // TODO SIZE CONTENT VIEW. (Y)
            int height = 300 + 250 * toDraw.Count;
            if (drawAvailable && player.current_project != null) {
                height += 400;
            }

            this.GetComponent<RectTransform>().sizeDelta = new Vector2(1111, height);

            // TODO draw current project if any
            Vector3 position = new Vector3(581, -100);

            if (drawAvailable && player.current_project != null) {

                GameObject listHeader = createListHeader("Current Project");
                listHeader.transform.localPosition = position;
                listHeader.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

                position.y = position.y - 200;

                ProjectElement element = new ProjectElement(player.current_project, false);
                GameObject GO = element.getGameObject();
                GO.transform.SetParent(this.transform);
                GO.transform.localPosition = position;
                GO.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

                position.y = position.y - 200;

            }

            GameObject header;
            if (drawAvailable) {
                header = createListHeader("Available Projects");
            }
            else {
                header = createListHeader("Completed Projects");
            }

            header.transform.localPosition = position;
            header.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            position.y = position.y - 200;

            foreach (Product product in toDraw) {

                ProjectElement element = new ProjectElement(product, drawAvailable);
                GameObject GO = element.getGameObject();
                GO.transform.SetParent(this.transform);
                GO.transform.localPosition = position;
                GO.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

                position.y = position.y - 250;

            }


        }


        private GameObject createListHeader (string header) {

            GameObject GO = new GameObject();
            GO.transform.SetParent(transform);

            Image img = GO.AddComponent<Image>();
            img.sprite = listHeader_sprite;

            GO.GetComponent<RectTransform>().sizeDelta = new Vector2(1110, 100);

            GameObject textGO = new GameObject("text");
            textGO.transform.SetParent(GO.transform);

            Text text = textGO.AddComponent<Text>();
            text.text = header;
            text.font = jupiter_font;
            text.fontSize = 72;
            text.color = Color.black;

            textGO.GetComponent<RectTransform>().sizeDelta = new Vector2(1000, 80);
            textGO.transform.localPosition = new Vector3(100, 0);

            return GO;

        }

        // Use this for initialization
        void Start() {

            listHeader_sprite = Resources.Load<Sprite>("GUI/ProjectView/ListHeader");
            jupiter_font = Resources.Load<Font>("Fonts/Jupiter/Jupiter");

            drawAvailable = true;
            draw();

        }

    }
}
