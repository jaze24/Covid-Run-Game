using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeControl : MonoBehaviour

{
    private Vector2 startTouchPosition;
    private Vector2 currentPosition;
    private Vector2 endTouchPosition;
    private bool stopTouch = false;

    public float swipeRange;
    public float tapRange;

    private Vector2 targetPos;
    public float Yincrement;
    public float speed;

  


   void Update()
   {
       SwipeIt();

     

        
   }
    public void SwipeIt()
    {
        
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
            targetPos = Input.GetTouch(0).position;
            
        }

        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            currentPosition = Input.GetTouch(0).position;
            Vector2 Distance = currentPosition - startTouchPosition;
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

            if(!stopTouch)
            {
                if(Distance.y > swipeRange)
                {
                    stopTouch = true;
                    targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);
                   
                }
                else if(Distance.y < -swipeRange)
                {
                    stopTouch = true;
                    targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);
                  
                }
            }
        }

        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
    {
        stopTouch = false;

        endTouchPosition = Input.GetTouch(0).position;
        targetPos = Input.GetTouch(0).position;

        Vector2 Distance = endTouchPosition - startTouchPosition;
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);


        if(Mathf.Abs(Distance.y) < tapRange)
        {
            Debug.Log("You just tapped the screen");
        }
    }

    }

    
}





        

    