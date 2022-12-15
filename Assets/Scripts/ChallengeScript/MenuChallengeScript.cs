using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuChallengeScript : MonoBehaviour
{
    public SaveSerial saveSerial;
    // Start is called before the first frame update
    void Start()
    {
        var failed = false;
        saveSerial.LoadData();
        if (saveSerial.isItChallengeMode)
        {
            foreach (bool item in saveSerial.success)
            {
                if (!item)
                {
                    failed = true;
                }
            }

            if (!failed)
            {
                if (saveSerial.difficulty == "easy")
                {
                    saveSerial.isEasyModeCompleted = true;
                }
            }
            saveSerial.success[0] = false;
            saveSerial.success[1] = false;
            saveSerial.success[2] = false;
            saveSerial.isItChallengeMode = false;
            saveSerial.SaveData();
            SceneManager.LoadScene("MenuChallenge");
        }
    }
}
