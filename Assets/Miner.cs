using UnityEngine;

public class Miner : MonoBehaviour
{
    public Animator animator;
    public GameCore moneystat;
    public float timer = 0f;
    public bool miner;

    void Start()
    {
        moneystat = FindFirstObjectByType<GameCore>();
        if (miner) { //animator.SetBool("grind", true); }
    }

    void Update()
    {
        if (miner) 
        {
            timer += Time.deltaTime;

            if (timer >= 3f)
            {
                moneystat.moneyadd(5);
                timer = 0f;
            }
        }
        
    }
    
}
