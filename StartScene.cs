using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : MonoBehaviour
{
    public void ChangeScene(string scenename)
    {
        Application.LoadLevel(scenename);
    }
}
