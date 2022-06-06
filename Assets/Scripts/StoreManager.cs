using System.IO;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    public static StoreManager Instance { get; private set; }

    public int characterIndex { get; set; }

    /// <summary>
    /// Awakes this instance.
    /// </summary>
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        Instance.Load();
    }

    /// <summary>
    /// Sets the character.
    /// </summary>
    /// <param name="gameObject">The game object.</param>
    public void SetCharacterIndex(int index)
    {
        characterIndex = index;
        Instance.Save();
    }

    /// <summary>
    /// Loads game data.
    /// </summary>
    public void Load()
    {
        string path = Application.persistentDataPath + "/saveFreeWorldFile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            characterIndex = data.CharacterIndex;
        }
    }

    /// <summary>
    /// Saves game data.
    /// </summary>
    public void Save()
    {
        SaveData data = new SaveData();
        data.CharacterIndex = characterIndex;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/saveFreeWorldFile.json", json);
    }

    [System.Serializable]
    class SaveData
    {
        public int CharacterIndex;
    }
}