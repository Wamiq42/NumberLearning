using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicked : MonoBehaviour
{

    private void OnMouseDown()
    {
        Debug.Log("Clicked");
        GameManager.instance.SetGameObject(gameObject);
    }
}
