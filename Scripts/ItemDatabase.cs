using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();

  
    void Awake() {
        BuildDatabase();
    }

    public Item GetItem(int id) {
        return items.Find(item => item.id == id);
    }

    public Item GetItem(string itemName) {
        return items.Find(item => item.name == itemName);
    }

    void BuildDatabase()
    {
        items = new List<Item>() {

            new Item(0,"watermelon","it is delicious.",
            new Dictionary<string, int>{
                { "power",15 },{ "Defence",10}
            }),

              new Item(1,"strawberry","it is sweet.",
            new Dictionary<string, int>{
                { "power",10 },{ "Defence",50}
            })


        };


    }
}
