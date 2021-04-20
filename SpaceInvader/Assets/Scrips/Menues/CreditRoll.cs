using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditRoll : MonoBehaviour
{
    public float speed;
    Vector3 moveVector;

    private void Update()
    {
        if (CreditsController.instance.creditRoll == true)
        {
            moveVector = Vector3.up * speed * Time.fixedDeltaTime;
        }        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        moveVector = Vector3.zero;
    }

    private void FixedUpdate()
    {
        transform.Translate(moveVector);
    }
}
