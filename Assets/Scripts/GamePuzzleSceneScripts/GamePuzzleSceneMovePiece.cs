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

        public float getY ()
        {
            return myVec2.y;
        }

        public float getX()
        {
            return myVec2.x;
        }

        public bool used()
        {
            return myBool;
        }
    }
    public bool bool0, bool1, bool2, bool3, bool4, bool5, bool6, bool7, bool8;

    private Vector2 tempPosition;
    private List<PositionPiece> listPosPiece;
    private Vector2 previousPosition;
    // Start is called before the first frame update
    void Start()
    {
        listPosPiece = new List<PositionPiece>();

        listPosPiece.Add(new PositionPiece(new Vector2(transform.position.x-1, transform.position.y+0.5f), bool0));
        listPosPiece.Add(new PositionPiece(new Vector2(transform.position.x, transform.position.y+ 0.5f), bool1));
        listPosPiece.Add(new PositionPiece(new Vector2(transform.position.x+1, transform.position.y+ 0.5f), bool2));
        listPosPiece.Add(new PositionPiece(new Vector2(transform.position.x-1, transform.position.y), bool3));
        listPosPiece.Add(new PositionPiece(new Vector2(transform.position.x, transform.position.y), bool4));
        listPosPiece.Add(new PositionPiece(new Vector2(transform.position.x+1, transform.position.y), bool5));
        listPosPiece.Add(new PositionPiece(new Vector2(transform.position.x-1, transform.position.y- 0.5f), bool6));
        listPosPiece.Add(new PositionPiece(new Vector2(transform.position.x, transform.position.y- 0.5f), bool7));
        listPosPiece.Add(new PositionPiece(new Vector2(transform.position.x+1, transform.position.y- 0.5f), bool8));

        previousPosition = new Vector2(listPosPiece[4].getX(), listPosPiece[4].getY());

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            tempPosition = Input.touches[0].position;
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(tempPosition.x, tempPosition.y, Camera.main.nearClipPlane - Camera.main.transform.position.z));
            listPosPiece[0] = (new PositionPiece(new Vector2(transform.position.x - 1, transform.position.y + 0.5f), bool0));
            listPosPiece[1] = (new PositionPiece(new Vector2(transform.position.x, transform.position.y + 0.5f), bool1));
            listPosPiece[2] = (new PositionPiece(new Vector2(transform.position.x + 1, transform.position.y + 0.5f), bool2));
            listPosPiece[3] = (new PositionPiece(new Vector2(transform.position.x - 1, transform.position.y), bool3));
            listPosPiece[4] = (new PositionPiece(new Vector2(transform.position.x, transform.position.y), bool4));
            listPosPiece[5] = (new PositionPiece(new Vector2(transform.position.x + 1, transform.position.y), bool5));
            listPosPiece[6] = (new PositionPiece(new Vector2(transform.position.x - 1, transform.position.y - 0.5f), bool6));
            listPosPiece[7] = (new PositionPiece(new Vector2(transform.position.x, transform.position.y - 0.5f), bool7));
            listPosPiece[8] = (new PositionPiece(new Vector2(transform.position.x + 1, transform.position.y - 0.5f), bool8));
        }
        else
        {
            if (listPosPiece[4].getY() > 1f)
            {
                float tempoY;
                float tempoX;
                if (listPosPiece[4].getY() < 2f)
                {
                    tempoY = 1.5f;
                }
                else if (listPosPiece[4].getY() < 3f)
                {
                    tempoY = 2.5f;
                }
                else if (listPosPiece[4].getY() < 4f)
                {
                    tempoY = 3.5f;
                }
                else
                {
                    tempoY = 4.5f;
                }

                if (listPosPiece[4].getX() < -1f)
                {
                    tempoX = -1.5f;
                }
                else if (listPosPiece[4].getX() < 0f)
                {
                    tempoX = -0.5f;
                }
                else if (listPosPiece[4].getX() < 1f)
                {
                    tempoX = 0.5f;
                }
                else
                {
                    tempoX = 1.5f;
                }

                transform.position = new Vector3(tempoX, tempoY, 0f);
                listPosPiece[0] = (new PositionPiece(new Vector2(transform.position.x - 1, transform.position.y + 0.5f), bool0));
                listPosPiece[1] = (new PositionPiece(new Vector2(transform.position.x, transform.position.y + 0.5f), bool1));
                listPosPiece[2] = (new PositionPiece(new Vector2(transform.position.x + 1, transform.position.y + 0.5f), bool2));
                listPosPiece[3] = (new PositionPiece(new Vector2(transform.position.x - 1, transform.position.y), bool3));
                listPosPiece[4] = (new PositionPiece(new Vector2(transform.position.x, transform.position.y), bool4));
                listPosPiece[5] = (new PositionPiece(new Vector2(transform.position.x + 1, transform.position.y), bool5));
                listPosPiece[6] = (new PositionPiece(new Vector2(transform.position.x - 1, transform.position.y - 0.5f), bool6));
                listPosPiece[7] = (new PositionPiece(new Vector2(transform.position.x, transform.position.y - 0.5f), bool7));
                listPosPiece[8] = (new PositionPiece(new Vector2(transform.position.x + 1, transform.position.y - 0.5f), bool8));
            }
            foreach (PositionPiece item in listPosPiece)
            {
                if (item.used() && (item.getX() > 1.5f || item.getY() > 4.5f || item.getX() < -1.5f || item.getY() < 0.5f))
                {
                    transform.position = new Vector3(previousPosition.x, previousPosition.y, 0f);
                    listPosPiece[0] = (new PositionPiece(new Vector2(transform.position.x - 1, transform.position.y + 0.5f), bool0));
                    listPosPiece[1] = (new PositionPiece(new Vector2(transform.position.x, transform.position.y + 0.5f), bool1));
                    listPosPiece[2] = (new PositionPiece(new Vector2(transform.position.x + 1, transform.position.y + 0.5f), bool2));
                    listPosPiece[3] = (new PositionPiece(new Vector2(transform.position.x - 1, transform.position.y), bool3));
                    listPosPiece[4] = (new PositionPiece(new Vector2(transform.position.x, transform.position.y), bool4));
                    listPosPiece[5] = (new PositionPiece(new Vector2(transform.position.x + 1, transform.position.y), bool5));
                    listPosPiece[6] = (new PositionPiece(new Vector2(transform.position.x - 1, transform.position.y - 0.5f), bool6));
                    listPosPiece[7] = (new PositionPiece(new Vector2(transform.position.x, transform.position.y - 0.5f), bool7));
                    listPosPiece[8] = (new PositionPiece(new Vector2(transform.position.x + 1, transform.position.y - 0.5f), bool8));
                }
            }
        }
    }
}
