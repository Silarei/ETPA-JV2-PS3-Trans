using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GamePathManager : MonoBehaviour
{
    public LineRenderer theLine;
    public SpriteRenderer currentHittedPiece;
    public TMP_Text instruction;
    public SpriteRenderer cross;
    public SpriteRenderer check;
    public TMP_Text textScore;
    public TMP_Text time;
    public GameObject panneauFin;
    public SaveSerial saveSerial;

    private bool drawing;
    private int indexLine;
    public List<SpriteRenderer> gameObjectList;
    private SpriteRenderer point1;
    private SpriteRenderer point2;
    private bool point1Check;
    private bool point2Check;
    private SpriteRenderer oldPoint1;
    private SpriteRenderer oldPoint2;
    private bool end;

    private float currentTime;
    private float timer;
    private int score;
    private bool error;
    private bool win;

    // Start is called before the first frame update
    void Start()
    {
        saveSerial.LoadData();
        cross.color = new Color(1, 1, 1, 0);
        check.color = new Color(1, 1, 1, 0);
        error = false;
        win = false;
        drawing = false;
        indexLine = 0;
        score = 0;

        var randPoint = Random.Range(0.51f, 6.5f);
        point1 = gameObjectList[Mathf.RoundToInt(randPoint)];
        while (point1 == point2 || point2 == null)
        {
            randPoint = Random.Range(0.51f, 6.5f);
            point2 = gameObjectList[Mathf.RoundToInt(randPoint)];
        }

        oldPoint1 = point1;
        oldPoint2 = point2;

        point1Check = false;
        point2Check = false;

        instruction.SetText("Aller de " + point1.name + " a " + point2.name);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > 60 && !end)
        {
            end = true;
            Instantiate(panneauFin);
        }
        else if (!end)
        {
            time.text = "" + System.Math.Round((60 - currentTime), 0);
        }
        if (currentTime > 65)
        {
            if (saveSerial.isItChallengeMode)
            {
                var difficulty = saveSerial.difficulty;
                if (difficulty == "easy")
                {
                    if (score > 10)
                    {
                        saveSerial.success[saveSerial.atWhichGameAreWe] = true;
                    }
                }
                else if (difficulty == "medium")
                {
                    if (score > 15)
                    {
                        saveSerial.success[saveSerial.atWhichGameAreWe] = true;
                    }
                }
                else if (difficulty == "hard")
                {
                    if (score > 20)
                    {
                        saveSerial.success[saveSerial.atWhichGameAreWe] = true;
                    }
                }
                else if (difficulty == "hardcore")
                {
                    if (score > 25)
                    {
                        saveSerial.success[saveSerial.atWhichGameAreWe] = true;
                    }
                }
                saveSerial.atWhichGameAreWe++; 
                saveSerial.SaveData(); 
                if (saveSerial.atWhichGameAreWe != saveSerial.orderListMiniGame.Count)
                {
                    SceneManager.LoadScene(saveSerial.orderListMiniGame[saveSerial.atWhichGameAreWe]);
                }
                else
                {
                    SceneManager.LoadScene("MenuChallenge");
                }
            }
            else
            {
                if (score > 10)
                {
                    saveSerial.isGame5Unlocked = true;
                    saveSerial.SaveData();
                }
                SceneManager.LoadScene("MenuFreeGame");
            }
        }

        if (Input.touchCount >= 1 && !error && !win && !end)
        {
            var tempPosition = Input.touches[0].position;
            var screenPos = new Vector3(tempPosition.x, tempPosition.y, Camera.main.nearClipPlane - Camera.main.transform.position.z);
            var newPos = Camera.main.ScreenToWorldPoint(screenPos);

            if (!drawing)
            {
                theLine.transform.position = newPos;
                drawing = true;
            }
            if (drawing)
            {
                theLine.positionCount++;
                theLine.SetPosition(indexLine, newPos);
                indexLine++;
            }

           var ray = Camera.main.ScreenPointToRay(screenPos);
           var hit = Physics2D.Raycast(ray.origin, ray.direction);
           if (hit == true)
           {
               currentHittedPiece = hit.collider.GetComponent<SpriteRenderer>();
            }
        }
        else
        {
            theLine.positionCount = 0;
            indexLine = 0;
            drawing = false;
            currentHittedPiece = null;
            point1Check = false;
            point2Check = false;
        }

        if (currentHittedPiece != null && currentHittedPiece != gameObjectList[0] && !win && !error)
        {
            if (currentHittedPiece == point1)
            {
                point1Check = true;
            }
            else if (currentHittedPiece == point2)
            {
                point2Check = true;
            }
            else
            {
                theLine.positionCount = 0;
                indexLine = 0;
                drawing = false;
                error = true;
                point1Check = false;
                point2Check = false;
                currentHittedPiece = null;
                timer = currentTime;
            }
        }
        if (point1Check && point2Check)
        {
            var randPoint = Random.Range(0.51f, 6.5f);
            point1 = gameObjectList[Mathf.RoundToInt(randPoint)];
            randPoint = Random.Range(0.51f, 6.5f);
            point2 = gameObjectList[Mathf.RoundToInt(randPoint)];
            while (point1 == null || point1 == oldPoint2 || point1 == oldPoint1)
            {
                randPoint = Random.Range(0.51f, 6.5f);
                point1 = gameObjectList[Mathf.RoundToInt(randPoint)];
            }
            while (point1 == point2 || point2 == null || point2 == oldPoint2 || point2 == oldPoint1)
            {
                randPoint = Random.Range(0.51f, 6.5f);
                point2 = gameObjectList[Mathf.RoundToInt(randPoint)];
            }

            oldPoint1 = point1;
            oldPoint2 = point2;
            
            point1Check = false;
            point2Check = false;

            instruction.SetText("Aller de " + point1.name + " a " + point2.name);
            score++;
            textScore.text = "" + score;
            win = true;
            timer = currentTime;
            currentHittedPiece = null;
        }

        if (error && currentTime - timer < 1)
        {
            cross.color = new Color(1, 1, 1, (currentTime - timer)*2);
        }
        if (error && currentTime - timer >= 1 && currentTime - timer < 2)
        {
            cross.color = new Color(1, 1, 1, 1 - (currentTime - (timer + 1))*2);
        }
        if (error && currentTime - timer >2)
        {
            error = false;
        }

        if (win && currentTime - timer < 1)
        {
            check.color = new Color(1, 1, 1, (currentTime - timer) * 2);
        }
        if (win && currentTime - timer >= 1 && currentTime - timer < 2)
        {
            check.color = new Color(1, 1, 1, 1 - (currentTime - (timer + 1)) * 2);
        }
        if (win && currentTime - timer > 2)
        {
            win = false;
        }
    }
}
