using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RandomUserDataService : MonoBehaviour, IUserDataService
{
    public IEnumerator DownloadUserData(Action<List<User>> onSuccess, Action<string> onFailure)
    {
        using UnityWebRequest webRequest = UnityWebRequest.Get(RandomUserDataLoader.API_URL);
        yield return webRequest.SendWebRequest();

        if (webRequest.result != UnityWebRequest.Result.Success)
        {
            throw new Exception(webRequest.error);
        }

        string jsonResponse = webRequest.downloadHandler.text;
        List<User> userList = JsonUtility.FromJson<RandomUserResponse>(jsonResponse).results;
        onSuccess?.Invoke(userList);
    }
}
