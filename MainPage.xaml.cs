﻿using System.Collections.ObjectModel;

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

        private void ButtonAddToTable_Clicked(object sender, EventArgs e)
        {
            if (!int.TryParse(EntryInput.Text, out int input))
            {
                //событие на случай ошибки, то есть запарсить не удалось
            }

            int hash = GetHash(input);

            if (!HashTable.TryAdd(hash, input.ToString()))
            { 
                /*
                 TryAdd возвращает логическое значение поэтому можно проверить добавлять или нет
                Например, если уже есть значение, то повторное хеширование
                Или вообще это можно добавить в while
                 */
            }
        }
    }

}
