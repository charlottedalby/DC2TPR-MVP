using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Class: Event
    Visibility: Public 
    Output: N/A
    Attributes: 

    a. EventID: Identification number of Event
    b. Description: Description of Event
    c. Stages: A List of all stages the Event can appear in
    d. Skipable: Determines if event is skipable or not 

    Methods: 

    a. Event

*/

public class Event : MonoBehaviour
{
    public int EventID { get; set; }
    public string Description { get; set; }
    public List<int> Stages { get; set; }
    public bool Skipable { get; set; }

    /*
        Method: Event()
        Visibility: public 
        Output: n/a
        Purpose: 

        a. Constructor for all Event Attributes
    */

    public Event (int EventID, string Description, List<int> Stage, bool Skipable)
    {
        this.EventID = EventID;
        this.Description = Description;
        this.Stages = Stages;
        this.Skipable = Skipable;
    }
}
