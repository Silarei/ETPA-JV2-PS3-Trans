using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceGatherer : MonoBehaviour
{
    public GamePuzzleSceneMovePiece currentHittedPiece;
    public List<GamePuzzleSceneMovePiece.PositionPiece> grillePosOccupied;
    private List<GamePuzzleSceneMovePiece.PositionPiece> tempoGrillePos;
    // Start is called before the first frame update
    void Start()
    {
        grillePosOccupied = new List<GamePuzzleSceneMovePiece.PositionPiece>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount >= 1)
        {
            var tempPosition = Input.touches[0].position;
            var screenPos = new Vector3(tempPosition.x, tempPosition.y, Camera.main.nearClipPlane - Camera.main.transform.position.z);

            if (currentHittedPiece == null)
            {
                var ray = Camera.main.ScreenPointToRay(screenPos);
                var hit = Physics2D.Raycast(ray.origin, ray.direction);
                if (hit == true) 
                {
                    currentHittedPiece = hit.collider.GetComponent<GamePuzzleSceneMovePiece>();
                    tempoGrillePos = currentHittedPiece.ReturnOccupiedPos();
                    foreach (GamePuzzleSceneMovePiece.PositionPiece item in tempoGrillePos)
                    {
                        foreach (GamePuzzleSceneMovePiece.PositionPiece item2 in grillePosOccupied)
                        {
                            if (item == item2)
                            {
                                Debug.Log(item2.GetX() + " " + item2.GetY());
                                grillePosOccupied.Remove(item2);
                                break;
                            }
                        }
                        
                    }
                }
            }

            if (currentHittedPiece != null)
            {
                var newPos = Camera.main.ScreenToWorldPoint(screenPos);
                currentHittedPiece.OnTouch(newPos);
            }
        }
        else
        {
            if (currentHittedPiece != null)
            {
                currentHittedPiece.OnPasTouch();
                tempoGrillePos = currentHittedPiece.ReturnOccupiedPos();
                foreach (GamePuzzleSceneMovePiece.PositionPiece item in tempoGrillePos)
                {
                    grillePosOccupied.Add(item);
                }
                currentHittedPiece = null;
            }
        }
    }
}
