using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthUI : MonoBehaviour
{

    public TMP_Text textHP;
    public PlayerStat playerStat;

    private void Update()
    {

        textHP.text = playerStat.currentHP.ToString();
    }


}
