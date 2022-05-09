using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropBehaviour : MonoBehaviour
{
    private Vector2 lastPosition;
    private bool isDragging;


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
        if (isDragging)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePosition);
        }
    }
}
