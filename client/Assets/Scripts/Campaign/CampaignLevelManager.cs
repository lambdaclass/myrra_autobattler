using System.Collections.Generic;
using UnityEngine;

public class CampaignLevelManager : MonoBehaviour
{
    [SerializeField]
    GameObject PlayButton;

    public void LevelSelected()
    {
        PlayButton.SetActive(true);
    }
}
