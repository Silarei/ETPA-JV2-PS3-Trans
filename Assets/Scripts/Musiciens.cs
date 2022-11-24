using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musiciens : MonoBehaviour
{

    public List<GameObject> artistes;
    private SpriteRenderer tempoSR;
    
    

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
            if (x == 2)
            {
                tempoSR = n.GetComponent<SpriteRenderer>();
                tempoSR.enabled = false;
                
                
                



            }
        }
    }
}
