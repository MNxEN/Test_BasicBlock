// Задача: Написать программу, которая из имеющегося массива строк 
// формирует новый массив из строк, длина которых меньше, 
// либо равна 3 символам. Первоначальный массив можно ввести с 
// клавиатуры, либо задать на старте выполнения алгоритма. 
// При решении не рекомендуется пользоваться коллекциями, 
// лучше обойтись исключительно массивами.

int PromptInt(string message)                  //Функция проверки на целое число больше 2
{
    System.Console.Write($"{message} > ");
    string inputedStr = Console.ReadLine();
    int value;
    if (int.TryParse(inputedStr, out value) && value > 1)
    {
        return value;
    }
    System.Console.WriteLine($"Извините, но '{inputedStr}' не является целым числом, либо менее 2");
    Environment.Exit(0);
    return 0;
}

string PromptStr(string message)             //Функция для ввода строковых значений в первичный массив
{
    System.Console.Write($"{message} > ");
    string inputedStr = Console.ReadLine();
    return inputedStr;
}

string[] GeneratePrimaryArray(int lenArray)   //Создание первичного строкового массива заданной длины
{
    string[] array = new string[lenArray];    //Создание строкового массива
    for (int i = 0; i < lenArray; i++)        //Заполняем массив
    {
        array[i] = PromptStr($"Введите значение {i+1} элемента массива");
    }
    return array;                              //Возвращаем значение функции  
}

string[] GenerateSecondaryArray(string[] array)     //Создание вторичного строкового массива из элементов первичного массива, длина которых < 4
{
    string[] arraySec = new string[0];              //Создание пустого строкового массива    
    foreach (string item in array)                  //Перебираем элементы первичного массива 
    {
        if (item.Length < 4)                        //Проверяем условие
        {
            Array.Resize(ref arraySec, arraySec.Length + 1);  //Увеличиваем длину массива
            arraySec[arraySec.Length - 1] = item;             //Добавляем элемент в массива
        }
    }
    return arraySec;                                     //Возвращаем значение функции     
}

void PrintArray(string[] array, string message)          //Вывод элементов массива на экран
{
    System.Console.WriteLine($"{message} массив:");
    foreach (string item in array)
    {
        System.Console.Write(item + "\t");               //Выводим поочередно элементы массива на экран 
    }
    System.Console.WriteLine();
}

int lenArray = PromptInt("Введите количество элементов массива");
string[] array = GeneratePrimaryArray(lenArray);
PrintArray(array,"Первичный");

string[] arraySec = GenerateSecondaryArray(array);
if (arraySec.Length > 0)
{
    PrintArray(arraySec,"Вторичный");
}
else
{
    System.Console.WriteLine("В первичном массиве отсутствуют элементы, длина которых меньше, либо равна 3 символам");
}