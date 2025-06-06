﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NewCarWPFApp.Core
{
    
        public class RelayCommand : ICommand
        {
            public event EventHandler? CanExecuteChanged;

            private Action<object> _Execute { get; set; }
            private Predicate<object> _CanExecute { get; set; }


            public RelayCommand(Action<object> ExecuteMethod, Predicate<object> CanExecuteMethod)
            {

                _Execute = ExecuteMethod;
                _CanExecute = CanExecuteMethod;

            }

            public bool CanExecute(object? parameter)
            {
                return _CanExecute(parameter);
            }

            public void Execute(object? parameter)
            {
                _Execute(parameter);
            }
        }
    }


        /*private Action<object> _execute;
        private Func<object, bool> _canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }*/
    
