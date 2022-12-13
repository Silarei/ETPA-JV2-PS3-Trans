using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSelectorScript : MonoBehaviour
{
    public SelectPointBehavior currentHittedSelector;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount >= 1)
        {
            var tempPosition = Input.touches[0].position;
            var screenPos = new Vector3(tempPosition.x, tempPosition.y, Camera.main.nearClipPlane - Camera.main.transform.position.z);

            if (currentHittedSelector == null)
            {
                var ray = Camera.main.ScreenPointToRay(screenPos);
                var hit = Physics2D.Raycast(ray.origin, ray.direction);
                if (hit == true) 
                {
                    currentHittedSelector = hit.collider.GetComponent<SelectPointBehavior>();
                    currentHittedSelector.LoadGame();
                }
            }
        }
    }
}
