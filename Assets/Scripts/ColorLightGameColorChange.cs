using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLightGameColorChange : MonoBehaviour
{
    public bool red1, red2, blue1, blue2, green1, green2 = false;

    private float red, green, blue, transparency = 0;
    private SpriteRenderer mySpriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (red1 || red2)
        {
            red = 0.5f;
            if (red1 && red2)
            {
                red = 1f;
            }
        }
        else { 
            red = 0f;
        }

        if (green1 || green2)
        {
            green = 0.5f;
            if (green1 && green2)
            {
                green = 1f;
            }
        }
        else
        {
            green = 0f;
        }

        if (blue1 || blue2)
        {
            blue = 0.5f;
            if (blue1 && blue2)
            {
                blue = 1f;
            }
        }
        else
        {
            blue = 0f;
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

