using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropBehaviour : MonoBehaviour
{
    [SerializeField] private float xAxisBoundary = 8.74f;
    [SerializeField] private float yAxisBoundary = 2.5f;
    private Vector2 lastPosition;
    
    private bool isDragging;
    
    private bool gameStarted = false;

    public bool GameStarted
    {
        get => gameStarted;
        set
        {
            gameStarted = value;
        }
    }
   
  
    private void OnMouseDown()
    {
        Debug.Log("Called OnMouseDown");
        isDragging = true;
    }
    private void OnMouseUp()
    {
        isDragging = false;
    }
    private void Update()
    {
        
            DraggingMouse();
            Boundary();
        
    }

    void Boundary()
    {
        if (GameManager.instance.IsGameStarted)
        {
            Vector3 tempPosition = transform.position;
            tempPosition.x = Mathf.Clamp(tempPosition.x, -xAxisBoundary, xAxisBoundary);
            tempPosition.y = Mathf.Clamp(tempPosition.y, -yAxisBoundary, yAxisBoundary);
            transform.position = tempPosition;
        }
       
    }

    void DraggingMouse()
    {

        if (isDragging && !CollisionController.Reset && GameManager.instance.GetCurrentLevel() == 1 && GameManager.instance.IsGameStarted)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePosition);
            gameStarted = true;
            Debug.Log("Draging log");
        }
        else if(CollisionController.Reset && GameManager.instance.GetCurrentLevel() == 1 && GameManager.instance.IsGameStarted)
        {
            gameStarted = true;
            transform.Translate(lastPosition);
           
            StartCoroutine("ResetCoroutine");
        }
        else if(GameManager.instance.GetCurrentLevel()==1 && gameStarted)
        {
            Debug.Log("Reseting");
            
            transform.position = lastPosition;
        }
    }

    IEnumerator ResetCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        CollisionController.Reset = false;
    }

    public void SetLastPosition(Vector3 position)
    {
       
        lastPosition = position;
    }
   

}
