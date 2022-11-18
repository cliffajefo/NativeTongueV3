using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontrol : MonoBehaviour
{
   
    private  Rigidbody2D saro_rigidbody;

    public float facedirection;
    public float movedirectionx;
    private float speed = 5.0f;


    private float minimalWalkspeedx = .25f;
    private float walkAccelerationx = .14f;
    private float currentspeedx;
    private float maximumWalkspeedx = 5.5f;

    private bool ischangingDirection;


    private float force = 5f;
    private bool moveLeft;
    private bool moveRight;
    private bool dontMove;


    // Start is called before the first frame update
    void Start()
    {
        saro_rigidbody = GetComponent<Rigidbody2D>();

        dontMove = true;

    }



    // Update is called once per frame

    void Update()
    {

        HandleMoving();
        facedirection = Input.GetAxisRaw("Horizontal");

    }


    void HandleMoving()
    {
        if(dontMove)
        {
            StopMoving();
        }
        else
        {
            if (moveRight)
            {
                moveright();
            }
            else if (!moveRight)
            {
                MoveLeft();
            }
        }
       
    }

    public void DontAllowMovement()
    {
        dontMove = true;
    }
    



    public void AllowMovement(bool movement)
    {
        dontMove = false;
        moveRight = movement;
    }





    public void StopMoving()
    {
        saro_rigidbody.velocity = new Vector2(0f, saro_rigidbody.velocity.y);
    }

    
    public void FixedUpdate()
    {
        //moveright();

        //moveright1();

    }
    
    
    

    public void moveright()
    {
        facedirection = 1;
        
        if (facedirection != 0)
        {
            if (currentspeedx == 0)
            {
                currentspeedx = minimalWalkspeedx;
            }

            else if (currentspeedx < maximumWalkspeedx)
            {
                currentspeedx = IncreasewithinBound(currentspeedx, walkAccelerationx, maximumWalkspeedx);
            }



        }


        ischangingDirection = currentspeedx > 0 && facedirection * movedirectionx < 0;

        movedirectionx = -facedirection;

        
        if (ischangingDirection)
        {
            movedirectionx = -facedirection;
        }
        else
        {
            movedirectionx = facedirection;
        }
        


        saro_rigidbody.velocity = new Vector2(movedirectionx * currentspeedx, saro_rigidbody.velocity.y);

        //saro_rigidbody.velocity = new Vector2(speed, saro_rigidbody.velocity.y);




        if (facedirection > 0)
        {
            transform.localScale = new Vector2(1, 1);
            //saro_rigidbody.velocity = new Vector2(speed, saro_rigidbody.velocity.y);

        }
        else if (facedirection < 0)
        {
            transform.localScale = new Vector2(-1, 1);
            // saro_rigidbody.velocity = new Vector2(-speed, saro_rigidbody.velocity.y);
        }
    }




    public void MoveLeft()
    {
        facedirection = 1;

        if (facedirection != 0)
        {
            if (currentspeedx == 0)
            {
                currentspeedx = minimalWalkspeedx;
            }

            else if (currentspeedx < maximumWalkspeedx)
            {
                currentspeedx = IncreasewithinBound(currentspeedx, walkAccelerationx, maximumWalkspeedx);
            }



        }


        ischangingDirection = currentspeedx > 0 && facedirection * movedirectionx < 0;

        movedirectionx = -facedirection;


        if (ischangingDirection)
        {
            movedirectionx = -facedirection;
        }
        else
        {
            movedirectionx = facedirection;
        }



        saro_rigidbody.velocity = new Vector2(-movedirectionx * currentspeedx, saro_rigidbody.velocity.y);

        //saro_rigidbody.velocity = new Vector2(speed, saro_rigidbody.velocity.y);




        if (facedirection > 0)
        {
            transform.localScale = new Vector2(-1, 1);
            //saro_rigidbody.velocity = new Vector2(speed, saro_rigidbody.velocity.y);

        }
        else if (facedirection < 0)
        {
            transform.localScale = new Vector2(1, 1);
            // saro_rigidbody.velocity = new Vector2(-speed, saro_rigidbody.velocity.y);
        }
    }


    public void Jump()
    {
        saro_rigidbody.velocity = new Vector2(saro_rigidbody.velocity.x, force);
    }




    public void moveright1()
    {
        saro_rigidbody.velocity = new Vector2(speed, saro_rigidbody.velocity.y);
    }
    
    
 
 



    float IncreasewithinBound(float val, float delta, float maxval )
    {
        val += delta;

        if(val > maxval)
        {
            val = maxval;
        } 
        return val;
    }



}
