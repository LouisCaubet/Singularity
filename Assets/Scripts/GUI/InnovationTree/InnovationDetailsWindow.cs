using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Singularity.Game;
using Singularity.Game.Entities;
using Singularity.Game.GameSystem;


namespace Singularity.GUI.InnovationTree {

    public class InnovationDetailsWindow {

        // Sprites
        private static Sprite background_sprite = Resources.Load<Sprite>("GUI/InnovationTree/InnovationDetails/InnovationDetailsBackground");
        private static Sprite logoCircle = Resources.Load<Sprite>("GUI/InnovationTree/InnovationLogoCircle");
        private static Sprite buttonSprite = Resources.Load<Sprite>("GUI/InnovationTree/InnovationDetails/button");

        private static Sprite tooltipSprite = Resources.Load<Sprite>("GUI/InnovationTree/InnovationDetails/Tooltip");

        // Fonts
        private static Font jupiterFont = Resources.Load<Font>("Fonts/Jupiter/Jupiter");
        private static Font balooFont = Resources.Load<Font>("Fonts/BalooBhaijaan/BalooBhaijaan-Regular");

        // Scale
        private static float scale;

        // Positions
        private static Vector3[] unlocked_positions = new Vector3[] {   new Vector3(-371, -2),
                                                                        new Vector3(-267, -2),
                                                                        new Vector3(-162, -2),
                                                                        new Vector3(-58.5f, -2),
                                                                        new Vector3(44, -2) };

        private Innovation innovation;
        private GameObject window;
        private Image background;

        private GameObject parent;

        private GameObject startButton;
        private ColorBlock buttonDisabledColor;
        private Text costText;



