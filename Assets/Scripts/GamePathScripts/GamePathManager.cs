using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePathManager : MonoBehaviour
{
    public LineRenderer theLine;

    private bool drawing;
    private int indexLine;
    // Start is called before the first frame update
    void Start()
    {
        drawing = false;
        indexLine = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount >= 1)
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
                theLine.positionCount += 1; 
                theLine.SetPosition(indexLine, newPos);
                indexLine += 1;
            }
        }
        else
        {
            theLine.positionCount = 0;
            indexLine = 0;
            drawing = false;
        }
    }
}
