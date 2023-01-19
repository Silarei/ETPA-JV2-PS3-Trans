using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ColorLightGameColorChange : MonoBehaviour
{
    public bool red1, blue1, green1, intensityLow, intensityHigh = false;
    public ColorLightGameGameScript cLGGS;

    public SpriteRenderer redSpot2SR, greenSpot2SR, blueSpot2SR;
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
        if (!cLGGS.end)
        {
            if (red1)
            {
                red = 0.5f;
                redSpot2SR.color = new Color(1f, 1f, 1f, 0.8f);
                if (intensityHigh)
                {
                    red = 0.8f;
                    redSpot2SR.color = new Color(1f, 1f, 1f, 1f);
                }

                if (intensityLow)
                {
                    red = 0.2f;
                    redSpot2SR.color = new Color(1f, 1f, 1f, 0.6f);
                }
            }
            else
            {
                red = 0f;
                redSpot2SR.color = new Color(1f, 1f, 1f, 0f);
            }

            if (green1)
            {
                green = 0.5f;
                greenSpot2SR.color = new Color(1f, 1f, 1f, 0.8f);
                if (intensityHigh)
                {
                    green = 0.8f;
                    greenSpot2SR.color = new Color(1f, 1f, 1f, 1f);
                }

                if (intensityLow)
                {
                    green = 0.2f;
                    greenSpot2SR.color = new Color(1f, 1f, 1f, 0.6f);
                }
            }
            else
            {
                green = 0f;
                greenSpot2SR.color = new Color(1f, 1f, 1f, 0f);
            }

            if (blue1)
            {
                blue = 0.5f;
                blueSpot2SR.color = new Color(1f, 1f, 1f, 0.8f);
                if (intensityHigh)
                {
                    blue = 0.8f;
                    blueSpot2SR.color = new Color(1f, 1f, 1f, 1f);
                }

                if (intensityLow)
                {
                    blue = 0.2f;
                    blueSpot2SR.color = new Color(1f, 1f, 1f, 0.6f);
                }
            }
            else
            {
                blue = 0f;
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

    public void IntensityHighSwitch()
    {
        if (intensityHigh)
        {
            intensityHigh = false;
        }
        else
        {
            intensityHigh = true;
            intensityLow = false;
        }
    }
    public void IntensityLowSwitch()
    {
        if (intensityLow)
        {
            intensityLow = false;
        }
        else
        {
            intensityLow = true;
            intensityHigh = false;
        }
    }

}

