using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UserDetails : MonoBehaviour
{
    public UserUIItem userUIItem;

    public GameObject dataUI;
    public RawImage imageUI;
    public TextMeshProUGUI fullInfo;

    internal List<Button> userbuttons = new List<Button>();

    private void EnableUI()
    {
        dataUI.SetActive(true);
    }

    internal void ShowUserDetails(User user)
    {
        EnableUI();
        int index = userbuttons.IndexOf(EventSystem.current.currentSelectedGameObject.GetComponent<Button>());
        imageUI.texture = userUIItem.picture[index].texture;

        fullInfo.text = "Name: " + user.name.first + " " + user.name.last + "\n"
            + "Gender: " + user.gender + "\n"
            + "Email: " + user.email + "\n"
            + "Age: " + user.dob.age + "\n"
            + "City: " + user.location.city + "\n";
    }
}
