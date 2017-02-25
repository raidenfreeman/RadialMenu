using UnityEngine;
using UnityEngine.UI;

public abstract class RadialMenuItemBase : MonoBehaviour
{
    public string DescriptionTooltip;
    public string Name;
    public Color Color;
    [HideInInspector]
    public Image ButtonBackgroundReference;
    [HideInInspector]
    public Text ButtonTextReference;

    protected void Awake()
    {
        if (ButtonBackgroundReference == null)
        {
            Debug.Log("Missing image ref!");
            ButtonBackgroundReference = this.GetComponentInChildren<Image>();
            if (ButtonBackgroundReference == null)
            {
                Debug.Log("BOOM!");
                return;
            }
        }
        ButtonBackgroundReference.color = Color;
        ButtonBackgroundReference.enabled = true;
        if (ButtonTextReference == null)
        {
            Debug.Log("Missing text ref!");
            ButtonTextReference = this.GetComponentInChildren<Text>();
            if (ButtonTextReference == null)
            {
                Debug.Log("BOOM!");
                return;
            }
        }
        ButtonTextReference.text = Name;
        ButtonTextReference.enabled = true;
    }
}