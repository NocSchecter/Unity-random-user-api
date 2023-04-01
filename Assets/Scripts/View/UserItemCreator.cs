using TMPro;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserItemCreator : MonoBehaviour, IUserItemCreator
{
    public UserDetails userDetails;
    public RandomUserDataLoader randomUserDataLoader;

    public GameObject prefab;
    public GameObject panel;
    public List<RawImage> picture { get; private set; } = new List<RawImage>();

    public void CreateItems(int index, List<User> user)
    {
        for (int i = 0; i < index; i++)
        {
            GameObject item = Instantiate(prefab, panel.transform);

            RawImage image = item.GetComponentInChildren<RawImage>();
            if (image != null)
                picture.Add(image);

            TextMeshProUGUI text = item.GetComponentInChildren<TextMeshProUGUI>();
            if (text != null)
                text.text = user[i].name.first;

            Button button = item.GetComponentInChildren<Button>();
            if (button != null)
            {
                User usr = randomUserDataLoader.userList[i];
                userDetails.btnDetails.Add(button);
                button.onClick.AddListener(() => userDetails.UpdateUserInfo(picture, usr));
            }
        }
    }
}
