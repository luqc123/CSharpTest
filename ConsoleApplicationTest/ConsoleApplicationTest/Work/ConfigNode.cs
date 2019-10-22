using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text;
using System.Reflection;

namespace ConsoleApplicationTest.Work
{
    /// <summary>
    /// auto load and save data from xmlnode
    /// </summary>
    public class ConfigNode
    {
        public ConfigNode()
        {
            #region init property

            List<PropertyInfo> pis = this.GetType().GetProperties().
                Where(x => x.CanWrite
                    &&(x.PropertyType==typeof(int)
                        || x.PropertyType==typeof(long)
                        || x.PropertyType==typeof(bool)
                        || x.PropertyType==typeof(double)
                        || x.PropertyType==typeof(string)
                    )
                ).ToList();

            foreach (PropertyInfo pi in pis)
            {
                object value = null;
                var list = pi.GetCustomAttributes(typeof(bool), true).ToList();
                try
                {
                    if (list.Count <=0)
                    {
                        if (pi.PropertyType == typeof(int) || pi.PropertyType == typeof(long) || pi.PropertyType == typeof
                            (double))
                            value = 0;
                        else if (pi.PropertyType == typeof(bool))
                            value = false;
                        else if (pi.PropertyType == typeof(string))
                            value = "";
                        else
                        {

                        }
                    }
                }
                catch (Exception err)
                {
                    System.Diagnostics.Trace.WriteLine(err.Message);
                }
            }
            #endregion
        }
    }
}
