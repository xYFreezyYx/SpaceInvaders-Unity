using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject laserBlastPrefab;
    public Transform firePoint;   
    public Animator animator;
    public float cooldown;
    public int speed = 35;
    private bool canFire;
    Vector3 moveVector;

    private void Awake()
    {
        moveVector = Vector3.left * speed * Time.fixedDeltaTime;
        canFire = true;
    }

    private void Update()
    {      
        animator.SetFloat("Speed", Mathf.Abs(speed));

        if (GameController.instance.gamePlaying == true)
        {
            if (Input.GetButtonDown("Shoot") && canFire == true)
            {
                Shoot();
            }
        }        
    }

    private void Shoot()
    {
        canFire = false;
        Instantiate(laserBlastPrefab, firePoint.position, transform.rotation);
        StartCoroutine(FireCooldown());
    }

    IEnumerator FireCooldown()
    {
        yield return new WaitForSeconds(cooldown);
        canFire = true;
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
