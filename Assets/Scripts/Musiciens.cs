using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musiciens : MonoBehaviour
{

    public List<GameObject> artistes;
    public List<GameObject> artistesOnScene;
    public List<GameObject> sliders;
    

    private SpriteRenderer tempoSR;
    private SpriteRenderer chanteurSR;
    
    

    // Start is called before the first frame update
    void Start()
    {
        NbArtistes();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NbArtistes()
    {
        foreach (GameObject n in artistes)
        {
            var x = Random.Range(0,3);
            var i = 0;
            if (x == 2)
            {
                tempoSR = n.GetComponent<SpriteRenderer>();
                tempoSR.enabled = false;
                i += 1;


            }

            else
            {
                artistesOnScene.Add(n);

            }

            if (i == 4)
            {
                chanteurSR = artistes[2].GetComponent<SpriteRenderer>();
                chanteurSR.enabled = true;
                artistesOnScene.Add(n);

            }

        }
        Debug.Log("Il y a " + artistesOnScene.Count + " artistes sur scène");


    }
}
