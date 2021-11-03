using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
using UnityEngine.UI;

using Singularity.Game.Products;
using Singularity.Game;
using Singularity.Game.GameSystem;

namespace Singularity.GUI.ProductView {

    public class ProductElement {

        protected static Sprite background_sprite = Resources.Load<Sprite>("GUI/ProductView/field_background");
        protected static Sprite edit_icon = Resources.Load<Sprite>("GUI/ProductView/edit_icon");
        protected static Sprite delete_icon = Resources.Load<Sprite>("GUI/ProductView/delete_icon");
        protected static Sprite red_button = Resources.Load<Sprite>("GUI/ProductView/buttonbackground_red");
        protected static Sprite gray_button = Resources.Load<Sprite>("GUI/ProductView/buttonbackground_gray");
        protected static Sprite green_button = Resources.Load<Sprite>("GUI/ProductView/buttonbackground_green");
        protected static Sprite back_button = Resources.Load<Sprite>("GUI/ProductView/back_icon");

        private static Font jupiter_font = Resources.Load<Font>("Fonts/Jupiter/Jupiter");
        private static Font baloo_font = Resources.Load<Font>("Fonts/BalooBhaijaan/BalooBhaijaan-Regular");

        private SellProduct sell_product;
        private Product product;
        private GameObject GO;
        private ColorBlock button_colors;
        private ProductElementBehaviour behaviour;

        public ProductElement(SellProduct product) {

            this.product = product.getProduct();
            this.sell_product = product;

            GO = new GameObject(this.product.getName());

            Image background = GO.AddComponent<Image>();
            background.sprite = background_sprite;

            GO.GetComponent<RectTransform>().sizeDelta = new Vector2(1300, 150);

            // DRAW LOGO
            GameObject logo = new GameObject("logo");
            logo.transform.SetParent(GO.transform);

            Image logo_img = logo.AddComponent<Image>();
            logo_img.sprite = Resources.Load<Sprite>(this.product.getImagePath());

            logo.GetComponent<RectTransform>().sizeDelta = new Vector2(90, 90);
            logo.transform.localPosition = new Vector3(-576, 0);

            button_colors = new ColorBlock();
            button_colors.normalColor = Color.white;
            button_colors.highlightedColor = new Color(0, 1, 0);
            button_colors.pressedColor = Color.white;
            button_colors.colorMultiplier = 1;

            // BEHAVIOUR
            behaviour = GO.AddComponent<ProductElementBehaviour>();

            // DRAW
            drawNormal();

        }

