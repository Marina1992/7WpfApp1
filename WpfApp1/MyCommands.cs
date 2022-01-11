using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp1
{
    class MyCommands
    {
        
        public static RoutedCommand Exit { get; set; }

        

        static MyCommands()

        {   

            InputGestureCollection inputs  = new InputGestureCollection();

            

            inputs.Add(   new KeyGesture(Key.T, ModifierKeys.Control, "Ctrl+T"  ));
            
            
            Exit = new RoutedCommand("Exit", typeof(MyCommands) , inputs);
           


        }
    }
}
