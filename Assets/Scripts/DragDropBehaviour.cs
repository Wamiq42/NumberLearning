using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropBehaviour : MonoBehaviour
{
    private Vector2 lastPosition;
    private bool isDragging;

    private void Start()
    {
        lastPosition = transform.position;
    }
    public void OnMouseDown()
    {
        isDragging = true;
    }
    public void OnMouseUp()
    {
        isDragging = false;
    }
    private void Update()
    {
        DraggingMouse();
    }

    void DraggingMouse()
    {
        if (isDragging && !CollisionController.Reset)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePosition);
            Debug.Log("Draging log");
        }
        else if(CollisionController.Reset)
        {
            transform.position = lastPosition;
            StartCoroutine("ResetCoroutine");
        }
    }

    IEnumerator ResetCoroutine()
    {
        yield return new WaitForSeconds(1.0f);
        CollisionController.Reset = false;
    }

}
