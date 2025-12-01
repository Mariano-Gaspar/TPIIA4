// MARIANO CODUTTI ALARCON
using UnityEngine;
using TMPro;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private TMP_Text healthText;


    private void Update()
    {
        healthText.text = PlayerStats.playerHealth.ToString();
    }
}
