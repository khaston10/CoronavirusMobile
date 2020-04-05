using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientData : MonoBehaviour
{
    #region Variables - BasicInformation
    public string nameOfPatient;
    public int ageOfPatient;
    public string sexOfPatient;
    public string statusOfPatient;
    public Sprite picOfPatient;

    public float patientTimer;

    #endregion
    // Start is called before the first frame update
    void Awake()
    {
        // Populate all the basic information for the patient
        LoadPatientData();
    }

    // Update is called once per frame
    void Update()
    {
        patientTimer += Time.deltaTime;
    }

    #region Functions
    public void LoadPatientData()
    {
        nameOfPatient = GlobalPatientData.namesOfPatients[Random.Range(0, 10)];
        ageOfPatient = GlobalPatientData.agesOfPatients[Random.Range(0, 10)];
        sexOfPatient = GlobalPatientData.sexesOfPatients[Random.Range(0, 10)];
        statusOfPatient = GlobalPatientData.statusOfPatients[Random.Range(1, 4)];

        if(sexOfPatient == "M")
        {
            picOfPatient = GlobalPatientData.picOfPatient[Random.Range(2,4)];
        }
        else
        {
            picOfPatient = GlobalPatientData.picOfPatient[Random.Range(0, 2)];
        }
    }
    #endregion
}
