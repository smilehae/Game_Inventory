using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // 드래그 확인용으로 쓰임

public class UIItem : MonoBehaviour , IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    //IPointerClickHandler 클릭에 대한 것
{
    //이 스크립트가 하는 일 : 아이템의 아이콘 보이기, 숨기기
    //아이콘이 존재하면 투명도를 0으로 하고, 아이콘이 없으면 투명도를 100으로 해서 숨겨버린다.

    public Item item;
    public Image spriteImage;
    private UIItem selectedItem;
    private Tooltip tooltip;

    private void Awake()
    {
        spriteImage = GetComponent<Image>();
        UpdateItem(null);
        selectedItem = GameObject.Find("selectedItem").GetComponent<UIItem>();
        tooltip = GameObject.Find("Tooltip").GetComponent<Tooltip>();
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

    public void OnPointerClick(PointerEventData eventData)
    {
        if (this.item != null) {
            if (selectedItem.item != null) {
                Item clone = new Item(selectedItem.item); //원래 선택중이었던 아이템을 clone에 저장
                selectedItem.UpdateItem(this.item); //선택된 아이템 그림을 방금 누른 아이템으로 바꿔줌
                UpdateItem(clone); //현재 인벤칸의 내용을 아까 저장한 clone으로 바꿔줌
            }
            //아무것도 안잡은 상태에서 드래그한것 : 현재 값을 드래그 하도록 바꿔주고 현재 칸을 비움
            else
            {
                selectedItem.UpdateItem(this.item);
                UpdateItem(null);
            }
        }
        //빈공간에 드래그하면 이 공간을 selected item으로 바꿔줌
        else if(selectedItem.item != null)
        {
            UpdateItem(selectedItem.item);
            selectedItem.UpdateItem(null);

        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (this.item != null) {
            tooltip.GenerateTooltip(this.item);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
       tooltip.gameObject.SetActive(false);
    }
}
