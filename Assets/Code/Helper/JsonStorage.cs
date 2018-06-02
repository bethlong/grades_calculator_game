using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace Assets.Code.Helper
{
    public class JsonStorage<T>
    {
        public void SaveInternalFile(T value, string filePath, string fileName, string extension)
        {
            SaveFile(value, GetInternalPath(filePath, fileName, extension));
        }

        public void SaveExternalFile(T value, string filePath, string fileName, string extension)
        {
            SaveFile(value, GetExternalPath(filePath, fileName, extension));
        }

        public T LoadInternalFile(string filePath, string fileName, string extension)
        {
            return LoadFile(GetInternalPath(filePath, fileName, extension));
        }

        public T LoadExternalFile(string filePath, string fileName, string extension)
        {
            return LoadFile(GetExternalPath(filePath, fileName, extension));
        }

        private void SaveFile(T value, string filePath)
        {
            string json = JsonConvert.SerializeObject(value, Formatting.Indented);
            
            File.SetAttributes(filePath, FileAttributes.Normal);
            File.WriteAllText(filePath, json);
            
            if (File.Exists(filePath)) Debug.Log("JsonStorage: saved file " + filePath);
            else Debug.LogWarning("JsonStorage: failed to save file " + filePath + "!");
        }

        private T LoadFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<T>(json);
            }
            else
            {
                Debug.LogError("JsonStorage: File '" + filePath + "' failed to load.");
                return default(T);
            }
        }

        private static string GetInternalPath(string filePath, string fileName, string extension)
        {
            return GetExternalPath(Application.streamingAssetsPath, fileName, extension);
        }

        private static string GetExternalPath(string filePath, string fileName, string extension)
        {
            return filePath + fileName + extension;
        }
    }
}