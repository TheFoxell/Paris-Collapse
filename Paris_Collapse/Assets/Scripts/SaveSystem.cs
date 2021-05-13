using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePlayer(Player player)
    {
        // Créer un ficher formater en Binaire
        
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);
        
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        // Lit un ficher formater en Binaire
        
        string path = Application.persistentDataPath + "/player.data";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            
            stream.Close();
            
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in "+ path );
            return null;
        }
    }

    public static void Delete(string toDelete)
    {
        string path = Application.persistentDataPath +"/"+ toDelete + ".data";
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }
}
