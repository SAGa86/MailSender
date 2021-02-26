﻿using MailSender.lib.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Commands
{
    public class LambdaCommand : Command
    {
        private readonly Action<object> _Execute;
        private Func<object, bool> _CanExecute;
        public LambdaCommand(Action<object> Execute, Func<object, bool> CanExecute = null)
        {
            _Execute = Execute;
            _CanExecute = CanExecute;
        }
        public override bool CanExecute(object parameter) => _CanExecute?.Invoke(parameter)??true;

        public override void Execute(object parameter) 
        { 
            if (CanExecute(parameter))    
            _Execute(parameter); 
        }
    }
}
