using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Movement : MonoBehaviour
{
    public GameObject laserBlastPrefab;
    public Transform firePoint;
    public Animator animator;
    public float fireCooldown, moveCooldown;
    public int speed = 6;
    private bool canFire, canMove;
    Vector3 moveVector;

    private void Awake()
    {
        moveVector = Vector3.right * speed * Time.fixedDeltaTime;
        canFire = true;
        canMove = true;
    }

    private void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(speed));

        if (GameController.instance.gamePlaying == true || GameController.instance.gamePlaying == true)
        {
            if (canMove == true)
            {
                GetMovementInput();
            }

            if (Input.GetButtonDown("P2Shoot") && canFire == true)
            {
                GetComponent<AudioSource>().Play();
                Shoot();
            }
        }
    }

    private void GetMovementInput()
    {
        canMove = false;

        if (Input.GetButtonDown("P2MoveLeft") || Input.GetButtonDown("P2MoveLeftCon"))
        {
            moveVector = Vector3.left * speed * Time.fixedDeltaTime;
        }
        else if (Input.GetButtonDown("P2MoveRight") || Input.GetButtonDown("P2MoveRightCon"))
        {
            moveVector = Vector3.right * speed * Time.fixedDeltaTime;
        }

        StartCoroutine(MoveCooldown());
    }

    private void Shoot()
    {
        canFire = false;
        Instantiate(laserBlastPrefab, firePoint.position, transform.rotation);
        StartCoroutine(FireCooldown());
    }

    IEnumerator FireCooldown()
    {
        yield return new WaitForSeconds(fireCooldown);
        canFire = true;
    }

    IEnumerator MoveCooldown()
    {
        yield return new WaitForSeconds(moveCooldown);
        canMove = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall Left")
        {
            moveVector = Vector3.right * speed * Time.fixedDeltaTime;
        }
        else if (collision.gameObject.tag == "Wall Right")
        {
            moveVector = Vector3.left * speed * Time.fixedDeltaTime;
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(moveVector);
    }
}