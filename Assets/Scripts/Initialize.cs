using UnityEngine;

public class Initialize : MonoBehaviour
{
    [SerializeField] private int startMoney;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerService.MoneyService.SetMoney(startMoney);
    }
}
