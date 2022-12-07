using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePuzzleGameScript : MonoBehaviour
{
    public PieceGatherer pieceGatherer;

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
        var aleaLevel = Random.Range(0, 1);
        if (aleaLevel <= 0.5f)
        {
            piece1 = Instantiate(batteriePiece90);
            piece2 = Instantiate(batteriePiece);
            piece3 = Instantiate(microPiece);
            piece4 = Instantiate(guitarePiece90);
            piece5 = Instantiate(guitarePiece90);
            piece6 = Instantiate(hornPiece270);
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
        if (pieceGatherer.grillePosOccupied.Count == 16 && !victory)
        {
            Debug.Log("Victoire !");
            victory = true;
        }
        if (pieceGatherer.grillePosOccupied.Count != 16 && victory)
        {
            Debug.Log("Ah non");
            victory = false;
        }
    }
}
