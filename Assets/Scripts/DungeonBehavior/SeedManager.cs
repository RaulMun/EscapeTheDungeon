using System.IO;
using UnityEngine;

public class DungeonSeedManager : MonoBehaviour
{
    [System.Serializable]
    public class DungeonSaveData
    {
        public int seed;
        public System.DateTime saveTime;
    }

    public void SaveCurrentSeed(DungeonCreator dungeonCreator)
    {
        DungeonSaveData saveData = new DungeonSaveData
        {
            seed = dungeonCreator.seed,
            saveTime = System.DateTime.Now
        };

        string json = JsonUtility.ToJson(saveData, true);
        string path = Application.persistentDataPath + $".json";
        File.WriteAllText(path, json);

        Debug.Log($"Seed saven on: {path} with the name: {saveData.seed}");
    }

    public int LoadSeed(string dungeonName)
    {
        string path = Application.persistentDataPath + $".json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            DungeonSaveData saveData = JsonUtility.FromJson<DungeonSaveData>(json);
            return saveData.seed;
        }

        Debug.LogWarning($"No seed found in: {path}");
        return 0;
    }
}
