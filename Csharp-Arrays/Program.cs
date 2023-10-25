
using System.Linq;

int[] A = new int[5];
double[,] B = new double[3, 4];
Console.WriteLine("Enter values for A array : ");
Random random = new Random();
for(int i = 0; i < A.Length; i++)
{
    A[i] = int.Parse(Console.ReadLine());
}
setArrValues_Double(ref B);
printArr(ref A);
printArrD(ref B);
Console.WriteLine($"Max value is : {findMax(ref A, ref B)}");
Console.WriteLine($"Min value is : {findMin(ref A, ref B)}");
Console.WriteLine($"Sum of values is : {findSum(ref A, ref B)}");
Console.WriteLine($"Product of values : {findProduct(ref A, ref B)}");
Console.WriteLine($"Sum of values is : {findSum_Even_Odd(ref A, ref B)}\n\n\n");
int[,] arr = new int[5, 5];
setArrValues(ref arr, -100);
printArrI(ref arr);
Console.WriteLine($"Sum : {findSumMinMax(ref arr)}\n\n\n");
arrayAddition(ref arr, 20);
printArrI(ref arr);
arraySubstraction(ref arr, 10);
printArrI(ref arr);
arrayMultiplication(ref arr, 2);
printArrI(ref arr);
//По масивах наче все





void arrayMultiplication(ref int[,] arr, int number)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            arr[i, j] *= number;
        }

    }
}

void arraySubstraction(ref int[,] arr, int number)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            arr[i, j] -= number;
        }

    }
}

void arrayAddition(ref int[,] arr, int number)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            arr[i,j] += number;
        }
        
    }
}
int findSumMinMax(ref int[,] arr)
{
    int minElement = arr[0, 0];
    int maxElement = arr[0, 0];
    int minRow = 0, minCol = 0;
    int maxRow = 0, maxCol = 0;
    int sum = 0;
    for (int i = 0; i < 5; i++)
    {
        for (int j = 0; j < 5; j++)
        {
            if (arr[i, j] < minElement)
            {
                minElement = arr[i, j];
                minRow = i;
                minCol = j;
            }
            if (arr[i, j] > maxElement)
            {
                maxElement = arr[i, j];
                maxRow = i;
                maxCol = j;
            }
        }
    }
    int startRow, startCol, endRow, endCol;
    if(minRow < maxRow)
    {
        startRow = minRow;
        startCol = minCol;
        endRow = maxRow;
        endCol= maxCol;
    }
    else if(maxRow < minRow)
    {
        startRow = maxRow;
        startCol = maxCol;
        endRow = minRow;
        endCol = minCol;
    }
    else
    {
        startRow = minRow;
        startCol = minCol < maxCol ? minCol : maxCol;
        endRow = maxRow;
        endCol = startCol == minCol ? maxCol : minCol;
    }
    for(int i = startRow; i <= endRow; i++)
    {
        for(int j = startCol; j < arr.GetLength(1); j++)
        {
            if (i == endRow && j > endCol) return sum;
            sum += arr[i, j];
        }
    }
    return sum;
}

    double findSum_Even_Odd(ref int[] arr, ref double[,] arr1) 
{
    double sum = 0;
    for(int i = 0; i < arr.Length; i += 2)
    {
        sum += arr[i];
    }
    for (int i = 0; i < arr1.GetLength(0); i++)
    {
        for (int j = 1; j < arr1.GetLength(1); j += 2)
        {
            sum += arr1[i, j];
        }
    }
    return sum;
}

double findProduct(ref int[] arr, ref double[,] arr1)
{
    double product = 1;
    for (int i = 0; i < arr.Length; i++)
    {
        product *= arr[i];
    }
    for (int i = 0; i < arr1.GetLength(0); i++)
    {
        for (int j = 0; j < arr1.GetLength(1); j++)
        {
            product *= arr1[i, j];
        }
    }
    return product;
}

double findSum(ref int[] arr, ref double[,] arr1)
{
    double sum = 0;
    for (int i = 0; i < arr.Length; i++)
    {
        sum += arr[i];
    }
    for (int i = 0; i < arr1.GetLength(0); i++)
    {
        for (int j = 0; j < arr1.GetLength(1); j++)
        {
            sum += arr1[i, j];
        }
    }
    return sum;
}

double findMax(ref int[] arr, ref double[,] arr1)
{
    double max = arr.Max();
    max = max > arr1.Cast<double>().Max() ? max : arr1.Cast<double>().Max();
    return max;
}
double findMin(ref int[] arr, ref double[,] arr1)
{
    double min = arr.Min();
    min = min < arr1.Cast<double>().Min() ? min : arr1.Cast<double>().Min();
    return min;
}

void printArr(ref int[] arr)
{
    for(int i = 0;i < arr.Length; i++)
    {
        Console.Write(arr[i] + "  ");
    }Console.WriteLine('\n');
}

void printArrD(ref double[,] arr)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            Console.Write(arr[i, j] + "  ");
        }
        Console.WriteLine();
    }Console.WriteLine();
}

void printArrI(ref int[,] arr)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            Console.Write(arr[i, j] + "  ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

void setArrValues_Double(ref double[,] arr, int min = 1, int max = 100, int roundTo = 2)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            arr[i, j] = Math.Round(random.Next(min, max) + random.NextDouble(), roundTo);
        }
    }
}

void setArrValues(ref int[,] arr, int min = 1, int max = 100)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            arr[i, j] = random.Next(min, max);
        }
    }
}

