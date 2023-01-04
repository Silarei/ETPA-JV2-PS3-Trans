using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlocker : MonoBehaviour
{
    public List<GameObject> gameObjectList;
    public SaveSerial saveSerial;
    void Start()
    {
        saveSerial.LoadData();
        foreach (GameObject item in gameObjectList)
        {

            var bruh = item.GetComponent<SpriteRenderer>();
            var bruhDah = item.GetComponent<SelectPointBehavior>();
            if (item.name == "point_14")
            {
                if (saveSerial.isGame2Unlocked)
                {
                    bruh.color = new Color(1f, 1f, 1f, 1f);
                    bruhDah.unlocked = true;
                }
                else
                {
                    bruh.color = new Color(1f, 1f, 1f, 0.4f);
                }
            }
            else if (item.name == "point_5")
            {
                if (saveSerial.isGame3Unlocked)
                {
                    bruh.color = new Color(1f, 1f, 1f, 1f);
                    bruhDah.unlocked = true;
                }
                else
                {
                    bruh.color = new Color(1f, 1f, 1f, 0.4f);
                }
            }
            else if (item.name == "point_7")
            {
                if (saveSerial.isGame4Unlocked)
                {
                    bruh.color = new Color(1f, 1f, 1f, 1f);
                    bruhDah.unlocked = true;
                }
                else
                {
                    bruh.color = new Color(1f, 1f, 1f, 0.4f);
                }
            }
            else if (item.name == "point_4_8")
            {
                if (saveSerial.isGame5Unlocked)
                {
                    bruh.color = new Color(1f, 1f, 1f, 1f);
                    bruhDah.unlocked = true;
                }
                else
                {
                    bruh.color = new Color(1f, 1f, 1f, 0.4f);
                }
            }
            else if (item.name == "ButtonChallenge" || item.name == "ButtonFacile" || item.name == "ButtonHistoire")
            {
                if (saveSerial.isChallengeUnlocked)
                {
                    bruh.color = new Color(1f, 1f, 1f, 1f);
                    bruhDah.unlocked = true;
                }
                else
                {
                    bruh.color = new Color(1f, 1f, 1f, 0.4f);
                }
            }
            else if (item.name == "ButtonMoyen")
            {
                if (saveSerial.isEasyModeCompleted)
                {
                    bruh.color = new Color(1f, 1f, 1f, 1f);
                    bruhDah.unlocked = true;
                }
                else
                {
                    bruh.color = new Color(1f, 1f, 1f, 0.2f);
                }
            }
            else if (item.name == "ButtonDifficile")
            {
                if (saveSerial.isMediumModeCompleted)
                {
                    bruh.color = new Color(1f, 1f, 1f, 1f);
                    bruhDah.unlocked = true;
                }
                else
                {
                    bruh.color = new Color(1f, 1f, 1f, 0.2f);
                }
            }
            else if (item.name == "ButtonOrganisateur")
            {
                if (saveSerial.isHardModeCompleted)
                {
                    bruh.color = new Color(1f, 1f, 1f, 1f);
                    bruhDah.unlocked = true;
                }
                else
                {
                    bruh.color = new Color(1f, 1f, 1f, 0.2f);
                }
            }
            else if (item.name == "")
            {
                if (saveSerial.isHardcoreModeCompleted)
                {
                    bruh.color = new Color(1f, 1f, 1f, 1f);
                }
                else
                {
                    bruh.color = new Color(1f, 1f, 1f, 0.4f);
                }
            }
        }
    }
}
