using UnityEngine;
using TMPro;

public class UI_Updater : MonoBehaviour
{
    [SerializeField] GameObject UI;
    [SerializeField] TextMeshProUGUI moneyTMP;

    public void updateMoney(float money)
    {
        moneyTMP.text = "Money \n " + money.ToString("0") + " $";
    }
}
