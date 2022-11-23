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
            buttonGoingToChange.color = Color.red;
            activated = true;
        }
        else
        {
            buttonGoingToChange.color = Color.white;
            activated = false;
        }
    }

    public void BlueChange()
    {
        if (!activated)
        {
            buttonGoingToChange.color = Color.blue;
            activated = true;
        }
        else
        {
            buttonGoingToChange.color = Color.white;
            activated = false;
        }
    }

    public void GreenChange()
    {
        if (!activated)
        {
            buttonGoingToChange.color = Color.green;
            activated = true;
        }
        else
        {
            buttonGoingToChange.color = Color.white;
            activated = false;
        }
    }
}