        public void drawNormal () {

            // CLEAR
            clearElement();

            // DRAW Type / Name / Price
            GameObject nameGO = new GameObject("name");
            nameGO.transform.SetParent(GO.transform);

            Text nameTXT = nameGO.AddComponent<Text>();
            nameTXT.text = product.getType() + "\n" + sell_product.getName() + "\n" + GameSystem.formatNumber(sell_product.getPrice()) + " $";
            nameTXT.font = jupiter_font;
            nameTXT.fontSize = 32;
            nameTXT.lineSpacing = 0.7f;

            nameGO.GetComponent<RectTransform>().sizeDelta = new Vector2(207, 81);
            nameGO.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            nameGO.transform.localPosition = new Vector3(-406, 0);


            // DRAW Sold Since
            GameObject soldSince = new GameObject("SoldSince");
            soldSince.transform.SetParent(GO.transform);

            Text soldSinceTXT = soldSince.AddComponent<Text>();
            soldSinceTXT.text = GameSystem.game.getDateString(sell_product.getSoldSince());
            soldSinceTXT.font = jupiter_font;
            soldSinceTXT.fontSize = 32;

            soldSince.GetComponent<RectTransform>().sizeDelta = new Vector2(120, 34);
            soldSince.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            soldSince.transform.localPosition = new Vector3(-216, 0);


            // DRAW Sales
            GameObject sales = new GameObject("Sales");
            sales.transform.SetParent(GO.transform);

            Text salesTXT = sales.AddComponent<Text>();
            salesTXT.text = GameSystem.formatNumber(sell_product.getSales());
            salesTXT.font = jupiter_font;
            salesTXT.fontSize = 32;
            salesTXT.alignment = TextAnchor.MiddleCenter;

            sales.GetComponent<RectTransform>().sizeDelta = new Vector2(86, 32);
            sales.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            sales.transform.localPosition = new Vector3(-66, 7);


            // DRAW Competition
            GameObject competition = new GameObject("Competition");
            competition.transform.SetParent(GO.transform);

            Text competitionTXT = competition.AddComponent<Text>();
            competitionTXT.text = computeCompetitionText();
            competitionTXT.font = jupiter_font;
            competitionTXT.fontSize = 20;
            competitionTXT.alignment = TextAnchor.LowerRight;

            competition.GetComponent<RectTransform>().sizeDelta = new Vector2(174, 82);
            competition.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            competition.transform.localPosition = new Vector3(116, 23);


            // DRAW Marketing Techs
            GameObject techs = new GameObject("Techs");
            techs.transform.SetParent(GO.transform);

            Text techsTXT = techs.AddComponent<Text>();
            techsTXT.text = generateMarketingTechsText();
            techsTXT.font = jupiter_font;
            techsTXT.fontSize = 20;
            techsTXT.alignment = TextAnchor.LowerLeft;

            techs.GetComponent<RectTransform>().sizeDelta = new Vector2(219, 82);
            techs.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            techs.transform.localPosition = new Vector3(364, 23);


            // DRAW edit button
            GameObject edit = new GameObject("EditButton");
            edit.transform.SetParent(GO.transform);

            Image edit_img = edit.AddComponent<Image>();
            edit_img.sprite = edit_icon;
            Button edit_button = edit.AddComponent<Button>();
            edit_button.colors = button_colors;
            edit.AddComponent<EditButtonScript>();

            edit.GetComponent<RectTransform>().sizeDelta = new Vector2(40, 40);
            edit.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            edit.transform.localPosition = new Vector3(549, 0);

            // DRAW delete button
            GameObject delete = new GameObject("DeleteButton");
            delete.transform.SetParent(GO.transform);

            Image delete_img = delete.AddComponent<Image>();
            delete_img.sprite = delete_icon;
            Button delete_button = delete.AddComponent<Button>();
            delete_button.colors = button_colors;
            delete.AddComponent<DeleteButtonScript>();

            delete.GetComponent<RectTransform>().sizeDelta = new Vector2(40, 40);
            delete.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            delete.transform.localPosition = new Vector3(600, 0);


            // DRAW details button
            GameObject details1 = createButton(gray_button, "Details...", button_colors); // competition
            details1.GetComponent<RectTransform>().sizeDelta = new Vector2(106, 30);
            details1.transform.localPosition = new Vector3(116, -43);

            GameObject details2 = createButton(gray_button, "Details...", button_colors); // sales
            details2.GetComponent<RectTransform>().sizeDelta = new Vector2(106, 30);
            details2.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            details2.transform.localPosition = new Vector3(-66, -43);

            // DRAW manage button
            GameObject manage_button = createButton(red_button, "Manage...", button_colors);
            manage_button.GetComponent<RectTransform>().sizeDelta = new Vector2(106, 30);
            manage_button.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            manage_button.transform.localPosition = new Vector3(364, -43);

        }

        private GameObject createButton(Sprite background, string text, ColorBlock colors) {

            GameObject button = new GameObject("button");
            button.transform.SetParent(GO.transform);

            Image backgroundImg = button.AddComponent<Image>();
            backgroundImg.sprite = background;
            Button buttonComp = button.AddComponent<Button>();
            buttonComp.colors = colors;

            GameObject textGO = new GameObject("Text");
            textGO.transform.SetParent(button.transform);

            Text textComp = textGO.AddComponent<Text>();
            textComp.text = text;
            textComp.font = jupiter_font;
            textComp.fontSize = 25;
            textComp.alignment = TextAnchor.MiddleCenter;

            return button;

        }

        private string computeCompetitionText() { // TODO
            return null;
        }

        private string generateMarketingTechsText() { // TODO

            string text = "";

            if (sell_product.getMarketingTechApplied().Count == 0) {
                return "No Marketing Tech Applied\nClick \"Manage\" to add";
            }

            foreach (MarketingTech tech in sell_product.getMarketingTechApplied()) {
                text = text + tech.getName() + "\n";
            }

            return text;
        }

