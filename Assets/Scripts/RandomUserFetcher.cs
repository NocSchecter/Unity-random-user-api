using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RandomUserFetcher : MonoBehaviour
{
    public UserUIItem userUIItem;

    public const string API_URL = "https://randomuser.me/api/?results=30";
    internal List<User> userList = new List<User>();
    private int userAmount;

    private void Start()
    {
        StartCoroutine(DownloadUserData());
    }

    private IEnumerator DownloadUserData()
    {
        using UnityWebRequest webRequest = UnityWebRequest.Get(API_URL);
        yield return webRequest.SendWebRequest();

        if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError(webRequest.error);
            yield break;
        }

        string jsonResponse = webRequest.downloadHandler.text;
        RandomUserResponse response = JsonUtility.FromJson<RandomUserResponse>(jsonResponse);
        userList = response.results;
        userAmount = userList.Count;
        userUIItem.CreateItems(userAmount);

        for (int i = 0; i < userList.Count; i++)
        {
            UnityWebRequest imageL = UnityWebRequestTexture.GetTexture(userList[i].picture.large);
            UnityWebRequest imageM = UnityWebRequestTexture.GetTexture(userList[i].picture.medium);
            UnityWebRequest imageTh = UnityWebRequestTexture.GetTexture(userList[i].picture.thumbnail);

            yield return imageL.SendWebRequest();

            if (imageL.result == UnityWebRequest.Result.ConnectionError || imageL.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError(imageL.error);
            }
            else
            {
                Texture2D texture = DownloadHandlerTexture.GetContent(imageL);
                userUIItem.picture[i].texture = texture;
                userUIItem.userName[i].text = userList[i].name.first;
            }
        }
    }
}