using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HookBehaviour : MonoBehaviour
{
    public float min_Z = -55f, max_Z = 55f;
    public float rotate_speed = 5f;

    private float rotate_Angle;
    private bool rotate_Right;
    private bool canRotate;

    public static float MOVE_SPEED = 3f;
    private float initial_Move_Speed;

    public float min_Y = -2.5f;
    private float initial_Y;

    private bool moveDown;

    private FishBehaviour[] fb;

    public static bool fishOnHook = false;

    private void Start()
    {
        fb = FindObjectsOfType<FishBehaviour>();

        initial_Y = transform.position.y;
        initial_Move_Speed = MOVE_SPEED;

        canRotate = true;
    }
    private void Update()
    {
        GetInput();
    }
    private void FixedUpdate()
    {
        Rotate();
        MoveLine();
    }

    void Rotate()
    {
        if (!canRotate)
            return;

        //checks if the rotation should be increasing or decreasing
        if (rotate_Right)
            rotate_Angle += rotate_speed * Time.deltaTime;
        else
            rotate_Angle -= rotate_speed * Time.deltaTime;

        transform.rotation = Quaternion.AngleAxis(rotate_Angle, Vector3.forward);

        //invert rotation when min/max Z value is reached
        if(rotate_Angle >= max_Z)
            rotate_Right = false;
        else if(rotate_Angle <= min_Z)
            rotate_Right = true;
    }

    void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canRotate)
            {
                canRotate = false;
                moveDown = true;
                FMODUnity.RuntimeManager.PlayOneShot("event:/LowerCage");
            }
        }
    }

    void MoveLine()
    {
        if (canRotate)
            return;

        if (!canRotate)
        {
            Vector3 temp = transform.position;

            if (moveDown)
            {
                temp -= transform.up * Time.deltaTime * MOVE_SPEED;
            }
            else
            {
                temp += transform.up * Time.deltaTime * MOVE_SPEED;
            }
            transform.position = temp;

            if(temp.y <= min_Y)
            {
                moveDown = false;
            }
            if(temp.y >= initial_Y)
            {
                canRotate = true;
                MOVE_SPEED = initial_Move_Speed;
            }
        }

        for (int i = 0; i < fb.Length; i++)
        {
            if (fb[i].isCaught)
            {
                moveDown = false;
            }
        }
    }
}