        public void drawEdit () {

            // CLEAR ELEMENT
            clearElement();

            // DRAW TITLE
            GameObject title = new GameObject("edit_title");
            title.transform.SetParent(GO.transform);

            Text title_text = title.AddComponent<Text>();
            title_text.text = "Edit Product:";
            title_text.font = jupiter_font;
            title_text.fontSize = 32;
            title_text.color = Color.red;

            title.GetComponent<RectTransform>().sizeDelta = new Vector2(207, 33);
            title.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            title.transform.localPosition = new Vector3(-411, 25);

            // DRAW "NAME"
            GameObject nameTitle = new GameObject("edit_name_1");
            nameTitle.transform.SetParent(GO.transform);

            Text name_title_text = nameTitle.AddComponent<Text>();
            name_title_text.text = "Name:";
            name_title_text.font = jupiter_font;
            name_title_text.fontSize = 32;

            nameTitle.GetComponent<RectTransform>().sizeDelta = new Vector2(120, 34);
            nameTitle.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            nameTitle.transform.localPosition = new Vector3(-278, 0);

            // DRAW NAME INPUT
            GameObject nameText = new GameObject("edit_name_2");
            nameText.transform.SetParent(GO.transform);

            Text input_name = nameText.AddComponent<Text>();
            input_name.font = baloo_font;
            input_name.fontSize = 25;

            InputField name_field = nameText.AddComponent<InputField>();
            name_field.text = sell_product.getName();
            name_field.textComponent = input_name;
            name_field.characterLimit = 16;

            nameText.GetComponent<RectTransform>().sizeDelta = new Vector2(177, 40);
            nameText.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            nameText.transform.localPosition = new Vector3(-150, 0);

            // DRAW "PRICE"
            GameObject priceTitle = new GameObject("edit_price_1");
            priceTitle.transform.SetParent(GO.transform);

            Text price_titleTXT = priceTitle.AddComponent<Text>();
            price_titleTXT.text = "Price:";
            price_titleTXT.font = jupiter_font;
            price_titleTXT.fontSize = 32;

            priceTitle.GetComponent<RectTransform>().sizeDelta = new Vector2(80, 37);
            priceTitle.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            priceTitle.transform.localPosition = new Vector3(73, 0);

            // DRAW PRICE INPUT
            GameObject priceText = new GameObject("edit_price_2");
            priceText.transform.SetParent(GO.transform);

            Text input_price = priceText.AddComponent<Text>();
            input_price.text = sell_product.getPrice() + "";
            input_price.font = baloo_font;
            input_price.fontSize = 40;

            InputField price_field = priceText.AddComponent<InputField>();
            price_field.textComponent = input_price;
            price_field.characterLimit = 16;
            price_field.contentType = InputField.ContentType.DecimalNumber;

            priceText.GetComponent<RectTransform>().sizeDelta = new Vector2(260, 68);
            priceText.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            priceText.transform.localPosition = new Vector3(294, 0);

            // DRAW DOLLAR SIGN
            GameObject dollar = new GameObject("edit_USD");
            dollar.transform.SetParent(GO.transform);

            Text dollarText = dollar.AddComponent<Text>();
            dollarText.text = "$";
            dollarText.font = jupiter_font;
            dollarText.fontSize = 40;

            dollar.GetComponent<RectTransform>().sizeDelta = new Vector2(55, 42);
            dollar.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            dollar.transform.localPosition = new Vector3(164, 0);

            // DRAW BACK BUTTON
            GameObject button = new GameObject("edit_back");
            button.transform.SetParent(GO.transform);

            Image button_img = button.AddComponent<Image>();
            button_img.sprite = back_button;
            Button b = button.AddComponent<Button>();
            b.colors = button_colors;
            button.AddComponent<BackButtonScript>();

            button.GetComponent<RectTransform>().sizeDelta = new Vector2(40, 40);
            button.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            button.transform.localPosition = new Vector3(600, 0);

        }

