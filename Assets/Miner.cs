using UnityEngine;

public class Miner : MonoBehaviour
{
    public Animator animator;
    public GameCore moneystat;
    public float timer = 0f;
    public bool miner;
    public bool enemy;

    void Start()
    {
        moneystat = FindFirstObjectByType<GameCore>();
        if (!enemy) { transform.localPosition = new Vector3(-1024.14f, -605.6f, transform.localPosition.z); }
        else { transform.localPosition = new Vector3(-1007.98f, -605.73f, transform.localPosition.z); }
        
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
