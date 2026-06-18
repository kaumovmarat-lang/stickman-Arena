using UnityEngine;
using UnityEngine.SceneManagement;

public class Gacha_System : MonoBehaviour
{
    public PlayerMemory mem;
    public GameObject Miner, Basic, Sword, Shield, Bow, Mage, Knight, Giant, Wall;
    public GameObject spawnPoint;
    public Transform transform;
    public GameObject selected;
    public GameObject boom;
    public GameObject gachaUI;
    public GameObject UIfull;
    public void roll()
    {
        if (mem.stars < 3) { UIfull.SetActive(true); return; }
        UIfull.SetActive(false);
        mem.stars -= 3;
        int rand = Random.Range(0, 90);
        
        //GameObject selected = null;
        Destroy(boom);

        if (rand < 15) selected = Miner;       //15%
        else if (rand < 30) selected = Basic;  //15%
        else if (rand < 45) selected = Wall;   //15%
        else if (rand < 60) selected = Sword;  //15%
        else if (rand < 70) { selected = Shield; mem.IsShieldOpen = true; } //10%
        else if (rand < 80) { selected = Bow; mem.IsBowOpen = true; }       //10%
        else if (rand < 85) { selected = Mage; mem.IsMageOpen = true; }     //5%
        else { selected = Giant; mem.IsGiantOpen = true; }                  //5%
        Debug.Log(selected);
        boom = Instantiate(selected, spawnPoint.transform.position, Quaternion.identity, transform);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mem = FindFirstObjectByType<PlayerMemory>();
        if (mem == null)
        {
            SceneManager.LoadScene("Whoops");
        }
    }
    public void OpenGacha()
    {
        gachaUI.SetActive(true);
    }
    public void CloseGacha()
    {
        gachaUI.SetActive(false);
    }
}
