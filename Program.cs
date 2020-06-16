using System;

namespace Calculator
{
	class Calculator
	{
		public static double DoOperation(double num1, double num2, string op)
		{
			double result = double.NaN; // Значением по умолчанию является «не число», которое мы используем, если такая операция, как деление, может привести к ошибке.

			// Используем оператор switch для вичислений.
			switch (op)
			{
				case "s":
					result = num1 + num2;
					break;
				case "v":
					result = num1 - num2;
					break;
				case "u":
					result = num1 * num2;
					break;
				case "d":
					// Запрос пользователя ввести ненулевой делитель.
					if (num2 != 0)
					{
						result = num1 / num2;
					}
					break;
				// Вернуть текст для неправильной записи опции.
				default:
					break;
			}
			return result;
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			bool endApp = false;
			// Показать заголовок как консольный калькулятор C#.
			Console.WriteLine("Консольный калькулятор в C#\r");
			Console.WriteLine("------------------------\n");

			while (!endApp)
			{
				// Объявляем переменные и оставляем их пустыми.
				string numInput1 = "";
				string numInput2 = "";
				double result = 0;

				// Запрос пользователю ввести первое число.
				Console.Write("Введите число и нажмите клавишу Enter: ");
				numInput1 = Console.ReadLine();

				double cleanNum1 = 0;
				while (!double.TryParse(numInput1, out cleanNum1))
				{
					Console.Write("Это неверный ввод. Пожалуйста, введите целочисленное значение: ");
					numInput1 = Console.ReadLine();
				}

				// Запрос пользователю ввести второе число.
				Console.Write("Введите ещё одно число и нажмите клавишу Enter: ");
				numInput2 = Console.ReadLine();

				double cleanNum2 = 0;
				while (!double.TryParse(numInput2, out cleanNum2))
				{
					Console.Write("Это неверный ввод. Пожалуйста, введите целочисленное значение:");
					numInput2 = Console.ReadLine();
				}

				// Запрос пользователю выбрать оператора.
				Console.WriteLine("Выберите оператора из следующего списка:");
				Console.WriteLine("\ts - Сложение");
				Console.WriteLine("\tv - Вычитание");
				Console.WriteLine("\tu - Умножение");
				Console.WriteLine("\td - Деление");
				Console.Write("Ваш вариант? ");

				string op = Console.ReadLine();

				try
				{
					result = Calculator.DoOperation(cleanNum1, cleanNum2, op);
					if (double.IsNaN(result))
					{
						Console.WriteLine("Эта операция приведёт к математической ошибке.\n");
					}
					else Console.WriteLine("Ваш результат: {0:0.##}\n", result);
				}
				catch (Exception e)
				{
					Console.WriteLine("О нет! Произошло исключение при попытке произвести вычисления.\n - Подробности: " + e.Message);
				}

				Console.WriteLine("------------------------\n");

				// Подождать, пока пользователь ответит, прежде чем закрывать.
				Console.Write("Нажмите «n» и «Enter», чтобы закрыть приложение, или нажмите любую другую клавишу и «Enter», чтобы продолжить.: ");
				if (Console.ReadLine() == "n") endApp = true;

				Console.WriteLine("\n");
			}
			return;
		}
	}
}