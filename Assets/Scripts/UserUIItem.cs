using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UserUIItem : MonoBehaviour
{
    public UserDetails userDetails;
    public RandomUserFetcher randomUserFetcher;

    public GameObject prefab;
    public GameObject panel;

    internal List<RawImage> picture = new List<RawImage>();
    internal List<TextMeshProUGUI> userName = new List<TextMeshProUGUI>();

    public void CreateItems(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject item = Instantiate(prefab, panel.transform);

            RawImage image = item.GetComponentInChildren<RawImage>();
            if (image != null)
            {
                picture.Add(image);
            }

            TextMeshProUGUI text = item.GetComponentInChildren<TextMeshProUGUI>();
            if (text != null)
            {
                userName.Add(text);
            }

            Button btn = item.GetComponentInChildren<Button>();
            if(btn != null)
            {
                User user = randomUserFetcher.userList[i];
                userDetails.userbuttons.Add(btn);
                btn.onClick.AddListener(() => userDetails.ShowUserDetails(user));
            }

        }
    }
}
