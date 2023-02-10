using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuChallengeScript : MonoBehaviour
{
    public SaveSerial saveSerial;
    public GameObject panneauFin;
    public GameObject buttonScore;
    public TMP_Text textFinalScore;
    public Sprite spriteOn;
    public Sprite spriteOff;
    
    private CanvasGroup panneauSR;
    private bool scoreOn;
    // Start is called before the first frame update
    void Start()
    {
        panneauSR = panneauFin.GetComponent<CanvasGroup>();
        scoreOn = false;
        var failed = false;
        saveSerial.LoadData();
        textFinalScore.text = "Records :" + saveSerial.bestScore + "\n\n\n\nDernier score :\n" + saveSerial.lastScore;
        if (saveSerial.isScoreCheckerOpen)
        {
            scoreInterraction();
            saveSerial.isScoreCheckerOpen = false;
        }
        
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

            while (saveSerial.success.Count < 5)
            {
                saveSerial.success.Add(false);
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

    public void scoreInterraction()
    {
        if (!scoreOn)
        {
            buttonScore.GetComponent<SpriteRenderer>().sprite = spriteOn;
            panneauSR.alpha = 1;
            panneauSR.blocksRaycasts = true;
            textFinalScore.enabled = true;
            scoreOn = true;
        }
        else if (scoreOn)
        {
            buttonScore.GetComponent<SpriteRenderer>().sprite = spriteOff;
            panneauSR.alpha = 0;
            panneauSR.blocksRaycasts = false;
            textFinalScore.enabled = false;
            scoreOn = false;
        }
    }
}
