using System.IO;
using UnityEngine;

namespace MG
{
    public class SaveService
    {
        private string Path =>
            Application.persistentDataPath + "/save.json";

        public void Save(GameSaveData a_data)
        {
            string l_json = JsonUtility.ToJson(a_data, true);
            File.WriteAllText(Path, l_json);
            Debug.Log("Path is " + Path);
        }

        public GameSaveData Load()
        {
            if (!HasSave()) return null;

            string l_json = File.ReadAllText(Path);
            return JsonUtility.FromJson<GameSaveData>(l_json);
        }

        public bool HasSave()
        {
            return File.Exists(Path);
        }

        public void Clear()
        {
            if (HasSave())
                File.Delete(Path);
        }
    }
}
