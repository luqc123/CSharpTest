using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ResourceLibrary
{
    public class CustomResource
    {
        public static ComponentResourceKey HappyBrush
        {
            get
            {
                return new ComponentResourceKey(typeof(CustomResource), "HappyBrush");
            }
        } 
    }
}