        public InnovationDetailsWindow(Innovation innovation) {

            this.innovation = innovation;

            // Weird, but it seams we dont need to scale the window, it's done by unity
            scale = 1; // ((float) Screen.width) / 1920;
            // Debug.Log(scale);

            window = new GameObject("DetailsWindow");
            background = window.AddComponent<Image>();

            // Set parent
            parent = GameObject.Find("InnovationTreeUI");
            window.transform.SetParent(parent.transform);

            // Set position and size
            window.transform.localPosition = new Vector3(0, 0); 
            window.GetComponent<RectTransform>().sizeDelta = new Vector2(980, 552);
            window.GetComponent<RectTransform>().localScale = new Vector3(scale, scale);

            // Set image
            background.sprite = background_sprite;

            // LOGO
            GameObject logoGO = new GameObject("Logo");
            // Add image
            Image logoImg = logoGO.AddComponent<Image>();
            logoImg.sprite = Resources.Load<Sprite>(innovation.getImagePath());
            // Set position and size
            logoGO.transform.SetParent(parent.transform);
            logoGO.GetComponent<RectTransform>().localScale = new Vector3(scale, scale);
            logoGO.transform.SetParent(window.transform);
            logoGO.transform.localPosition = new Vector3(316, 89);
            logoGO.GetComponent<RectTransform>().sizeDelta = new Vector2(311, 306);
            

            // BLUE CIRCLE AROUND LOGO
            GameObject circleGO = new GameObject("LogoCircle");
            
            // Add image
            Image circle = circleGO.AddComponent<Image>();
            circle.sprite = logoCircle;
            // Set position and size
            circleGO.transform.SetParent(parent.transform);
            circleGO.GetComponent<RectTransform>().localScale = new Vector3(scale, scale);
            circleGO.transform.SetParent(window.transform);
            circleGO.transform.localPosition = new Vector3(316, 89);
            circleGO.GetComponent<RectTransform>().sizeDelta = new Vector2(311, 306);
            


            // TITLE
            GameObject titleGO = new GameObject("TitleGO");
            
            // Add text
            Text titleText = titleGO.AddComponent<Text>();
            titleText.font = jupiterFont;
            titleText.fontSize = 60;
            titleText.color = Color.black;
            titleText.text = innovation.getName();
            // Set position and size
            titleGO.transform.SetParent(parent.transform);
            titleGO.GetComponent<RectTransform>().localScale = new Vector3(scale, scale);
            titleGO.transform.SetParent(window.transform);
            titleGO.transform.localPosition = new Vector3(-177, 207);
            titleGO.GetComponent<RectTransform>().sizeDelta = new Vector2(501.4f, 69);



            // COST
            costText = this.createCostText(innovation.getCostText());

            // "UNLOCKS" TEXT
            GameObject unlockGO = new GameObject("UnlocksText");
            
            // Add text
            Text unlockTxt = unlockGO.AddComponent<Text>();
            unlockTxt.font = jupiterFont;
            unlockTxt.fontSize = 40;
            unlockTxt.color = new Color(0, 0, 205 / 255);
            unlockTxt.text = "Unlocks:";
            // Set position and size
            unlockGO.transform.SetParent(parent.transform);
            unlockGO.GetComponent<RectTransform>().localScale = new Vector3(scale, scale);
            unlockGO.transform.SetParent(window.transform);
            unlockGO.transform.localPosition = new Vector3(-365, 80.4f);
            unlockGO.GetComponent<RectTransform>().sizeDelta = new Vector2(125.5f, 42.4f);
            


            // SCENARIO TEXT
            GameObject scenarioGO = new GameObject("ScenarioText");
            
            // Add text
            Text scenarioText = scenarioGO.AddComponent<Text>();
            scenarioText.font = balooFont;
            scenarioText.fontSize = 16;
            scenarioText.color = Color.white;
            scenarioText.text = innovation.getScenario();
            // Set position and size
            scenarioGO.transform.SetParent(parent.transform);
            scenarioGO.GetComponent<RectTransform>().localScale = new Vector3(scale, scale);
            scenarioGO.transform.SetParent(window.transform);
            scenarioGO.transform.localPosition = new Vector3(-162.8f, -169.3f);
            scenarioGO.GetComponent<RectTransform>().sizeDelta = new Vector2(488.3f, 94.6f);
            


            // BUTTONS
            startButton = this.createButton("Start Research", Color.blue, new Vector3(316, -117), new Vector2(291, 53), typeof(InnovationStartButton));
            this.createButton("Back", new Color(165, 0, 0), new Vector3(316, -190), new Vector2(291, 53), typeof(DetailsCloseButton));

            buttonDisabledColor = new ColorBlock();
            buttonDisabledColor.colorMultiplier = 1;
            buttonDisabledColor.normalColor = Color.gray;
            buttonDisabledColor.highlightedColor = Color.gray;
            buttonDisabledColor.pressedColor = Color.gray;


            // UNLOCKED OBJECTS
            int count = 0;
            foreach (Unlockable unlockable in innovation.unlockedObjects()) {

                createUnlockableImage(unlockable, unlocked_positions[count]);

                count++;
                if (count == 5) break;

            }
            Player player = GameSystem.game.getPlayer();
            if (player.innovation_current == innovation || player.innovations_done.Contains(innovation)) {
                updateTexts();
            }
        }

