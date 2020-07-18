using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;


namespace CommandTest
{
    public interface IDelegateCommand : ICommand
    {
        object Target { get; set; }
    }
    class DelegateCommand : IDelegateCommand
    {
        #region Constructors
        public DelegateCommand(Action executeMethod) : this(executeMethod,null,false) { }
        public DelegateCommand(Action executeMethod,Func<bool> canExecuteMethod) : this(executeMethod,canExecuteMethod,false) { }
        public DelegateCommand(Action executeMethod,Func<bool> canExecuteMethod, bool isAutomaticRequeryDisabled)
        {
            if (executeMethod == null) throw new ArgumentNullException("executeMethod");
            _executeMethod = executeMethod;
            _canExecuteMethod = canExecuteMethod;
            _isAutomaticRequeryDisabled = isAutomaticRequeryDisabled;
        }
        #endregion

        #region Public Methods
        public bool CanExecute()
        {
            if(_canExecuteMethod != null)
            {
                return _canExecuteMethod();
            }
            return true;
        }

        public void Execute()
        {
            if(_executeMethod != null)
            {
                _executeMethod();
            }
        }

        public object Target
        {
            get
            {
                if (_executeMethod == null) return null;
                return _executeMethod.Target;
            }
            set { }
        }

        public bool IsAutomaticRequeryDisabled
        {
            get
            {
                return _isAutomaticRequeryDisabled;
            }
            set
            {
                if(IsAutomaticRequeryDisabled != value)
                {
                    if(value)
                    {
                        CommandManagerHelper.RemoveHandlersFromRequerySuggested(_canExecuteChangedHandlers);
                    }
                    else
                    {
                        CommandManagerHelper.AddHandlersToRequerySuggested(_canExecuteChangedHandlers);
                    }
                    IsAutomaticRequeryDisabled = value;
                }
            }
        }
        /// <summary>
        /// Raise the CanExecutedChanged event
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            OnCanExecuteChanged();
        }
        protected virtual void OnCanExecuteChanged()
        {
            CommandManagerHelper.CallWeakReferenceHandler(_canExecuteChangedHandlers);
        }

        #endregion
        public event EventHandler CanExecuteChanged
        {
            add
            {
                if(!IsAutomaticRequeryDisabled)
                {
                    CommandManager.RequerySuggested += value;
                }
                CommandManagerHelper.AddWeakReferenceHandler(ref _canExecuteChangedHandlers, value, 2);
            }
            remove
            {
                if(!IsAutomaticRequeryDisabled)
                {
                    CommandManager.RequerySuggested -= value;   
                }
                CommandManagerHelper.RemoveWeakReferenceHandler(_canExecuteChangedHandlers, value);
            }
        }
        public bool CanExecute(object parameter)
        {
            return CanExecute();
        }
        public void Execute(object parameter)
        {
            Execute();
        }

        #region Data
        private readonly Action _executeMethod = null;
        private readonly Func<bool> _canExecuteMethod = null;
        private bool _isAutomaticRequeryDisabled = false;
        private List<WeakReference> _canExecuteChangedHandlers;
        #endregion
    }

    internal class CommandManagerHelper
    {
        internal static void CallWeakReferenceHandler(List<WeakReference> handlers)
        {
            if(handlers != null)
            {
                int count = 0;
                int handersCount = handlers.Count;
                EventHandler[] callees = new EventHandler[handersCount];
                for(int i=handersCount-1;i>=0;i--)
                {
                    EventHandler eventHandler = handlers[i].Target as EventHandler;
                    if (eventHandler != null)
                    {
                        callees[count] = eventHandler;
                        ++count;
                    }
                    else
                    {
                        handlers.Remove(handlers[i]);
                    }
                }

                for(int i=0;i<count;i++)
                {
                    EventHandler eventHandler = callees[i];
                    eventHandler(null, EventArgs.Empty);
                }
            } 
        }

        internal static void AddHandlersToRequerySuggested(List<WeakReference> handlers)
        {
            if (handlers != null)
            {
                foreach (var handler in handlers)
                {
                    EventHandler eventHandler = handler.Target as EventHandler;
                    if (eventHandler != null)
                    {
                        CommandManager.RequerySuggested += eventHandler;
                    }
                }
            }
        }

        internal static void RemoveHandlersFromRequerySuggested(List<WeakReference> handlers)
        {
            if(handlers != null)
            {
                foreach(WeakReference weakReference in handlers)
                {
                    EventHandler eventHandler = weakReference.Target as EventHandler;
                    if(eventHandler != null)
                    {
                        CommandManager.RequerySuggested -= eventHandler;
                    }
                }
            }
        }

        internal static void AddWeakReferenceHandler(ref List<WeakReference> handlers, EventHandler eventHandler, int defaultListSize)
        {
            if (handlers == null)
            {
                handlers = defaultListSize > 0 ? new List<WeakReference>(defaultListSize) : new List<WeakReference>();
            }
            else
                handlers.Add(new WeakReference(eventHandler));
        }

        internal static void RemoveWeakReferenceHandler(List<WeakReference> handlers,EventHandler eventHandler)
        {
            if(handlers != null)
            {
                for(int i = handlers.Count - 1;i>=0;i--)
                {
                    if (handlers[i].Target == null)
                        handlers.Remove(handlers[i]);
                    else
                    {
                        if (handlers[i].Target as EventHandler == eventHandler)
                            handlers.Remove(handlers[i]);
                    }
                }
            }
        }

        internal static void AddWeakReferenceHandler(ref List<WeakReference> handlers,EventHandler handler)
        {
            AddWeakReferenceHandler(ref handlers, handler, -1);
        }


    }
}
