using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    
    //Player sauvegarde
    
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
    
    
    
    //Zorg sauvegarde
    
    public static void SaveZorg(Unit zorg)
    {
        // Créer un ficher formater en Binaire
        
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/zorg.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        UnitData data = new UnitData(zorg);
        
        formatter.Serialize(stream, data);
        stream.Close();
    }
    
    public static UnitData LoadZorg()
    {
        // Lit un ficher formater en Binaire
        
        string path = Application.persistentDataPath + "/zorg.data";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            UnitData data = formatter.Deserialize(stream) as UnitData;
            
            stream.Close();
            
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in "+ path );
            return null;
        }
    }
    
    
    //T800 sauvegarde
    
    
    public static void SaveT800(Unit T800)
    {
        // Créer un ficher formater en Binaire
        
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/T800.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        UnitData data = new UnitData(T800);
        
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static UnitData LoadT800()
    {
        // Lit un ficher formater en Binaire
        
        string path = Application.persistentDataPath + "/t800.data";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            UnitData data = formatter.Deserialize(stream) as UnitData;
            
            stream.Close();
            
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in "+ path );
            return null;
        }
    }
    
    
    //T100 sauvegarde
    
    public static void SaveT1000(Unit T1000)
    {
        // Créer un ficher formater en Binaire
        
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/T800.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        UnitData data = new UnitData(T1000);
        
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static UnitData LoadT1000()
    {
        // Lit un ficher formater en Binaire
        
        string path = Application.persistentDataPath + "/t800.data";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            UnitData data = formatter.Deserialize(stream) as UnitData;
            
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