        private void createUnlockableImage(Unlockable unlockable, Vector3 position) {

            // GO
            GameObject GO = new GameObject(unlockable.getName().Replace(" ", ""));
            GO.transform.SetParent(window.transform);

            // Image
            Image img = GO.AddComponent<Image>();
            img.sprite = Resources.Load<Sprite>(unlockable.getImagePath());

            // Position and size
            GO.GetComponent<RectTransform>().sizeDelta = new Vector2(97, 92);
            GO.GetComponent<RectTransform>().localScale = new Vector3(scale, scale);
            GO.transform.localPosition = position;

            // Script (for ToolTip)
            TooltipScript script = GO.AddComponent<TooltipScript>();

            // Tooltip
            GameObject tooltip = new GameObject("Tooltip");
            Image tooltipImg = tooltip.AddComponent<Image>();
            tooltipImg.sprite = tooltipSprite;

            GameObject title = new GameObject("title");
            Text titleText = title.AddComponent<Text>();
            titleText.text = unlockable.getName();
            titleText.color = new Color(0, 0.79f, 1);
            titleText.font = jupiterFont;
            titleText.fontSize = 25;
            titleText.alignment = TextAnchor.MiddleCenter;

            GameObject description = new GameObject("description");
            Text descText = description.AddComponent<Text>();
            descText.text = unlockable.getToolTip();
            descText.color = Color.white;
            descText.font = balooFont;
            descText.fontSize = 10;
            descText.alignment = TextAnchor.MiddleCenter;
            descText.horizontalOverflow = HorizontalWrapMode.Wrap;

            title.transform.SetParent(tooltip.transform);
            description.transform.SetParent(tooltip.transform);

            // Position and size
            tooltip.GetComponent<RectTransform>().sizeDelta = new Vector2(290, 98);
            title.GetComponent<RectTransform>().sizeDelta = new Vector2(257, 28);
            title.transform.localPosition = new Vector3(0, 24);
            description.GetComponent<RectTransform>().sizeDelta = new Vector2(257, 49);
            description.transform.localPosition = new Vector3(0, -14);

            tooltip.transform.SetParent(GameObject.Find("InnovationTreeUI").transform);
            tooltip.GetComponent<RectTransform>().localScale = new Vector3(scale, scale);

            script.setTooltip(tooltip);

        }

        private Text createCostText (string text) {

            GameObject costGO = new GameObject("CostGO");

            // Add text
            Text costText = costGO.AddComponent<Text>();
            costText.font = jupiterFont;
            costText.fontSize = 60;
            costText.color = Color.black;
            costText.text = text;  
            // Set position and size
            costGO.transform.SetParent(parent.transform);
            costGO.GetComponent<RectTransform>().localScale = new Vector3(scale, scale);
            costGO.transform.SetParent(window.transform);
            costGO.transform.localPosition = new Vector3(-177, 162.4f);
            costGO.GetComponent<RectTransform>().sizeDelta = new Vector2(501.4f, 69);

            return costText;

        }

        private GameObject createButton(string text, Color buttonColor, Vector3 position, Vector2 size, Type script) {

            GameObject GO = new GameObject("button");
            
            Image img = GO.AddComponent<Image>();
            img.sprite = buttonSprite;

            Button b = GO.AddComponent<Button>();
            ColorBlock colorBlock = new ColorBlock();
            colorBlock.normalColor = buttonColor;
            colorBlock.highlightedColor = Color.white;
            colorBlock.pressedColor = Color.black;
            colorBlock.colorMultiplier = 1;
            b.colors = colorBlock;

            GO.transform.SetParent(window.transform.parent);
            GO.GetComponent<RectTransform>().localScale = new Vector3(scale, scale);
            GO.transform.SetParent(window.transform);

            GO.AddComponent(script);

            GO.transform.localPosition = position;
            GO.GetComponent<RectTransform>().sizeDelta = size;

            GameObject textGO = new GameObject("Text");
            
            Text textElement = textGO.AddComponent<Text>();
            textElement.font = jupiterFont;
            textElement.fontSize = 25;
            textElement.color = new Color(0, 1, 139);
            textElement.alignment = TextAnchor.MiddleCenter;
            textElement.text = text;

            textGO.transform.SetParent(window.transform.parent);
            textGO.GetComponent<RectTransform>().localScale = new Vector3(scale, scale);
            textGO.transform.SetParent(GO.transform);

            textGO.transform.localPosition = new Vector3(0, 0);
            textGO.GetComponent<RectTransform>().sizeDelta = size;

            return GO;

        }

        private void updateTexts() {

            costText.text = innovation.getCostText().Split(' ')[0] + " " + innovation.getCostText().Split(' ')[1];
            startButton.transform.Find("Text").gameObject.GetComponent<Text>().text = innovation.getCostText();
            startButton.GetComponent<Button>().colors = buttonDisabledColor;

        }

        // Public methods
        public void startInnovation() {

            // Add DayChange Listener
            Events.DayChangeEvent.AddListener(onDayChange);

            // Update Texts
            updateTexts();

        }

        // Listens to DayChangeEvent
        public void onDayChange() {

            // UpdateTexts
            updateTexts();

        }

    }

}
