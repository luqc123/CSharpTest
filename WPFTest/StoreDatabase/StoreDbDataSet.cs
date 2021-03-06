﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDatabase
{
    public class StoreDbDataSet
    {
        public DataTable GetProducts()
        {
            return GetCategoriesAndProducts().Tables[0];
        }

        public DataSet GetCategoriesAndProducts()
        {
            return ReadDataSet();
        }

        internal static DataSet ReadDataSet()
        {
            DataSet ds = new DataSet();
            ds.ReadXmlSchema("store.xsd");
            ds.ReadXml("store.xml");
            return ds;
        }
    }
}
