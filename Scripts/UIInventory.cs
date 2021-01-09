using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    //얘가 모든 아이템을 keep track 하는 역할
    //어떤 것이 visible 하고 어떤 것이 invisible한지, 어디 위치에 어떤 아이템이 있는지

    public List<UIItem> uiItems = new List<UIItem>();
    public GameObject slotPrefab;
    public Transform slotPanel;
    public int numberOfSlots = 16;


    private void Awake() {
        for (int i = 0; i < numberOfSlots; i++) {
            GameObject instance = Instantiate(slotPrefab);
            instance.transform.SetParent(slotPanel);
            uiItems.Add(instance.GetComponentInChildren<UIItem>());
        }
    }

    //특정 인덱스에 가서 updateItem을 한다. ( 있으면 표시, 없으면 투명_
    public void UpdateSlot(int slot, Item item) {
        uiItems[slot].UpdateItem(item);
    }

    //객체가 들어있지 않은 인덱스를 찾아서, 으 인덱스에 item 객체를 넣는다.
    public void AddNewItem(Item item) {
        UpdateSlot(uiItems.FindIndex(i => i.item == null), item);
    }

    //해당 item이라는 객체가 있는 index를 찾아서 객체를 null로 바꾼다.
    public void RemoveItem(Item item) {
        UpdateSlot(uiItems.FindIndex(i => i.item == item), null);
    }
}