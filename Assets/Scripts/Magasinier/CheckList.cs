using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckList : MonoBehaviour
{

    public Timer timer;

    public CheckList checkList;
    public CanvasGroup checkListImage;
    public SwipeUp swipeUp;

    public TMP_Text nbProjos;
    public TMP_Text nbMicros;
    public TMP_Text nbEnceintes;
    public TMP_Text nbSynthes;


    // Start is called before the first frame update
    void Start()
    {
        checkListImage = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
       if (swipeUp.isCheckListUp == true)
       {
            checkListImage.interactable = true;
            checkListImage.blocksRaycasts = true;
            nbProjos.enabled = true;
            nbMicros.enabled = true;
            nbEnceintes.enabled = true;
            nbSynthes.enabled = true;

       }

        else
        {
            checkListImage.interactable = false;
            checkListImage.blocksRaycasts = false;
            nbProjos.enabled = false;
            nbMicros.enabled = false;
            nbEnceintes.enabled = false;
            nbSynthes.enabled = false;
        }

        if (timer.gameOver == true)
        {
            swipeUp.isCheckListUp = false;
            
        }

    }


    
}
