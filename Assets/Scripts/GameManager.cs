using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;


    public delegate void ToNextLevel(int number);
    public ToNextLevel toNextLevel;

   
    private int currentLevel;
    private static int counter = 0;
    private bool isGameStarted = false;
    public bool IsGameStarted
    {
        get => isGameStarted;
        set
        {
            isGameStarted = value;
        }
    }
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
    
    [SerializeField] private List<GameObject> Levels;
   



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
    private void OnEnable()
    {
        toNextLevel += ChangeLevel;   
    }
    private void OnDisable()
    {
        toNextLevel -= ChangeLevel;
    }
    void ChangeLevel(int levelNumber)
    {
        for (int i = 0; i < Levels.Count; i++)
        {
            if (levelNumber == i)
            {
                Levels[i].SetActive(true);
                currentLevel = i;
                //clickedNumber?.Invoke(numberToLearn);
            }
            else
            {
                Levels[i].SetActive(false);
            }
        }
        
    }

   



    //Setter Getters'
   
    public int GetCurrentLevel()
    {
        return currentLevel;
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
