using UnityEngine;

namespace Resource.Money
{
    public class MoneyService
    {
        private static MoneyCollection _moneyCollection;

        public MoneyService()
        {
            if (_moneyCollection == null)
            {
                _moneyCollection = new MoneyCollection();
            }
        }

        public void AddMoney(int value)
        {
            _moneyCollection.AddMoney(value);
        }

        public void SubMoney(int value)
        {
            _moneyCollection.SubMoney(value);
        }

        public void SetMoney(int value)
        {
            _moneyCollection.SetMoney(value);
        }
    }

}