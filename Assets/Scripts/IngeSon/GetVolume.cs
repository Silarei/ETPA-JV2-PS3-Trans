using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GetVolume : MonoBehaviour
{
    public Musiciens musiciens;
    public GameObject spotBleu;
    public bool bleuOn = false;
    public GameObject spotRouge;
    public bool rougeOn = false;
    public GameObject spotVert;
    public bool vertOn = false;


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

    public TMP_Text textScore;

    public bool win = false;
    public int score = 0;
    public bool slidersList = false;
    private SpriteRenderer chanteurSR;
    private SpriteRenderer pianisteSR;
    private SpriteRenderer batteurSR;
    private SpriteRenderer guitaristeSR;
    public SpriteRenderer spotBleuSR;
    public SpriteRenderer spotRougeSR;
    public SpriteRenderer spotVertSR;


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        artistesOnScene = musiciens.artistesOnScene;
        pianisteSR = musiciens.artistes[0].GetComponent<SpriteRenderer>();
        batteurSR = musiciens.artistes[1].GetComponent<SpriteRenderer>();
        chanteurSR = musiciens.artistes[2].GetComponent<SpriteRenderer>();
        guitaristeSR = musiciens.artistes[3].GetComponent<SpriteRenderer>();
        spotBleuSR = spotBleu.GetComponent<SpriteRenderer>();
        spotRougeSR = spotRouge.GetComponent<SpriteRenderer>();
        spotVertSR = spotVert.GetComponent<SpriteRenderer>();

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

            if (slidersActive[0].value > 15 && slidersActive[0].value < 35)
            {
                Handheld.Vibrate();
            }

            if (slidersActive[1].value > 15 && slidersActive[0].value < 35)
            {
                Handheld.Vibrate();
            }

            if (slidersActive[2].value > 15 && slidersActive[0].value < 35)
            {
                Handheld.Vibrate();
            }

            if (slidersActive[3].value > 15 && slidersActive[0].value < 35)
            {
                Handheld.Vibrate();
            }

            if (generalValue.value > 90 && generalValue.value < 110 && slidersActive[0].value > 15 && slidersActive[0].value < 35 && slidersActive[1].value > 15 && slidersActive[1].value < 35 && slidersActive[2].value > 15 && slidersActive[2].value < 35 && slidersActive[3].value > 15 && slidersActive[3].value < 35)
            {

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

            if (slidersActive[0].value > 20 && slidersActive[0].value < 40)
            {
                Handheld.Vibrate();
            }

            if (slidersActive[1].value > 20 && slidersActive[0].value < 40)
            {
                Handheld.Vibrate();
            }

            if (slidersActive[2].value > 20 && slidersActive[0].value < 40)
            {
                Handheld.Vibrate();
            }

            if (generalValue.value > 90 && generalValue.value < 110 && slidersActive[0].value > 20 && slidersActive[0].value < 40 && slidersActive[1].value > 20 && slidersActive[1].value < 40 && slidersActive[2].value > 20 && slidersActive[2].value < 40)
            {

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

            if (slidersActive[0].value > 40 && slidersActive[0].value < 60)
            {
                Handheld.Vibrate();
            }

            if (slidersActive[1].value > 40 && slidersActive[1].value < 60)
            {
                Handheld.Vibrate();
            }

            if (generalValue.value > 90 && generalValue.value < 110 && slidersActive[0].value > 40 && slidersActive[0].value < 60 && slidersActive[1].value > 40 && slidersActive[1].value < 60)
            {

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
                    if (slidersList == false)
                    {
                        slidersActive.Add(slider4Value);
                    }
                }
            }

            slidersList = true;

            if (slidersActive[0].value == 100)
            {
                Handheld.Vibrate();
            }

            if (generalValue.value > 90 && generalValue.value < 110)
            {
                win = true;

            }
        }
        if (win)
        {
            score++;
            textScore.text = "" + score;
            StartCoroutine(SpotLight());
            win = false;
            slidersList = false;
            slidersActive.Clear();
            artistesOnScene.Clear();
            pianisteSR.enabled = true;
            batteurSR.enabled = true;
            chanteurSR.enabled = true;
            guitaristeSR.enabled = true;
            musiciens.NbArtistes();
            generalValue.value = 0;
            slider1Value.value = 0;
            slider2Value.value = 0;
            slider3Value.value = 0;
            slider4Value.value = 0;
            
 
        }

        

    }


    public void Volume(float volume)
    {
        
    }

    public void VolumeGeneral(float volumeGeneral)
    {
        

    }

    public IEnumerator SpotLight()
    {
        spotRougeSR.enabled = true;
        yield return new WaitForSeconds(0.5f);
        spotRougeSR.enabled = false;
        spotBleuSR.enabled = true;
        spotVertSR.enabled = true;
        yield return new WaitForSeconds(0.5f);
        spotBleuSR.enabled = false;
        spotVertSR.enabled = false;

    }
    
}
