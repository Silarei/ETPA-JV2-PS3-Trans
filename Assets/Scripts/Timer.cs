using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public TMP_Text time;
    public float currentTime;
    public GameObject panneauFin;
    public CanvasGroup panneauSR;
    public SaveSerial saveSerial;
    public GetVolume getVolume;
    public Objets objets;

    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        panneauSR = panneauFin.GetComponent<CanvasGroup>();
        saveSerial.LoadData();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > 60 && !gameOver)
        {
            if (saveSerial.isItChallengeMode)
            {
                var difficulty = saveSerial.difficulty;
                if (difficulty == "easy")
                {
                    if (getVolume != null)
                    {
                        if (getVolume.score > 4)
                        {
                            getVolume.textFinalScore.text = "" + (1000 * (getVolume.score / 5));
                        }
                    }
                    else
                    {
                        if (objets.score > 1)
                        {
                            objets.textFinalScore.text = "" + (1000 * (objets.score / 2));
                        }
                    }
                }
                else if (difficulty == "medium")
                {
                    if (getVolume != null)
                    {
                        getVolume.textFinalScore.text = "" + (2000 * (getVolume.score / 15));
                    }
                    else
                    {
                        objets.textFinalScore.text = "" + (2000 * (objets.score / 4));
                    }
                }
                else if (difficulty == "hard")
                {
                    if (getVolume != null)
                    {
                        getVolume.textFinalScore.text = "" + (4000 * (getVolume.score / 30));
                    }
                    else
                    {
                        objets.textFinalScore.text = "" + (4000 * (objets.score / 7));
                    }
                }
                else if (difficulty == "hardcore")
                {
                    if (getVolume != null)
                    {
                        getVolume.textFinalScore.text = "" + (10000 * (getVolume.score / 50));
                    }
                    else
                    {
                        objets.textFinalScore.text = "" + (10000 * (objets.score / 10));
                    }
                }
            }
            else
            {
                if (getVolume != null)
                {
                    getVolume.textFinalScore.text = "" + (1000 * (getVolume.score / 4));
                }
                else
                {
                    objets.textFinalScore.text = "" + (1000 * (objets.score / 4));
                }
            }
            gameOver = true;
            panneauSR.alpha = 1;
            panneauSR.blocksRaycasts = true;
        }

        else if (!gameOver)
        {
            time.text = "" + System.Math.Round((60 - currentTime), 0);
        }

        if (currentTime > 65)
        {
            if (saveSerial.isItChallengeMode)
            {
                var difficulty = saveSerial.difficulty;
                if (difficulty == "easy")
                {
                    if (getVolume != null)
                    {
                        if (getVolume.score > 4)
                        {
                            saveSerial.success[saveSerial.atWhichGameAreWe] = true;
                        }
                    }
                    else
                    {
                        if (objets.score > 1)
                        {
                            saveSerial.success[saveSerial.atWhichGameAreWe] = true;
                        }
                    }
                }
                else if (difficulty == "medium")
                {
                    if (getVolume != null)
                    {
                        if (getVolume.score > 14)
                        {
                            saveSerial.success[saveSerial.atWhichGameAreWe] = true;
                        }
                    }
                    else
                    {
                        if (objets.score >3)
                        {
                            saveSerial.success[saveSerial.atWhichGameAreWe] = true;
                        }
                    }
                }
                else if (difficulty == "hard")
                {
                    if (getVolume != null)
                    {
                        if (getVolume.score > 29)
                        {
                            saveSerial.success[saveSerial.atWhichGameAreWe] = true;
                        }
                    }
                    else
                    {
                        if (objets.score > 6)
                        {
                            saveSerial.success[saveSerial.atWhichGameAreWe] = true;
                        }
                    }
                }
                else if (difficulty == "hardcore")
                {
                    if (getVolume != null)
                    {
                        if (getVolume.score > 49)
                        {
                            saveSerial.success[saveSerial.atWhichGameAreWe] = true;
                        }
                    }
                    else
                    {
                        if (objets.score > 9)
                        {
                            saveSerial.success[saveSerial.atWhichGameAreWe] = true;
                        }
                    }
                }

                if (getVolume != null)
                {
                    saveSerial.lastScore += int.Parse(getVolume.textFinalScore.text);
                }
                else
                {
                    saveSerial.lastScore += int.Parse(objets.textFinalScore.text);
                }

                saveSerial.atWhichGameAreWe++;
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
                if (getVolume != null)
                {
                    if (getVolume.score > 4)
                    {
                        saveSerial.isGame3Unlocked = true;
                    }
                }
                else
                {
                    if (objets.score > 1)
                    {
                        saveSerial.isChallengeUnlocked = true;
                    }
                }
                saveSerial.SaveData();
                SceneManager.LoadScene("MenuFreeGame");
            }
        }
    }
}
