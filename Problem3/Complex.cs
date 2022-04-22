namespace Problem3;

internal class Complex
{
    double Re;
    double Im;
    public double Modulus => Math.Sqrt(Re * Re + Im * Im);
    public static Complex operator +(Complex comp1, Complex comp2)
    {
        return new Complex() { Im = comp1.Im + comp2.Im,
            Re = comp1.Re + comp2.Re };
    }
    public static Complex operator -(Complex comp1, Complex comp2)
    {
        return new Complex()
        {
            Im = comp1.Im - comp2.Im,
            Re = comp1.Re - comp2.Re
        };
    }
    public static Complex operator *(Complex comp1, Complex comp2)
    {
        Complex result = new Complex();
        result.Re = comp1.Re * comp2.Re - comp1.Im * comp2.Im;
        result.Im = comp1.Im * comp2.Re + comp1.Re * comp2.Im;
        return result;
    }
    public static Complex operator /(Complex comp1, Complex comp2)
    {
        //(1 + i) / (2 - i) = (1 + i) * (2 + i) / 4 + 1
        Complex result = new Complex();
        result = comp1 * new Complex() { Re = comp2.Re, Im = -comp2.Im };
        double divider = comp2.Re * comp2.Re - comp1.Im * comp1.Im;
        result.Im = result.Im / divider;
        result.Re = result.Re / divider;
        return result;
    }
    public static bool operator ==(Complex comp1, Complex comp2)
    {
        return comp1.Re == comp2.Re && comp1.Im == comp2.Im;
    }
    public static bool operator !=(Complex comp1, Complex comp2)
    {
        return !(comp1 == comp2);
    }
    public static bool operator >(Complex comp1, Complex comp2)
    {
        return comp1.Modulus > comp2.Modulus;
    }
    public static bool operator <(Complex comp1, Complex comp2)
    {
        return comp1.Modulus < comp2.Modulus;
    }

}
