using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using TMPro;


public class EnergyLogic : MonoBehaviour
{
    public int energycount = 5;

    public TextMeshProUGUI energyText;

    void Update()
    {
        energyText.text = $"{(int)energycount}";
    }
}
