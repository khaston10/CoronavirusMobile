using System.Collections;
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
    #endregion

    #region Variables - Patients
    public GameObject patientPrefab;

    // This array will be filled with current patients. 0 - patient in bed 1, 1 - patient in bed 2 ...
    public GameObject[] currentPatients;

    #endregion

    #region Variables Doctor

    public string nameOfDoctor;
    public int ageOfDoctor;
    public string sexOfDoctor;
    public string statusOfDoctor;

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

        // Set text objects to inital values.
        dayText.text = "1";
        numberOfNewPatientsText.text = "0";
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

    }
    public void HidePatientPanels()
    {
        for (int i = 0; i < patientPanels.Length; i++)
        {
            patientPanels[i].SetActive(false);
        }
    }

    public void ClickPatientPanel(int bedNumber)
    {
        HidePatientPanels();
        patientPanels[bedNumber].SetActive(true);
    }
    #endregion
}
