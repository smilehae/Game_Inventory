using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> characterItems = new List<Item>();
    public ItemDatabase Database;
    public UIInventory inventoryUI;

    private void Start() {
        GiveItem(1);
        GiveItem("watermelon");
        GiveItem(2);
    }
    //아이템을 인벤토리에 넣어주는 코드
    public void GiveItem(int id) {
        //데이터베이스에서 이 id 값을 가진 아이템을 가져오고
        //캐릭터 인벤에 이 아이템을 추가해준다.
        Item itemToAdd = Database.GetItem(id);
        characterItems.Add(itemToAdd);
        inventoryUI.AddNewItem(itemToAdd);
        Debug.Log("Added Item : " + itemToAdd.name);
    }

    public void GiveItem(string itemName) {
        Item itemToAdd = Database.GetItem(itemName);
        characterItems.Add(itemToAdd);
        inventoryUI.AddNewItem(itemToAdd);
        Debug.Log("Added Item : " + itemName);
    }

    //아이템 있는지 확인
    public Item CheckForItem(int id) {
        return characterItems.Find(item => item.id == id);
    }

    //아이템 삭제
    public void RemoveItem(int id) {
        //아이템 있는지 확인하고, 없앨 아이템을 item이라는 변수에 가져옴
        Item item = CheckForItem(id);
        if (item != null) {
            characterItems.Remove(item);
            inventoryUI.RemoveItem(item);
            Debug.Log("Item removed " + item.name);
        }
    }
}
