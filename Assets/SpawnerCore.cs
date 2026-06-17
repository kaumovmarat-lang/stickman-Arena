using UnityEngine;
using UnityEngine.UI;

public class SpawnerCore : MonoBehaviour
{
    public PlayerMemory mem;
    public GameCore game;

    //Spawn Stuff
    public GameObject targetObject;
    public Transform parentTransform;
    public bool Icon = false;

    // ALL UNITS
    public GameObject Miner;
    public GameObject Basic;
    public GameObject Sword;
    public GameObject Shield;
    public GameObject Bow;
    public GameObject Mage;
    //public GameObject Knight;
    public GameObject Giant;
    public GameObject Wall;

    // SLOTS
    public GameObject Slot1;
    public GameObject Slot2;
    public GameObject Slot3;
    public GameObject Slot4;

    // SLOTS COSTS
    public int Slot1Cost = 0;
    public int Slot2Cost = 0;
    public int Slot3Cost = 0;
    public int Slot4Cost = 0;

    //UI POSITIONS
    public GameObject pos1;
    public GameObject pos2;
    public GameObject pos3;
    public GameObject pos4;
    public GameObject wallpos;
    public Text slot1price;
    public Text slot2price;
    public Text slot3price;
    public Text slot4price;

    //SOUNDS
    public AudioSource cancel;
    public AudioSource spawned;

    void Awake()
    {
        mem = FindFirstObjectByType<PlayerMemory>();
    }
    void Start()
    {
        Slot1 = SlotsUpdate(mem, 1);
        Debug.Log($"SlotsGive(1) = '{mem.SlotsGive(1)}'");
        Slot1Cost = SlotsCost(mem, 1);

        Slot2 = SlotsUpdate(mem, 2);
        Debug.Log($"SlotsGive(2) = '{mem.SlotsGive(2)}'");
        Slot2Cost = SlotsCost(mem, 2);

        Slot3 = SlotsUpdate(mem, 3);
        Debug.Log($"SlotsGive(3) = '{mem.SlotsGive(3)}'");
        Slot3Cost = SlotsCost(mem, 3);

        Slot4 = SlotsUpdate(mem, 4);
        Debug.Log($"SlotsGive(4) = '{mem.SlotsGive(4)}'");
        Slot4Cost = SlotsCost(mem, 4);

        if (Icon) { SpawnIcons(); }
        else 
        {
            slot1price.text = Slot1Cost.ToString() + " $";
            slot2price.text = Slot2Cost.ToString() + " $";
            slot3price.text = Slot3Cost.ToString() + " $";
            slot4price.text = Slot4Cost.ToString() + " $";
        }
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
         /* case "Knight":
                return Knight; */
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
        if (game.money >= Slot1Cost)
        {
            if (Slot1 == Wall) { Instantiate(Slot1, wallpos.transform.position, Quaternion.identity, parentTransform); }
            else { Instantiate(Slot1, targetObject.transform.position, Quaternion.identity, parentTransform); }
            Debug.Log(Slot1);
            game.moneyadd(-Slot1Cost);
            spawned.Play();
        }
        else
        {
            cancel.Play();
        }
    }
    public void SpawnSlot2()
    {
        if (game.money >= Slot2Cost)
        {
            if (Slot2 == Wall) { Instantiate(Slot2, wallpos.transform.position, Quaternion.identity, parentTransform); }
            else { Instantiate(Slot2, targetObject.transform.position, Quaternion.identity, parentTransform); }
            Debug.Log(Slot2);
            game.moneyadd(-Slot2Cost);
            spawned.Play();
        }
        else
        {
            cancel.Play();
        }
    }
    public void SpawnSlot3()
    {
        if (game.money >= Slot3Cost)
        {
            if (Slot3 == Wall) { Instantiate(Slot3, wallpos.transform.position, Quaternion.identity, parentTransform); }
            else { Instantiate(Slot3, targetObject.transform.position, Quaternion.identity, parentTransform); }
            Debug.Log(Slot3);
            game.moneyadd(-Slot3Cost);
            spawned.Play();
        }
        else
        {
            cancel.Play();
        }
    }
    public void SpawnSlot4()
    {
        if (game.money >= Slot4Cost)
        {
            if (Slot4 == Wall) { Instantiate(Slot4, wallpos.transform.position, Quaternion.identity, parentTransform); }
            else { Instantiate(Slot4, targetObject.transform.position, Quaternion.identity, parentTransform); }
            Debug.Log(Slot4);
            game.moneyadd(-Slot4Cost);
            spawned.Play();
        }
        else
        {
            cancel.Play();
        }
    }
    public void SpawnIcons()
    {
        Instantiate(Slot1, pos1.transform.position, Quaternion.identity, parentTransform);
        Instantiate(Slot2, pos2.transform.position, Quaternion.identity, parentTransform);
        Instantiate(Slot3, pos3.transform.position, Quaternion.identity, parentTransform);
        Instantiate(Slot4, pos4.transform.position, Quaternion.identity, parentTransform);
    }

    int SlotsCost(PlayerMemory mem, int x)
    {
        switch (mem.SlotsGive(x))
        {
            case "Basic":
                return 50;
            case "Miner":
                return 25;
            case "Sword":
                return 100;
            case "Shield":
                return 75;
            case "Bow":
                return 150;
            case "Mage":
                return 200;
         /* case "Knight":
                return 300; */
            case "Giant":
                return 300;
            case "Wall":
                return 50;
            default:
                return 50;
        }
    }
        // Update is called once per frame
        void Update()
    {
        
    }
}
