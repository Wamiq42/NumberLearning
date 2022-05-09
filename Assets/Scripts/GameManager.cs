using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    

    

    private int counter = 0;
    private bool nextGame;

    public delegate void ClickedNumber(int number);
    public ClickedNumber clickedNumber;

    public delegate void NextMiniGame(bool nextGame);
    public NextMiniGame nextMiniGame;
    public int numberToLearn;
    //[SerializeField] private GameObject numberPanel;
    [SerializeField] private bool panelStatus = true;
    [SerializeField] private GameObject firstMiniGame;
    [SerializeField] private GameObject secondMiniGame;



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
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && firstMiniGame.active == true)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject.GetComponent<Numbers>().GetNumber() == numberToLearn)
            {
                Destroy(hit.collider.gameObject);
                counter++;
                if(counter == 4)
                {
                   counter = 0;
                   nextGame = true;
                   nextMiniGame?.Invoke(nextGame);
                }
            }
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

    public GameObject GetFirstGame()
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

    public int GetNumber()
    {
        return numberToLearn;
    }

    public void SetNumber(int number)
    {
        numberToLearn = number;
    }

}
