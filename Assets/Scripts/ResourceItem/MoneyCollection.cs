using UnityEngine;

namespace Resource.Money
{
    public class MoneyCollection
    {
        public int money;

        public int GetMoney() => money;

        public void AddMoney(int value)
        {
            money += value;
        }

        public void SubMoney(int value)
        {
            money = Mathf.Max(0, money - value);
        }

        public void SetMoney(int value)
        {
            money = value;
        }
    }
}