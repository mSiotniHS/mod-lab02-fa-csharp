using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fans
{
  public class State
  {
    public string Name;
    public Dictionary<char, State> Transitions;
    public bool IsAcceptState;
  }


  public sealed class FA1
  {
    public static State Initial = new State
    {
      Name = nameof(Initial),
      IsAcceptState = false,
      Transitions = new Dictionary<char, State>()
    };

    public static State HaveOne = new State
    {
      Name = nameof(HaveOne),
      IsAcceptState = false,
      Transitions = new Dictionary<char, State>()
    };

    public static State HaveZero = new State
    {
      Name = nameof(HaveZero),
      IsAcceptState = false,
      Transitions = new Dictionary<char, State>()
    };

    public static State HaveZeroAndOnes = new State
    {
      Name = nameof(HaveZeroAndOnes),
      IsAcceptState = true,
      Transitions = new Dictionary<char, State>()
    };

    public static State TooManyZeros = new State
    {
      Name = nameof(TooManyZeros),
      IsAcceptState = false,
      Transitions = new Dictionary<char, State>()
    };

    public FA1()
    {
      Initial.Transitions['0'] = HaveZero;
      Initial.Transitions['1'] = HaveOne;

      HaveOne.Transitions['0'] = HaveZeroAndOnes;
      HaveOne.Transitions['1'] = HaveOne;

      HaveZero.Transitions['0'] = TooManyZeros;
      HaveZero.Transitions['1'] = HaveZeroAndOnes;

      HaveZeroAndOnes.Transitions['0'] = TooManyZeros;
      HaveZeroAndOnes.Transitions['1'] = HaveZeroAndOnes;

      TooManyZeros.Transitions['0'] = TooManyZeros;
      TooManyZeros.Transitions['1'] = TooManyZeros;
    }

    public bool? Run(IEnumerable<char> s)
    {
      var current = Initial;

      foreach (var character in s)
      {
        current = current.Transitions[character];
        if (current == null) return null;
      }

      return current.IsAcceptState;
    }
  }

  public sealed class FA2
  {
    public static State EvenZerosAndEvenOnes = new State
    {
      Name = nameof(EvenZerosAndEvenOnes),
      IsAcceptState = false,
      Transitions = new Dictionary<char, State>()
    };

    public static State EvenZerosAndOddOnes = new State
    {
      Name = nameof(EvenZerosAndOddOnes),
      IsAcceptState = false,
      Transitions = new Dictionary<char, State>()
    };

    public static State OddZerosAndEvenOnes = new State
    {
      Name = nameof(OddZerosAndEvenOnes),
      IsAcceptState = false,
      Transitions = new Dictionary<char, State>()
    };

    public static State OddZerosAndOddOnes = new State
    {
      Name = nameof(OddZerosAndOddOnes),
      IsAcceptState = true,
      Transitions = new Dictionary<char, State>()
    };

    public FA2()
    {
      EvenZerosAndEvenOnes.Transitions['0'] = OddZerosAndEvenOnes;
      EvenZerosAndEvenOnes.Transitions['1'] = EvenZerosAndOddOnes;

      OddZerosAndEvenOnes.Transitions['0'] = EvenZerosAndEvenOnes;
      OddZerosAndEvenOnes.Transitions['1'] = OddZerosAndOddOnes;

      EvenZerosAndOddOnes.Transitions['0'] = OddZerosAndOddOnes;
      EvenZerosAndOddOnes.Transitions['1'] = EvenZerosAndEvenOnes;

      OddZerosAndOddOnes.Transitions['0'] = EvenZerosAndOddOnes;
      OddZerosAndOddOnes.Transitions['1'] = OddZerosAndEvenOnes;
    }

    public bool? Run(IEnumerable<char> s)
    {
      var current = EvenZerosAndEvenOnes;

      foreach (var character in s)
      {
        current = current.Transitions[character];
        if (current == null) return null;
      }

      return current.IsAcceptState;
    }
  }

  public sealed class FA3
  {
    public static State NoCombination = new State
    {
      Name = nameof(NoCombination),
      IsAcceptState = false,
      Transitions = new Dictionary<char, State>()
    };

    public static State HaveFirstOne = new State
    {
      Name = nameof(HaveFirstOne),
      IsAcceptState = false,
      Transitions = new Dictionary<char, State>()
    };

    public static State HaveCombination = new State
    {
      Name = nameof(HaveCombination),
      IsAcceptState = true,
      Transitions = new Dictionary<char, State>()
    };

    public FA3()
    {
      NoCombination.Transitions['0'] = NoCombination;
      NoCombination.Transitions['1'] = HaveFirstOne;

      HaveFirstOne.Transitions['0'] = NoCombination;
      HaveFirstOne.Transitions['1'] = HaveCombination;

      HaveCombination.Transitions['0'] = HaveCombination;
      HaveCombination.Transitions['1'] = HaveCombination;
    }

    public bool? Run(IEnumerable<char> s)
    {
      var current = NoCombination;

      foreach (var character in s)
      {
        current = current.Transitions[character];
        if (current == null) return null;
      }

      return current.IsAcceptState;
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      String s = "01111";
      FA1 fa1 = new FA1();
      bool? result1 = fa1.Run(s);
      Console.WriteLine(result1);
      FA2 fa2 = new FA2();
      bool? result2 = fa2.Run(s);
      Console.WriteLine(result2);
      FA3 fa3 = new FA3();
      bool? result3 = fa3.Run(s);
      Console.WriteLine(result3);
    }
  }
}
