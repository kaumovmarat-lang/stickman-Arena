using UnityEngine;

public class InventoryCore : MonoBehaviour
{
    public PlayerMemory mem;

    //UI
    public GameObject closebutton;
    public GameObject sh;
    public GameObject bow;
    public GameObject mage;
    public GameObject g;
    public GameObject InventoryUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mem = FindFirstObjectByType<PlayerMemory>();
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
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
