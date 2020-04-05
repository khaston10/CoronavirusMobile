﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    #region Variables - Panels and Buttons

    public Button[] newPatientButtons;
    public Button[] patientPanelButtons;
    public GameObject[] patientPanels;

    #endregion

    #region Variables - Text objects to update
    public Text dayText;
    public Text numberOfNewPatientsText;
    public Text[] nameOfPatientsText;
    public Text[] ageOfPatientsText;
    public Text[] sexOfPatientsText;
    public Text[] statusOfPatientsText;
    public Image[] picOfPatientImages;
    public Text nameOfDoxtorText;
    public Text statusOfDoctorText;
    public Image imageOfDoctor;
    #endregion

    #region Variables - Patients
    public GameObject patientPrefab;
    // This array will be filled with current patients. 0 - patient in bed 1, 1 - patient in bed 2 ...
    public GameObject[] currentPatients = new GameObject[6];

    // Each Bed-Panel has 4 buttons that can only be pressed when the doctor is in reach - TODO.
    // The lights around the button indicate if a user can press the button. Here is where we store the
    // images to update when a button needs to be updated.
    public Sprite greenLightImage;
    public Sprite redLightImage;
    public Sprite blankImage;
    // LayoutForBedButtons [maskLight, IVLight, pneumoniaLight, criticalLight]
    public Image[] bedButtons1;
    public Image[] bedButtons2;
    public Image[] bedButtons3;
    public Image[] bedButtons4;
    public Image[] bedButtons5;
    public Image[] bedButtons6;
    // Layout For bedButtonsForAllBeds [bedButtons1[], bedButtons2[], bedButtons3[], bedButtons4[], bedButtons5[], bedButtons6[]]
    public Image[][] bedButtonsForAllBeds = new Image[6][];
    public Image[] newPatientButtonImages;
    #endregion

    #region Variables Doctor

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

    // Start is called before the first frame update
    void Start()
    {
        LoadData();

        // Disable all panels/buttons.
        HidePatientPanels();
        ClickPatientPanel(0);

        // Set text objects to inital values.
        dayText.text = "1";
        numberOfNewPatientsText.text = "0";

        // Load Doctor Data to screen.
        LoadDoctorsPage();

        // Set All Buttons Images to the appropriate availability.
        bedButtonsForAllBeds[0] = bedButtons1;
        bedButtonsForAllBeds[1] = bedButtons2;
        bedButtonsForAllBeds[2] = bedButtons3;
        bedButtonsForAllBeds[3] = bedButtons4;
        bedButtonsForAllBeds[4] = bedButtons5;
        bedButtonsForAllBeds[5] = bedButtons6;

        for(int i = 0; i < 6; i++)
        {
            SetBedButtonsOnOff(i, false);
            SetNewPatientButtonsOnOff(i, true);

            // Clear Patient Information From Screen.
            ClearPatientDataFromScreen(i);
        }




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
        spriteOfDoctor = GlobalCont.Instance.spriteOfDoctor;
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
    public void HidePatientPanels()
    {
        for (int i = 0; i < patientPanels.Length; i++)
        {
            patientPanels[i].SetActive(false);
        }
    }


    #region Functions - Set Lights For Buttons
    public void SetButtonImgAvailable(Image buttonImg)
    {
        buttonImg.sprite = greenLightImage;
    }

    public void SetButtonImgUnAvailable(Image buttonImg)
    {
        buttonImg.sprite = redLightImage;
    }

    public void SetBedButtonsOnOff(int bed, bool on)
    {
        //This function is used to make handeling turing on and off lights for
        // the bed panels easy.
        if (on)
        {
            for (int i = 0; i < bedButtonsForAllBeds[bed].Length; i++)
            {
                bedButtonsForAllBeds[bed][i].sprite = greenLightImage;
            }
        } 

        else
        {
            for (int i = 0; i < bedButtonsForAllBeds[bed].Length; i++)
            {
                bedButtonsForAllBeds[bed][i].sprite = redLightImage;
            }
        }
            
        

    }

    public void SetNewPatientButtonsOnOff(int bed, bool on)
    {
        if (on)
        {
            newPatientButtonImages[bed].sprite = greenLightImage;
        }

        else
        {
            newPatientButtonImages[bed].sprite = redLightImage;
        }
    }
    #endregion


    #region Functions - Patient Update Functions
    public void ClickNewPatient(int bed)
    {
        bool providerLoaded = CreatePatientAndPopulateBed(bed);
        UpdatePatientDataToScreen(bed);

        if (providerLoaded) SetNewPatientButtonsOnOff(bed, false);

    }

    
    public bool CreatePatientAndPopulateBed(int bed)
    {
        //Returns True if is successfully loads the patient.
        if (currentPatients[bed] == null)
        {
            GameObject temp = Instantiate(patientPrefab);
            currentPatients[bed] = temp;
            Debug.Log(currentPatients[bed].GetComponent<PatientData>().nameOfPatient);
            return true;
        }

        else
        {
            Debug.Log("Bed Is Taken");
            return false;
        }
    }

    public void UpdatePatientDataToScreen(int bed)
    {
        if (currentPatients[bed] != null)
        {
            nameOfPatientsText[bed].text = currentPatients[bed].GetComponent<PatientData>().nameOfPatient;
            ageOfPatientsText[bed].text = currentPatients[bed].GetComponent<PatientData>().ageOfPatient.ToString();
            sexOfPatientsText[bed].text = currentPatients[bed].GetComponent<PatientData>().sexOfPatient;
            statusOfPatientsText[bed].text = currentPatients[bed].GetComponent<PatientData>().statusOfPatient;
            picOfPatientImages[bed].sprite = currentPatients[bed].GetComponent<PatientData>().picOfPatient;
        }

        else
        {
            Debug.Log("No Patient Data to load.");
        }
    }

    public void ClearPatientDataFromScreen(int bed)
    {
      
        nameOfPatientsText[bed].text = "";
        ageOfPatientsText[bed].text = "";
        sexOfPatientsText[bed].text = "";
        statusOfPatientsText[bed].text = "";
        picOfPatientImages[bed].sprite = blankImage;


    }

    public void ClickPatientPanel(int bedNumber)
    {
        HidePatientPanels();
        patientPanels[bedNumber].SetActive(true);
    }
    #endregion


    #region Functions - Doctor Update Function

    public void LoadDoctorsPage()
    {
        nameOfDoxtorText.text = nameOfDoctor;
        statusOfDoctorText.text = statusOfDoctor;
        imageOfDoctor.sprite = spriteOfDoctor;

    }

    #endregion

    #endregion
}
