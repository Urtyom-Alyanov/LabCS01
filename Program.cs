using System;

namespace Lab01
{
  class Program
  {
    const int MAX_ABS_COEF = 10_000;

    // Метод для ввода и валидации коэффициентов
    static private int? GetAndValidateCoefficient(string? prompt)
    {
      try
      {
        if (prompt != null)
          Console.Write(prompt + ": ");
        int coef = int.Parse(Console.ReadLine());
        if (Math.Abs(coef) > MAX_ABS_COEF)
          throw new ArgumentOutOfRangeException();
        return coef; // Возвращаем валидный коэффициент
      }
      catch (FormatException)
      {
        Console.WriteLine("Ошибка. Введите целое число.");
      }
      catch (OverflowException)
      {
        Console.WriteLine($"Произошло переполнение. Введите целое число меньшее по модулю максимального числа {MAX_ABS_COEF}.");
      }
      catch (ArgumentOutOfRangeException)
      {
        Console.WriteLine($"Ошибка. Введите целое число меньшее по модулю максимального числа {MAX_ABS_COEF}.");
      }
      catch (Exception)
      {
        Console.WriteLine("Ошибка. Введите корректное целое число.");
      }
      Environment.Exit(0);
      return null;
      // return GetAndValidateCoefficient(prompt);
    }

    static private void LinearEquationSolution(int B, int C)
    {
      Console.WriteLine($"Уравнение является линейным. {B}x + {C} = 0");
      if (B == 0)
      {
        if (C == 0)
          Console.WriteLine("Уравнение имеет бесконечное множество решений: x ∈ R");
        else
          Console.WriteLine("Уравнение не имеет решений.");
        return;
      }

      double x = -C / (double)B;
      Console.WriteLine($"Уравнение имеет единственное решение: x = {x}");
      return;
    }

    static private void SquareEquationSolution(int A, int B, int C)
    {
      Console.WriteLine($"Уравнение является квадратным. {A}x² + {B}x + {C} = 0; A != 0");

      double D = B * B - 4 * A * C; // Дискриминант
      Console.WriteLine($"Дискриминант D = {D:F3}");
      if (D < 0)
      {
        Console.WriteLine("Уравнение не имеет действительных корней.");
        return;
      }
      else if (D == 0)
      {
        double x = -B / (2.0 * A); // Единственный корень
        Console.WriteLine($"Уравнение имеет единственное решение: x = {x:F3}");
        return;
      }
      else
      {
        double sqrtD = Math.Sqrt(D);
        double x1 = (-B + sqrtD) / (2.0 * A); // Первый корень (больший)
        double x2 = (-B - sqrtD) / (2.0 * A); // Второй корень (меньший)
        Console.WriteLine($"Уравнение имеет два решения: x1 = {x1:F3}, x2 = {x2:F3}");
        return;
      }
    }

    private static void Main(string[] args)
    {
      int? A, B, C;

      // Ввод и валидация коэффициентов
      Console.WriteLine("Введите коэффициенты A, B и C для уравнения Ax² + Bx + C = 0 по порядку:");
      A = GetAndValidateCoefficient("Введите A");
      B = GetAndValidateCoefficient("Введите B");
      C = GetAndValidateCoefficient("Введите C");

      if (A == null || B == null || C == null)
        return;

      // Если уравнение линейное, то решаем его, см. метод
      if (A == 0)
      {
        LinearEquationSolution((int)B, (int)C);
        return;
      }

      // Если уравнение квадратное, то решаем его, см. метод
      SquareEquationSolution((int)A, (int)B, (int)C);
    }
  }
}