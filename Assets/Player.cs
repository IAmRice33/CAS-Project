using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
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
        SceneManager.LoadScene("GameOver");
    }
}
