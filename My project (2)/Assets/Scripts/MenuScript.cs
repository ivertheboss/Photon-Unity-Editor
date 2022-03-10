using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public GameObject joinpanel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            this.transform.localScale = new Vector3(1.03f, 1.03f, 1);
        }
    }

    public void CloseMenu()
    {
        this.transform.localScale = new Vector3(0, 0, 0);//dwddwwdwdwd
    }

    public void JoinGame()
    {
        joinpanel.transform.localScale = new Vector3(0, 0, 0);
    }
}
