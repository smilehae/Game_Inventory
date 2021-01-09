using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public int id;
    public string name;
    public string description;
    public Sprite icon;
    //power은 16이다, 이동속도가 증가한다 이런거 넣으려고 key와 value가 있는 dictionary 사용

    public Dictionary<string, int> stats = new Dictionary<string, int>();

    public Item(int id, string name, string desc, Dictionary<string, int> stats) {
        this.id = id;
        this.name = name;
        this.description = desc;
        this.stats = stats;

        this.icon = Resources.Load<Sprite>("Sprites/Items/" + name);

    }

    public Item(Item item)
    {
        this.id = item.id;
        this.name = item.name;
        this.description = item.description;
        this.stats = item.stats;

        this.icon = Resources.Load<Sprite>("Sprites/Items/" + item.name);

    }
}
