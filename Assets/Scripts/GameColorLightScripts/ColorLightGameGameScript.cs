using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ColorLightGameGameScript : MonoBehaviour
{
    public SpriteRenderer LightPlayer;
    public TMP_Text textScore;
    public TMP_Text time;
    public float currentTime;
    public GameObject panneauFin;
    public ColorLightGameColorChange cLGCC;
    public List<ButtonColorChange> bCCList;

    private bool end;
    private int score;
    private float red, green, blue;
    private SpriteRenderer mySpriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        end = false;
        score = 0;
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        RandomColorChange();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > 60 && !end) 
        {
            end = true;
            Instantiate(panneauFin);
        }
        else if (!end) 
        {
            time.text = "" + System.Math.Round((60 - currentTime), 0);
        }
        if (currentTime > 70)
        {
            SceneManager.LoadScene("MenuFreeGame");
        }
        if (LightPlayer.color == mySpriteRenderer.color && !end)
        {
            RandomColorChange();
            Handheld.Vibrate();
            score++;
            textScore.text = "" + score;
            ResetGame();
        }
    }

    private void RandomColorChange()
    {
        float i = Random.Range(0f, 3f);
        if (i < 1f)
        {
            i = Random.Range(0f, 2f);
            if (i < 1f)
            {
                red = 0f;
            }
            else
            {
                red = 0.5f;
            }
            i = Random.Range(0f, 2f);
            if (i < 1f)
            {
                green = 0f;
            }
            else
            {
                green = 0.5f;
            }
            i = Random.Range(0f, 2f);
            if (i < 1f)
            {
                blue = 0f;
            }
            else
            {
                blue = 0.5f;
            }
        }
        else if (i < 2f)
        {
            i = Random.Range(0f, 2f);
            if (i < 1f)
            {
                red = 0f;
            }
            else
            {
                red = 0.2f;
            }
            i = Random.Range(0f, 2f);
            if (i < 1f)
            {
                green = 0f;
            }
            else
            {
                green = 0.2f;
            }
            i = Random.Range(0f, 2f);
            if (i < 1f)
            {
                blue = 0f;
            }
            else
            {
                blue = 0.2f;
            }
        }
        else
        {
            i = Random.Range(0f, 2f);
            if (i < 1f)
            {
                red = 0f;
            }
            else
            {
                red = 0.8f;
            }
            i = Random.Range(0f, 2f);
            if (i < 1f)
            {
                green = 0f;
            }
            else
            {
                green = 0.8f;
            }
            i = Random.Range(0f, 2f);
            if (i < 1f)
            {
                blue = 0f;
            }
            else
            {
                blue = 0.8f;
            }
        }

        if (red != 0 || green != 0 || blue != 0)
        {
            mySpriteRenderer.color = new Color(red, green, blue, 1);
        }
        else
        {
            RandomColorChange();
        }        
    }

    public void ResetGame()
    {
        cLGCC.blue1 = true;
        cLGCC.red1 = true;
        cLGCC.green1 = true;
        cLGCC.intensityHigh = true;
        cLGCC.intensityLow = true;
        cLGCC.Green1Switch();
        cLGCC.Red1Switch();
        cLGCC.Blue1Switch();
        cLGCC.IntensityHighSwitch();
        cLGCC.IntensityLowSwitch();
        foreach (ButtonColorChange item in bCCList)
        {
            if (item.activated)
            {
                item.Change();
            }
        }
    }
}
