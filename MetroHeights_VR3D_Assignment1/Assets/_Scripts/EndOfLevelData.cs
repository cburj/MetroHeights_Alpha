using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndOfLevelData : MonoBehaviour
{
    public Text FundsReceived;
    public Text AccountValue;

    public int FundsInt;
    public int AccountInt;

    // Start is called before the first frame update
    void Start()
    {
        FundsInt = PlayerPrefs.GetInt("PREF_LastFunds");
        AccountInt = PlayerPrefs.GetInt("PREF_AccountValue");

        FundsReceived.text = "M$" + FundsInt;
        AccountValue.text = "M$" + AccountInt;
    }
}