        public void drawDelete () {

            // CLEAR
            clearElement();

            // DRAW title
            GameObject title = new GameObject("del_title");
            title.transform.SetParent(GO.transform);

            Text titleTXT = title.AddComponent<Text>();
            titleTXT.text = "DELETE ?";
            titleTXT.font = jupiter_font;
            titleTXT.fontSize = 32;
            titleTXT.color = Color.red;

            RectTransform titleRect = title.GetComponent<RectTransform>();
            titleRect.sizeDelta = new Vector2(207, 33);
            titleRect.localScale = new Vector3(1, 1, 1);
            title.transform.localPosition = new Vector3(-413, 15);

            // DRAW confirmation
            GameObject confirm = new GameObject("del_text");
            confirm.transform.SetParent(GO.transform);

            Text confirmTXT = confirm.AddComponent<Text>();
            confirmTXT.text = "Are you sure you want to remove \"" + sell_product.getName() + "\" from the market ?";
            confirmTXT.font = jupiter_font;
            confirmTXT.fontSize = 32;

            RectTransform confirmRect = confirm.GetComponent<RectTransform>();
            confirmRect.sizeDelta = new Vector2(759, 34);
            confirmRect.localScale = new Vector3(1, 1, 1);
            confirm.transform.localPosition = new Vector3(-137, -10);

            // DRAW yes button
            GameObject yes = new GameObject("yes_button");
            yes.transform.SetParent(GO.transform);
           
            Image yes_img = yes.AddComponent<Image>();
            yes_img.sprite = green_button;
            Button yes_button = yes.AddComponent<Button>();
            yes_button.colors = button_colors;
            yes.AddComponent<ConfirmDeleteScript>();

            GameObject yes_textGO = new GameObject("Text");
            yes_textGO.transform.SetParent(yes.transform);

            Text yes_text = yes_textGO.AddComponent<Text>();
            yes_text.text = "Yes";
            yes_text.font = baloo_font;
            yes_text.fontSize = 26;
            yes_text.alignment = TextAnchor.MiddleCenter;

            RectTransform yesRect = yes.GetComponent<RectTransform>();
            yesRect.sizeDelta = new Vector2(126, 43);
            yesRect.localScale = new Vector3(1, 1, 1);
            yes.transform.localPosition = new Vector3(340, 21);


            // DRAW no button
            GameObject no = new GameObject("no_button");
            no.transform.SetParent(GO.transform);

            Image no_img = no.AddComponent<Image>();
            no_img.sprite = red_button;
            Button no_button = no.AddComponent<Button>();
            no_button.colors = button_colors;
            no.AddComponent<CancelDeleteScript>();

            GameObject no_textGO = new GameObject("Text");
            no_textGO.transform.SetParent(no.transform);

            Text no_text = no_textGO.AddComponent<Text>();
            no_text.text = "No";
            no_text.font = baloo_font;
            no_text.fontSize = 26;
            no_text.color = Color.white;
            no_text.alignment = TextAnchor.MiddleCenter;

            RectTransform noRect = no.GetComponent<RectTransform>();
            noRect.sizeDelta = new Vector2(125, 43);
            noRect.localScale = new Vector3(1, 1, 1);
            no.transform.localPosition = new Vector3(340, -21);

        }

        private void clearElement () {

            for (int i=0; i<GO.transform.childCount; i++) {
                GameObject child = GO.transform.GetChild(i).gameObject;
                if (child.name != "logo") {
                    GameObject.Destroy(child);
                }
            }

        }

        public void deleteAnim () {
            behaviour.fadeAndDestroy(sell_product);
        }

        public GameObject getGameObject() {
            return GO;
        }

        public SellProduct getSellProduct() {
            return sell_product;
        }

    }

    class ProductElementBehaviour : MonoBehaviour {

        private float lastAlpha;
        private SellProduct self;

        public void fadeAndDestroy (SellProduct self) {

            lastAlpha = 1;
            this.self = self;
            fadeStep();

        }

        void fadeStep () {

            lastAlpha = lastAlpha - 0.1f;
            if (lastAlpha < 0) lastAlpha = 0;
            foreach (Image c in GetComponentsInChildren<Image>()) {
                Color color = c.color;
                color.a = lastAlpha;
                c.color = color;
            }
            foreach (Text c in GetComponentsInChildren<Text>()) {
                Color color = c.color;
                color.a = lastAlpha;
                c.color = color;
            }

            if (lastAlpha > 0) {
                Invoke("fadeStep", 0.1f);
            }
            else {
                GameSystem.game.getPlayer().soldProducts.Remove(self);
                transform.parent.gameObject.GetComponent<ProductContentManager>().draw();
                Destroy(this);
            }

        }

    }

}
