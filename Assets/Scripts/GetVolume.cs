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
    public List<Slider> slidersActive;

    public bool win = false;
    public int score = 0;
    public bool slidersList = false;

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
            generalValue.value = 0;

            foreach (GameObject n in artistesOnScene)
            {
                if (n == musiciens.artistes[0])
                {
                    generalValue.value += slider1Value.value;
                    if (slidersList == false)
                    {
                        slidersActive.Add(slider1Value);
                    }
                }
                if (n == musiciens.artistes[1])
                {
                    generalValue.value += slider2Value.value;
                    if (slidersList == false)
                    {
                        slidersActive.Add(slider2Value);
                    }
                }
                if (n == musiciens.artistes[2])
                {
                    generalValue.value += slider3Value.value;
                    if (slidersList == false)
                    {
                        slidersActive.Add(slider3Value);
                    }
                }
                if (n == musiciens.artistes[3])
                {
                    generalValue.value += slider4Value.value;
                    if (slidersList == false)
                    {
                        slidersActive.Add(slider4Value);
                    }
                }
            }

            slidersList = true;

            if (generalValue.value > 90 && generalValue.value < 110 && slidersActive[0].value > 20 && slidersActive[0].value < 30 && slidersActive[1].value > 20 && slidersActive[1].value < 30 && slidersActive[2].value > 20 && slidersActive[2].value < 30 && slidersActive[3].value > 20 && slidersActive[3].value < 30)
            {
                Debug.Log("gagné");
                win = true;

            }
        }

        if (artistesOnScene.Count == 3)
        {
            generalValue.value = 0;

            foreach (GameObject n in artistesOnScene)
            {
                if (n == musiciens.artistes[0])
                {
                    generalValue.value += slider1Value.value;
                    if (slidersList == false)
                    {
                        slidersActive.Add(slider1Value);
                    }
                }
                if (n == musiciens.artistes[1])
                {
                    generalValue.value += slider2Value.value;
                    if (slidersList == false)
                    {
                        slidersActive.Add(slider2Value);
                    }
                }
                if (n == musiciens.artistes[2])
                {
                    generalValue.value += slider3Value.value;
                    if (slidersList == false)
                    {
                        slidersActive.Add(slider3Value);
                    }
                }
                if (n == musiciens.artistes[3])
                {
                    generalValue.value += slider4Value.value;
                    if (slidersList == false)
                    {
                        slidersActive.Add(slider4Value);
                    }
                }
            }

            slidersList = true;

            if (generalValue.value > 145 && generalValue.value < 155 && slidersActive[0].value > 45 && slidersActive[0].value < 55 && slidersActive[1].value > 45 && slidersActive[1].value < 55 && slidersActive[2].value > 45 && slidersActive[2].value < 55)
            {
                Debug.Log("gagné");
                win = true;

            }
        }

        if (artistesOnScene.Count == 2)
        {
            generalValue.value = 0;

            foreach (GameObject n in artistesOnScene)
            {
                if (n == musiciens.artistes[0])
                {
                    generalValue.value += slider1Value.value;
                    if (slidersList == false)
                    {
                        slidersActive.Add(slider1Value);
                    }
                }
                if (n == musiciens.artistes[1])
                {
                    generalValue.value += slider2Value.value;
                    if (slidersList == false)
                    {
                        slidersActive.Add(slider2Value);
                    }
                }
                if (n == musiciens.artistes[2])
                {
                    generalValue.value += slider3Value.value;
                    if (slidersList == false)
                    {
                        slidersActive.Add(slider3Value);
                    }
                }
                if (n == musiciens.artistes[3])
                {
                    generalValue.value += slider4Value.value;
                    if (slidersList == false)
                    {
                        slidersActive.Add(slider4Value);
                    }
                }
            }

            slidersList = true;

            if (generalValue.value > 145 && generalValue.value < 155 && slidersActive[0].value > 70 && slidersActive[0].value < 80 && slidersActive[1].value > 70 && slidersActive[1].value < 80)
            {
                Debug.Log("gagné");
                win = true;

            }
        }

        if (artistesOnScene.Count == 1)
        {
            generalValue.value = 0;

            foreach (GameObject n in artistesOnScene)
            {
                if (n == musiciens.artistes[0])
                {
                    generalValue.value += slider1Value.value;
                    if (slidersList == false)
                    {
                        slidersActive.Add(slider1Value);
                    }
                }
                if (n == musiciens.artistes[1])
                {
                    generalValue.value += slider2Value.value;
                    if (slidersList == false)
                    {
                        slidersActive.Add(slider2Value);
                    }
                }
                if (n == musiciens.artistes[2])
                {
                    generalValue.value += slider3Value.value;
                    if (slidersList == false)
                    {
                        slidersActive.Add(slider3Value);
                    }
                }
                if (n == musiciens.artistes[3])
                {
                    generalValue.value += slider4Value.value;
                    slidersActive.Add(slider4Value);
                }
            }

            slidersList = true;

            if (generalValue.value == 100)
            {
                Debug.Log("gagné");
                win = true;

            }
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
