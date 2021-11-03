using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Singularity.Game;
using Singularity.Game.GameSystem;
using Singularity.Game.Entities;


namespace Singularity.GUI.InnovationTree {

    public class InnovationChoose {

        //Scale Factor
        private static float scaleFactor = 1f;

        // Load sprite here as static (so that it is done only once)
        protected static Sprite chooseRect = Resources.Load<Sprite>("GUI/InnovationTree/InnovationChooseRect");
        protected static Sprite chooseTriangle = Resources.Load<Sprite>("GUI/InnovationTree/InnovationChooseTriangle");
        protected static Sprite innovationLogoBorder = Resources.Load<Sprite>("GUI/InnovationTree/InnovationLogoCircle");

        // Load Fonts
        protected static Font jupiterFont = Resources.Load<Font>("Fonts/Jupiter/Jupiter");


        // Field
        private GameObject chooser;
        private int nbOfChilds;
        private Innovation[] childs;

        private Text costText1;
        private Text costText2;


        public InnovationChoose(Innovation parent) {

            scaleFactor = ContentManager.scaleFactor;

            if (parent == null) { // Begin of the game
                nbOfChilds = 1;
                childs = new Innovation[] { GameSystem.game.getPlayer().innovations.NEURAL_NETWORK };
            }
            else {
                nbOfChilds = parent.getChildCount();
                childs = parent.getChilds();
            }

            // Create chooser : GameObject which contains everything
            this.chooser = new GameObject();
            chooser.name = "Chooser";
            Image baseImg = chooser.AddComponent<Image>();
            chooser.GetComponent<RectTransform>().localScale = new Vector3(scaleFactor, scaleFactor);

            // Get ContentManager instance
            ContentManager contentManager = GameObject.Find("InnovationTreeUI/ScrollView/Viewport/Content").GetComponent<ContentManager>();


            if (nbOfChilds == 1) {

                // Save instance in Content Manager dictionnary
                contentManager.choosers.Add(childs[0].getName(), this);

                // Set chooser size
                chooser.GetComponent<RectTransform>().sizeDelta = new Vector2(300, 83);
                chooser.name = childs[0].getName();

                baseImg.sprite = chooseRect;

                // Add GameObject containing the innovation logo image
                this.createLogoImageObject(childs[0].getImagePath(), new Vector2(70, 66), new Vector3(97, 0));

                // Add GameObject containing the blue circle
                this.createBlueCircleObject(new Vector3(97, 0));

                // Create Title Text
                this.createTitleText(childs[0].getName(), new Vector3(-40, 10), new Vector2(194, 22), Color.white);

                // COST
                costText1 = this.createCostText(childs[0].getCostText(), new Vector3(-40, -8.3f), new Vector2(194, 16.6f), Color.white);

                // BUTTON
                Button button = chooser.AddComponent<Button>();
                button.transition = Selectable.Transition.None;

                chooser.AddComponent<InnovationButtonScript>();



            }
            else if (nbOfChilds == 2) {

                // Save in ContentManager dict
                contentManager.choosers.Add(childs[0].getName(), this);
                contentManager.choosers.Add(childs[1].getName(), this);

                // Set chooser size
                chooser.GetComponent<RectTransform>().sizeDelta = new Vector2(505, 271);

                baseImg.sprite = chooseTriangle;

                // LOGO IMAGES
                // Add first logo image (TOP INNOVATION)
                this.createLogoImageObject(childs[0].getImagePath(), new Vector2(70, 66), new Vector3(61.2f, 68.5f));

                // Add second logo image (BOTTON INNOVATION)
                this.createLogoImageObject(childs[1].getImagePath(), new Vector2(70, 66), new Vector3(61.2f, -71.1f));


                // BLUE CIRCLES
                this.createBlueCircleObject(new Vector3(61.2f, 68.5f));
                this.createBlueCircleObject(new Vector3(61.2f, -71.1f));

                // TITLES
                this.createTitleText(childs[0].getName(), new Vector3(-88.6f, 78.8f), new Vector2(201.66f, 20.89f), Color.black);
                this.createTitleText(childs[1].getName(), new Vector3(-88.6f, -61.2f), new Vector2(201.66f, 20.89f), Color.black);

                // COSTS
                costText1 = this.createCostText(childs[0].getCostText(), new Vector3(-88.6f, 60), new Vector2(201.66f, 16.77f), Color.black);
                costText2 = this.createCostText(childs[1].getCostText(), new Vector3(-88.6f, -81.5f), new Vector2(201.66f, 16.77f), Color.black);

                // BUTTONS
                this.createButton(new Vector3(-47.5f, 69.1f), new Vector2(315, 79.7f), childs[0].getName());
                this.createButton(new Vector3(-47.5f, -70f), new Vector2(315, 79.7f), childs[1].getName());


            }
            else {
                throw new System.ArgumentException("An Innovation can only have up to two children!");
            }

        }

