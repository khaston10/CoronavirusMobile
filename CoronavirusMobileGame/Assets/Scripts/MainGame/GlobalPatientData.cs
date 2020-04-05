using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalPatientData : MonoBehaviour
{
    // This script is simple here to store global patient data.
    //It will be randomly selected when a character is created.
    public Sprite[] pics;

    public static string[] namesOfPatients = new string[] { "Mary", "John", "Robert", "William", "James", "Dorothy", "Helen", "Charles", "George", "Joseph" };
    public static int[] agesOfPatients = new int[] { 98, 98, 98, 89, 98, 98, 98, 98, 98, 98 };
    public static string[] sexesOfPatients = new string[] { "F", "M", "M", "M", "M", "F", "F", "M", "M", "M" };
    public static string[] statusOfPatients = new string[] { "HEALTHY", "INFECTED", "DEHYDRATED", "PNEUMONIA", "CRITICAL", "DECEASED" };
    public static Sprite[] picOfPatient = new Sprite[4];

    private void Awake()
    {
        for (int i = 0; i < pics.Length; i++)
        {
            picOfPatient[i] = pics[i];
        }
        

    }


}