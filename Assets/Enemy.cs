using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public HealthBarUI healthBar;

    void Update()
    {
        if (healthBar.currentHP <= 0)
        {
            isDefeated();
        }
    }

    void isDefeated()
    {
        SceneManager.LoadScene("Win");
    }
}
