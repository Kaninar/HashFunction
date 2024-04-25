using System.Collections.ObjectModel;

namespace MauiApp3
{
    public partial class MainPage : ContentPage
    {
        ObservableDictionary<int, string> HashTable;
        int TableSize = 0;

        public MainPage()
        {
            InitializeComponent();
            HashTableList.ItemsSource = null;
            BindingContext = this;
        }

        private void ButtonCreateTable_Clicked(object sender, EventArgs e)
        {
                
            if (!int.TryParse(EntryTableSize.Text, out TableSize))
            {

            }

            HashTable = new ObservableDictionary<int, string>(TableSize, string.Empty);

            for (int i = 0; i < TableSize; i++)
            { 
                HashTable.Add(i, null);
            }

            HashTableList.ItemsSource = HashTable;
        }

        private int GetHash(int number)
        {
            return number % TableSize;
        }
        private int DubleHash(int number)
        { 
            return(DigitsSum(number) + 17)% TableSize;
        }
        private int DigitsSum(int number) 
        {
            int DigitsCount = (int)Math.Log10(number) + 1;
            int[] digits = new int[DigitsCount];
            int temp = number;
            for (int i = 0; i < DigitsCount; i++)
            {
                int digit = temp % 10;
                digits[i] = digit;
                temp = (temp - digit) / 10;
            }
            return digits.Sum();
        }

        private void ButtonAddToTable_Clicked(object sender, EventArgs e)
        {
            if (!int.TryParse(EntryInput.Text, out int input))
            {
                //событие на случай ошибки, то есть запарсить не удалось
            }
            
            int hash = GetHash(input);
            if(!HashTable.TryAdd(hash, input.ToString()))
            while (!HashTable.TryAdd(hash, input.ToString()))
            { 
                input = DubleHash(input);
            }
            /*if (!HashTable.TryAdd(hash, input.ToString()))
            { 
                *//*
                 TryAdd возвращает логическое значение поэтому можно проверить добавлять или нет
                Например, если уже есть значение, то повторное хеширование
                Или вообще это можно добавить в while
                 *//*
            }*/
        }
    }

}
