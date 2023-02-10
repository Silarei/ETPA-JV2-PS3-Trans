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
    public SaveSerial saveSerial;
    public TMP_Text textFinalScore;
    
    private CanvasGroup panneauSR;
    public bool end;
    private int score;
    private float red, green, blue;
    private SpriteRenderer mySpriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        panneauSR = panneauFin.GetComponent<CanvasGroup>();
        end = false;
        score = 0;
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        RandomColorChange();
        saveSerial.LoadData();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > 60 && !end) 
        {
            if (saveSerial.isItChallengeMode)
            {
                var difficulty = saveSerial.difficulty;
                if (difficulty == "easy")
                {
                    textFinalScore.text = "" + (1000 * (score / 5));
                }
                else if (difficulty == "medium")
                {
                    textFinalScore.text = "" + (2000 * (score / 15));
                }
                else if (difficulty == "hard")
                {
                    textFinalScore.text = "" + (4000 * (score / 30));
                }
                else if (difficulty == "hardcore")
                {
                    textFinalScore.text = "" + (10000 * (score / 55));
                }
            }
            else
            {
                textFinalScore.text = "" + (1000 * (score / 5));
            }
            end = true;
            panneauSR.alpha = 1;
            panneauSR.blocksRaycasts = true;
            textFinalScore.enabled = true;
        }
        else if (!end) 
        {
            time.text = "" + System.Math.Round((60 - currentTime), 0);
        }
        if (currentTime > 64)
        {
            if (saveSerial.isItChallengeMode)
            {
                var difficulty = saveSerial.difficulty;
                if (difficulty == "easy")
                {
                    if (score > 4)
                    {
                        saveSerial.success[saveSerial.atWhichGameAreWe] = true;
                    }
                }
                if (difficulty == "medium")
                {
                    if (score > 14)
                    {
                        saveSerial.success[saveSerial.atWhichGameAreWe] = true;
                    }
                }
                if (difficulty == "hard")
                {
                    if (score > 29)
                    {
                        saveSerial.success[saveSerial.atWhichGameAreWe] = true;
                    }
                }
                if (difficulty == "hardcore")
                {
                    if (score > 54)
                    {
                        saveSerial.success[saveSerial.atWhichGameAreWe] = true;
                    }
                }
                saveSerial.atWhichGameAreWe++;
                saveSerial.lastScore += int.Parse(textFinalScore.text);
                saveSerial.SaveData();
                if (saveSerial.atWhichGameAreWe != saveSerial.orderListMiniGame.Count)
                {
                    SceneManager.LoadScene(saveSerial.orderListMiniGame[saveSerial.atWhichGameAreWe]);
                }
                else
                {
                    if (saveSerial.lastScore > saveSerial.bestScore)
                    {
                        saveSerial.bestScore = saveSerial.lastScore;
                    }
                    saveSerial.isScoreCheckerOpen = true;
                    saveSerial.SaveData();
                    SceneManager.LoadScene("MenuChallenge");
                }
            }
            else
            {
                if (score > 4)
                {
                    saveSerial.isGame2Unlocked = true;
                    saveSerial.SaveData();
                }
                SceneManager.LoadScene("MenuFreeGame");
            }
        }
        if (LightPlayer.color == mySpriteRenderer.color && !end)
        {
            RandomColorChange();
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
