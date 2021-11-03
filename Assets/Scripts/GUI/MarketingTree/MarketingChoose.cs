using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
using UnityEngine.UI;

using Singularity.Game;
using Singularity.Game.GameSystem;

namespace Singularity.GUI.MarketingTree {

    public class MarketingChoose {

        // Load sprite here - static (so that it is done only once)
        protected static Sprite chooseRect = Resources.Load<Sprite>("GUI/InnovationTree/InnovationChooseRect");
        protected static Sprite marketingLogoCircle = Resources.Load<Sprite>("GUI/MarketingTree/MarketingLogoCircle");
        protected static Sprite tooltipBackground = Resources.Load<Sprite>("GUI/MarketingTree/TooltipBackground");

        // Font 
        protected static Font jupiterFont = Resources.Load<Font>("Fonts/Jupiter/Jupiter");
        protected static Font balooFont = Resources.Load<Font>("Fonts/BalooBhaijaan/BalooBhaijaan-Regular");


        private static float scaleFactor = 1f;

        //Fields
        private MarketingTech marketingTech;
        private GameObject chooser;

        private Text costText;

        public MarketingChoose(MarketingTech marketingTech) {

            scaleFactor = ContentManager.scaleFactor;

            this.marketingTech = marketingTech;

            this.chooser = new GameObject(marketingTech.getName());
            Image baseImg = chooser.AddComponent<Image>();
            chooser.GetComponent<RectTransform>().localScale = new Vector3(scaleFactor, scaleFactor);

            // Get ContentManager instance
            ContentManager contentManager = GameObject.Find("MarketingTreeUI/ScrollView/Viewport/Content").GetComponent<ContentManager>();

            // Set chooser size
            chooser.GetComponent<RectTransform>().sizeDelta = new Vector2(300, 83);
            chooser.name = marketingTech.getName();

            baseImg.sprite = chooseRect;

            // Add GameObject containing the innovation logo image
            this.createLogoImageObject(marketingTech.getImagePath(), new Vector2(70, 66), new Vector3(97, 0));

            // Add GameObject containing the blue circle
            this.createBlueCircleObject(new Vector3(97, 0));

            // Create Title Text
            this.createTitleText(marketingTech.getName(), new Vector3(-40, 10), new Vector2(194, 22), Color.white);

            // COST
            costText = this.createCostText(marketingTech.getCostText(), new Vector3(-40, -8.3f), new Vector2(194, 16.6f), Color.white);

            // BUTTON
            Button button = chooser.AddComponent<Button>();
            button.transition = Selectable.Transition.None;

            MarketingChooseButton buttonScript = chooser.AddComponent<MarketingChooseButton>();

            // TOOLTIP
            buttonScript.setTooltip(createTooltip());

            // OFFSET
            if (marketingTech.getPosInRow() == 2) {
                Vector2 size = buttonScript.getTooltip().GetComponent<RectTransform>().sizeDelta;
                buttonScript.setOffset(new Vector3(size.x / 2 + 10, size.y/2 - 20));
            }


        }

        private GameObject createTooltip () {

            GameObject tooltip = new GameObject("tooltip");
            tooltip.transform.SetParent(GameObject.Find("MarketingTreeUI").transform);

            Image background = tooltip.AddComponent<Image>();
            background.sprite = tooltipBackground;

            RectTransform tooltipRect = tooltip.GetComponent<RectTransform>();
            tooltipRect.sizeDelta = new Vector2(300*scaleFactor, 160*scaleFactor);

            GameObject tooltipTitle = new GameObject("title");
            tooltipTitle.transform.SetParent(tooltip.transform);
            tooltipTitle.transform.localPosition = new Vector3(0, 60*scaleFactor);

            Text title = tooltipTitle.AddComponent<Text>();
            title.text = marketingTech.getName();
            title.font = jupiterFont;
            title.fontSize = (int) (25*scaleFactor);
            title.color = new Color(1, 0.18f, 0);
            title.alignment = TextAnchor.MiddleLeft;

            tooltipTitle.GetComponent<RectTransform>().sizeDelta = new Vector2(280*scaleFactor, 30*scaleFactor);

            GameObject tooltipDesc = new GameObject("Description");
            tooltipDesc.transform.SetParent(tooltip.transform);
            tooltipDesc.transform.localPosition = new Vector3(0, -10*scaleFactor);

            Text description = tooltipDesc.AddComponent<Text>();
            description.text = marketingTech.getDescription();
            description.font = balooFont;
            description.fontSize = (int) (10*scaleFactor);
            description.color = Color.gray;
            description.alignment = TextAnchor.MiddleLeft;

            tooltipDesc.GetComponent<RectTransform>().sizeDelta = new Vector2(280*scaleFactor, 130*scaleFactor);

            return tooltip;
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
            circle.name = "LogoCircle";

            // Add image to GameObject
            Image circleImg = circle.AddComponent<Image>();
            circleImg.sprite = marketingLogoCircle;

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

        public void update() {

            // Update cost text
            costText.text = marketingTech.getCostText();

            if (GameSystem.game.getPlayer().marketingtech_current != marketingTech) {
                setMarketingTechStopped();
            }

        }

        public void setMarketingTechRunning() {
            Events.DayChangeEvent.AddListener(update);
            update();
        }

        public void setMarketingTechStopped() {
            Events.DayChangeEvent.RemoveListener(update);
        }

        public GameObject getGameObject() {
            return chooser;
        }


    }

}
