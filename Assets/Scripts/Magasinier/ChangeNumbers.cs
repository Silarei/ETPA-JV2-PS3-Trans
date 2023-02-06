using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeNumbers : MonoBehaviour
{
    public TMP_Text nbProjos;
    public TMP_Text nbMicros;
    public TMP_Text nbEnceintes;
    public TMP_Text nbSynthes;

    void Start()
    {

    }


    void Update()
    {

    }

    public void ChangeNbProjos()
    {
        if (nbProjos.text != "5")
        {
            int projosValue = int.Parse(nbProjos.text);

            nbProjos.text = (projosValue + 1).ToString();
        }

        else if (nbProjos.text == "5")
        {
            nbProjos.text = "0";
        }

    }

    public void ChangeNbMicros()
    {
        if (nbMicros.text != "5")
        {
            int microsValue = int.Parse(nbMicros.text);

            nbMicros.text = (microsValue + 1).ToString();
        }

        else if (nbMicros.text == "5")
        {
            nbMicros.text = "0";
        }

    }


    public void ChangeNbEnceintes()
    {
        if (nbEnceintes.text != "5")
        {
            int enceintesValue = int.Parse(nbEnceintes.text);

            nbEnceintes.text = (enceintesValue + 1).ToString();
        }

        else if (nbEnceintes.text == "5")
        {
            nbEnceintes.text = "0";
        }

    }

    public void ChangeNbSynthes()
    {
        if (nbSynthes.text != "5")
        {
            int synthesValue = int.Parse(nbSynthes.text);

            nbSynthes.text = (synthesValue + 1).ToString();
        }

        else if (nbSynthes.text == "5")
        {
            nbSynthes.text = "0";
        }

    }
}
