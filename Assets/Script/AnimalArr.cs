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
            animalArrayString = "parrot,snake,pig,dog,hippo";
            PlayerPrefs.SetString("AnimalArray", animalArrayString);
            PlayerPrefs.Save();
        }
        AnimalArray = animalArrayString.Split(',');
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
