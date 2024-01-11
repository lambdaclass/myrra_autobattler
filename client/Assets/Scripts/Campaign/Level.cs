using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    // The characters of the units the level has, in order.
    [SerializeField]
    List<Character> characters;
    
    // The levels of the units the level has, in order.
    [SerializeField]
    List<int> levels;

    // Unlock this level if current level is beaten.
    // Level instead of string (like campaigns) to make it easier to set up in UI.
    [SerializeField]
    Level nextLevel;

    [SerializeField]
    GameObject lockObject;

    [SerializeField]
    GameObject completedCrossObject;

    // Wether this level is the first one of the campaign (unlocked automatically)
    [SerializeField]
    bool first;

    // Mark this campaign as completed if this level is beaten
    [SerializeField]
    string campaignToComplete;

    // Unlock this campaign if this level is beaten
    [SerializeField]
    string campaignToUnlock;

    private void Start(){
        if(first) { LevelProgressData.Instance.SetUnlocked(name); }

        switch(LevelProgressData.Instance.LevelStatus(name)) 
        {
            case LevelProgressData.Status.Locked:
                break;
            case LevelProgressData.Status.Unlocked:
                lockObject.SetActive(false);
                break;
            case LevelProgressData.Status.Completed:
                completedCrossObject.SetActive(true);
                lockObject.SetActive(false);
                break;
        }
    }

    public void SelectLevel(){
        if(LevelProgressData.Instance.LevelStatus(name) != LevelProgressData.Status.Unlocked) {
            return;
        }

        // Get the CampaignLevelManager parent and make it pop up the Battle button
        Transform parent = transform.parent;
        if (parent.TryGetComponent<CampaignLevelManager>(out CampaignLevelManager campaignLevelManager)) { campaignLevelManager.LevelSelected(); }
        else { Debug.LogError("Level has no CampaignLevelManager parent."); }
        
        SetUnits();
        SetLevelToComplete();
        SetLevelToUnlock();
        SetCampaignToComplete();
        SetCampaignToUnlock();
    }

    private void SetUnits() {
        OpponentData opponentData = OpponentData.Instance;
        List<Unit> units = new List<Unit>();
        for(int i = 0; i < characters.Count; i++) {
            units.Add(new Unit { id = "op-" + i.ToString(), level = levels[i], character = characters[i], slot = i, selected = true });
        }
        opponentData.Units = units;
    }

    private void SetLevelToComplete() {
        LevelProgressData.Instance.LevelToCompleteName = name;
    }

    private void SetLevelToUnlock() {
        if(nextLevel != null) { LevelProgressData.Instance.LevelToUnlockName = nextLevel.name; }
        else { LevelProgressData.Instance.LevelToUnlockName = null; }
    }

    private void SetCampaignToComplete() {
        CampaignProgressData.Instance.CampaignToComplete = campaignToComplete;
    }

    private void SetCampaignToUnlock() {
        CampaignProgressData.Instance.CampaignToUnlock = campaignToUnlock;
    }
}