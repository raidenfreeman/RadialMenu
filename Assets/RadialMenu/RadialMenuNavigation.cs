using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;

namespace Assets.RadialMenu
{
    class RadialMenuNavigation : RadialMenuItemBase
    {
        public Button forwardButton;
        public Button backwardButton;

        void Awake()
        {
            base.Awake();
            //wrong hierarchy, need children of child
            //if (forwardButton == null)
            //    forwardButton = this.GetComponentInChildren<Button>();
            //if (backwardButton== null)
            //    backwardButton= this.GetComponentsInChildren<Button>()[1];
            backwardButton.GetComponent<Image>().enabled = true;
            forwardButton.GetComponent<Image>().enabled = true;
            backwardButton.GetComponentInChildren<Text>().enabled = true;
            forwardButton.GetComponentInChildren<Text>().text = "Next >";
            backwardButton.GetComponentInChildren<Text>().text = "< Prev";
        }
    }
}
