using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GamePuzzleGameScript : MonoBehaviour
{
    public PieceGatherer pieceGatherer;

    public float currentTime;
    public TMP_Text timer;
    private float end;

    public GameObject saxoPiece;
    public GameObject pianoPiece;
    public GameObject microPiece;
    public GameObject hornPiece;
    public GameObject hornPiece270;
    public GameObject guitarePiece;
    public GameObject guitarePiece90;
    public GameObject batteriePiece;
    public GameObject batteriePiece90;

    private GameObject piece1;
    private GameObject piece2;
    private GameObject piece3;
    private GameObject piece4;
    private GameObject piece5;
    private GameObject piece6;

    private bool victory;
    // Start is called before the first frame update
    void Start()
    {
        victory = false;
        end = 0f;
        var aleaLevel = Random.Range(0, 1);
        if (aleaLevel <= 0.5f)
        {
            piece1 = Instantiate(batteriePiece90);
            piece2 = Instantiate(batteriePiece, new Vector3(0.7f,0f,0), Quaternion.identity);
            piece3 = Instantiate(microPiece, new Vector3(1.7f,-3.7f,0), Quaternion.identity);
            piece4 = Instantiate(guitarePiece90, new Vector3(1.75f,-1.6f,0), guitarePiece90.transform.rotation);
            piece5 = Instantiate(guitarePiece90);
            piece6 = Instantiate(hornPiece270, new Vector3(-0.7f,-3.6f,0), hornPiece270.transform.rotation);
        }
        else if (aleaLevel > 0.5f)
        {
            piece1 = Instantiate(batteriePiece90);
            piece2 = Instantiate(batteriePiece);
            piece3 = Instantiate(microPiece);
            piece4 = Instantiate(guitarePiece90);
            piece5 = Instantiate(guitarePiece90);
            piece6 = Instantiate(hornPiece270);
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if (!victory) {
            timer.text = "" + System.Math.Round(currentTime, 2);
        }
        if (pieceGatherer.grillePosOccupied.Count == 16 && !victory)
        {
            end = currentTime;
            Debug.Log("Victoire !");
            victory = true;
        }
        if (currentTime - end > 10 && victory)
        {
            SceneManager.LoadScene("MenuFreeGame");
        }
    }
}
