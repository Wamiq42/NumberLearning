using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondLevel : MonoBehaviour
{
    public static SecondLevel secondLevel;
    
    private void Awake()
    {
        if (secondLevel != null)
        {
            Destroy(gameObject);
        }
        else
        {
            secondLevel = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnEnable()
    {
        GameManager.instance.counterAdded += LoadNext;
    }
    private void OnDisable()
    {
        GameManager.instance.counterAdded -= LoadNext;
    }

    void LoadNext(int counter)
    {
        if(counter == 3)
        {
            GameManager.instance.IsGameStarted = false;
            GameManager.instance.NextGame = true;
            GameManager.instance.nextMiniGame?.Invoke(GameManager.instance.NextGame);
           
            GameManager.instance.Counter = 0;

            GameManager.instance.toNextLevel(2);
          
        }
    }
    
}
