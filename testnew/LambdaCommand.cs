using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentCard
{
    public class LambdaCommand : ICommand
    {
        delegate bool CanExecutedelegate(object CanExec);
        delegate void Executedelegate(object Exec);

        CanExecutedelegate _canExecuteDelegate;
        Executedelegate _executeDelegate;


        public LambdaCommand(Func<object, bool> canExec, Action<object> exec)
        {

            _canExecuteDelegate = new CanExecutedelegate(canExec);
            _executeDelegate = new Executedelegate(exec);
        }


        public bool CanExecute(object canExec)
        {
            return _canExecuteDelegate(canExec);
        }
        public void Execute(object exec)
        {
            _executeDelegate(exec);
        }
        public void CanExeсChanged()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged.Invoke(this, new EventArgs());
        }
        public event EventHandler CanExecuteChanged;
    }
}
