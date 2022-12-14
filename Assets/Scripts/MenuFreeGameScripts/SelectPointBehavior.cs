using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectPointBehavior : MonoBehaviour
{
    public string sceneToLoad;
    public bool unlocked;
    public bool challenge;
    public SaveSerial saveSerial;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadGame () 
    {
        if (unlocked)
        {
            if (challenge)
            {
                saveSerial.isItChallengeMode = true;
            }
            else
            {
                saveSerial.isItChallengeMode = false;
            }
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
