// MARIANO CODUTTI ALARCON
using UnityEngine;
using TMPro;

public class MoneyUI : MonoBehaviour
{
    [SerializeField] private TMP_Text moneyText;


    private void Update()
    {
        moneyText.text = "$" + PlayerStats.money;
    }
}
