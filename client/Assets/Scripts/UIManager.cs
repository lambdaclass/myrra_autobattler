using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Transform lobbiesContainer;
    [SerializeField] GameObject lobbyItemPrefab;
    [SerializeField] GameObject gameItemPrefab;
    [SerializeField] Transform gamesContainer;


    bool lobbiesEmpty = true;
    bool gamesEmpty = true;

    // Update is called once per frame
    void Update()
    {
        if (lobbiesEmpty && LobbyConnection.Instance.lobbiesList.Count > 0)
        {
            GenerateList(LobbyConnection.Instance.lobbiesList, lobbyItemPrefab, lobbiesContainer);
            lobbiesEmpty = false;
        }
        if (gamesEmpty && LobbyConnection.Instance.gamesList.Count > 0)
        {
            GenerateList(LobbyConnection.Instance.gamesList, gameItemPrefab, gamesContainer);
            gamesEmpty = false;
        }
    }


    public void GenerateList(List<string> itemList, Object itemPrefab, Transform container)
    {
        itemList.ForEach(el =>
        {
            GameObject item = (GameObject)Instantiate(itemPrefab, container);
            item.GetComponent<LobbiesListItem>().setId(el);
        });
    }

}