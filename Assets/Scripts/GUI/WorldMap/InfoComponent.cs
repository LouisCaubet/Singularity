using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Singularity.GUI.WorldMap {

    public class InfoComponent : UnityEngine.Object {

        public InfoComponent() {
            Start();
        }

        // Info Component GameObject
        private GameObject infoComponent;

        private Text geoAreaVal;
        private Image areaImage;
        private Text areaState;
        private Text satisfaction;
        private Text unemployment;
        private Text enterpriseInfluence;
        private Text enterprisePopularity;

        // Use this for initialization
        void Start() {

            infoComponent = GameObject.Find("WorldMapUI").GetComponent<WorldMapUI>().getInfoComponent();

            geoAreaVal = infoComponent.transform.Find("GeoAreaValue").GetComponent<Text>();
            areaImage = infoComponent.transform.Find("Image").GetComponent<Image>();

            areaState = infoComponent.transform.Find("AreaStatusValue").GetComponent<Text>();
            satisfaction = infoComponent.transform.Find("SatisfactionValue").GetComponent<Text>();
            unemployment = infoComponent.transform.Find("UnemploymentValue").GetComponent<Text>();

            enterpriseInfluence = infoComponent.transform.Find("EnterpriseInfluenceValue").GetComponent<Text>();
            enterprisePopularity = infoComponent.transform.Find("EnterprisePopularityValue").GetComponent<Text>();

        }

        // Update is called once per frame
        void Update() {

        }


        // Methods used to write to info component

        public void writeGeographicalArea(string newText) {
            geoAreaVal.text = newText;
        }

        public void writeImage(string path) {
            Sprite image_sprite = Resources.Load<Sprite>(path);

            if (image_sprite == null) {
                Debug.Log("ERROR : image does not exist");
            }



            areaImage.sprite = image_sprite;
        }

        public void writeAreaState(string state) {
            areaState.text = state;
        }

        public void writeSatisfaction(int value) {
            string text = value + " / 100";
            satisfaction.text = text;
        }

        public void writeUnemployment(string value) {
            unemployment.text = value;
        }

        public void writeEnterpriseInfluence(string value) {
            enterpriseInfluence.text = value;
        }

        public void writeEnterprisePopularity(string value) {
            enterprisePopularity.text = value;
        }

    }
}
