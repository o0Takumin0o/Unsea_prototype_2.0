using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleSwitch : MonoBehaviour
{
    public GameObject switchOn, switchOff;
    
    public void OnchangeValue()
    {
        bool OnOffSwitch = gameObject.GetComponent<Toggle>().isOn;
        if(OnOffSwitch)
        {
            switchOn.SetActive(true);
            switchOff.SetActive(false);
        }
        if(!OnOffSwitch)
        {
            switchOn.SetActive(false);
            switchOff.SetActive(true);
        }
            
    }
}
