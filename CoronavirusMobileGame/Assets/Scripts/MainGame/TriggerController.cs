using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    // Trigger Number 0- Sink, 1 - Bed1, ...
    public int triggerNum;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        // Check to see if the doctor hit the correct trigger.
        if(Vector3.Distance(GameObject.Find("MainController").GetComponent<Main>().targetPos, transform.position) < .2)
        {
            // Play The Doctors Idle Animation.
            GameObject.Find("MainController").GetComponent<Main>().docAnim.Play("MIdle");
        }

        // Update Current Patient Buttons if Doctor is on trigger.
        if (triggerNum != 0)
        {
            GameObject.Find("MainController").GetComponent<Main>().SetBedButtonsOnOff(triggerNum - 1, true);
        }
        
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        // Update Current Patient Buttons if Doctor is leaving trigger.
        if (triggerNum != 0)
        {
            GameObject.Find("MainController").GetComponent<Main>().SetBedButtonsOnOff(triggerNum - 1, false);
        }
        
    }
}
