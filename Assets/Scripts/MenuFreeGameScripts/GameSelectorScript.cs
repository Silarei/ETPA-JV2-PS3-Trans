using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSelectorScript : MonoBehaviour
{
    public SelectPointBehavior currentHittedSelector;
    private bool previousWasTouching;
    // Start is called before the first frame update
    void Start()
    {
        previousWasTouching = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1 && !previousWasTouching)
        {
            previousWasTouching = true;
            var tempPosition = Input.touches[0].position;
            var screenPos = new Vector3(tempPosition.x, tempPosition.y,
                Camera.main.nearClipPlane - Camera.main.transform.position.z);

            if (currentHittedSelector == null)
            {
                var ray = Camera.main.ScreenPointToRay(screenPos);
                var hit = Physics2D.Raycast(ray.origin, ray.direction);
                if (hit == true)
                {
                    currentHittedSelector = hit.collider.GetComponent<SelectPointBehavior>();
                    currentHittedSelector.LoadGame();
                    currentHittedSelector = null;
                }
            }
            StartCoroutine(Wait());
        }
    }
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        previousWasTouching = false;
    }
}
