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
                if (saveSerial.difficulty == "medium")
                {
                    saveSerial.isMediumModeCompleted = true;
                }
                if (saveSerial.difficulty == "hard")
                {
                    saveSerial.isHardModeCompleted = true;
                }
                if (saveSerial.difficulty == "hardcore")
                {
                    saveSerial.isHardcoreModeCompleted = true;
                }
            }
            saveSerial.success[0] = false;
            saveSerial.success[1] = false;
            saveSerial.success[2] = false;
            saveSerial.success[3] = false;
            saveSerial.success[4] = false;
            saveSerial.isItChallengeMode = false;
            saveSerial.SaveData();
            SceneManager.LoadScene("MenuChallenge");
        }
    }
}
