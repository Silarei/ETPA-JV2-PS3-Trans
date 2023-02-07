using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveSerial : MonoBehaviour
{
    public bool isGame2Unlocked;
    public bool isGame3Unlocked;
    public bool isGame4Unlocked;
    public bool isGame5Unlocked;
    public bool isChallengeUnlocked;
    public bool isEasyModeCompleted;
    public bool isMediumModeCompleted;
    public bool isHardModeCompleted;
    public bool isHardcoreModeCompleted;
    public bool isItChallengeMode;
    public List<string> orderListMiniGame;
    public int atWhichGameAreWe;
    public string difficulty;
    public List<bool> success;
    public string sceneToLoad;

    public void SaveData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath
                     + "/MySaveData.dat");
        DataSaved data = new DataSaved();
        data.isGame2Unlocked = isGame2Unlocked;
        data.isGame3Unlocked = isGame3Unlocked;
        data.isGame4Unlocked = isGame4Unlocked;
        data.isGame5Unlocked = isGame5Unlocked;
        data.isChallengeUnlocked = isChallengeUnlocked;
        data.isEasyModeCompleted = isEasyModeCompleted;
        data.isMediumModeCompleted = isMediumModeCompleted;
        data.isHardModeCompleted = isHardModeCompleted;
        data.isHardcoreModeCompleted = isHardcoreModeCompleted;
        data.isItChallengeMode = isItChallengeMode;
        data.orderListMiniGame = orderListMiniGame;
        data.atWhichGameAreWe = atWhichGameAreWe;
        data.difficulty = difficulty;
        data.success = success;
        data.sceneToLoad = sceneToLoad;
        bf.Serialize(file, data);
        file.Close();
    }

    public void LoadData()
    {
        if (File.Exists(Application.persistentDataPath
                   + "/MySaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file =
                       File.Open(Application.persistentDataPath
                       + "/MySaveData.dat", FileMode.Open);
            file.Position = 0;
            DataSaved data = (DataSaved)bf.Deserialize(file);
            file.Close();
            isGame2Unlocked = data.isGame2Unlocked;
            isGame3Unlocked = data.isGame3Unlocked;
            isGame4Unlocked = data.isGame4Unlocked;
            isGame5Unlocked = data.isGame5Unlocked;
            isChallengeUnlocked = data.isChallengeUnlocked;
            isEasyModeCompleted = data.isEasyModeCompleted;
            isMediumModeCompleted = data.isMediumModeCompleted;
            isHardModeCompleted = data.isHardModeCompleted;
            isHardcoreModeCompleted = data.isHardcoreModeCompleted;
            isItChallengeMode = data.isItChallengeMode;
            orderListMiniGame = data.orderListMiniGame;
            atWhichGameAreWe = data.atWhichGameAreWe;
            difficulty = data.difficulty;
            success = data.success;
            sceneToLoad = data.sceneToLoad;
            Debug.Log("Game data loaded!");
        }
        else
            Debug.LogError("There is no save data!");
    }
}

[Serializable]
class DataSaved
{
    public bool isGame2Unlocked;
    public bool isGame3Unlocked;
    public bool isGame4Unlocked;
    public bool isGame5Unlocked;
    public bool isChallengeUnlocked;
    public bool isEasyModeCompleted;
    public bool isMediumModeCompleted;
    public bool isHardModeCompleted;
    public bool isHardcoreModeCompleted;
    public bool isItChallengeMode;
    public List<string> orderListMiniGame;
    public int atWhichGameAreWe;
    public string difficulty;
    public List<bool> success;
    public string sceneToLoad;
}
