using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUi : MonoBehaviour
{

    public Text playerId;
    // Start is called before the first frame update
    void Start()
    {
        string loggedInUserId = PlayerPrefs.GetString("LoggedInUserId", "No user ID found");
        playerId.text = "player : "+loggedInUserId;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
