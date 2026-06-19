using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject Miner, Basic, Sword, Shield, Bow, Mage, Knight, Giant, Wall;
    public Transform Transform;
    public GameObject pos;
    public float timer = 0f;
    public float timerforbasic = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timerforbasic += Time.deltaTime;
        if (timerforbasic >= 15f) { Instantiate(Basic, pos.transform.position, Quaternion.identity, Transform); timerforbasic = 0f; }
        switch (timer)
        {
            case 3f:
                Instantiate(Miner, pos.transform.position, Quaternion.identity, Transform);
                break;
            case 5f:
                Instantiate(Miner, pos.transform.position, Quaternion.identity, Transform);
                break;
            case 26f:
                Instantiate(Sword, pos.transform.position, Quaternion.identity, Transform);
                break;
            case 39f:
                Instantiate(Basic, pos.transform.position, Quaternion.identity, Transform);
                break;
            case 70f:
                Instantiate(Bow, pos.transform.position, Quaternion.identity, Transform);
                break;
            case 100f:
                Instantiate(Giant, pos.transform.position, Quaternion.identity, Transform);
                break;
            case 120f:
                timer = 0f;
                break;

        }

    }


}

