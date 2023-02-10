using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueScript : MonoBehaviour
{
    public SaveSerial saveSerial;
    public SpriteRenderer sPTuto;
    public SpriteRenderer sPNext;
    public List<Sprite> next;
    public List<Sprite> gameLight;
    public List<Sprite> gameSound;
    public List<Sprite> gamePuzzle;
    public List<Sprite> gamePath;
    public List<Sprite> gameBox;

    public List<Sprite> currentGame;
    private List<string> dialogueColorGameLight;
    private float lastTouchTime;
    private float currentTime;
    private bool stillTalking;
    private bool tutoLaunched;
    private bool chara1Talking;
    private int index;

    private int atWhichDialogueAreWe;
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        currentGame = new List<Sprite>();
        if (saveSerial.sceneToLoad == "GameColorLight")
        {
            currentGame = gameLight;
        }
        else if (saveSerial.sceneToLoad == "MiniJeuIngeSon")
        {
            currentGame = gameSound;
        }
        else if (saveSerial.sceneToLoad == "GamePuzzleScene")
        {
            currentGame = gamePuzzle;
        }
        else if (saveSerial.sceneToLoad == "GamePath")
        {
            currentGame = gamePath;
        }
        else if (saveSerial.sceneToLoad == "Magasinier")
        {
            currentGame = gameBox;
        }
        
        sPTuto.sprite = currentGame[index];
        
        if (index == currentGame.Count - 1)
        {
            sPNext.sprite = next[1];
        }
        
        Debug.Log(saveSerial.sceneToLoad);
    }

    public void Next()
    {
        if (index != currentGame.Count - 1)
        {
            index += 1;
            sPTuto.sprite = currentGame[index];
            if (index == currentGame.Count - 1)
            {
                sPNext.sprite = next[1];
            }
        }
        else
        {
            SceneManager.LoadScene(saveSerial.sceneToLoad);
        }
    }
}
