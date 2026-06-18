using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCore : MonoBehaviour
{
    public PlayerMemory mem;

    //InventoryLogic
    string[] units = new string[4];
    int i = 0; //счетчик
    private Dictionary<string, GameObject> PrefabsUI;
    public Transform parentTransform;

    //UI
    public GameObject closebutton;
    public GameObject sh;
    public GameObject bow;
    public GameObject mage;
    public GameObject g;
    public GameObject InventoryUI;
    public GameObject FullInventory;

    // ALL UNITS
    public GameObject Miner;
    public GameObject Basic;
    public GameObject Sword;
    public GameObject Shield;
    public GameObject Bow;
    public GameObject Mage;
    public GameObject Giant;
    public GameObject Wall;

    //Positions
    public GameObject pos1;
    public GameObject pos2;
    public GameObject pos3;
    public GameObject pos4;

    //Slots for delete
    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;
    public GameObject slot4;


    //Sounds
    public AudioSource fullsound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mem = FindFirstObjectByType<PlayerMemory>();
        PrefabsUI = new Dictionary<string, GameObject>
        {
            { "Miner", Miner },
            { "Basic", Basic },
            { "Sword", Sword },
            { "Shield", Shield },
            { "Bow", Bow },
            { "Mage", Mage },
            { "Giant", Giant },
            { "Wall", Wall }
        };
    }
    void check(PlayerMemory mem)
    {
        if (mem.IsShieldOpen) { sh.SetActive(false); }
        else {  sh.SetActive(true); }
        if (mem.IsBowOpen) { bow.SetActive(false); }
        else  {bow.SetActive(true); }
        if (mem.IsMageOpen) { mage.SetActive(false); }
        else { mage.SetActive(true); }
        if (mem.IsGiantOpen) { g.SetActive(false); }
        else { g.SetActive(true); }
    }
    public void OpenInventory()
    {
            closebutton.SetActive(false);
            InventoryUI.SetActive(true);
            check(mem);
    }
    public void CloseInventory()
    {
        InventoryUI.SetActive(false);
        closebutton.SetActive(true);
        FullInventory.SetActive(false);
    }

    public void choice(string unitname)
    {
        if (i < 4)
        {
            PrefabsUI.TryGetValue(unitname, out GameObject prefab);
            switch (i)
            {
                case 0:
                    slot1 = Instantiate(prefab, pos1.transform.position, Quaternion.identity, parentTransform);
                    break;
                case 1:
                    slot2 = Instantiate(prefab, pos2.transform.position, Quaternion.identity, parentTransform);
                    break;
                case 2:
                    slot3 = Instantiate(prefab, pos3.transform.position, Quaternion.identity, parentTransform);
                    break;
                case 3:
                    slot4 = Instantiate(prefab, pos4.transform.position, Quaternion.identity, parentTransform);
                    break;
            }
            
            units[i] = unitname;
            i++;
            updatememory(mem);
        }
        else
        {
            FullInventory.SetActive(true);
            fullsound.Play();
        }
    }
    public void updatememory(PlayerMemory mem) 
    {
        mem.Slot1 = units[0];
        mem.Slot2 = units[1];
        mem.Slot3 = units[2];
        mem.Slot4 = units[3];
    }
    public void deleteslots() 
    {
        for (int i = 0; i < units.Length; i++)
        {
            units[i] = null;
        }
        Destroy(slot1);
        Destroy(slot2);
        Destroy(slot3);
        Destroy(slot4);
        FullInventory.SetActive(false);
        i = 0;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
