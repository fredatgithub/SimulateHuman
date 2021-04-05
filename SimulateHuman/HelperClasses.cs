using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace SimulateHuman
{
  public static class HelperClasses
  {
    public static int GenerateRndNumberUsingCrypto(int min, int max)
    {
      if (max > 255 || min < 0)
      {
        return 0;
      }

      if (max == min)
      {
        return min;
      }

      int result;
      var crypto = new RNGCryptoServiceProvider();
      byte[] randomNumber = new byte[1];
      do
      {
        crypto.GetBytes(randomNumber);
        result = randomNumber[0];
      } while (result < min || result > max);

      return result;
    }

    public static List<int> GenerateSeveralRandomNumbers(int min, int max, int numberOfNumbers)
    {
      var result = new List<int>();
      if (numberOfNumbers < 1)
      {
        return result;
      }

      int counter = 0;
      while (counter < numberOfNumbers)
      {
        int tmpNumber = GenerateRndNumberUsingCrypto(min, max);
        if (!result.Contains(tmpNumber))
        {
          result.Add(tmpNumber);
          counter++;
        }
      }

      return result;
    }

    public static DateTime GenerateRandomTime()
    {
      int numberOfSeconds = GenerateRndNumberUsingCrypto(1, 59);
      int numberOfMinutes = GenerateRndNumberUsingCrypto(0, 59);
      DateTime nextTime = new DateTime(1, 1, 1, 0, numberOfMinutes, numberOfSeconds);
      return nextTime;
    }
  }
}
