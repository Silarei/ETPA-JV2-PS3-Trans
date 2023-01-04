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
    public SpriteRenderer panneauSR;
    public SaveSerial saveSerial;
    public GetVolume getVolume;
    public Objets objets;

    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        panneauSR = panneauFin.GetComponent<SpriteRenderer>();
        saveSerial.LoadData();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > 60 && !gameOver)
        {
            gameOver = true;
            panneauSR.enabled = true;
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
                        if (getVolume.score > 15)
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
                        if (getVolume.score > 25)
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
                        if (getVolume.score > 40)
                        {
                            saveSerial.success[saveSerial.atWhichGameAreWe] = true;
                        }
                    }
                    else
                    {
                        if (objets.score > 5)
                        {
                            saveSerial.success[saveSerial.atWhichGameAreWe] = true;
                        }
                    }
                }
                else if (difficulty == "hardcore")
                {
                    if (getVolume != null)
                    {
                        if (getVolume.score > 50)
                        {
                            saveSerial.success[saveSerial.atWhichGameAreWe] = true;
                        }
                    }
                    else
                    {
                        if (objets.score > 7)
                        {
                            saveSerial.success[saveSerial.atWhichGameAreWe] = true;
                        }
                    }
                }

                saveSerial.atWhichGameAreWe++;
                saveSerial.SaveData();
                if (saveSerial.atWhichGameAreWe != saveSerial.orderListMiniGame.Count) 
                { 
                    SceneManager.LoadScene(saveSerial.orderListMiniGame[saveSerial.atWhichGameAreWe]);
                }
                else 
                { 
                    SceneManager.LoadScene("MenuChallenge");
                }
            }
            else
            {
                if (getVolume != null)
                {
                    if (getVolume.score > 15)
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
