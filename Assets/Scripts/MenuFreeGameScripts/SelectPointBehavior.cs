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
    public SaveSerial saveSerial;
    public List<string> listMiniGame;
    public string difficulty;

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
        if (unlocked)
        {
            if (challenge)
            {
                saveSerial.isItChallengeMode = true;
                while (listMiniGameToLaunch.Count < 3)
                {
                    var bruh= Random.Range(0, listMiniGame.Count - 1);
                    Debug.Log(bruh);
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
                saveSerial.SaveData();
                SceneManager.LoadScene(saveSerial.orderListMiniGame[saveSerial.atWhichGameAreWe]);
            }
            else
            {
                saveSerial.isItChallengeMode = false;
                saveSerial.SaveData();
                SceneManager.LoadScene(sceneToLoad);
            }
        }
    }
}
