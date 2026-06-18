using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameCore : MonoBehaviour
{
    public PlayerMemory mem;

    // Main Objects
    public GameObject MainCastle;
    public GameObject EnemyCastle;
    public GameObject WinScreen; //рамис сделай
    public GameObject LoseScreen; //рамис сделай

    //Money System
    public int money = 0;
    public Text moneyText;
    public float timer = 0f;

    void Awake()
    {
        mem = FindFirstObjectByType<PlayerMemory>();
        if (mem == null) 
        {
            SceneManager.LoadScene("Whoops");
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moneyText.text = money.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (MainCastle == null) 
        {
            WinScreen.SetActive(false);
            LoseScreen.SetActive(true);
        }
        else if (EnemyCastle == null) 
        {
            LoseScreen.SetActive(false);
            WinScreen.SetActive(true);
            mem.stars += 3;
        }
        timer += Time.deltaTime;


        if (timer >= 3f)
        {
            moneyadd(5);
            timer = 0f;
        }
    }
    public void moneyadd(int mon)
    {
        money += mon;
        moneyText.text = money.ToString(); 
    }

}
