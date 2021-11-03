using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
using UnityEngine.UI;

using Singularity.Game;

namespace Singularity.GUI.ProjectView {

    public class ProjectElement {

        private static Sprite background_sprite = Resources.Load<Sprite>("GUI/ProjectView/ProjectFieldBackground");

        private static Font jupiter_font = Resources.Load<Font>("Fonts/Jupiter/Jupiter");
        private static Font baloo_font = Resources.Load<Font>("Fonts/BalooBhaijaan/BalooBhaijaan-Regular");

        private Product product;
        private GameObject element;

        public ProjectElement (Product product, bool clickButtons) {

            this.product = product;
            GameObject parent = GameObject.Find("ProjectViewUI/ProjectsScrollView/Viewport/Content");

            element = new GameObject(product.getName());
            // element.transform.SetParent(parent.transform);

            Image backgroundGO = element.AddComponent<Image>();
            backgroundGO.sprite = background_sprite;

            element.GetComponent<RectTransform>().sizeDelta = new Vector2(1110, 222);

            // TITLE
            createTitle();

            // DESCRIPTION
            createDescription();

            // DURATION
            createDurationText();

            // LOGO
            createLogo();

            // PRICE
            createPriceText();

            if (clickButtons) {
                element.AddComponent<ProjectStartButton>();
            }

        }

        private void createTitle () {

            GameObject titleGO = new GameObject("title");
            titleGO.transform.SetParent(element.transform);

            Text title = titleGO.AddComponent<Text>();
            title.text = product.getName();
            title.font = jupiter_font;
            title.fontSize = 48;
            title.color = Color.white;

            titleGO.GetComponent<RectTransform>().sizeDelta = new Vector2(555, 72);
            titleGO.transform.localPosition = new Vector3(-242, 54);

        }

        private void createDescription () {

            GameObject descGO = new GameObject("desc");
            descGO.transform.SetParent(element.transform);

            Text desc = descGO.AddComponent<Text>();
            desc.text = product.getToolTip();
            desc.font = baloo_font;
            desc.fontSize = 25;
            desc.color = new Color(0.65f, 0, 1);

            descGO.GetComponent<RectTransform>().sizeDelta = new Vector2(480, 40);
            descGO.transform.localPosition = new Vector3(-240, 9);

        }

        private void createDurationText () {

            GameObject durationGO = new GameObject("duration");
            durationGO.transform.SetParent(element.transform);

            Text duration = durationGO.AddComponent<Text>();
            duration.text = "Duration: " + product.getDevTime() + " days";
            duration.font = baloo_font;
            duration.fontSize = 25;
            duration.color = new Color(0, 1, 0);

            durationGO.GetComponent<RectTransform>().sizeDelta = new Vector2(480, 40);
            durationGO.transform.localPosition = new Vector3(-240, -42);

        }

        private void createLogo () {

            GameObject logoGO = new GameObject("logo");
            logoGO.transform.SetParent(element.transform);

            Image logo = logoGO.AddComponent<Image>();
            logo.sprite = Resources.Load<Sprite>(product.getImagePath());

            logoGO.GetComponent<RectTransform>().sizeDelta = new Vector2(160, 154);
            logoGO.transform.localPosition = new Vector3(127, 0);

        }

        private void createPriceText () {

            GameObject priceGO = new GameObject("price");
            priceGO.transform.SetParent(element.transform);

            Text priceText = priceGO.AddComponent<Text>();
            priceText.text = product.getDevCostToDisplay() + " $";
            priceText.font = jupiter_font;
            priceText.fontSize = 64;
            priceText.color = Color.red;

            priceGO.GetComponent<RectTransform>().sizeDelta = new Vector2(250, 69);
            priceGO.transform.localPosition = new Vector3(398, 0);

        }

        public GameObject getGameObject () {
            return element;
        }


    }

}
