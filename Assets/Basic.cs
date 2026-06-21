using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Basic : MonoBehaviour
{
    public Animator animator;
    public float speed = 1.5f;
    public double damage = 2;
    public bool isRunning = true;
    public bool isEnemy = false;
    public bool isAttacking = false;
    private Coroutine currentcor = null;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, -605.21f, transform.localPosition.z);
        if (isEnemy)
        {
            gameObject.tag = "Enemy";
        }
        else
        {
            gameObject.tag = "Player";
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
           animator.SetBool("animations", true);
           animator.SetBool("attack", false); 
           transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else 
        {
            animator.SetBool("animations", false);
            animator.SetBool("attack", true);
            
        }
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isAttacking) return;
        if (collision == null) return;
        if (isEnemy) 
        {
            if (collision.CompareTag("Player") || collision.CompareTag("PlayerBase"))
            {
                isRunning = false;
                isAttacking = true;
                currentcor = StartCoroutine(Attack(collision));
                
            }
        }
        else 
        {
            if (collision.CompareTag("Enemy") || collision.CompareTag("EnemyBase"))
            {
                isRunning = false;
                isAttacking = true;
                currentcor = StartCoroutine(Attack(collision));
            }
        }
        
    }
    private IEnumerator Attack(Collider2D collision)
    {
        var target = collision.gameObject;
        while (target != null) {
            yield return new WaitForSeconds(3f);
            target.GetComponent<health>().TakeDamage(damage);
            if (target == null) break;
        }
        StopCoroutine(currentcor);
        currentcor = null;
        isAttacking = false;
        isRunning = true;

    }

    }

