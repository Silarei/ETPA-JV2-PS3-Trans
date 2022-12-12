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
            time.text = "" + System.Math.Round((60 - currentTime), 1);
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
