using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("Awake SaveManager");
        //LoadGame();
    }

    private Save CreateSaveGameObject()
    {
        Save save = new Save();
        List<string> itemNames = new List<string>();

        foreach (var item in Inventory.Instance.AllItems.Distinct())
        {
            itemNames.Add(item.name);
            Debug.Log("Saved " + item.name);
        }
        save.unlockedItems = itemNames;

        return save;
    }

    void OnApplicationQuit()
    {
        Debug.Log("Application ending after " + Time.time + " seconds");
        SaveGame();
    }

    public void SaveGame()
    {
        Save save = CreateSaveGameObject();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, save);
        file.Close();

        Debug.Log("Game Saved at " + Application.persistentDataPath + "/gamesave.save");
    }

    public static List<Item> LoadGame()
    {
        string savePath = Application.persistentDataPath + "/gamesave.save";
        List<Item> loadedItems = new List<Item>();
        if (File.Exists(savePath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(savePath, FileMode.Open);
            try
            {
                Save save = (Save) bf.Deserialize(file);
                file.Close();

                var allItems = Resources.LoadAll<Item>("Items").ToList();

                foreach (var savedItemName in save.unlockedItems)
                {
                    Debug.Log("Trying to load " + savedItemName);
                    foreach (var item in allItems)
                    {
                        if (item.name == savedItemName)
                        {
                            if (!loadedItems.Contains(item))
                            {
                                loadedItems.Add(item);
                            }
                            
                            Debug.Log("Loaded " + item.name);
                        }
                    }
                }

                Debug.Log("Game Loaded from " + Application.persistentDataPath + "/gamesave.save");
            }
            catch (Exception e)
            {
                Debug.LogError("Invalid game save \n" + e.Message);
            }
            
        }
        else
        {
            Debug.Log("No game saved!");
        }

        return loadedItems;
    }
}