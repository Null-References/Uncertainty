using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace SavingAndLoading
{
    public class SavingLoadingData : MonoBehaviour
    {
        public static void Save<T>(T saveThisThing, string saveName)
        {
            //Debug.Log(Application.persistentDataPath);
            string path = Application.persistentDataPath + "/Uncertainty/saves/";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream fileStream = new FileStream(path + saveName + ".dat", FileMode.Create))
            {
                binaryFormatter.Serialize(fileStream, saveThisThing);
            }
        }

        public static T Load<T>(string saveName)
        {
            T getThisThing;
            string path = Application.persistentDataPath + "/Uncertainty/saves/";
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream fileStream = new FileStream(path + saveName + ".dat", FileMode.Open))
            {
                getThisThing = (T) binaryFormatter.Deserialize(fileStream);
            }

            return getThisThing;
        }

        public static bool SaveExist(string saveName)
        {
            string saveFile = Application.persistentDataPath + "/Uncertainty/saves/" + saveName + ".dat";
            return File.Exists(saveFile);
        }

        public static void DeleteSave(string saveName)
        {
            string saveFile = Application.persistentDataPath + "/Uncertainty/saves/" + saveName + ".dat";
            File.Delete(saveFile);
        }
    }
}