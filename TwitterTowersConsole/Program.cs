using System;

namespace TwitterTowersConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Manager();
        }
        public static void Manager()
        {
            Console.WriteLine("\nPlease choose one of these options: \n " +
                    "1: Rectangle tower. \n " +
                    "2: Triangle tower. \n" +
                    " 3: Exit.\n");

            int UserChoise = int.Parse(Console.ReadLine());

            switch (UserChoise)
            {

                case 1:
                    int towerHeight1 = GetTowerParam("Height");
                    int towerWidth1 = GetTowerParam("Width");

                    try
                    {
                        if (Math.Abs(towerHeight1 - towerWidth1) >= 5 | towerWidth1 == towerHeight1)
                        {
                            int rectangleArea = towerHeight1 * towerHeight1;
                            Console.WriteLine($"\nThis tower is a Rectangle. \nThe area of the tower is: {rectangleArea}.");
                        }
                        else 
                        {
                            int rectanglePerimeter = (towerHeight1 * 2) + (towerHeight1 * 2);
                            Console.WriteLine($"\nThe perimeter of the tower is: {rectanglePerimeter}.");
                        }
                    }
                    catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                    Manager();
                    break;
                case 2:
                    int towerHeight2 = GetTowerParam("Height");
                    int towerWidth2 = GetTowerParam("Width");

                    Console.WriteLine("\nPlease choose one of these options: \n " +
                    "1: Calculate the perimeter of the triangle. \n " +
                    "2: Print the triangle. \n");

                    int SecondUserChoise = int.Parse(Console.ReadLine());

                    try
                    {
                        if (SecondUserChoise == 1)
                        {
                            int perimeter = CalculatePerimeterTriangle(towerHeight2, towerWidth2);
                            Console.WriteLine($"The triangle perimeter is: {perimeter}"); 
                        }
                        else if (SecondUserChoise == 2)
                        {
                            if (towerWidth2 % 2 == 0 | towerWidth2 > (towerHeight2 * 2))
                            {
                                Console.WriteLine("The triangle can not be printed.");
                            }
                            else if (towerWidth2 % 2 != 0 | towerWidth2 < (towerHeight2 * 2))
                            {
                                PrintTriangle(towerHeight2, towerWidth2);
                            }
                        }
                        break;
                    }
                    catch (Exception ex) { Console.WriteLine(ex.ToString()); }

                    Manager();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
            }
        }
        public static void PrintTriangle(int TowerHeight, int TowerWidht)
        {
            int InnerHeight = TowerHeight - 2;
            int NumOfOdds = (TowerWidht / 2) - 1;
            int NumOfRows = InnerHeight / NumOfOdds;
            int Rest = InnerHeight % NumOfOdds;
            int conter = TowerWidht / 2;

            for (int r = 0; r < TowerWidht / 2; r++)
            {
                Console.Write(" ");
            }
            Console.WriteLine("*");

            for (int i = 3; i < TowerWidht; i += 2)
            {
                int RowsToPrint = NumOfRows;
                if (i == 3)
                {
                    RowsToPrint += Rest;
                }
                conter--;
                for (int k = 0; k < RowsToPrint; k++)
                {
                    for (int s = conter; s > 0; s--)
                    {
                        Console.Write(" ");
                    }
                    for (int j = 0; j < i; j++)
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine();
                }
            }
            for (int i = 0; i < TowerWidht; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
            Console.WriteLine();

            Manager();
        }

        public static int GetTowerParam(string parameter)
        {
            Console.Write($"Enter the {parameter} of the tower: ");
            int towerHeight = int.Parse(Console.ReadLine());
            return towerHeight;
        }

        public static int CalculatePerimeterTriangle(int TowerHeight, int TowerWidht)
        {
            // Calculate the length of the equal sides
            double equalSideLength = Math.Sqrt(Math.Pow(TowerHeight, 2) + Math.Pow(TowerWidht / 2, 2));

            // Calculate the perimeter
            int perimeter = (int)(2 * equalSideLength + TowerWidht);

            return perimeter;
        }
    }
}



