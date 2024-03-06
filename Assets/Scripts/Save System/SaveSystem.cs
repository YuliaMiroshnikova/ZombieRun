using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{

    public static void SaveGame(int health, float posX, float posY, float posZ)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.itproger";
        FileStream file = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(health, posX, posY, posZ);
        binaryFormatter.Serialize(file, data);
        file.Close();
    }

    public static PlayerData LoadGame()
    {
        string path = Application.persistentDataPath + "/player.itproger";
        if (File.Exists(path))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream file = new FileStream(path, FileMode.Open);
            
            PlayerData data = binaryFormatter.Deserialize(file) as PlayerData;
            file.Close();
            return data;
        }
        else
        {
            Debug.LogError("File not found " + path);
            return null;
        }
    }
    
}
