namespace Problem4;

internal class Account<TBank>
{
    public static TBank bank;
    public Account(TBank _bank = default)
    {
        bank = _bank;
    }
}
