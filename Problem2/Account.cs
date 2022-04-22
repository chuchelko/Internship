namespace Problem2;

class Account
{
    public static decimal bonus = 100;
    public decimal totalSum;

    public Account(decimal sum)
    {
        totalSum = sum + bonus;
    }
}

/* 
 поле не объявлено статическим
 class Account
   {
       private decimal minSum = 100;
       public static decimal MinSum
       {
           get { return minSum; }
           set { if(value>0) minSum = value; }
       }
   } 
 */

/*
 в статическом классе могут быть только статические члены, но свойство в примере не статическое
 static class Account
   {
       private static decimal minSum = 100;

       public decimal MinSum
       {
           get { return minSum; }
           set { if(value>0) minSum = value; }
       }

       public static decimal GetSum(decimal sum, decimal rate, int period)
       {
           decimal result = sum;
           for (int i = 1; i <= period; i++)
               result = result + result * rate / 100;
           return result;
       }
   }
 */