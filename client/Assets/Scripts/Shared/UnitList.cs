using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UnitList : MonoBehaviour
{
    [SerializeField]
    GameObject unitItemUIPrefab;

    [SerializeField]
    GameObject unitContainer;

    [NonSerialized]
    public UnityEvent<Unit> OnUnitSelected = new UnityEvent<Unit>();

    public void PopulateList(List<Unit> units)
    {
        units.ForEach(unit =>
        {
            GameObject unitItem = Instantiate(unitItemUIPrefab, unitContainer.transform);
            unitItem.GetComponent<Image>().sprite = unit.character.characterSprite;
            var ss = new SpriteState();
            ss.disabledSprite = unit.character.disabledSprite;
            Button unitItemButton = unitItem.GetComponent<Button>();
            unitItemButton.spriteState = ss;
            unitItemButton.onClick.AddListener(() => SelectUnit(unit, unitItemButton));
            if(unit.selected) {
                unitItemButton.interactable = false;
            }
        });
    }

    public void SelectUnit(Unit unit, Button unitItemButton)
    {
        OnUnitSelected.Invoke(unit);
        unitItemButton.interactable = false;
    }
}
