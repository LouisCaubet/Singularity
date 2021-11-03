using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

using Singularity.Game;
using Singularity.Game.Entities;
using Singularity.Game.GameSystem;

namespace Singularity.GUI.MarketingTree {

    public class MarketingChooseButton : TooltipScript, IPointerClickHandler {

        public void OnPointerClick(PointerEventData eventData) {

            Player player = GameSystem.game.getPlayer();

            MarketingTech old = player.marketingtech_current;

            MarketingTech called = player.marketingTechs.getByName(this.name);
            player.marketingtech_current = called;

            if (old != null) {
                ContentManager.choosers[old].update();
            }

            // Invoke update method of Marketing Chooser
            MarketingChoose chooser = ContentManager.choosers[called];
            chooser.setMarketingTechRunning();

        }


        // Update is called once per frame
        protected override void Update() {
            base.Update();
        }

        protected override void OnDestroy() {
            base.OnDestroy();
        }

    }

}
