using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Singularity.GUI.DetailedInfo {

    public class GraphMaker : MonoBehaviour {

        private int year;
        private float scaleX;
        private float scaleY;

        // private float posX;
        // private float posY;
        private float width;
        private float height;

        // Keep if graph is already drawn
        private bool isSatisfactionDrawn;
        private bool isUnemploymentDrawn;
        private bool isInfluenceDrawn;
        private bool isPopularityDrawn;

        // Scale up to fill screen
        private float upscaleFactor;

        void drawAxis() {

            float currentPos = 0;

            for (int i = 0; i < year; i++) {
                //drawLine(currentPos+16, 12, currentPos+16, 2, Color.gray, "X-AXIS");
                drawLine(currentPos, 10, currentPos, 0, Color.gray, "X-AXIS");
                currentPos += scaleX; //  / 2
            }

        }

        float scale(float a) {
            return a * upscaleFactor;
        }

        int scale(int a) {
            return Mathf.RoundToInt(a * upscaleFactor);
        }

        Vector3 scale(Vector3 a, float upscale) {
            return new Vector3(a.x * upscale, a.y * upscale, a.z * upscale);
        }

        // These methods should access game data to get values to draw -- #TODO

        int getSatisfactionValue(int year) {

            // Here we must get the value at year. For now we return year/100;
            return year * year;

        }

        int getUnemploymentValue(int year) {

            // Here we must get the value at year. For now we return year/100;
            return year * year;

        }

        int getInfluenceValue(int year) {

            // Here we must get the value at year. For now we return year/100;
            return year * year;

        }

        int getPopularityValue(int year) {

            // Here we must get the value at year. For now we return year/100;
            return year * year;

        }



        // Use this for initialization
        void Start() {

            // Compute Upscale Factor
            // float parentHeight = ((RectTransform) this.transform.parent).rect.height;
            //float standardHeight = 326;
            float standardWidth = 579;
            upscaleFactor = (Screen.width / standardWidth); // * 1.5f;
                                                            //Debug.Log(Screen.height, this);
                                                            //Debug.Log(upscaleFactor, this);

            // Debug.Log(Screen.width, this);
            //Debug.Log((Screen.width / standardWidth), this);

            // Debug.Log("Init GraphMaker...", this);

            isSatisfactionDrawn = false;
            isUnemploymentDrawn = false;
            isInfluenceDrawn = false;
            isPopularityDrawn = false;

            // Find scaleX
            RectTransform rt = (RectTransform)this.transform;
            width = rt.rect.width;
            height = rt.rect.height;

            // this.posX = this.transform.position.x - width / 2;
            // this.posY = this.transform.position.y - height / 2;

            Debug.Log("Width :" + width + " Height : " + height);

            // Here we must find the current year of the game, for now default to 10
            int year = 6;

            float scaleX = (width / year);
            // Debug.Log("ScaleX = " + scaleX);
            this.scaleY = height / 100;

            // Now that we know the scaleX we can draw the X-axis
            this.year = year;
            this.scaleX = scaleX;

            drawAxis();



        }

        // Update is called once per frame
        void Update() {

        }

        private void drawLine(float x1, float y1, float x2, float y2, Color color, string objname) {


            // Debug.Log("Drawing Line !");

            // Vector3 between two points
            Vector3 pointA = new Vector3(x1, y1);
            pointA = pointA - new Vector3(width / 2, height / 2);
            Vector3 pointB = new Vector3(x2, y2);
            pointB = pointB - new Vector3(width / 2, height / 2);
            Vector3 differenceVector = pointB - pointA;

            // New Object with Line Image
            GameObject GO = new GameObject();
            GO.name = objname;
            GO.transform.SetParent(this.transform, true);
            Image image = GO.AddComponent<Image>();
            image.sprite = Resources.Load<Sprite>("GUI/DetailedInfo/line");

            // Adjust image to link both points
            RectTransform imageRect = image.rectTransform;
            imageRect.sizeDelta = new Vector2(differenceVector.magnitude, 2);
            imageRect.pivot = new Vector2(0, 0.5f);
            imageRect.localPosition = pointA;

            float angle = Mathf.Atan2(differenceVector.y, differenceVector.x) * Mathf.Rad2Deg;
            imageRect.rotation = Quaternion.Euler(0, 0, angle);

            //imageRect.localPosition = imageRect.localPosition * (((upscaleFactor-1)/2048)+1);
            if (objname == "X-AXIS") {
                imageRect.sizeDelta = imageRect.sizeDelta * upscaleFactor;
            }
            else {
                imageRect.sizeDelta = new Vector2(imageRect.sizeDelta.x, imageRect.sizeDelta.y * upscaleFactor);
            }


            // Set color
            image.color = color;


        }

        private void deleteObjects(string name) {
            Image[] childs = this.GetComponentsInChildren<Image>();
            foreach (Image element in childs) {
                if (element.name == name) {
                    GameObject.Destroy(element);
                }
            }
        }

        // Public methods to write a specific graph

        public void drawSatisfactionGraph() {

            if (isSatisfactionDrawn) {
                deleteObjects("SatisfactionX");
                isSatisfactionDrawn = false;
                return;
            }

            // For each year draw line from precedent one to this one
            for (int i = 1; i < year; i++) {

                float year1 = (i - 1) * (scaleX);
                float year2 = i * (scaleX);

                float value1 = getSatisfactionValue(i - 1) * scaleY;
                float value2 = getSatisfactionValue(i) * scaleY;

                drawLine(year1, value1, year2, value2, new Color(118, 0, 118), "SatisfactionX");

            }

            isSatisfactionDrawn = true;

        }

        public void drawUnemploymentGraph() {

            if (isUnemploymentDrawn) {
                deleteObjects("UnemploymentX");
                isUnemploymentDrawn = false;
                return;
            }

            // For each year draw line from precedent one to this one
            for (int i = 1; i < year; i++) {

                float year1 = (i - 1) * scaleX;
                float year2 = i * scaleX;

                float value1 = getUnemploymentValue(i - 1) * scaleY;
                float value2 = getUnemploymentValue(i) * scaleY;

                drawLine(year1, value1, year2, value2, new Color(255, 100, 0), "UnemploymentX");

            }

            isUnemploymentDrawn = true;

        }

        public void drawEnterpriseInfluenceGraph() {

            if (isInfluenceDrawn) {
                deleteObjects("InfluenceX");
                isInfluenceDrawn = false;
                return;
            }

            // For each year draw line from precedent one to this one
            for (int i = 1; i < year; i++) {

                float year1 = (i - 1) * scaleX;
                float year2 = i * scaleX;

                float value1 = getInfluenceValue(i - 1) * scaleY;
                float value2 = getInfluenceValue(i) * scaleY;

                drawLine(year1, value1, year2, value2, new Color(0, 255, 0), "InfluenceX");

            }

            isInfluenceDrawn = true;

        }

        public void drawEnterprisePopularityGraph() {

            if (isPopularityDrawn) {
                deleteObjects("PopularityX");
                isPopularityDrawn = false;
                return;
            }

            // For each year draw line from precedent one to this one
            for (int i = 1; i < year; i++) {

                float year1 = (i - 1) * scaleX;
                float year2 = i * scaleX;

                float value1 = getPopularityValue(i - 1) * scaleY;
                float value2 = getPopularityValue(i) * scaleY;

                drawLine(year1, value1, year2, value2, new Color(0, 0, 255), "PopularityX");

            }

            isPopularityDrawn = true;

        }


    }

}