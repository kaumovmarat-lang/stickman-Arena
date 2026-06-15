using UnityEngine;
using UnityEngine.UI;

public class GameCore : MonoBehaviour
{
    public GameObject MainCastle;
    public GameObject EnemyCastle;
    public int money = 0;
    public Text moneyText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moneyText.text = money.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void moneyadd(int mon)
    {
        money += mon;
        moneyText.text = money.ToString(); 
    }
}
