using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IUserDataService
{
    IEnumerator DownloadUserData(Action<List<User>> onSuccess, Action<string> onFailure);
}
