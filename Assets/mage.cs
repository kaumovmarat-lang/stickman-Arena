using System.Net.NetworkInformation;
using UnityEngine;
using System.Collections;

public class mage : MonoBehaviour
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
        transform.localPosition = new Vector3(transform.localPosition.x, -605.04f, transform.localPosition.z); 
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
            transform.Translate(Vector2.right * speed * Time.deltaTime);
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
            if (collision.CompareTag("Enemy"))
            {
                isRunning = false;
                isAttacking = true;
                currentcor = StartCoroutine(Attack(collision));
            }
        }
        else
        {
            if (collision.CompareTag("Player"))
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

