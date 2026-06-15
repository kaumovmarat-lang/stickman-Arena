using UnityEngine;

public class SpawnerCore : MonoBehaviour
{
    public PlayerMemory mem;

    //Spawn Stuff
    public GameObject targetObject;
    public Transform parentTransform;

    // ALL UNITS
    public GameObject Miner;
    public GameObject Basic;
    public GameObject Sword;
    public GameObject Shield;
    public GameObject Bow;
    public GameObject Mage;
    public GameObject Knight;
    public GameObject Giant;
    public GameObject Wall;

    // SLOTS
    public GameObject Slot1;
    public GameObject Slot2;
    public GameObject Slot3;
    public GameObject Slot4;

    void Start()
    {
        mem = FindFirstObjectByType<PlayerMemory>();
        Slot1 = SlotsUpdate(mem, 1);
        Slot2 = SlotsUpdate(mem, 2);
        Slot3 = SlotsUpdate(mem, 3);
        Slot4 = SlotsUpdate(mem, 4);
    }
    GameObject SlotsUpdate(PlayerMemory mem, int x)
    {
        switch (mem.SlotsGive(x)) 
        {
            case "Basic":
                return Basic;
            case "Miner":
                return Miner;
            case "Sword":
                return Sword;
            case "Shield":
                return Shield;
            case "Bow":
                return Bow;
            case "Mage":
                return Mage;
            case "Knight":
                return Knight;
            case "Giant":
                return Giant;
            case "Wall":
                return Wall;
            default:
                return Basic;
        }
        
    }
    public void SpawnSlot1()
    {
        Instantiate(Slot1, targetObject.transform.position, Quaternion.identity, parentTransform);
    }
    public void SpawnSlot2()
    {
        Instantiate(Slot2, targetObject.transform.position, Quaternion.identity, parentTransform);
    }
    public void SpawnSlot3()
    {
        Instantiate(Slot3, targetObject.transform.position, Quaternion.identity, parentTransform);
    }
    public void SpawnSlot4()
    {
        Instantiate(Slot4, targetObject.transform.position, Quaternion.identity, parentTransform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
