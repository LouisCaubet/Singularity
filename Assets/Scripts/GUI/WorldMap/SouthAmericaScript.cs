﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace Singularity.GUI.WorldMap {

    public class SouthAmericaScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {

        public void OnPointerClick(PointerEventData eventData) {

            DetailedInfo.SceneArguments.writeArgs("South America", "GUI/WorldMap/SouthAmerica", "in development", "Good - 70 %", "Medium - 14 %", "Good - 56", "Normal - 45");

            PlayerPrefs.SetInt("previousScene", SceneManager.GetActiveScene().buildIndex);
            WorldMapUI.loadDetailedInfoScene();

        }

        public void OnPointerEnter(PointerEventData eventData) {

            // Fill info component with data
            WorldMapUI instance = this.transform.parent.parent.parent.parent.GetComponent<WorldMapUI>();
            InfoComponent editor = instance.getInfoEditor();

            editor.writeGeographicalArea("South America");
            editor.writeImage("GUI/WorldMap/SouthAmerica");
            editor.writeAreaState("undeveloped");
            editor.writeSatisfaction(43);
            editor.writeUnemployment("High");
            editor.writeEnterpriseInfluence("Unknown");
            editor.writeEnterprisePopularity("Bad");

            // Set Info Component Visible
            instance.getInfoComponent().SetActive(true);

        }

        public void OnPointerExit(PointerEventData eventData) {

            // Set Info Component Invisible
            WorldMapUI instance = this.transform.parent.parent.parent.parent.GetComponent<WorldMapUI>();
            instance.getInfoComponent().SetActive(false);

        }

        // Use this for initialization
        void Start() {

            // Take transparency in consideration for button shape
            this.GetComponent<Image>().alphaHitTestMinimumThreshold = 1f;

        }

    }
}
