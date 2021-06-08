using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    

    public float speed = 10f;
    Vector2 lastClickedPos;
    [SerializeField]
    public List<Vector2> movementOrder;
    [SerializeField]
    public int queueSize = 6;
    public EnvironmentalController ec;



    void Start(){
        movementOrder = new List<Vector2>();
        ec = (EnvironmentalController)GameObject.Find("LevelController").GetComponent(typeof(EnvironmentalController));
       

    }
    // Update is called once per frame
    void Update()
    {
        addTask();
        movement();

    }


    public void addTask(){
        if (Input.GetMouseButtonDown(0)){

                    bool customerClicked = false;
                    Vector2 mouseClick = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    RaycastHit2D whatDidYouClick = Physics2D.Raycast(mouseClick,Vector2.zero);
                    if(whatDidYouClick){
                       
                       if(whatDidYouClick.collider.CompareTag("Customer") || whatDidYouClick.collider.CompareTag("Garbage")){
                           Debug.Log("You Hit a Customer or Garbage");
                           customerClicked = true;
                       }
                    }
                      
                      if(!customerClicked && movementOrder.Count < 6){
 
                            lastClickedPos = mouseClick;
                            
                            movementOrder.Add(lastClickedPos);
                            ec.addCheckmark();



                /* if(movementOrder.Count < 6){
                     movementOrder.Add(lastClickedPos);
                 }else{
                     Debug.Log(" You have too many moves in your queue");
                     Debug.Log("You have "+ movementOrder.Count +" moves in the queue");
                 }*/
            }
        }

        if (Input.GetMouseButtonDown(1) && movementOrder.Count != 0) {
            Debug.Log("Removing " + movementOrder[movementOrder.Count-1]);
            movementOrder.RemoveAt(movementOrder.Count-1);
        }
     }
                
    

                   
        
    

    public void movement(){
        

        try{
            Vector2 newTargetPosition = movementOrder[0];
             transform.position = Vector2.MoveTowards(transform.position,movementOrder[0],Time.deltaTime*speed);

            if(Vector2.Distance(transform.position,newTargetPosition) < 0.1f ){
                ec.removeCheckmark();
                movementOrder.RemoveAt(0);
                
            } 
        } catch(ArgumentException){

        }
        
       

  /*       if (Input.GetMouseButtonDown(0)){
                    lastClickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        Debug.Log(movementOrder.Count);

                        if(movementOrder.Count < 6){
                            movementOrder.Add(lastClickedPos);
                        }else{
                            Debug.Log(" You have too many moves in your queue");
                            Debug.Log("You have "+ movementOrder.Count +" moves in the queue");
                        }

        }

        for(int i =0; i < movementOrder.Count;i++){
            if ( (Vector2) transform.position != movementOrder[i]){

                     do{
                             transform.position = Vector2.MoveTowards(transform.position,movementOrder[i],Time.deltaTime*speed);
                        }
                    while((Vector2)transform.position != movementOrder[i]);   
                            movementOrder.RemoveAt(0);
            }
                    } */

                 
            

            
    }



    public List<Vector2> getQueue() {


        return movementOrder;
    }
}

 
       
    