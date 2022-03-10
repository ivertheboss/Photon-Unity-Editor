using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;

public class Username : MonoBehaviourPun
{
    public InputField nameInput2;
    public GameObject nameInput;
    public string name;
    public Text nameText;
    public TextMeshProUGUI my_text;
    public PhotonView view;

    void Update()
    {
        //view.Owner.NickName = name;
        //my_text = GameObject.Find("nametext").GetComponent<TextMeshProUGUI>();
        nameInput2 = GameObject.Find("Name").GetComponent<InputField>();
        view.Owner.NickName = nameInput2.text;
        name = view.Owner.NickName;
        nameText.text = view.Owner.NickName; 
        //my_text.text = view.Owner.NickName;
        if (view.IsMine)
        { 
        }
        else
        {
            nameText.text = view.Owner.NickName;
        }
    }
}
