using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem /// Klasa statyczna z metodami do zapisywania i wczytywania stanu gry
{
    public static void SaveGame(Character character) /// Metoda do zapisywania stanu gry, w parametratch zosta³ podany obiekt klasy Character, poniewaz to on ma zostaæ zapisany
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/game.save";
        FileStream stream = new FileStream(path, FileMode.Create);
        Debug.Log("Gra zapisana.");

        GameData data = new GameData(character);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static GameData LoadGame() /// Metoda do wczytywania stanu gry zwraca zdeserializowane dane gry, lub jesli plik z zapisem nie istnieje to zwraca wartosc null
    {
        string path = Application.persistentDataPath + "/game.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            Debug.Log("Gra wczytana.");

            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();

            return data;
        }
        else
        {
            return null;
        }
    }
}