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

  public class FA2
  {
    public bool? Run(IEnumerable<char> s)
    {
      return false;
    }
  }
  
  public class FA3
  {
    public bool? Run(IEnumerable<char> s)
    {
      return false;
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