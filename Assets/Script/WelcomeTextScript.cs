using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WelcomeTextScript : MonoBehaviour
{
    public string Playername;
    public Text WelcomeText;
    // Start is called before the first frame update
    void Start()
    {
        SetPlayerName(Playername);
    }

    public void SetPlayerName(string Name)
    {
        WelcomeText.text = "Welcome, " + Name;
    }
}
