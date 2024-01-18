using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UnitDetail : MonoBehaviour
{
    private static Unit selectedUnit;

    [SerializeField]
    TMP_Text goldCostText;

    [SerializeField]
    TMP_Text gemCostText;
    
    [SerializeField]
    Text actionButtonText;

    [SerializeField]
    Image backgroundImage;

    [SerializeField]
    GameObject modelContainer;

    [SerializeField]
    GameObject characterNameContainer;

    [SerializeField]
    GameObject levelStatUI;

    [SerializeField]
    GameObject tierStatUI;

    [SerializeField]
    GameObject rankStatUI;

    [SerializeField]
    GameObject headItem;

    [SerializeField]
    GameObject chestItem;

    [SerializeField]
    GameObject bootsItem;

    [SerializeField]
    GameObject weaponItem;

    private Dictionary<Currency, int> cost;

    // true if we're leveling up, false if we're tiering up
    private bool actionLevelUp;

    void Start() {
        SetActionAndCosts();
        UpdateTexts();
        SetBackgroundImage();
        DisplayUnit();
        DisplayUnitItems();
    }

    public void ActionButton() {
        User user = GlobalUserData.Instance.User;
        if (user.CanAfford(cost)) {
            bool result;
            if (actionLevelUp) { result = LevelUp(); } else { result = TierUp(); }

            if (result) { 
                user.SubstractCurrency(cost);
                SetActionAndCosts();
                UpdateTexts();
            }
        } else {
            // Blocked by currency cost.
        }
    }

    private bool LevelUp() {
        if (selectedUnit.LevelUp()) {
            return true;
        }
        Debug.LogError("[UnitDetail.cs] Could not level up unit. Likely cause: a disparity between User.CanLevelUp() calls in UnitDetail.SetActionAndCosts() and Unit.LevelUp().");
        return false;
    }

    private bool TierUp() {
        if (selectedUnit.TierUp()) {
            return true;
        }
        // Tell user they need to improve the ranking of their unit via fusion.
        return false;
    }

    public static void SelectUnit(Unit unit) {
        selectedUnit = unit;
        SceneManager.LoadScene("UnitDetail");
    }

    private void UpdateTexts() {
        if (actionLevelUp) actionButtonText.text = "Level Up";
        else actionButtonText.text = "Tier up";

        //unitName.text = $"{selectedUnit.character.name}, tier/lvl: {selectedUnit.tier}/{selectedUnit.level} {selectedUnit.rank.ToString()}";
        tierStatUI.GetComponentInChildren<TextMeshProUGUI>().text = "Tier\n" + selectedUnit.tier.ToString();
        levelStatUI.GetComponentInChildren<TextMeshProUGUI>().text = "Level\n" + selectedUnit.level.ToString();
        rankStatUI.GetComponentInChildren<TextMeshProUGUI>().text = "Rank\n" + selectedUnit.rank.ToString();
        goldCostText.text = cost.ContainsKey(Currency.Gold) ? cost[Currency.Gold].ToString() : "0";
        gemCostText.text = cost.ContainsKey(Currency.Gems) ? cost[Currency.Gems].ToString() : "0";
    }

    private void SetActionAndCosts() {
        if (selectedUnit.CanLevelUp()) {
            actionLevelUp = true;
            cost = selectedUnit.LevelUpCost;
        } else {
            actionLevelUp = false;
            cost = selectedUnit.TierUpCost;
        }
    }

    private void SetBackgroundImage() 
    {
        switch (selectedUnit.character.faction) 
        {
            case Faction.Araban:
                backgroundImage.sprite = Resources.Load<Sprite>("UI/UnitDetailBackgrounds/ArabanBackground");
                break;
            case Faction.Kaline:
                backgroundImage.sprite = Resources.Load<Sprite>("UI/UnitDetailBackgrounds/KalineBackground");
                break;
            case Faction.Merliot:
                backgroundImage.sprite = Resources.Load<Sprite>("UI/UnitDetailBackgrounds/MerliotBackground");
                break;
            case Faction.Otobi:
                backgroundImage.sprite = Resources.Load<Sprite>("UI/UnitDetailBackgrounds/OtobiBackground");
                break;
            default:
                backgroundImage.sprite = Resources.Load<Sprite>("UI/UnitDetailBackgrounds/ArabanBackground");
                break;
        }
    }

    private void DisplayUnit()
    {
        if (modelContainer.transform.childCount > 0)
        {
            RemoveUnitFromContainer();
        }
        Instantiate(selectedUnit.character.prefab, modelContainer.transform);
        characterNameContainer.GetComponentInChildren<TextMeshProUGUI>().text = selectedUnit.character.name;
        characterNameContainer.SetActive(true);
    }

    private void RemoveUnitFromContainer()
    {
        Destroy(modelContainer.transform.GetChild(0).gameObject);
        characterNameContainer.SetActive(false);
    }

    private void DisplayUnitItems()
    {
        Debug.Log("Displaying unit items for: " + selectedUnit.character.name);
        Debug.Log("Items: " + selectedUnit.Items.Count);
        if (selectedUnit.head != null)
        {
            Debug.Log("Assigning head");
            headItem.GetComponent<Image>().sprite = selectedUnit.head.sprite;
        }
        if (selectedUnit.chest != null)
        {
            Debug.Log("Assigning chest");
            chestItem.GetComponent<Image>().sprite = selectedUnit.chest.sprite;
        }
        if (selectedUnit.boots != null)
        {
            Debug.Log("Assigning boots");
            bootsItem.GetComponent<Image>().sprite = selectedUnit.boots.sprite;
        }
        if (selectedUnit.weapon != null)
        {
            Debug.Log("Assigning weapon");
            weaponItem.GetComponent<Image>().sprite = selectedUnit.weapon.sprite;
        }
    }

}
