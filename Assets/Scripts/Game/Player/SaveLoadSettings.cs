using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoadSettings : MonoBehaviour
{
    [SerializeField]
    private Toggle vibrationsToggle;
    [SerializeField]
    private VibrationManager vibrationManager;

    private bool data;

    private void Awake()
    {
        Load();
        vibrationsToggle.isOn = data;
        vibrationManager.Switch(data);
    }

    private void OnEnable()
    {
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    private void OnSceneUnloaded(Scene currentScene)
    {
        Save();
    }

    public void Save()
    {
        // Serialize and save all the necessary data into the file named "SettingsData.gd"
        data = vibrationsToggle.isOn;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/SettingsData.gd");
        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        // Deseialize file "SettingsData.gd" and extract all the data
        if (File.Exists(Application.persistentDataPath + "/SettingsData.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/SettingsData.gd", FileMode.Open);
            data = (bool)bf.Deserialize(file);
            file.Close();
        }
    }
}
