using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ColorLightGameGameScript : MonoBehaviour
{
    public SpriteRenderer LightPlayer;
    public TMP_Text textScore;

    private int score;
    private float red, green, blue;
    private SpriteRenderer mySpriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        RandomColorChange();
    }

    // Update is called once per frame
    void Update()
    {
        if (LightPlayer.color == mySpriteRenderer.color)
        {
            Debug.Log("Prout");
            RandomColorChange();
            score++;
            textScore.text = "" + score;
        }
    }

    private void RandomColorChange()
    {
        red = RandomRGB();
        green = RandomRGB();
        blue = RandomRGB();

        if (red != 0 || green != 0 || blue != 0)
        {
            mySpriteRenderer.color = new Color(red, green, blue, 1);
        }
        else
        {
            RandomColorChange();
        }        
    }

    private float RandomRGB()
    {
        float i = Random.Range(0f, 3f);
        if (i < 1f)
        {
            return 0f;
        }
        else if (i < 2f)
        {
            return 0.5f;
        }
        else
        {
            return 1f;
        }
    }
}
