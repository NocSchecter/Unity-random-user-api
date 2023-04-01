using System.Collections.Generic;
using UnityEngine.UI;

public interface IUserItemCreator
{
    List<RawImage> picture { get;  }
    void CreateItems(int index, List<User> user);
}
