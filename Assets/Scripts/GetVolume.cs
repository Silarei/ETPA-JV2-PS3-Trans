using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetVolume : MonoBehaviour
{
    public Musiciens musiciens;
    private int artistesOnScene;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Volume(float volume)
    {
        Debug.Log(volume);
    }

    public void VolumeGeneral(float volumeGeneral)
    {
        Debug.Log(volumeGeneral);
    }
}
