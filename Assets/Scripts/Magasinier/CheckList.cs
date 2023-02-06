using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckList : MonoBehaviour
{

    public Timer timer;

    public GameObject listButton;
    public CheckList checkList;
    public CanvasGroup checkListImage;

    public TMP_Text nbProjos;
    public TMP_Text nbMicros;
    public TMP_Text nbEnceintes;
    public TMP_Text nbSynthes;

    public bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        checkListImage = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
       if (isActive == true)
       {
            checkListImage.alpha = 1;
            checkListImage.interactable = true;
            nbProjos.enabled = true;
            nbMicros.enabled = true;
            nbEnceintes.enabled = true;
            nbSynthes.enabled = true;

       }

        else
        {
            checkListImage.alpha = 0;
            checkListImage.interactable = false;
            nbProjos.enabled = false;
            nbMicros.enabled = false;
            nbEnceintes.enabled = false;
            nbSynthes.enabled = false;
        }

        if (timer.gameOver == true)
        {
            isActive = false;
            
        }

    }

    public void CheckListVisible()
    {
        if (isActive)
        {
            isActive = false;
        }

        else
        {
            isActive = true;
        }
    }

    
}
