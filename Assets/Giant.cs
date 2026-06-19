using UnityEngine;
using System.Collections;

public class Giant : MonoBehaviour
{
    public Animator animator;
    public float speed = 1f;
    public double damage = 30;
    public bool isRunning = true;
    public bool isEnemy = false;
    public bool isAttacking = false;
    private Coroutine currentcor = null;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.localPosition = new Vector3(-1023.78f, -606.14f, transform.localPosition.z);
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
            // animator.SetBool("run", true);
            // animator.SetBool("attack", false); 
            if (isEnemy)
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
        }
        else
        {
            // animator.SetBool("run", false);
            //animator.SetBool("attack", true);

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isAttacking) return;
        if (isEnemy)
        {
            if (collision.CompareTag("PlayerBase"))
            {
                isRunning = false;
                isAttacking = true;
                currentcor = StartCoroutine(Attack(collision));
            }
        }
        else
        {
            if (collision.CompareTag("EnemyBase"))
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
        while (target != null)
        {
            target.GetComponent<health>().TakeDamage(damage);
            yield return new WaitForSeconds(3f);
        }
        StopCoroutine(currentcor);
        currentcor = null;
        isAttacking = false;
        isRunning = true;

    }
}
