using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleController : MonoBehaviour
{
    #region Variables - Doctor
    public string nameOfDoctor;
    public int ageOfDoctor;
    public string sexOfDoctor;
    public string statusOfDoctor;
    public Sprite spriteOfDoctor;
    #endregion

    #region Variables - Stats
    public int day;
    public int patientsHealed;
    public int patientsDeceased;
    #endregion

    #region Variables - Text and Images to Update
    public Text doctorsNameText;
    public Text doctorsTaxText;
    public Image[] buttonLights;
    public Sprite geenLightImage;
    public Sprite blankImage;
    public Sprite[] spriteOfDoctors;
    public string[] doctorsNames = new string[4] { "Dave", "Kristen", "Cat", "Stevens" };
    public int[] agesOfDoctors = new int[4] { 40, 29, 32, 56 };
    public string[] genderOfDoctors = new string[4] { "M", "M", "M", "M" };
    public string[] taxonomyOfDoctors = new string[4] { "Nurse Practitioner", "Registered Nurse", "MD Pulmonary", "MD Family" };
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        LoadData();

        ClickDoctor(0);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region Functions

    public void LoadData()
    {
        nameOfDoctor = GlobalCont.Instance.nameOfDoctor;
        ageOfDoctor = GlobalCont.Instance.ageOfDoctor;
        sexOfDoctor = GlobalCont.Instance.sexOfDoctor;
        statusOfDoctor = GlobalCont.Instance.statusOfDoctor;
        day = GlobalCont.Instance.day;
        patientsHealed = GlobalCont.Instance.patientsHealed;
        patientsDeceased = GlobalCont.Instance.patientsDeceased;
    }

    public void SaveData()
    {
        GlobalCont.Instance.nameOfDoctor = nameOfDoctor;
        GlobalCont.Instance.ageOfDoctor = ageOfDoctor;
        GlobalCont.Instance.sexOfDoctor = sexOfDoctor;
        GlobalCont.Instance.statusOfDoctor = statusOfDoctor;
        GlobalCont.Instance.day = day;
        GlobalCont.Instance.patientsHealed = patientsHealed;
        GlobalCont.Instance.patientsDeceased = patientsDeceased;
        GlobalCont.Instance.spriteOfDoctor = spriteOfDoctor;

    }

    public void ClickStart()
    {
        SaveData();
        SceneManager.LoadScene(1);
    }

    public void ClickDoctor(int doc)
    {
        // Update text on screen.
        doctorsNameText.text = doctorsNames[doc];
        doctorsTaxText.text = taxonomyOfDoctors[doc];

        // Load variables to pass on to next screen.
        nameOfDoctor = doctorsNames[doc];
        ageOfDoctor = agesOfDoctors[doc];
        sexOfDoctor = genderOfDoctors[doc];
        spriteOfDoctor = spriteOfDoctors[doc];


        // Update Select Box.
        TurnLightOnOff(doc);
    }

    public void TurnLightOnOff(int doc)
    {
        for(int i = 0; i < buttonLights.Length; i++)
        {
            buttonLights[i].sprite = blankImage;
            Debug.Log("Clearing Pic");
        }

        buttonLights[doc].sprite = geenLightImage;
    }



    #endregion
}
