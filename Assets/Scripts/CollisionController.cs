using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    
    private static bool reset = false;



    public static bool Reset
    {
        get => reset;

        set
        {
            reset = value;
        }
    }

    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entered Collision");
        if (GetComponent<Numbers>().GetNumber() == GameManager.instance.GetNumberToLearn())
        {
            GameManager.instance.Counter += 1;
            GameManager.instance.counterAdded?.Invoke(GameManager.instance.Counter);
            Destroy(gameObject);
           
        }
        else
        {
            reset = true;
        }
    }

   
}
