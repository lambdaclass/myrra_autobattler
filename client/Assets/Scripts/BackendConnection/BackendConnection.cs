using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

public static class BackendConnection
{
    public static IEnumerator GetAvailableUnits(
        Action<List<UnitDTO>> successCallback
    )
    {
        string url = "http://localhost:4000/users-characters/faker_device/get_units";
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            webRequest.SetRequestHeader("Content-Type", "application/json");

            yield return webRequest.SendWebRequest();
            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                if (webRequest.downloadHandler.text.Contains("NOT_FOUND"))
                {
                    // errorCallback?.Invoke("USER_NOT_FOUND");
                }
                else
                {
                    List<UnitDTO> units = JsonConvert.DeserializeObject<List<UnitDTO>>(
                        webRequest.downloadHandler.text
                    );
                    // It would be nice to get the units ordered from the backend
                    units = units.OrderByDescending(unit => unit.selected).ThenByDescending(unit => unit.slot).ThenByDescending(unit => unit.level).ToList();
                    successCallback?.Invoke(units);
                }
                webRequest.Dispose();
            }
            else
            {
                switch (webRequest.result)
                {
                    case UnityWebRequest.Result.ProtocolError:
                        Debug.LogError("Something unexpected happened");
                        break;
                    case UnityWebRequest.Result.ConnectionError:
                        Debug.LogError("Connection Error");
                        break;
                    case UnityWebRequest.Result.DataProcessingError:
                        Debug.LogError("Data processing error.");
                        break;
                    default:
                        Debug.LogError("Unhandled error.");
                        break;
                }
            }
        }
    }

    public static IEnumerator SelectUnit(string unitId, int slot)
    {
        Debug.Log($"selected unit: {unitId} in slot: {slot}");
        string url = $"http://localhost:4000/users-characters/faker_device/select_unit/{unitId}";
        string parametersJson = "{\"slot\":\"" + slot + "\"}";
        byte[] byteArray = Encoding.UTF8.GetBytes(parametersJson);
        using (UnityWebRequest webRequest = UnityWebRequest.Put(url, byteArray))
        {
            webRequest.SetRequestHeader("Content-Type", "application/json");

            yield return webRequest.SendWebRequest();
            Debug.Log(webRequest.result);
            switch (webRequest.result)
            {
                case UnityWebRequest.Result.Success:
                    if (webRequest.downloadHandler.text.Contains("INEXISTENT_USER"))
                    {
                        // errorCallback?.Invoke(webRequest.downloadHandler.text);
                    }
                    else
                    {
                        // UserCharacterResponse response =
                        //     JsonUtility.FromJson<UserCharacterResponse>(
                        //         webRequest.downloadHandler.text
                        //     );
                        // successCallback?.Invoke(response);
                    }
                    break;
                default:
                    // errorCallback?.Invoke(webRequest.downloadHandler.error);
                    Debug.LogError(webRequest.downloadHandler.text);
                    Debug.LogError(webRequest.downloadHandler.error);
                    break;
            }
        }
    }

    public static IEnumerator UnselectUnit(string unitId)
    {
        string url = $"http://localhost:4000/users-characters/faker_device/unselect_unit/{unitId}";
        string parameters = "slot=";
        using (UnityWebRequest webRequest = UnityWebRequest.Put(url, parameters))
        {
            yield return webRequest.SendWebRequest();
            switch (webRequest.result)
            {
                case UnityWebRequest.Result.Success:
                    if (webRequest.downloadHandler.text.Contains("INEXISTENT_USER"))
                    {
                        // errorCallback?.Invoke(webRequest.downloadHandler.text);
                    }
                    else
                    {
                        // UserCharacterResponse response =
                        //     JsonUtility.FromJson<UserCharacterResponse>(
                        //         webRequest.downloadHandler.text
                        //     );
                        // successCallback?.Invoke(response);
                        Debug.Log(webRequest.downloadHandler.text);
                    }
                    break;
                default:
                    // errorCallback?.Invoke(webRequest.downloadHandler.error);
                    Debug.LogError(webRequest.downloadHandler.error);
                    break;
            }
        }
    }

    public static IEnumerator GetBattleResult(
        string playerDeviceId,
        string opponentId,
        Action<string> successCallback
    )
    {
        string url = $"http://localhost:4000/autobattle/{playerDeviceId}/{opponentId}";
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            webRequest.SetRequestHeader("Content-Type", "application/json");

            yield return webRequest.SendWebRequest();
            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                if (webRequest.downloadHandler.text.Contains("NOT_FOUND"))
                {
                    // errorCallback?.Invoke("USER_NOT_FOUND");
                }
                else
                {
                    BattleResultDTO battleResult = JsonConvert.DeserializeObject<BattleResultDTO>(
                        webRequest.downloadHandler.text
                    );
                    yield return new WaitForSeconds(2);
                    successCallback?.Invoke(battleResult.winner);
                }
                webRequest.Dispose();
            }
            else
            {
                switch (webRequest.result)
                {
                    case UnityWebRequest.Result.ProtocolError:
                        Debug.LogError("Something unexpected happened");
                        break;
                    case UnityWebRequest.Result.ConnectionError:
                        Debug.LogError("Connection Error");
                        break;
                    case UnityWebRequest.Result.DataProcessingError:
                        Debug.LogError("Data processing error.");
                        break;
                    default:
                        Debug.LogError("Unhandled error.");
                        break;
                }
            }
        }
    }
}
