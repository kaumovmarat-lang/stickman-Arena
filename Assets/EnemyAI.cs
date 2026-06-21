using UnityEngine;
using System.Collections;

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
        StartCoroutine(SpawnSequence());
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timerforbasic += Time.deltaTime;
        if (timerforbasic >= 30f) { Instantiate(Basic, pos.transform.position, Quaternion.Euler(0f, 180f, 0f), Transform); timerforbasic = 0f; }
        
    }

    IEnumerator SpawnSequence()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            Instantiate(Miner, pos.transform.position, Quaternion.Euler(0f, 180f, 0f), Transform);

            yield return new WaitForSeconds(2f);
            Instantiate(Miner, pos.transform.position, Quaternion.Euler(0f, 180f, 0f), Transform);

            yield return new WaitForSeconds(21f);
            Instantiate(Sword, pos.transform.position, Quaternion.Euler(0f, 180f, 0f), Transform);

            yield return new WaitForSeconds(13f);
            Instantiate(Basic, pos.transform.position, Quaternion.Euler(0f, 180f, 0f), Transform);

            yield return new WaitForSeconds(31f);
            Instantiate(Bow, pos.transform.position, Quaternion.Euler(0f, 180f, 0f), Transform);

            yield return new WaitForSeconds(30f);
            Instantiate(Giant, pos.transform.position, Quaternion.Euler(0f, 180f, 0f), Transform);

            yield return new WaitForSeconds(20f);

        }

    }
}

