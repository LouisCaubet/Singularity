using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Singularity.GUI.DetailedInfo {

    public class InfoEditor : MonoBehaviour {

        private GameObject detailsUI;
        private GameObject currentInfo;

        private Text title;
        private Image areaImage;
        private Text bonusMalus;

        // Current Informations
        private Text areaStatus;
        private Text satisfaction;
        private Text unemployment;
        private Text influence;
        private Text popularity;

        // Use this for initialization
        void Start() {

            detailsUI = GameObject.Find("/AreaDetailsUI");
            currentInfo = GameObject.Find("/AreaDetailsUI/CurrentInfoViewport");

            title = detailsUI.transform.Find("Title").GetComponent<Text>();
            areaImage = detailsUI.transform.Find("AreaImage").GetComponent<Image>();
            bonusMalus = detailsUI.transform.Find("BonusMalusText").GetComponent<Text>();

            areaStatus = currentInfo.transform.Find("AreaStatusValue").GetComponent<Text>();
            satisfaction = currentInfo.transform.Find("SatisfactionValue").GetComponent<Text>();
            unemployment = currentInfo.transform.Find("UnemploymentValue").GetComponent<Text>();
            influence = currentInfo.transform.Find("InfluenceValue").GetComponent<Text>();
            popularity = currentInfo.transform.Find("PopularityValue").GetComponent<Text>();

            // Load from SceneArguments
            writeTitle(SceneArguments.AreaName);
            writeImage(SceneArguments.ImagePath);

            writeAreaStatus(SceneArguments.AreaStatus);
            writeSatisfaction(SceneArguments.Satisfaction);
            writeUnemployment(SceneArguments.Unemployment);
            writeInfluence(SceneArguments.EnterpriseInfluence);
            writePopularity(SceneArguments.EnterprisePopularity);

        }

        // Update is called once per frame
        void Update() {

        }

        // Methods to modify the components
        public void writeTitle(string areaName) {
            string titleText = "Detailed Information - " + areaName;
            title.text = titleText;
        }

        public void writeImage(string path) {
            Sprite sprite = Resources.Load<Sprite>(path);
            areaImage.sprite = sprite;
        }

        public void writeBonusMalus(string text) {
            bonusMalus.text = text;
        }

        public void writeAreaStatus(string status) {
            areaStatus.text = status;
        }

        public void writeSatisfaction(string satisfaction) {
            this.satisfaction.text = satisfaction;
        }

        public void writeUnemployment(string unemployment) {
            this.unemployment.text = unemployment;
        }

        public void writeInfluence(string influence) {
            this.influence.text = influence;
        }

        public void writePopularity(string popularity) {
            this.popularity.text = popularity;
        }

    }
}
