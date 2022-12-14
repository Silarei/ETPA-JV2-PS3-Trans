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
    public bool isChallengeUnlocked;
    public bool isEasyModeCompleted;
    public bool isMediumModeCompleted;
    public bool isHardModeCompleted;
    public bool isHardcoreModeCompleted;

    public void SaveData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath
                     + "/MySaveData.dat");
        DataSaved data = new DataSaved();
        data.isGame2Unlocked = isGame2Unlocked;
        data.isGame3Unlocked = isGame3Unlocked;
        data.isGame4Unlocked = isGame4Unlocked;
        data.isChallengeUnlocked = isChallengeUnlocked;
        data.isEasyModeCompleted = isEasyModeCompleted;
        data.isMediumModeCompleted = isMediumModeCompleted;
        data.isHardModeCompleted = isHardModeCompleted;
        data.isHardcoreModeCompleted = isHardcoreModeCompleted;
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
            DataSaved data = (DataSaved)bf.Deserialize(file);
            file.Close();
            isGame2Unlocked = data.isGame2Unlocked;
            isGame3Unlocked = data.isGame3Unlocked;
            isGame4Unlocked = data.isGame4Unlocked;
            isChallengeUnlocked = data.isChallengeUnlocked;
            isEasyModeCompleted = data.isEasyModeCompleted;
            isMediumModeCompleted = data.isMediumModeCompleted;
            isHardModeCompleted = data.isHardModeCompleted;
            isHardcoreModeCompleted = data.isHardcoreModeCompleted;
            Debug.Log("Game data loaded!");
        }
        else
            Debug.LogError("There is no save data!");
    }
}

class DataSaved
{
    public bool isGame2Unlocked;
    public bool isGame3Unlocked;
    public bool isGame4Unlocked;
    public bool isChallengeUnlocked;
    public bool isEasyModeCompleted;
    public bool isMediumModeCompleted;
    public bool isHardModeCompleted;
    public bool isHardcoreModeCompleted;
}
