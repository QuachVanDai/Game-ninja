using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class inventoryManager : NCKHMonoBehaviour
{
    
    [SerializeField] private GameObject itemCursor;
    [SerializeField] private GameObject slotsHolder;
    [SerializeField] private slotClass[] items ;
    [SerializeField] private slotClass[] startingItems;
    [SerializeField] private TextMeshProUGUI txtShowInfor;
   // private ItemSO itemToAdd;
   // private ItemSO itemToRemove;
    private GameObject[] slots;
    private slotClass movingSlot;
    private slotClass temSlot;
    private slotClass originalSlot;
    private bool isMovingItem;

    private static inventoryManager instance;
    public static inventoryManager Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        inventoryManager.instance = this;
    }
    public void Start()
    {
        slots = new GameObject[slotsHolder.transform.childCount];

        items = new slotClass[slots.Length];
        for (int i = 0; i < items.Length; i++)
            items[i] = new slotClass();

        for (int i = 0; i < startingItems.Length; i++)
        {
            items[i] = startingItems[i];
        }

        for (int i = 0; i < slotsHolder.transform.childCount; i++)
        {
            slots[i] = slotsHolder.transform.GetChild(i).gameObject;
        }
        RefreshUI();
    }
    public GameObject[] getSlots() { return slots; }
    public slotClass[] getstartingItems() { return startingItems; }
    private void Update()
    {
        itemCursor.SetActive(isMovingItem);
        itemCursor.transform.position = Input.mousePosition;
        if(isMovingItem ) { itemCursor.GetComponent<Image>().sprite = movingSlot.getItemSO().icon; }

        if(Input.GetMouseButtonDown(1))
        {
             if (!isMovingItem)
            {
                BeginItemMove();
            }
            else
            {
                EndItemMove();
            }
        }
      
      if (Input.GetMouseButtonDown(0))
        {
            showInforItem();
        }
        /*if (Input.GetMouseButtonUp(0))
        {
            if (isMovingItem)
            {
                EndItemMove();
            }
        }*/
    }
    #region units
    public void RefreshUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            try
            {
                slots[i].transform.GetChild(1).GetComponent<Image>().enabled = true;
                slots[i].transform.GetChild(1).GetComponent<Image>().sprite = items[i].getItemSO().icon;
                if (items[i].getItemSO().isStackable)
                {
                    slots[i].transform.GetChild(2).GetComponent<Text>().text = items[i].getQuantity().ToString();
                }
                else
                {
                    slots[i].transform.GetChild(2).GetComponent<Text>().text = "";
                }
            }
            catch
            {
                slots[i].transform.GetChild(1).GetComponent<Image>().sprite = null;
                slots[i].transform.GetChild(1).GetComponent<Image>().enabled = false;
                slots[i].transform.GetChild(2).GetComponent<Text>().text = "";
            }
        }
    }

    public bool Add(ItemSO item,int quantity)
    {
        slotClass sl = Contain(item);
        if (sl != null && sl.getItemSO().isStackable)
        {
            sl.addQuantity(quantity);
        }
        else
        {
            for(int i = 0;i < items.Length;i++) 
            {
                if (items[i].getItemSO()==null)
                {
                    items[i].addItemSO(item, quantity);
                    break;
                }
            }
        }
        RefreshUI();
        return true;
    }

    public bool Remove(ItemSO item)
    {

        int slotToRemoveIndex=0 ;
        slotClass temp = Contain(item);
        if (temp != null)
        {
            if (temp.getQuantity()>1)
            {
                temp.SubQuantity(1);
            }
            else
            {
                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i].getItemSO() == item)
                    {
                        slotToRemoveIndex = i;
                        break;
                    }
                }
                items[slotToRemoveIndex].Clear();
            }
        }
        else
        {
            return false;
        }
 
        RefreshUI();
        return true;
    }
 
    public slotClass Contain(ItemSO item)
    {

        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].getItemSO() == item) return items[i];
        }
        return null;

    }
    #endregion

    #region show Information
    public void showInforItem()
    {
        string str = "";
        originalSlot = GetClosestSLot();
        if (originalSlot == null || originalSlot.getItemSO() == null)
        {
            txtShowInfor.text = "Chọn vật phẩm";
            return ;
        }
    //    < color = "red" > Game </ color >< color = "orange" > Thu </ color >< color = "green" > Thach </ color >

        str += originalSlot.getItemSO().itemName+ "\n";
        str += "Cấp độ "+originalSlot.getItemSO().level+ "\n";
        str += originalSlot.getItemSO().Description + "\n";
        txtShowInfor.text = str;
        RefreshUI();
    }
    #endregion
    #region update
    public int updateHP(int number)
    {
        int quanitity = 0;
        bool flat = true;
        for (int i = 0; i < getstartingItems().Length; i++)
        {
            
                try
                {
                    if (getstartingItems()[i].getItemSO().itemName == "HP")
                    {
                        if (flat)
                        {
                            if (number == 1)
                            {
                                getstartingItems()[i].addQuantity(1);
                            }
                            else if (number == -1)
                            {
                                getstartingItems()[i].SubQuantity(1);
                            }
                            if (getstartingItems()[i].getQuantity() <= 0)
                            {
                                Remove(getstartingItems()[i].getItemSO());
                            }
                            else
                                quanitity += getstartingItems()[i].getQuantity();
                        flat = false;
                        }
                        else
                        {
                            quanitity += getstartingItems()[i].getQuantity();
                        }
                    }
                }
                catch
                {

                }
        }
        return quanitity;
    }
    public int updateMP(int number)
    {
        int quanitity = 0;
        bool flat = true;
        for (int i = 0; i < getstartingItems().Length; i++)
        {

            try
            {
                if (getstartingItems()[i].getItemSO().itemName == "MP")
                {
                    if (flat)
                    {
                        if (number == 1)
                        {
                            getstartingItems()[i].addQuantity(1);
                        }
                        else if (number == -1)
                        {
                            getstartingItems()[i].SubQuantity(1);
                        }
                        if (getstartingItems()[i].getQuantity() <= 0)
                        {
                            Remove(getstartingItems()[i].getItemSO());
                        }
                        else
                            quanitity += getstartingItems()[i].getQuantity();
                        flat = false;
                    }
                    else
                    {
                        quanitity += getstartingItems()[i].getQuantity();
                    }
                }
            }
            catch
            {

            }
        }
        return quanitity;
    }
    #endregion


    #region 
    private bool BeginItemMove()
    {
        originalSlot = GetClosestSLot();
        if (originalSlot == null || originalSlot.getItemSO() == null)
        {
            return false;
        }
        movingSlot = new slotClass(originalSlot);
        isMovingItem = true;
        originalSlot.Clear();
        RefreshUI();
        return true;
    }
  
    private bool EndItemMove()
    {
        originalSlot = GetClosestSLot();
            if (originalSlot == null)
            {
                Add(movingSlot.getItemSO(), movingSlot.getQuantity());
                movingSlot.Clear();
            }
            else
            {
                if (originalSlot.getItemSO() != null)
                {
                    if (originalSlot.getItemSO() == movingSlot.getItemSO())
                    {
                        if (originalSlot.getItemSO().isStackable)
                        {
                            originalSlot.addQuantity(movingSlot.getQuantity());
                            movingSlot.Clear();
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        temSlot = new slotClass(originalSlot);
                        originalSlot.addItemSO(movingSlot.getItemSO(), movingSlot.getQuantity());
                        movingSlot.addItemSO(temSlot.getItemSO(), temSlot.getQuantity());
                        RefreshUI();
                        return true;
                    }
                }
                else
                {
                    originalSlot.addItemSO(movingSlot.getItemSO(), movingSlot.getQuantity());
                    movingSlot.Clear();
                }
            }
        isMovingItem = false;
        RefreshUI();
        return true;
    }
    public void setSelect(int index)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].transform.GetChild(0).gameObject.SetActive(false);
        }
        slots[index].transform.GetChild(0).gameObject.SetActive(true);
    }
    private slotClass GetClosestSLot()
    {
      for (int i = 0; i < slots.Length; i++)
        {
            if (Vector2.Distance(slots[i].transform.position,Input.mousePosition)<=64)
            {
                setSelect(i);
                return items[i];
            }
        }
        return null;
    }
    #endregion
}
