using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class SelectPointBehavior : MonoBehaviour
{
    public string sceneToLoad;
    public bool unlocked;
    public bool challenge;
    public bool scoreButton;
    public SaveSerial saveSerial;
    public List<string> listMiniGame;
    public string difficulty;
    public MenuChallengeScript mCS;
    public DialogueScript dS;

    private bool canWeAddIt;
    private List<string> listMiniGameToLaunch;
    // Start is called before the first frame update
    void Start()
    {
        canWeAddIt = true;
        listMiniGameToLaunch = new List<string>();
        saveSerial.LoadData();
    }

    public void LoadGame () 
    {
        if (dS != null)
        {
            dS.Next();
        }
        else if (unlocked)
        {
            if (challenge)
            {
                saveSerial.isItChallengeMode = true;
                while (listMiniGameToLaunch.Count < 5)
                {
                    var bruh= Random.Range(0, listMiniGame.Count);
                    if (listMiniGameToLaunch != null)
                    {
                        foreach (string item in listMiniGameToLaunch)
                        {
                            if (item == listMiniGame[bruh])
                            {
                                canWeAddIt = false;
                                break;
                            }
                        }
                    }

                    if (canWeAddIt)
                    {
                        listMiniGameToLaunch.Add(listMiniGame[bruh]);
                    }

                    canWeAddIt = true;
                }

                saveSerial.orderListMiniGame = listMiniGameToLaunch;
                saveSerial.atWhichGameAreWe = 0;
                saveSerial.difficulty = difficulty;
                saveSerial.lastScore = 0;
                saveSerial.SaveData();
                SceneManager.LoadScene(saveSerial.orderListMiniGame[saveSerial.atWhichGameAreWe]);
            }
            else if (scoreButton)
            {
                mCS.scoreInterraction();
            }
            else
            {
                saveSerial.isItChallengeMode = false;
                saveSerial.sceneToLoad = sceneToLoad;
                saveSerial.SaveData();
                StartCoroutine(Go());
            }
        }
    }

    private IEnumerator Go()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene("SceneTuto");
    }
    
}
