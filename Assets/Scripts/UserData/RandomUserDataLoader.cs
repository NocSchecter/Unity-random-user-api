using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class RandomUserDataLoader : MonoBehaviour
{
    private IUserDataService userDataService;
    private IUserItemCreator userItemCreator;

    public const string API_URL = "https://randomuser.me/api/?results=50";
    internal List<User> userList;
    private int userAmount;


    private void Start()
    {
        userDataService = gameObject.AddComponent<RandomUserDataService>();
        userItemCreator = gameObject.GetComponent<IUserItemCreator>();
        StartCoroutine(userDataService.DownloadUserData(OnUserDataDownloadSuccess, OnUserDataDownloadFailed));
    }

    private void OnUserDataDownloadSuccess(List<User> userList)
    {
        this.userList = userList;
        userAmount = userList.Count;

        for (int i = 0; i < userList.Count; i++)
        {
            UnityWebRequest imageL = UnityWebRequestTexture.GetTexture(userList[i].picture.large);

            StartCoroutine(DownloadUserImage(imageL, i));
        }
        userItemCreator.CreateItems(userAmount, userList);
    }

    private IEnumerator DownloadUserImage(UnityWebRequest imageRequest, int index)
    {
        yield return imageRequest.SendWebRequest();

        if (imageRequest.result == UnityWebRequest.Result.ConnectionError || imageRequest.result == UnityWebRequest.Result.ProtocolError)
            Debug.LogError(imageRequest.error);
        else
        {
            Texture2D texture = DownloadHandlerTexture.GetContent(imageRequest);
            userItemCreator.picture[index].texture = texture;
        }
    }

    private void OnUserDataDownloadFailed(string errorMessage)
    {
        Debug.LogError(errorMessage);
    }
}