using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    public TMP_Text remainingText;
    int maxSelections = 3;
    public int currentSelections = 0;
    public void NextBoss()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    void UpdateRemainingText()
    {
        int remaining = maxSelections - currentSelections;
        remainingText.text = $"({remaining} cards remaining)";
    }

    public void CardSelected(Card card)
    {
        if (currentSelections >= maxSelections)
        {
            return;
        }

        currentSelections++;

        Debug.Log("Card selected");

        UpdateRemainingText();
    }

    // public void AddToDeck()
    // {
        
    // }

    void Start()
    {
        UpdateRemainingText();
    }
}
