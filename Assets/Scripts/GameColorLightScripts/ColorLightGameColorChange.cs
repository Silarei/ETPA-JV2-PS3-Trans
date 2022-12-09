using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ColorLightGameColorChange : MonoBehaviour
{
    public bool red1, red2, blue1, blue2, green1, green2 = false;

    public GameObject redSpot1, redSpot2, greenSpot1, greenSpot2, blueSpot1, blueSpot2;

    private SpriteRenderer redSpot1SR, redSpot2SR, greenSpot1SR, greenSpot2SR, blueSpot1SR, blueSpot2SR;
    private float red, green, blue, transparency = 0;
    private SpriteRenderer mySpriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        redSpot1SR = redSpot1.GetComponent<SpriteRenderer>();
        redSpot2SR = redSpot2.GetComponent<SpriteRenderer>();
        greenSpot1SR = greenSpot1.GetComponent<SpriteRenderer>();
        greenSpot2SR = greenSpot2.GetComponent<SpriteRenderer>();
        blueSpot1SR = blueSpot1.GetComponent<SpriteRenderer>();
        blueSpot2SR = blueSpot2.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (red1 || red2)
        {
            red = 0.5f;
            redSpot1SR.color = new Color(1f, 1f, 1f, 1f);
            redSpot2SR.color = new Color(1f, 1f, 1f, 0f);
            if (red1 && red2)
            {
                red = 1f;
                redSpot2SR.color = new Color(1f, 1f, 1f, 1f);
            }
        }
        else { 
            red = 0f;
            redSpot1SR.color = new Color(1f, 1f, 1f, 0f);
            redSpot2SR.color = new Color(1f, 1f, 1f, 0f);
        }

        if (green1 || green2)
        {
            green = 0.5f; 
            greenSpot1SR.color = new Color(1f, 1f, 1f, 1f);
            greenSpot2SR.color = new Color(1f, 1f, 1f, 0f);
            if (green1 && green2)
            {
                green = 1f;
                greenSpot2SR.color = new Color(1f, 1f, 1f, 1f);
            }
        }
        else
        {
            green = 0f;
            greenSpot1SR.color = new Color(1f, 1f, 1f, 0f);
            greenSpot2SR.color = new Color(1f, 1f, 1f, 0f);
        }

        if (blue1 || blue2)
        {
            blue = 0.5f;
            blueSpot1SR.color = new Color(1f, 1f, 1f, 1f);
            blueSpot2SR.color = new Color(1f, 1f, 1f, 0f);
            if (blue1 && blue2)
            {
                blue = 1f;
                blueSpot2SR.color = new Color(1f, 1f, 1f, 1f);
            }
        }
        else
        {
            blue = 0f;
            blueSpot1SR.color = new Color(1f, 1f, 1f, 0f);
            blueSpot2SR.color = new Color(1f, 1f, 1f, 0f);
        }

        if (red > 0 || green > 0 || blue > 0)
        {
            transparency = 1;
        }
        else
        {
            transparency = 0;
        }

        mySpriteRenderer.color = new Color(red, green, blue, transparency);
    }

    public void Red1Switch()
    {
        if (red1)
        {
            red1 = false;
        }
        else
        {
            red1 = true;
        }
    }

    public void Red2Switch()
    {
        if (red2)
        {
            red2 = false;
        }
        else
        {
            red2 = true;
        }
    }

    public void Blue1Switch()
    {
        if (blue1)
        {
            blue1 = false;
        }
        else
        {
            blue1 = true;
        }
    }

    public void Blue2Switch()
    {
        if (blue2)
        {
            blue2 = false;
        }
        else
        {
            blue2 = true;
        }
    }

    public void Green1Switch()
    {
        if (green1)
        {
            green1 = false;
        }
        else
        {
            green1 = true;
        }
    }

    public void Green2Switch()
    {
        if (green2)
        {
            green2 = false;
        }
        else
        {
            green2 = true;
        }
    }

}

