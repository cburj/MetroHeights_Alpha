using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccountValueWidget : MonoBehaviour
{
    public Text valueText;
    // Start is called before the first frame update
    void Start()
    {
        valueText.text = "M$" + PlayerPrefs.GetInt("PREF_AccountValue");
    }
}
