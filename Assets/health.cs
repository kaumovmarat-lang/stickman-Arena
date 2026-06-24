using UnityEngine;

public class health : MonoBehaviour
{
    public float Maxhp; 
    public float hp = 10;
    public int money = 25;
    public GameCore moneystat;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        moneystat = FindFirstObjectByType<GameCore>();
        Maxhp = hp;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0) 
        {
            if(gameObject.tag == "Enemy") { moneystat.moneyadd(money); }
            Destroy(gameObject); 
        }
    }
    public void TakeDamage(float damage)
    {
        hp -= damage;
    }
}
