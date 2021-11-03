using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

using Singularity.Game;
using Singularity.Game.Products;
using Singularity.Game.GameSystem;


namespace Singularity.GUI.ProductView {

    public class DeleteButtonScript : MonoBehaviour, IPointerClickHandler {

        public void OnPointerClick(PointerEventData eventData) {

            GameObject parent = this.transform.parent.gameObject;
            Product product = GameSystem.game.getPlayer().products.getByName(parent.name);
            ProductElement element = parent.transform.parent.gameObject.GetComponent<ProductContentManager>().elements[product];

            element.drawDelete();

        }

    }

}
