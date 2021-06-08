using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerGroup : MonoBehaviour
{
    [SerializeField]
   private Transform Garbage;
    bool locked;
   private float deltaX, deltaY;
   private Vector2 initialPosition;
   private Vector2 mousePosition; 
  

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        Garbage = GameObject.FindGameObjectWithTag("Garbage").transform;
    }

    // Update is called once per frame
   


    public void OnMouseDown(){
        //To determine the offset, when the mouse button is pushed

        Debug.Log("clicked");

        if(!locked){
            deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x-transform.position.x;
            deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y-transform.position.y;

        }
    }

    public void OnMouseDrag(){
        Debug.Log("dragging");

        if (!locked){
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePosition.x - deltaX, mousePosition.y - deltaY);
        }
    }


    public void OnMouseUp()
    {

        Debug.Log("drug");
        if (Mathf.Abs(transform.position.x - Garbage.position.x) <= 0.9f &&
            Mathf.Abs(transform.position.y - Garbage.position.y) <= 0.9f)
        {

            transform.position = new Vector2(Garbage.position.x, Garbage.position.y);
            locked = true;
            Destroy(this.gameObject);
        }
        else {
            transform.position = new Vector2(initialPosition.x, initialPosition.y);
        }

    }
}
