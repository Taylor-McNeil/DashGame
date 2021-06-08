using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerMovement : MonoBehaviour
{

    private bool isDragged = false;
    private Vector3 mouseDragStartPostition;
    private Vector3 spriteDragStartPosition;


    private void OnMouseDown()
    {
        isDragged = true;
        mouseDragStartPostition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spriteDragStartPosition = transform.localPosition;
    }

    private void OnMouseDrag()
    {
        if (isDragged) {
            transform.localPosition = spriteDragStartPosition + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseDragStartPostition);

        }
    }

    private void OnMouseUp()
    {
        isDragged = false;
    }


}
