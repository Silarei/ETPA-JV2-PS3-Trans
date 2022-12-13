using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public TMP_Text time;
    public float currentTime;
    public GameObject panneauFin;
    public SpriteRenderer panneauSR;

    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        panneauSR = panneauFin.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > 60 && !gameOver)
        {
            gameOver = true;
            panneauSR.enabled = true;
        }

        else if (!gameOver)
        {
            time.text = "" + System.Math.Round((60 - currentTime), 0);
        }

        if (currentTime > 65)
        {
            SceneManager.LoadScene("MenuFreeGame");
        }
    }
}
