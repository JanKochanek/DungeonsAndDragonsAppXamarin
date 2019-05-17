using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using DungeonsAndDragonsApp.Model;

using Xamarin.Forms;

namespace DungeonsAndDragonsApp.ViewModel
{
    class MainViewModel : Abstract.ViewModel
    {
        public Command RollDiceCommand { get; set; }
        public int MaxNumberOfSides = 20;
        public int MaxNumberOfDice = 7;

        public ObservableCollection<SideOptions> NumberOfSidesOptions { get; }
        public ObservableCollection<int> NumberOfDiceOptions { get; }
        public MainViewModel()
        {
            RollDiceCommand = new Command(RollDice);
            NumberOfSidesOptions = new ObservableCollection<SideOptions>(Enumerable.Range(4, MaxNumberOfSides - 1)
                .Select(s => new SideOptions
                {
                    SideDisplayName = "D" + s,
                    NumberOfSides = s
                }));
            NumberOfDiceOptions = new ObservableCollection<int>(Enumerable.Range(1, MaxNumberOfDice));
            NumberOfSides = NumberOfSidesOptions.First();
            NumberOfDice = 1;
        }

        private SideOptions _numberOfSides;
        public SideOptions NumberOfSides
        {
            get { return _numberOfSides; }
            set
            {
                _numberOfSides = value;
                OnPropertyChanged("NumberOfSides");

                if (_numberOfDice != 0 && _numberOfSides.NumberOfSides != 0)
                {
                    ChangeDiceSides();
                }
            }
        }

        private int _numberOfDice;
        public int NumberOfDice
        {
            get { return _numberOfDice; }
            set
            {
                _numberOfDice = value;
                OnPropertyChanged("NumberOfDice");

                if (_numberOfDice > 0)
                {
                    ChangeDice();
                }
            }
        }
        public ObservableCollection<DiceViewModel> Dices { get; set; } = new ObservableCollection<DiceViewModel>();

        public void RollDice()
        {
            foreach (var dice in Dices)
            {
                dice.RollDice();
            }
        }
        private void ChangeDice()
        {
            Dices.Clear();
            for (int i = 0; i < NumberOfDice; i++)
            {
                var dice = new DiceViewModel
                {
                    NumberOfSides = NumberOfSides.NumberOfSides,
                };
                Dices.Add(dice);
            }
        }
        private void ChangeDiceSides()
        {
            foreach (var dice in Dices)
            {
                dice.NumberOfSides = NumberOfSides.NumberOfSides;
                dice.SideUp = 1;
            }
        }
    }
}