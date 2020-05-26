using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationTest.Work
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DefaultValueAttribute : Attribute
    {

        public object defaultValue { get; set; }
        public DefaultValueAttribute(object defValue)
        {
            defaultValue = defValue;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class NodeKeyAttribute : Attribute
    {
        public NodeKeyAttribute()
        {

        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class NodeNameAttribute : Attribute
    {
        public string NodeName { get; set; }
        public NodeNameAttribute(string nodeName)
        {
            NodeName = nodeName;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class ChildAttribute : Attribute
    {
        public ChildAttribute() { }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class NotAttributeAttribute : Attribute
    {

    }

    [AttributeUsage(AttributeTargets.Property)]
    public class PluginNameAttribute : Attribute
    {
        string PluginName { get; set; }
        public PluginNameAttribute(string pluginName)
        {
            PluginName = pluginName;
        }
    }
}

