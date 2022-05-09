using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{

    [SerializeField] private GameObject panelObject;
    public void OnButtonClick(Button button)
    {
        
        GameManager.instance.SetNumber(int.Parse(button.GetComponentInChildren<Text>().text));
        GameManager.instance.clickedNumber?.Invoke(GameManager.instance.numberToLearn);
        panelObject.SetActive(false);
    }
}
