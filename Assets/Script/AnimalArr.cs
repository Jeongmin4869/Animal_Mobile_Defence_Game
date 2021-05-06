using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalArr
{
    public static string[] AnimalArray;
    public static string animalArrayString;
    //static 
    public static void callAnimalArr()
    {
        //다시불러오기
        animalArrayString = PlayerPrefs.GetString("AnimalArray");
        if (animalArrayString == "")
        {
            //처음 동물은 parrot,penguin,pig 3마리.
            Debug.Log(null);
            animalArrayString = "parrot,snake,pig,dog,hippo";
            PlayerPrefs.SetString("AnimalArray", animalArrayString);
            PlayerPrefs.Save();
        }
        AnimalArray = animalArrayString.Split(',');
        Debug.Log(animalArrayString);
        Debug.Log(AnimalArray[AnimalArray.Length-1]); 
    }



    public static void saveAnimalArr()
    {
        for (int i = 0; i < AnimalArray.Length; i++)
        {
            animalArrayString = animalArrayString + AnimalArray[i];
            if (i < AnimalArray.Length - 1)
            {
                animalArrayString = animalArrayString + ",";
            }
        }
        PlayerPrefs.SetString("AnimalArray", animalArrayString);
        PlayerPrefs.Save();
    }


}
