using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using Singularity.Game;
using Singularity.Game.GameSystem;


namespace Singularity.GUI.ProductView {

    public class BackButtonScript : MonoBehaviour, IPointerClickHandler {

        public void OnPointerClick(PointerEventData eventData) {

            ProductContentManager manager = transform.parent.parent.gameObject.GetComponent<ProductContentManager>();
            Product product = GameSystem.game.getPlayer().products.getByName(transform.parent.gameObject.name);
            ProductElement element = manager.elements[product];

            for (int i=0; i<transform.parent.childCount; i++) {

                GameObject child = transform.parent.GetChild(i).gameObject;

                if(child.name == "edit_name_2") {
                    element.getSellProduct().rename(child.GetComponent<InputField>().text);
                }
                else if (child.name == "edit_price_2") {
                    string s = child.GetComponent<InputField>().text;
                    double price;
                    
                    if (s == "") {
                        price = 0;
                    }
                    else {
                        price = Math.Abs(double.Parse(s));
                    }

                    element.getSellProduct().setPrice(price);
                }

            }

            element.drawNormal();

        }

    }

}
