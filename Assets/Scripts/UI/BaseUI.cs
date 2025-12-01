// MARIANO CODUTTI ALARCON
using UnityEngine;
using UnityEngine.UI;

public class BaseUI : MonoBehaviour
{
    [SerializeField] private Image healthBar;

    [SerializeField] private PlayerStats playerStats;
    private float maxHealth;

    [SerializeField] private Color goodHealthColor;
    [SerializeField] private Color mediumHealthColor;
    [SerializeField] private Color criticalHealthColor;


    private void Start()
    {
        maxHealth = playerStats.GetStartHealth();
        healthBar.color = goodHealthColor;
    }


    public void UpdateHealthBar()
    {
        healthBar.fillAmount = PlayerStats.playerHealth / maxHealth;

        if (healthBar.fillAmount > .50f)
        {
            healthBar.color = goodHealthColor;
        }
        else if (healthBar.fillAmount <= .50f && healthBar.fillAmount > .25f)
        {
            healthBar.color = mediumHealthColor;
        }
        else if (healthBar.fillAmount <= .25f)
        {
            healthBar.color = criticalHealthColor;
        }
    }
}
