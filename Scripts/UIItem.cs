using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItem : MonoBehaviour
{
    //이 스크립트가 하는 일 : 아이템의 아이콘 보이기, 숨기기
    //아이콘이 존재하면 투명도를 0으로 하고, 아이콘이 없으면 투명도를 100으로 해서 숨겨버린다.

    public Item item;
    public Image spriteImage;

    private void Awake()
    {
        spriteImage = GetComponent<Image>();
        UpdateItem(null);
    }

    public void UpdateItem(Item item) {
        this.item = item;
        if (this.item != null) {
            spriteImage.color = Color.white;
            spriteImage.sprite = this.item.icon;
        }
        else
        {
            spriteImage.color = Color.clear;
        }
    }
}
