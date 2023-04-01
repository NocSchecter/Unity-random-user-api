using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class UserDetails : MonoBehaviour
{
    internal List<Button> btnDetails = new List<Button>();
    public GameObject detailsUI;

    public RawImage picture;
    public TextMeshProUGUI userInfo;

    private void Start()
    {
        detailsUI.SetActive(false);
    }

    public void UpdateUserInfo(List<RawImage> pic,  User user)
    {
         detailsUI.SetActive(true);
        int index = btnDetails.IndexOf(EventSystem.current.currentSelectedGameObject.GetComponent<Button>());

        picture.texture = pic[index].texture;

        userInfo.text = "Name: " + user.name.first + " " + user.name.last + "\n"
        + "Gender: " + user.gender + "\n"
        + "Email: " + user.email + "\n"
        + "Age: " + user.dob.age + "\n"
        + "City: " + user.location.city + "\n";
    }
}
