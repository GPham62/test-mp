using Resource.Money;
using UnityEngine;

public static class PlayerService
{
   public static MoneyService _moneyService;
   
   public static MoneyService MoneyService
   {
      get
      {
         if (_moneyService != null)
            return _moneyService;

         _moneyService = new MoneyService();
         return _moneyService;
      }
   }
}
