using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player_Controller : MonoBehaviour
{
    public float moveSpeed;
    private Vector3 targetPosition;
    private bool isMoving = false;
    private float distanceClick; //d1
    private float distanceObject; //d2
    private Animator anim;
    [SerializeField] private GameObject efectClick;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();

    }

    void Update()
    {
        if(Input.GetMouseButton(1))
        {
            SetTargetPosition();
        }
        if(isMoving)
        {
           Move();
        }
        else
        {
            anim.SetBool("IsMoving", false);
        }     

        if(Input.GetMouseButtonDown(1))
        {
            Instantiate(efectClick, targetPosition, Quaternion.Euler(0f, 0f, 0f));
        }
  
    }

    void SetTargetPosition()
    {
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.z = transform.position.z;
        distanceClick = targetPosition.y - transform.position.y;
        distanceObject = targetPosition.x - transform.position.x;
        if(distanceClick > 0.1f || distanceObject > 0.1f || distanceObject < -0.1f || distanceClick < -0.1f)
        {
            anim.SetBool("IsMoving", true);
            isMoving = true;
            if (distanceClick > 0.5f) //look up
            {

                if(distanceObject > 0.5f) // look right
                {
                    //anim up_right
                    anim.SetFloat("MoveX", 1);
                    anim.SetFloat("MoveY", 1);

                }
                else if(distanceObject < -0.5f) //look left
                {
                    //anim up_left
                    anim.SetFloat("MoveX", -1);
                    anim.SetFloat("MoveY", 1);
                }
                else
                {
                    //anim up
                    anim.SetFloat("MoveX", 0);
                    anim.SetFloat("MoveY", 1);

                }
            }
            else if(distanceClick < -0.5f) // look down
            {

                if(distanceObject > 0.5f) // look right
                {
                    //anim down_right
                    anim.SetFloat("MoveX", 1);
                    anim.SetFloat("MoveY", -1);
                }
                else if(distanceObject < -0.5f) //look left
                {
                    //anim down_left
                    anim.SetFloat("MoveX", -1);
                    anim.SetFloat("MoveY", -1);
                }
                else
                {
                    anim.SetFloat("MoveX", 0);
                    anim.SetFloat("MoveY", -1);
                    //anim down
                }

            }
            else
            {
                float aux;
                if(distanceClick<0)
                {
                    aux = -distanceClick;
                }
                else
                {
                    aux = distanceClick;
                }
                if (distanceObject > 0.0 && distanceObject>aux) // look right
                {

                    //anim right
                    anim.SetFloat("MoveX", 1);
                    anim.SetFloat("MoveY", 0);
                }
                else if(distanceObject > 0.0 && distanceObject < aux)
                {
                    if(distanceClick>0)
                    {
                        //anim up
                        anim.SetFloat("MoveX", 0);
                        anim.SetFloat("MoveY", 1);
                    }
                    else
                    {
                        anim.SetFloat("MoveX", 0);
                        anim.SetFloat("MoveY", -1);
                        //anim down
                    }
                }
                else if(distanceObject < 0.0 && distanceObject < -aux)
                {
                    //anim left
                    anim.SetFloat("MoveX", -1);
                    anim.SetFloat("MoveY", 0);
                }
                else
                {
                    if(distanceClick > 0)
                    {
                        //anim up
                        anim.SetFloat("MoveX", 0);
                        anim.SetFloat("MoveY", 1);
                    }
                    else
                    {
                        anim.SetFloat("MoveX", 0);
                        anim.SetFloat("MoveY", -1);
                        //anim down
                    }
                }
            }
        }
        else
        {
            isMoving = false;
            anim.SetBool("IsMoving", false);
        }
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        if(transform.position == targetPosition)
        {
            isMoving = false;
            anim.SetBool("IsMoving", false);
        }
    }
}
