using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Data.Common;

public class HealthBarUI : MonoBehaviour
{
    public Image fillImage;
    public float maxHP = 1000;
    public float currentHP = 1000;
    public TextMeshProUGUI hpText;

    public DOT_Logic dot;


    void Update()
    {
        fillImage.fillAmount = currentHP / maxHP;
        hpText.text = $"{(int)currentHP} / {(int)maxHP}";
    }

    public void TakeDamage(float dmg)
    {

        currentHP -= dmg;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        
    }
}