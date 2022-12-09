using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musiciens : MonoBehaviour
{

    public List<GameObject> artistes;
    public List<GameObject> artistesOnScene;
    public List<GameObject> sliders;
    public List<GameObject> slidersActive;

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
                /*int sliderPosition = sliders.IndexOf(n);
                sliders[sliderPosition].isStatic = true;*/
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
                //sliders[4].isStatic = false;

                
            }

        }
        Debug.Log("Il y a " + artistesOnScene.Count + " artistes sur scène");

        /*foreach (GameObject n in sliders)
        {
            int artistePosition = artistesOnScene.IndexOf(n);
            if (artistesOnScene[artistePosition])
            {
            


            }

            else
            {
                slidersActive.Add(n);

            }


        }
        Debug.Log("Il y a " + slidersActive.Count + " slider.s actif.s");*/
    }
}
