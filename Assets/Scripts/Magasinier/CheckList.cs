using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckList : MonoBehaviour
{

    public Timer timer;

    public GameObject listButton;
    public CheckList checkList;
    public SpriteRenderer checkListSR;

    public TMP_Text nbProjos;
    public TMP_Text nbMicros;
    public TMP_Text nbTambours;
    public TMP_Text nbEnceintes;
    public TMP_Text nbSynthes;
    public TMP_Text nbGuitares;

    public bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        checkListSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
       if (isActive == true)
       {
            checkListSR.enabled = true;
            nbProjos.enabled = true;
            nbMicros.enabled = true;
            nbTambours.enabled = true;
            nbEnceintes.enabled = true;
            nbSynthes.enabled = true;
            nbGuitares.enabled = true;

       }

        else
        {
            checkListSR.enabled = false;
            nbProjos.enabled = false;
            nbMicros.enabled = false;
            nbTambours.enabled = false;
            nbEnceintes.enabled = false;
            nbSynthes.enabled = false;
            nbGuitares.enabled = false;
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
