using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonColorChange : MonoBehaviour
{
    private bool activated;
    private Image buttonGoingToChange;
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

    public void RedChange()
    {
        if (!activated)
        {
            buttonGoingToChange.color = new Color(1f, 0f, 0f, 1f);
            activated = true;
        }
        else
        {
            buttonGoingToChange.color = new Color(0.5f, 0.2f, 0.2f, 1f);
            activated = false;
        }
    }

    public void BlueChange()
    {
        if (!activated)
        {
            buttonGoingToChange.color = new Color(0f, 0f, 1f, 1f);
            activated = true;
        }
        else
        {
            buttonGoingToChange.color = new Color(0.2f, 0.2f, 0.5f, 1f);
            activated = false;
        }
    }

    public void GreenChange()
    {
        if (!activated)
        {
            buttonGoingToChange.color = new Color(0f, 1f, 0f, 1f);
            activated = true;
        }
        else
        {
            buttonGoingToChange.color = new Color(0.2f, 0.5f, 0.2f, 1f);
            activated = false;
        }
    }
}
