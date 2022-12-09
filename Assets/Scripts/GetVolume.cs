using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetVolume : MonoBehaviour
{
    public Musiciens musiciens;
    public Slider generalValue;
    public GameObject slider1;
    public Slider slider1Value;
    public GameObject slider2;
    public Slider slider2Value;
    public GameObject slider3;
    public Slider slider3Value;
    public GameObject slider4;
    public Slider slider4Value;
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
            generalValue.value = slider1Value.value + slider2Value.value + slider3Value.value + slider4Value.value;
            if(generalValue.value > 90 && generalValue.value < 110)
            {
                Debug.Log("gagné");
            }
        }

        if (artistesOnScene.Count == 3)
        {
            
        }
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
