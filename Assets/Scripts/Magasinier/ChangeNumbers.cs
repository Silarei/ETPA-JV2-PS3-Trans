using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeNumbers : MonoBehaviour
{
    public TMP_Text nbProjos;
    public TMP_Text nbMicros;
    public TMP_Text nbTambours;
    public TMP_Text nbEnceintes;
    public TMP_Text nbSynthes;
    public TMP_Text nbGuitares;

    void Start()
    {

    }


    void Update()
    {

    }

    public void ChangeNbProjos()
    {
        if (nbProjos.text == "0")
        {
            nbProjos.text = "1";
        }

        else if (nbProjos.text == "1")
        {
            nbProjos.text = "2";
        }

        else if (nbProjos.text == "2")
        {
            nbProjos.text = "4";
        }

        else
        {
            nbProjos.text = "0";
        }
    }

    public void ChangeNbMicros()
    {
        if (nbMicros.text == "0")
        {
            nbMicros.text = "1";
        }

        else if (nbMicros.text == "1")
        {
            nbMicros.text = "2";
        }

        else if (nbMicros.text == "2")
        {
            nbMicros.text = "3";
        }

        else
        {
            nbMicros.text = "0";
        }
    }

    public void ChangeNbTambours()
    {
        if (nbTambours.text == "0")
        {
            nbTambours.text = "2";
        }

        else if (nbTambours.text == "2")
        {
            nbTambours.text = "5";
        }

        else if (nbTambours.text == "5")
        {
            nbTambours.text = "6";
        }

        else
        {
            nbTambours.text = "0";
        }
    }

    public void ChangeNbEnceintes()
    {
        if (nbEnceintes.text == "0")
        {
            nbEnceintes.text = "2";
        }

        else if (nbEnceintes.text == "2")
        {
            nbEnceintes.text = "3";
        }

        else if (nbEnceintes.text == "3")
        {
            nbEnceintes.text = "5";
        }

        else
        {
            nbEnceintes.text = "0";
        }
    }

    public void ChangeNbSynthes()
    {
        if (nbSynthes.text == "0")
        {
            nbSynthes.text = "1";
        }

        else if (nbSynthes.text == "1")
        {
            nbSynthes.text = "2";
        }

        else if (nbSynthes.text == "2")
        {
            nbSynthes.text = "3";
        }

        else
        {
            nbSynthes.text = "0";
        }
    }

    public void ChangeNbGuitares()
    {
        if (nbGuitares.text == "0")
        {
            nbGuitares.text = "1";
        }

        else if (nbGuitares.text == "1")
        {
            nbGuitares.text = "2";
        }

        else
        {
            nbGuitares.text = "0";
        }
    }
}
