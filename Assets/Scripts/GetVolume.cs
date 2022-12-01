using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetVolume : MonoBehaviour
{
    public Musiciens musiciens;
    public GameObject volumeGeneral;
    public GameObject slider1;
    public int slider1Volume;
    public GameObject slider2;
    public int slider2Volume;
    public GameObject slider3;
    public int slider3Volume;
    public GameObject slider4;
    public int slider4Volume;
    private List<GameObject> artistesOnScene;

    // Start is called before the first frame update
    void Start()
    {
        artistesOnScene = musiciens.artistesOnScene;
    }

    // Update is called once per frame
    void Update()
    {
        if (artistesOnScene.Count == 4)
        {
            if(slider1Volume == 25)
            {
                
            }
        }
    }

    public void Volume(int volume)
    {
        Debug.Log(volume);
    }

    public void VolumeGeneral(int volumeGeneral)
    {
        Debug.Log(volumeGeneral);
    }
}
