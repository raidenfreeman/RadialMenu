using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    class RadialMenuOption:RadialMenuItemBase
    {
        public Sprite Icon;
        public Color IconColor;
        public Action Action;
        [HideInInspector]
        public Image ImageReference;

        void Awake()
        {
            base.Awake();
            if(Icon!=null)
            {
                if (ImageReference == null)
                {
                    Debug.Log("Missing image ref!");
                    ImageReference = this.GetComponentInChildren<Image>();
                    if(ImageReference == null)
                    {
                        Debug.Log("BOOM!");
                        return;
                    }
                }
                ImageReference.sprite= Icon;
                ImageReference.enabled = true;
                ImageReference.color = IconColor;
            }
            else
            {
                base.ButtonTextReference.transform.Translate(new Vector3(-35, 0, 0));
                base.ButtonTextReference.GetComponent<RectTransform>().sizeDelta = new Vector2(150, 25);
                //Destroy(ImageReference)
            }
        }
    }
}
