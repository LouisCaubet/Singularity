using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Singularity.Game;
using Singularity.Game.Entities;
using Singularity.Game.GameSystem;
using Singularity.Game.Products;

namespace Singularity.GUI.ProductView {

    public class ProductContentManager : MonoBehaviour {

        public Dictionary<Product, ProductElement> elements;

        // Use this for initialization
        void Start() {

            // TEMP, WILL HAVE TO BE REMOVED
            GameSystem.startGame();
            Player player = GameSystem.game.getPlayer();

            // FOR DEBUG PURPOSES ONLY
            player.soldProducts = new ArrayList(new SellProduct[] {

                new SellProduct(player.products.ADVERTISING_SERVICE, new GeographicArea[0], 500, "ADS+"),
                new SellProduct(player.products.CAR_AUTOPILOT_TECHS, new GeographicArea[0], 500, "Highway+"),
                new SellProduct(player.products.CLIENT_TRACKING_IOT, new GeographicArea[0], 500, "Stalk+"),
                new SellProduct(player.products.CREATE_SEARCH_ENGINE, new GeographicArea[0], 500, "google")

            });

            draw();

        }

        public void draw () {

            // DELETE CURRENT ELEMENTS
            for (int i = 0; i < transform.childCount; i++) {
                GameObject child = transform.GetChild(i).gameObject;
                Destroy(child);
            }

            elements = new Dictionary<Product, ProductElement>();

            Player player = GameSystem.game.getPlayer();


            ArrayList toDraw = player.soldProducts;


            Vector3 position = new Vector3(650, -100);

            foreach (SellProduct p in toDraw) {

                ProductElement element = new ProductElement(p);
                GameObject GO = element.getGameObject();

                GO.transform.SetParent(transform);
                GO.transform.localPosition = position;
                GO.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

                position.y = position.y - 200;
                elements.Add(p.getProduct(), element);

            }

        }

        // Update is called once per frame
        void Update() {

        }
    }

}
