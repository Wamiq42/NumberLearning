using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{

    [SerializeField] private GameObject panelObject;
    
    public void OnButtonClick(Button button)
    {
        GameManager.instance.SetNumberToLearn(int.Parse(button.GetComponentInChildren<Text>().text));
        GameManager.instance.toNextLevel(0);
       
        
        
        panelObject.SetActive(false);
    }

   
}
