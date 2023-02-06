using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Objets : MonoBehaviour
{

    public List<GameObject> objets;
    public List<SpriteRenderer> synthetizersSRList;
    public List<SpriteRenderer> enceintesSRList;
    public List<SpriteRenderer> microsSRList;
    public List<SpriteRenderer> projecteursSRList;

    private SpriteRenderer synthetizerSR;
    private SpriteRenderer enceinteSR;
    private SpriteRenderer microSR;
    private SpriteRenderer projecteurSR;
    public CanvasGroup checkListImage;
    public CheckList checkList;

    public TMP_Text nbProjosText;
    public TMP_Text nbMicrosText;
    public TMP_Text nbEnceintesText;
    public TMP_Text nbSynthesText;

    public TMP_Text textScore;
    public int score;

    public string nbSynthetizers;
    public string nbEnceintes;
    public string nbMicros;
    public string nbProjecteurs;

    public bool win = false;

    
    void Start()
    {
        RandomizeObject();
        checkListImage = GetComponent<CanvasGroup>();

    }


    void Update()
    {

        textScore.text = "" + score;

        if (nbSynthetizers == nbSynthesText.text && nbEnceintes == nbEnceintesText.text && nbMicros == nbMicrosText.text && nbProjecteurs == nbProjosText.text)
        {
            win = true;
            score++;

            Debug.Log("Gagne");
        }

        if (win == true)
        {
            
            synthetizerSR.enabled = false;
            enceinteSR.enabled = false;
            microSR.enabled = false;
            projecteurSR.enabled = false;
            checkList.isActive = false;
            checkListImage.alpha = 0;
            checkListImage.interactable = false;

            nbProjosText.text = "0";
            nbMicrosText.text = "0";
            nbEnceintesText.text = "0";
            nbSynthesText.text = "0";
            RandomizeObject();
            win = false;
        }



    }





    public void RandomizeObject()
    {
        var b = Random.Range(1, 4);//Synthetizer
        var c = Random.Range(1, 4);//Enceinte
        var e = Random.Range(1, 4);//Micro
        var f = Random.Range(1, 4);//Projecteur




        //Synthetizer
        if (b == 1)
        {
            synthetizerSR = synthetizersSRList[0].GetComponent<SpriteRenderer>();
            synthetizerSR.enabled = true;
            nbSynthetizers = "1";
        }

        else if (b == 2)
        {
            synthetizerSR = synthetizersSRList[1].GetComponent<SpriteRenderer>();
            synthetizerSR.enabled = true;
            nbSynthetizers = "2";
        }

        else
        {
            synthetizerSR = synthetizersSRList[2].GetComponent<SpriteRenderer>();
            synthetizerSR.enabled = true;
            nbSynthetizers = "3";
        }


        //Enceinte
        if (c == 1)
        {
            enceinteSR = enceintesSRList[0].GetComponent<SpriteRenderer>();
            enceinteSR.enabled = true;
            nbEnceintes = "2";
        }

        else if (c == 2)
        {
            enceinteSR = enceintesSRList[1].GetComponent<SpriteRenderer>();
            enceinteSR.enabled = true;
            nbEnceintes = "3";
        }

        else
        {
            enceinteSR = enceintesSRList[2].GetComponent<SpriteRenderer>();
            enceinteSR.enabled = true;
            nbEnceintes = "5";
        }




        //Micro
        if (e == 1)
        {
            microSR = microsSRList[0].GetComponent<SpriteRenderer>();
            microSR.enabled = true;
            nbMicros = "1";
        }

        else if (e == 2)
        {
            microSR = microsSRList[1].GetComponent<SpriteRenderer>();
            microSR.enabled = true;
            nbMicros = "2";
        }

        else
        {
            microSR = microsSRList[2].GetComponent<SpriteRenderer>();
            microSR.enabled = true;
            nbMicros = "3";
        }


        //Projecteur
        if (f == 1)
        {
            projecteurSR = projecteursSRList[0].GetComponent<SpriteRenderer>();
            projecteurSR.enabled = true;
            nbProjecteurs = "1";
        }

        else if (f == 2)
        {
            projecteurSR = projecteursSRList[1].GetComponent<SpriteRenderer>();
            projecteurSR.enabled = true;
            nbProjecteurs = "2";
        }

        else
        {
            projecteurSR = projecteursSRList[2].GetComponent<SpriteRenderer>();
            projecteurSR.enabled = true;
            nbProjecteurs = "4";
        }

    }
}
