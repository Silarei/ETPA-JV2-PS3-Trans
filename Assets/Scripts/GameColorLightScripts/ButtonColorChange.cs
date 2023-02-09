using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonColorChange : MonoBehaviour
{
    public bool activated;
    private Image buttonGoingToChange;
    public ButtonColorChange otherButton;
    public float red, green, blue;

    // Start is called before the first frame update
    void Start()
    {
        activated = false;
        buttonGoingToChange = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Change()
    {
        if (otherButton != null)
        {
            if (!activated && otherButton.activated)
            {
                buttonGoingToChange.color = new Color(red, green, blue, 1f);
                buttonGoingToChange.transform.localScale = new Vector3(0.8f, 0.8f, 1f);
                activated = true;
                otherButton.buttonGoingToChange.color = new Color(0.6f, 0.6f, 0.6f, 1f);
                otherButton.buttonGoingToChange.transform.localScale = new Vector3(0.75f, 0.75f, 1f);
                otherButton.activated = false;
            }
            else if (!activated)
            {
                buttonGoingToChange.color = new Color(red, green, blue, 1f);
                buttonGoingToChange.transform.localScale = new Vector3(0.8f, 0.8f, 1f);
                activated = true;
            }
            else
            {
                buttonGoingToChange.color = new Color(0.6f, 0.6f, 0.6f, 1f);
                buttonGoingToChange.transform.localScale = new Vector3(0.75f, 0.75f, 1f);
                activated = false;
            }
        }
        else if (!activated)
        {
            buttonGoingToChange.color = new Color(red, green, blue, 1f);
            buttonGoingToChange.transform.localScale = new Vector3(0.8f, 0.8f, 1f);
            activated = true;
        }
        else
        {
            buttonGoingToChange.color = new Color(red / 2, green / 2, blue / 2, 1f);
            buttonGoingToChange.transform.localScale = new Vector3(0.75f, 0.75f, 1f);
            activated = false;
        }
    }
}
