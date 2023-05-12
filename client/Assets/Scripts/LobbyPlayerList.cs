using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyPlayerList : MonoBehaviour
{
    [SerializeField] GameObject playerItemPrefab;
    [SerializeField] GameObject playButton;
    int totalPlayersBefore = 0;


    // Start is called before the first frame update

    private void CreatePlayerItem(int id)
    {
        GameObject newPlayer = Instantiate(playerItemPrefab, gameObject.transform);
        PlayerItem playerI = newPlayer.GetComponent<PlayerItem>();

        if (id == 1)
        {
            playerI.playerText.text += " " + (id.ToString() + " " + "HOST");
            playButton.SetActive(true);
        }
        else
        {
            if (LobbyConnection.Instance.playerId == id)
            {
                playerI.playerText.text += " " + id.ToString() + " " + "YOU";
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        print(totalPlayersBefore != LobbyConnection.Instance.playerCount);
        print(LobbyConnection.Instance.playerCount);
        for (int i = 0; i < LobbyConnection.Instance.playerCount; i++)
        {
            if (totalPlayersBefore != LobbyConnection.Instance.playerCount)
            {
                totalPlayersBefore++;
                CreatePlayerItem(totalPlayersBefore);
            }
        }
    }
}
