using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FishBehaviour : MonoBehaviour
{
    private float dirX, dirY;
    public float moveSpeed, moveTime;
    public float minMoveSpeed = 1f, maxMoveSpeed = 3f, minMoveTime = 1f, maxMoveTime = 4f;
    private int changeDirectionProbability;
    private int changeDirectionProbabilityValue = 2;
    private Rigidbody2D rb;
    private bool facingRight = false;
    private Vector3 localScale;

    [NonSerialized]
    public bool isCaught = false;
    public GameObject hook;

    private ScoreManager scoreManager;


    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();

        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        dirX = Random.Range(-1f, 1f);
        dirY = Random.Range(-1f, 1f);
    }

    private void FixedUpdate()
    {
        Movement();
        FishCaught();
    }

    private void LateUpdate()
    {
        CheckWhereToFace();
    }

    private void Movement()
    {
        moveTime -= Time.deltaTime;
        if(moveTime <= 0)
        {
            moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);
            moveTime = Random.Range(minMoveTime, maxMoveTime);
            changeDirectionProbability = Random.Range(0, changeDirectionProbabilityValue);
            dirX = Random.Range(-1f, 1f);
            dirY = Random.Range(-1f, 1f);
            if (changeDirectionProbability == 1)
            {
                dirX *= -1f;
                dirY *= -1f;
            }
        }
        rb.velocity = new Vector2(dirX * moveSpeed, dirY * moveSpeed);
    }

   private void FishCaught()
    {
        if (isCaught)
        {
            moveSpeed = 0;
            transform.position = hook.transform.position;

            if (transform.position.y >= 0)
            {
                scoreManager.CheckValue(gameObject);
                Destroy(gameObject);
                isCaught = false;
                HookBehaviour.fishOnHook = false;
            }
        }
    }
    private void CheckWhereToFace()
    {
        if (dirX > 0)
            facingRight = true;
        else if (dirX < 0)
            facingRight = false;

        Vector3 scale = transform.localScale;
        if ((facingRight && scale.x < 0) || (!facingRight && scale.x > 0))
        {
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("WaterBorder"))
        {
            dirX *= -1f;
            dirY *= -1f;
        }

        if (collision.gameObject.CompareTag("Hook") && !HookBehaviour.fishOnHook)
        {
            isCaught = true;
            HookBehaviour.fishOnHook = true;
        }
    }
}

