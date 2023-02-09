using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueScript : MonoBehaviour
{
    public SpriteRenderer spriteChara1;
    public SpriteRenderer spriteChara2;
    public SpriteRenderer spriteZoneTexte;
    public TMP_Text dialogue;
    public SaveSerial saveSerial;

    private List<string> dialogueColorGameLight;
    private float lastTouchTime;
    private float currentTime;
    private bool stillTalking;
    private bool tutoLaunched;
    private bool chara1Talking;
    private int atWhichDialogueAreWe;
    // Start is called before the first frame update
    void Start()
    {
        atWhichDialogueAreWe = 0;
        lastTouchTime = 0f;
        stillTalking = true;
        tutoLaunched = false;
        dialogueColorGameLight = new List<string>();
        dialogueColorGameLight.Add("Il faut allumer les lumières Billy !");
        dialogueColorGameLight.Add("Pardon mais qui ètes vous ?");
        dialogueColorGameLight.Add("Les lumières Billy ! Allume les !");
        dialogueColorGameLight.Add("S'il vous plait laissez moi tranquille ou j'appelle la police !");
        dialogueColorGameLight.Add("J'ENCULE LA POLICE !");
        if (saveSerial.sceneToLoad == "GameColorLight")
        {
            chara1Talking = false;
            spriteChara2.transform.localScale = new Vector3(1.5f, 1.5f, 1f);
            spriteChara1.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (Input.touchCount >= 1)
        {
            if (!tutoLaunched && stillTalking && currentTime - lastTouchTime > 0.5f)
            {
                changeWhoTalk();
                NextDialogue();
                lastTouchTime = currentTime;
            }
        }
    }

    private void NextDialogue()
    {
        if (saveSerial.sceneToLoad == "GameColorLight")
        {
            dialogue.SetText(dialogueColorGameLight[atWhichDialogueAreWe]);
            if (dialogueColorGameLight[atWhichDialogueAreWe] == dialogueColorGameLight[dialogueColorGameLight.Count - 1])
            {
                stillTalking = false;
            }
            else
            {
                atWhichDialogueAreWe++;
            }
        }
    }

    private void changeWhoTalk()
    {
        if (chara1Talking)
        {
            chara1Talking = false;
            spriteChara2.transform.localScale = new Vector3(1.5f, 1.5f, 1f);
            spriteChara1.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
            spriteChara1.transform.localScale = new Vector3(1f, 1f, 1f);
            spriteChara2.color = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
            chara1Talking = true;
            spriteChara1.transform.localScale = new Vector3(1.5f, 1.5f, 1f);
            spriteChara2.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
            spriteChara2.transform.localScale = new Vector3(1f, 1f, 1f);
            spriteChara1.color = new Color(1f, 1f, 1f, 1f);
        }
    }
}
