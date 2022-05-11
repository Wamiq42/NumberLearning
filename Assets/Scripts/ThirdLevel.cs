using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThirdLevel : MonoBehaviour
{
    public static ThirdLevel instance;

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


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject.GetComponent<Numbers>().GetNumber() == GameManager.instance.numberToLearn)
            {
                Destroy(hit.collider.gameObject);
                GameManager.instance.Counter += 1;
                if (GameManager.instance.Counter == 4)
                {
                    GameManager.instance.NextGame = true;
                    GameManager.instance.nextMiniGame?.Invoke(GameManager.instance.NextGame);
                    GameManager.instance.GetFirstMiniGame().SetActive(true);
                    GameManager.instance.GetSecondMiniGame().SetActive(false);
                    GameManager.instance.GetThirdMiniGame().SetActive(false);
                    GameManager.instance.Counter = 0;
                   //Application.Quit();
                    Debug.Log(GameManager.instance.Counter);
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }
    }



}
