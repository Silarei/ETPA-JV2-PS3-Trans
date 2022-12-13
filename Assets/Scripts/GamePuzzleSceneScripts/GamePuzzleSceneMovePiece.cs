using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePuzzleSceneMovePiece : MonoBehaviour
{
    public class PositionPiece
    {

        Vector2 myVec2;
        bool myBool;

        public PositionPiece(Vector2 newVec2, bool newBool)
        {
            myVec2 = newVec2;
            myBool = newBool;
        }

        public float GetY ()
        {
            return myVec2.y;
        }

        public float GetX()
        {
            return myVec2.x;
        }

        public bool Used()
        {
            return myBool;
        }
    }
    public bool bool0, bool1, bool2, bool3, bool4, bool5, bool6, bool7, bool8;
    public PieceGatherer pieceGatherer;

    private bool inPlace;
    private List<PositionPiece> listPosPiece;
    private Vector2 previousPosition;
    // Start is called before the first frame update
    void Start()
    {
        inPlace = false;
        listPosPiece = new List<PositionPiece>();

        listPosPiece.Add(new PositionPiece(new Vector2(transform.position.x-1, transform.position.y+1f), bool0));
        listPosPiece.Add(new PositionPiece(new Vector2(transform.position.x, transform.position.y+ 1f), bool1));
        listPosPiece.Add(new PositionPiece(new Vector2(transform.position.x+1, transform.position.y+ 1f), bool2));
        listPosPiece.Add(new PositionPiece(new Vector2(transform.position.x-1, transform.position.y), bool3));
        listPosPiece.Add(new PositionPiece(new Vector2(transform.position.x, transform.position.y), bool4));
        listPosPiece.Add(new PositionPiece(new Vector2(transform.position.x+1, transform.position.y), bool5));
        listPosPiece.Add(new PositionPiece(new Vector2(transform.position.x-1, transform.position.y- 1f), bool6));
        listPosPiece.Add(new PositionPiece(new Vector2(transform.position.x, transform.position.y- 1f), bool7));
        listPosPiece.Add(new PositionPiece(new Vector2(transform.position.x+1, transform.position.y- 1f), bool8));

        previousPosition = new Vector2(listPosPiece[4].GetX(), listPosPiece[4].GetY());

        pieceGatherer = GameObject.Find("PieceGatherer").GetComponent<PieceGatherer>();
        
    }


    public void OnTouch(Vector3 newPos)
    {
        transform.position = newPos;

        listPosPiece[0] = (new PositionPiece(new Vector2(transform.position.x - 1, transform.position.y + 1f), bool0));
        listPosPiece[1] = (new PositionPiece(new Vector2(transform.position.x, transform.position.y + 1f), bool1));
        listPosPiece[2] = (new PositionPiece(new Vector2(transform.position.x + 1, transform.position.y + 1f), bool2));
        listPosPiece[3] = (new PositionPiece(new Vector2(transform.position.x - 1, transform.position.y), bool3));
        listPosPiece[4] = (new PositionPiece(new Vector2(transform.position.x, transform.position.y), bool4));
        listPosPiece[5] = (new PositionPiece(new Vector2(transform.position.x + 1, transform.position.y), bool5));
        listPosPiece[6] = (new PositionPiece(new Vector2(transform.position.x - 1, transform.position.y - 1f), bool6));
        listPosPiece[7] = (new PositionPiece(new Vector2(transform.position.x, transform.position.y - 1f), bool7));
        listPosPiece[8] = (new PositionPiece(new Vector2(transform.position.x + 1, transform.position.y - 1f), bool8));

    }

    public void OnPasTouch()
    {

        if (listPosPiece[4].GetY() > 1f)
        {
            float tempoY;
            float tempoX;
            if (listPosPiece[4].GetY() < 2f)
            {
                tempoY = 1.4f;
            }
            else if (listPosPiece[4].GetY() < 3f)
            {
                tempoY = 2.4f;
            }
            else if (listPosPiece[4].GetY() < 4f)
            {
                tempoY = 3.4f;
            }
            else
            {
                tempoY = 4.4f;
            }

            if (listPosPiece[4].GetX() < -1f)
            {
                tempoX = -1.5f;
            }
            else if (listPosPiece[4].GetX() < 0f)
            {
                tempoX = -0.5f;
            }
            else if (listPosPiece[4].GetX() < 1f)
            {
                tempoX = 0.5f;
            }
            else
            {
                tempoX = 1.5f;
            }
            inPlace = true;

            transform.position = new Vector3(tempoX, tempoY, 0f);
            listPosPiece[0] = (new PositionPiece(new Vector2(transform.position.x - 1, transform.position.y + 1f), bool0));
            listPosPiece[1] = (new PositionPiece(new Vector2(transform.position.x, transform.position.y + 1f), bool1));
            listPosPiece[2] = (new PositionPiece(new Vector2(transform.position.x + 1, transform.position.y + 1f), bool2));
            listPosPiece[3] = (new PositionPiece(new Vector2(transform.position.x - 1, transform.position.y), bool3));
            listPosPiece[4] = (new PositionPiece(new Vector2(transform.position.x, transform.position.y), bool4));
            listPosPiece[5] = (new PositionPiece(new Vector2(transform.position.x + 1, transform.position.y), bool5));
            listPosPiece[6] = (new PositionPiece(new Vector2(transform.position.x - 1, transform.position.y - 1f), bool6));
            listPosPiece[7] = (new PositionPiece(new Vector2(transform.position.x, transform.position.y - 1f), bool7));
            listPosPiece[8] = (new PositionPiece(new Vector2(transform.position.x + 1, transform.position.y - 1f), bool8));
        }
        foreach (PositionPiece item in listPosPiece)
        {
            if (item.Used() && (item.GetX() > 1.5f || item.GetY() > 4.5f || item.GetX() < -1.5f || item.GetY() < 1f))
            {
                ReturnToInitialPos();
                break;
            }
        }
        foreach (PositionPiece item in listPosPiece)
        {
            foreach (PositionPiece item2 in pieceGatherer.grillePosOccupied)
            {
                if (item.Used() && (item.GetX() == item2.GetX() && item.GetY() == item2.GetY()))
                {
                    ReturnToInitialPos(); 
                    goto End;
                }
            }
        }
        End:
        return;
        
    }

    public List<PositionPiece> ReturnOccupiedPos ()
    {
        var listOccupiedPos = new List<PositionPiece>();
        var tempList = new List<PositionPiece>();
        tempList = null;
        foreach (PositionPiece item in listPosPiece)
        {
            if (item.Used() && inPlace)
            {
                listOccupiedPos.Add(item);
            }
        }
        tempList = listOccupiedPos;
        return tempList;
    }

    public void ReturnToInitialPos()
    {
        transform.position = new Vector3(previousPosition.x, previousPosition.y, 0f);
        listPosPiece[0] = (new PositionPiece(new Vector2(transform.position.x - 1, transform.position.y + 1f), bool0));
        listPosPiece[1] = (new PositionPiece(new Vector2(transform.position.x, transform.position.y + 1f), bool1));
        listPosPiece[2] = (new PositionPiece(new Vector2(transform.position.x + 1, transform.position.y + 1f), bool2));
        listPosPiece[3] = (new PositionPiece(new Vector2(transform.position.x - 1, transform.position.y), bool3));
        listPosPiece[4] = (new PositionPiece(new Vector2(transform.position.x, transform.position.y), bool4));
        listPosPiece[5] = (new PositionPiece(new Vector2(transform.position.x + 1, transform.position.y), bool5));
        listPosPiece[6] = (new PositionPiece(new Vector2(transform.position.x - 1, transform.position.y - 1f), bool6));
        listPosPiece[7] = (new PositionPiece(new Vector2(transform.position.x, transform.position.y - 1f), bool7));
        listPosPiece[8] = (new PositionPiece(new Vector2(transform.position.x + 1, transform.position.y - 1f), bool8));
        inPlace = false;
    }
}
