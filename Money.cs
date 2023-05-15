using System;

public class Money
{
    static readonly string DOLLAR = "DOLLAR";
    static readonly string CENT = "CENT";
    static readonly string NUNDRED = "hundred";
    static readonly string THOUSAND = "thousand";
    static readonly string MILLION = "million";
    static readonly string BILLION = "billion";
    static readonly int MINVALUE = 0;
    static readonly int MAXVALUE = 2000000000;
    private readonly double money = MINVALUE;
    private string result = string.Empty;
    public Money(double moneyNumeric)
    {
        money = moneyNumeric;
    }


    public override string ToString()
    {
        if (money == MINVALUE || money > MAXVALUE)
        {
            throw new Exception("Money can not be printed.\nPlease, type money value more then 0 and less then 2000000000 (like 1357256.32)");
        }

        var moneyStrParts = money.ToString().Split(".");

        var dollarWritting = DOLLAR;
        if (moneyStrParts.First() != "1")
        {
            dollarWritting = $"{dollarWritting}S";
        }

        var dollarsResult = $"{PrintBigNumber(int.Parse(moneyStrParts.First()))} {dollarWritting}";

        var centsResult = $"NULL {CENT}S";
        if (moneyStrParts.Length != 1 && moneyStrParts.Last() != "00" && moneyStrParts.Last() != "0")
        {
            var centsWriting = CENT;

            if (moneyStrParts[1] != "01")
            {
                centsWriting = $"{centsWriting}S";
            }

            centsResult = $"{PrintBigNumber(int.Parse(moneyStrParts.Last()))} {centsWriting}";
        }

        return $"{dollarsResult} AND {centsResult}";
    }


    private string PrintBigNumber(double number)
    {
        if (number >= 1e9)
        {
            var o = number % 1e9;
            var t = (number - o) / 1e9;

            return PrintMoneyTranscriptionPart(o, t, BILLION);
        }
        else if (number >= 1e6)
        {
            var o = number % 1e6;
            var t = (number - o) / 1e6;

            return PrintMoneyTranscriptionPart(o, t, MILLION);
        }
        else if (number >= 1e3)
        {
            var o = number % 1e3;
            var t = (number - o) / 1e3;

            return PrintMoneyTranscriptionPart(o, t, THOUSAND);
        }
        else if (number >= 1e2)
        {
            var o = number % 1e2;
            var t = (number - o) / 1e2;

            return PrintMoneyTranscriptionPart(o, t, NUNDRED);
        }

        return PrintDec(number);
    }

    private string PrintMoneyTranscriptionPart(double o, double t, string s)
    {
        var last = PrintBigNumber(o);
        var df = s == NUNDRED ? " AND": ",";
        return !string.IsNullOrEmpty(last) ? $"{PrintBigNumber(t)} {s}{df} {last}" : $"{PrintBigNumber(t)} {s}";
    }

    private string PrintTenths(double number)
    {
        switch (number)
        {
            case 2:
                return "twenty";
            case 3:
                return "thirty";
            case 4:
                return "fourty";
            case 5:
                return "fifty";
            case 6:
                return "sixty";
            case 7:
                return "seventy";
            case 8:
                return "eighty";
            case 9:
                return "ninety";
            default:
                return "";
        }
    }

    private string PrintDec(double number)
    {
        switch (number)
        {
            case 0:
                return "";
            case 1:
                return "one";
            case 2:
                return "two";
            case 3:
                return "three";
            case 4:
                return "four";
            case 5:
                return "five";
            case 6:
                return "six";
            case 7:
                return "seven";
            case 8:
                return "eight";
            case 9:
                return "nine";
            case 10:
                return "ten";
            case 11:
                return "eleven";
            case 12:
                return "twelve";
            case 13:
                return "thirteen";
            case 14:
                return "fourteen";
            case 15:
                return "fifteen";
            case 16:
                return "sixteen";
            case 17:
                return "seventeen";
            case 18:
                return "eighteen";
            case 19:
                return "nineteen";
            default:
                {
                    var o = number % 10;
                    var t = (number - o) / 10;

                    return $"{PrintTenths(t)} {PrintDec(o)}";
                }
        }
    }
}