using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class KalineTreeManager : MonoBehaviour
{
    [SerializeField] TMP_Text goldLevelUpCost;
    [SerializeField] TMP_Text fertilizerLevelUpCost;
    [SerializeField] TMP_Text goldAfkRewardRate;
    [SerializeField] TMP_Text heroSoulsAfkRewardRate;
    [SerializeField] TMP_Text experienceAfkRewardRate;
    [SerializeField] TMP_Text arcaneCrystalsAfkRewardRate;
    [SerializeField] GameObject confirmPopUp;
    [SerializeField] GameObject insufficientCurrencyPopup;
    [SerializeField] TextMeshProUGUI gems;
    [SerializeField] TextMeshProUGUI gold;
    [SerializeField] TextMeshProUGUI xp;
    

    private const string EMPTY_AFK_REWARD = "0 (0/m)";

    void Start()
    {
        GlobalUserData user = GlobalUserData.Instance;
        goldLevelUpCost.text = user.User.kalineTreeLevel.goldLevelUpCost.ToString();
        fertilizerLevelUpCost.text = user.User.kalineTreeLevel.goldLevelUpCost.ToString();
    }
    public void ShowRewards() {
        GlobalUserData user = GlobalUserData.Instance;
        SocketConnection.Instance.GetAfkRewards(user.User.id, (afkRewards) => {
            confirmPopUp.SetActive(true);
            if (afkRewards.Count == 0) {
                gems.text = EMPTY_AFK_REWARD;
                gold.text = EMPTY_AFK_REWARD;
                xp.text = EMPTY_AFK_REWARD;
            } else {
                gems.text = $"{afkRewards.Single(ar => ar.currency == Currency.Gems).amount.ToString()} ({user.User.afkRewardRates.Single(arr => arr.currency == Currency.Gems).rate * 60}/m)";
                gold.text = $"{afkRewards.Single(ar => ar.currency == Currency.Gold).amount.ToString()} ({user.User.afkRewardRates.Single(arr => arr.currency == Currency.Gold).rate * 60}/m)";
                //xp.text = $"{afkRewards.Single(ar => ar.currency == Currency.Experience).amount.ToString()} ({user.User.afkRewardRates.Single(arr => arr.currency == Currency.Experience)}/m)";
            }
        });
    }

    public void ClaimRewards() {
        SocketConnection.Instance.ClaimAfkRewards(GlobalUserData.Instance.User.id, (userReceived) => {
            GlobalUserData userToUpdate = GlobalUserData.Instance;
            Dictionary<Currency, int> currenciesToAdd = new Dictionary<Currency, int>();

            userReceived.currencies.Select(c => c.Key).ToList().ForEach(c => {
                if (!currenciesToAdd.ContainsKey(c)) {
                    currenciesToAdd.Add(c, userReceived.currencies[c] - userToUpdate.GetCurrency(c).Value);
                }
            });
            currenciesToAdd.Add(Currency.Experience, userReceived.experience - userToUpdate.User.experience);
            userToUpdate.AddCurrencies(currenciesToAdd);
        });
        confirmPopUp.SetActive(false);
    }

    public void LevelUpKalineTree()
    {
        SocketConnection.Instance.LevelUpKalineTree(
            GlobalUserData.Instance.User.id, 
            (userReceived) => {
                GlobalUserData userToUpdate = GlobalUserData.Instance;
                Dictionary<Currency, int> currenciesToAdd = new Dictionary<Currency, int>();

                userReceived.currencies.Select(c => c.Key).ToList().ForEach(c => {
                    if (!currenciesToAdd.ContainsKey(c))
                    {
                        userToUpdate.SetCurrencyAmount(c, userReceived.currencies[c]);
                    }
                });
                UpdateLevelUpCosts(userReceived);
            },
            (reason) => {
                if(reason == "cant_afford") {
                    insufficientCurrencyPopup.SetActive(true);
                }
            }
        );
    }

    public void UpdateLevelUpCosts(User user)
    {
        goldLevelUpCost.text = user.kalineTreeLevel.goldLevelUpCost.ToString();
        fertilizerLevelUpCost.text = user.kalineTreeLevel.goldLevelUpCost.ToString();
    }
}
