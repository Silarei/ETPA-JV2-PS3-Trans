using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class GamePuzzleGameScript : MonoBehaviour
{
    public PieceGatherer pieceGatherer;

    public float currentTime;
    public TMP_Text timer;
    public TMP_Text scoreText;
    private float end;
    public SaveSerial saveSerial;
    public GameObject panneauFin;
    public TMP_Text textFinalScore;
    
    private CanvasGroup panneauSR;

    public GameObject saxoPiece;
    public GameObject pianoPiece;
    public GameObject microPiece;
    public GameObject hornPiece;
    public GameObject hornPiece180;
    public GameObject hornPiece270;
    public GameObject guitarePiece;
    public GameObject guitarePiece90;
    public GameObject batteriePiece;
    public GameObject batteriePiece90;
    public GameObject batteriePiece180;
    public GameObject guitareBoxPiece;
    public GameObject guitareBoxPiece90;
    public GameObject guitareBoxPiece180;
    public GameObject pianoPiece90;
    public GameObject hornPiece90;

    private List<GameObject> piece;
    private int score;
    private int lastPuzzle;
    private int aleaLevel;

    // Start is called before the first frame update
    void Start()
    {
        panneauSR = panneauFin.GetComponent<CanvasGroup>();
        saveSerial.LoadData();
        end = 0f;
        piece = new List<GameObject>();
        generateNewPuzzle();
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        timer.text = "" + System.Math.Round(currentTime, 1);
        
        if (pieceGatherer.grillePosOccupied.Count == 16 && currentTime < 61)
        {
            score++;
            scoreText.text = "" + score;
            generateNewPuzzle();
        }
        if (currentTime > 60)
        {
            if (saveSerial.isItChallengeMode)
            {
                var difficulty = saveSerial.difficulty;
                if (difficulty == "easy")
                {
                    textFinalScore.text = "" + (1000 * (score / 2));
                }
                else if (difficulty == "medium")
                {
                    textFinalScore.text = "" + (2000 * (score / 4));
                }
                else if (difficulty == "hard")
                {
                    textFinalScore.text = "" + (4000 * (score / 7));
                }
                else if (difficulty == "hardcore")
                {
                    textFinalScore.text = "" + (10000 * (score / 10));
                }
            }
            else
            {
                textFinalScore.text = "" + (1000 * (score / 2));
            }

            panneauSR.alpha = 1;
            panneauSR.blocksRaycasts = true;
            textFinalScore.enabled = true;
        }
        if (currentTime > 65)
        {
            if (saveSerial.isItChallengeMode)
            {
                var difficulty = saveSerial.difficulty;
                if (difficulty == "easy")
                {
                    if (score > 1)
                    {
                        saveSerial.success[saveSerial.atWhichGameAreWe] = true;
                    }
                }
                else if (difficulty == "medium")
                {
                    if (score > 3)
                    {
                        saveSerial.success[saveSerial.atWhichGameAreWe] = true;
                    }
                }
                else if (difficulty == "hard")
                {
                    if (score > 6)
                    {
                        saveSerial.success[saveSerial.atWhichGameAreWe] = true;
                    }
                }
                else if (difficulty == "hardcore")
                {
                    if (score > 9)
                    {
                        saveSerial.success[saveSerial.atWhichGameAreWe] = true;
                    }
                }
                saveSerial.atWhichGameAreWe++;
                saveSerial.lastScore += int.Parse(textFinalScore.text);
                saveSerial.SaveData();
                if (saveSerial.atWhichGameAreWe != saveSerial.orderListMiniGame.Count)
                { 
                    SceneManager.LoadScene(saveSerial.orderListMiniGame[saveSerial.atWhichGameAreWe]);
                }
                else
                {
                    if (saveSerial.lastScore > saveSerial.bestScore)
                    {
                        saveSerial.bestScore = saveSerial.lastScore;
                    }
                    saveSerial.isScoreCheckerOpen = true;
                    saveSerial.SaveData();
                    SceneManager.LoadScene("MenuChallenge");
                }
            }
            else
            {
                if (score > 1)
                {
                    saveSerial.isGame4Unlocked = true;
                    saveSerial.SaveData();
                }
                SceneManager.LoadScene("MenuFreeGame");
            }
        }
    }

    private void generateNewPuzzle()
    {
        foreach (GameObject item in piece)
        {
            Destroy(item);
        }
        piece.Clear();
        pieceGatherer.grillePosOccupied.Clear();
        while (aleaLevel == lastPuzzle && lastPuzzle != null)
        {
            aleaLevel = Random.Range(0, 6);
        }

        lastPuzzle = aleaLevel;
        if (aleaLevel == 0)
        {
            piece.Add(Instantiate(batteriePiece90, new Vector3(-0.65f,-1.21f,0), batteriePiece90.transform.rotation));
            piece.Add(Instantiate(batteriePiece, new Vector3(0.65f,-3.54f,0), Quaternion.identity));
            piece.Add(Instantiate(microPiece, new Vector3(0.48f,-0.5f,0), Quaternion.identity));
            piece.Add(Instantiate(guitarePiece90, new Vector3(1.65f,-1.27f,0), guitarePiece90.transform.rotation));
            piece.Add(Instantiate(guitarePiece90, new Vector3(-1.47f,-4.2f,0), guitarePiece90.transform.rotation));
            piece.Add(Instantiate(hornPiece270, new Vector3(1.46f,-2.45f,0), hornPiece270.transform.rotation));
        }
        else if (aleaLevel == 1)
        {
            piece.Add(Instantiate(guitareBoxPiece, new Vector3(-1.55f,-2.28f,0), guitareBoxPiece.transform.rotation));
            piece.Add(Instantiate(guitareBoxPiece180, new Vector3(1.57f,-2.77f,0), guitareBoxPiece180.transform.rotation));
            piece.Add(Instantiate(microPiece, new Vector3(1.12f,-0.52f,0), microPiece.transform.rotation));
            piece.Add(Instantiate(microPiece, new Vector3(0.56f,-3.23f,0), microPiece.transform.rotation));
            piece.Add(Instantiate(pianoPiece90, new Vector3(-0.7f,-4.39f,0), pianoPiece90.transform.rotation));
            piece.Add(Instantiate(hornPiece90, new Vector3(-1.35f,-0.19f,0), hornPiece90.transform.rotation));
        }
        else if (aleaLevel == 2)
        {
            piece.Add(Instantiate(guitarePiece90, new Vector3(-0.44f,-2.35f,0), guitarePiece90.transform.rotation));
            piece.Add(Instantiate(guitareBoxPiece90, new Vector3(-0.57f,-0.37f,0), guitareBoxPiece90.transform.rotation));
            piece.Add(Instantiate(guitarePiece, new Vector3(0.77f,-3.4f,0), guitarePiece.transform.rotation));
            piece.Add(Instantiate(microPiece, new Vector3(0.66f,-2.4f,0), microPiece.transform.rotation));
            piece.Add(Instantiate(batteriePiece180, new Vector3(-0.55f,-4.41f,0), batteriePiece180.transform.rotation));
            piece.Add(Instantiate(hornPiece90, new Vector3(0.83f,-1.38f,0), hornPiece90.transform.rotation));
        }
        else if (aleaLevel == 3)
        {
            piece.Add(Instantiate(guitarePiece, new Vector3(-1.63f,-3.35f,0), guitarePiece.transform.rotation));
            piece.Add(Instantiate(microPiece, new Vector3(1.59f,-0.22f,0), microPiece.transform.rotation));
            piece.Add(Instantiate(microPiece, new Vector3(0.41f,-0.9f,0), microPiece.transform.rotation));
            piece.Add(Instantiate(pianoPiece90, new Vector3(-0.7f,-4.39f,0), pianoPiece90.transform.rotation));
            piece.Add(Instantiate(pianoPiece, new Vector3(1.55f,-2.44f,0), pianoPiece.transform.rotation));
            piece.Add(Instantiate(hornPiece180, new Vector3(-1.59f,-1.22f,0), hornPiece180.transform.rotation));
            piece.Add(Instantiate(hornPiece90, new Vector3(-0.5f,-2.01f,0), hornPiece90.transform.rotation));
        }
        else if (aleaLevel == 4)
        {
            piece.Add(Instantiate(microPiece, new Vector3(1.53f,-4.3f,0), microPiece.transform.rotation));
            piece.Add(Instantiate(pianoPiece, new Vector3(-1.7f,-3.3f,0), pianoPiece.transform.rotation));
            piece.Add(Instantiate(hornPiece270, new Vector3(-0.6f,-1.05f,0), hornPiece270.transform.rotation));
            piece.Add(Instantiate(hornPiece270, new Vector3(1.75f,-1.05f,0), hornPiece270.transform.rotation));
            piece.Add(Instantiate(hornPiece90, new Vector3(0.8f,-2.25f,0), hornPiece90.transform.rotation));
            piece.Add(Instantiate(hornPiece, new Vector3(0.4f,-3.41f,0), hornPiece.transform.rotation));
        }
        else
        {
            piece.Add(Instantiate(guitarePiece, new Vector3(0.77f,-3.4f,0), guitarePiece.transform.rotation));
            piece.Add(Instantiate(guitareBoxPiece90, new Vector3(-0.57f,-2.4f,0), guitareBoxPiece90.transform.rotation));
            piece.Add(Instantiate(batteriePiece180, new Vector3(-0.35f,-4.49f,0), batteriePiece180.transform.rotation));
            piece.Add(Instantiate(hornPiece90, new Vector3(-1.52f,-0.3f,0), hornPiece90.transform.rotation));
            piece.Add(Instantiate(hornPiece90, new Vector3(0.71f,-0.3f,0), hornPiece90.transform.rotation));
        }
    }
}
