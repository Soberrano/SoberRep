using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace testnew
{
    public class LambdaCommand : ICommand
    {
        delegate bool CanExecutedelegate(object nekoeOpisanieCanExec);
        delegate void Executedelegate(object nekoeOpisanieExec);

        CanExecutedelegate _CanExecuteDelegate;
        Executedelegate _ExecuteDelegate;


        public LambdaCommand(Func<object, bool> konkretnoeOpisanieCanExec, Action<object> konkretnoeOpisanieExec)
        {

            _CanExecuteDelegate = new CanExecutedelegate(konkretnoeOpisanieCanExec);
            _ExecuteDelegate = new Executedelegate(konkretnoeOpisanieExec);
        }


        public bool CanExecute(object exemplarDelegata)
        {
            return _CanExecuteDelegate(exemplarDelegata);
        }
        public void Execute(object exemplarDelegata)
        {
            _ExecuteDelegate(exemplarDelegata);
        }
        public void CanExeсChanged()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged.Invoke(this, new EventArgs());
        }
        public event EventHandler CanExecuteChanged;
    }
}
