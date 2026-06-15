using UnityEngine;

public class PlayerMemory : MonoBehaviour
{
    //Slots
    public string Slot1 = "Empty";
    public string Slot2 = "Empty";
    public string Slot3 = "Empty";
    public string Slot4 = "Empty";

    //Wishes
    public int stars = 0;

    //GachaCheck
    public bool IsMinerOpen = true;
    public bool IsBasicOpen = true;
    public bool IsSwordOpen = true;
    public bool IsShieldOpen = false;
    public bool IsBowOpen = false;
    public bool IsMageOpen = false;
    public bool IsKnightOpen = false;
    public bool IsGiantOpen = false;
    public bool IsWallOpen = true;

    public string SlotsGive(int slot)
    {
        switch (slot) 
        {
            case 1:
                return Slot1;
            case 2:
                return Slot2;
            case 3:
                return Slot3;
            case 4:
                return Slot4;
            default:
                return "give slot number, idiot";
        }
    }
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
