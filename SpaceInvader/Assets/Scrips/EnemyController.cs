using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyController : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            StartCoroutine(KillEnemy());            
        }        
    }

    IEnumerator KillEnemy()
    {
        GameController.instance.Kills();
        GetComponent<Collider2D>().enabled = false;
        animator.SetTrigger("Kill Enemy");
        AnimatorStateInfo killAnimeState = animator.GetCurrentAnimatorStateInfo(0);
        GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(killAnimeState.length);

        Destroy(gameObject);
    }
}
