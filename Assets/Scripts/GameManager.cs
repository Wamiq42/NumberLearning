using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    

    

    private static int counter = 0;
    public int Counter
    {
        get => counter;

        set
        {
            counter = value;
        }
    }

    private bool nextGame;
    public bool NextGame
    {
        get => nextGame;
        set
        {
            nextGame = value;
        }
    }

    public delegate void ClickedNumber(int number);
    public ClickedNumber clickedNumber;

    public delegate void CounterAdded(int counter);
    public CounterAdded counterAdded;

    public delegate void NextMiniGame(bool nextGame);
    public NextMiniGame nextMiniGame;

    public int numberToLearn;
    //[SerializeField] private GameObject numberPanel;
   //[SerializeField] private bool panelStatus = true;
    [SerializeField] private GameObject firstMiniGame;
    [SerializeField] private GameObject secondMiniGame;
    [SerializeField] private GameObject thirdMiniGame;



    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
      
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
    }


    //Setter Getters
    //public bool GetStatus()
    //{
    //    return panelStatus;
    //}
    //public void SetStatus(bool status)
    //{
    //    panelStatus = status;
    //}
    public GameObject GetThirdMiniGame()
    {
        return thirdMiniGame;
    }
    public GameObject GetFirstMiniGame()
    {
        return firstMiniGame;
    }
    public void SetGameObjectFirstActive(bool active)
    {
        firstMiniGame.SetActive(active);
    }
    public GameObject GetSecondMiniGame()
    {
        return secondMiniGame;
        
    }
    public void SetGameObjectSecondActive(bool active)
    {
        secondMiniGame.SetActive(active);
    }

    public int GetNumberToLearn()
    {
        return numberToLearn;
    }

    public void SetNumberToLearn(int number)
    {
        numberToLearn = number;
    }

}