        public GameObject getGameObject() {
            return chooser;
        }

        public bool isTopInnovation(Innovation i) {
            return i.getName() == childs[0].getName();
        }

        private void createLogoImageObject(string path, Vector2 size, Vector3 position) {

            GameObject logo1 = new GameObject();
            logo1.name = "Logo";

            Image logo1Img = logo1.AddComponent<Image>();
            logo1Img.sprite = Resources.Load<Sprite>(path);

            logo1.transform.SetParent(chooser.transform.parent);
            logo1.GetComponent<RectTransform>().localScale = new Vector3(scaleFactor, scaleFactor);
            logo1.transform.SetParent(chooser.transform);

            logo1.transform.localPosition = position;
            logo1.GetComponent<RectTransform>().sizeDelta = size;


        }

        private void createBlueCircleObject(Vector3 position) {

            // Add GameObject containing the blue circle
            GameObject circle = new GameObject();
            circle.name = "BlueCircle";

            // Add image to GameObject
            Image circleImg = circle.AddComponent<Image>();
            circleImg.sprite = innovationLogoBorder;

            circle.transform.SetParent(chooser.transform.parent);
            circle.GetComponent<RectTransform>().localScale = new Vector3(scaleFactor, scaleFactor);
            circle.transform.SetParent(chooser.transform);

            // Set local position
            circle.transform.localPosition = position;

            // Set size
            circle.GetComponent<RectTransform>().sizeDelta = new Vector2(70, 66);

        }

        private void createTitleText(string title, Vector3 position, Vector2 size, Color color) {

            // Create Title Text
            GameObject titleGO = new GameObject();
            titleGO.name = "TitleText";

            // Add text to GO
            Text titleText = titleGO.AddComponent<Text>();
            titleText.font = jupiterFont;
            titleText.fontSize = Mathf.RoundToInt(20);
            titleText.alignment = TextAnchor.MiddleRight;
            titleText.text = title;
            titleText.color = color;

            titleGO.transform.SetParent(chooser.transform.parent);
            titleGO.GetComponent<RectTransform>().localScale = new Vector3(scaleFactor, scaleFactor);
            titleGO.transform.SetParent(chooser.transform);

            // Set local pos
            titleGO.transform.localPosition = position;

            // Set size
            titleGO.GetComponent<RectTransform>().sizeDelta = size;


        }

        private Text createCostText(string cost, Vector3 position, Vector2 size, Color color) {

            // Create cost Text
            GameObject costGO = new GameObject();
            costGO.name = "CostText";

            // Add text to GO
            Text costText = costGO.AddComponent<Text>();
            costText.font = jupiterFont;
            costText.fontSize = Mathf.RoundToInt(16);
            costText.alignment = TextAnchor.MiddleRight;
            costText.text = cost;
            costText.color = color;

            costGO.transform.SetParent(chooser.transform.parent);
            costGO.GetComponent<RectTransform>().localScale = new Vector3(scaleFactor, scaleFactor);
            costGO.transform.SetParent(chooser.transform);

            // Set local pos
            costGO.transform.localPosition = position;

            // Set size
            costGO.GetComponent<RectTransform>().sizeDelta = size;

            return costText;

        }

        private void createButton(Vector3 position, Vector2 size, string name) {

            GameObject GO = new GameObject();
            GO.name = name;

            GO.AddComponent<Image>();
            Button button = GO.AddComponent<Button>();

            ColorBlock color = new ColorBlock();
            color.normalColor = new Color(1, 1, 1, 0);
            color.highlightedColor = new Color(1, 1, 1, 0);
            color.pressedColor = new Color(1, 1, 1, 0);

            button.colors = color;

            GO.AddComponent<InnovationButtonScript>();

            GO.transform.SetParent(chooser.transform.parent);
            GO.GetComponent<RectTransform>().localScale = new Vector3(scaleFactor, scaleFactor);
            GO.transform.SetParent(chooser.transform);

            GO.transform.localPosition = position;
            GO.GetComponent<RectTransform>().sizeDelta = size;

        }

        private void update() {

            Player player = GameSystem.game.getPlayer();

            if (nbOfChilds == 1) {
                costText1.text = childs[0].getCostText();

                if (player.innovations_done.Contains(childs[0])) {
                    setInnovationStopped();
                }

            }
            else if (nbOfChilds == 2){
                costText1.text = childs[0].getCostText();
                costText2.text = childs[1].getCostText();

                if (player.innovations_done.Contains(childs[0]) || player.innovations_done.Contains(childs[1])) {
                    setInnovationStopped();
                }
            }

        }

        public void setInnovationRunning() {
            Events.DayChangeEvent.AddListener(onDayChange);
            update();
        }

        public void onDayChange() {
            update();
        }

        public void setInnovationStopped() {
            Events.DayChangeEvent.RemoveListener(onDayChange);
            update();
        }


    }

}
