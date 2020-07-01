using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace AspNetShop.DummyServer
{
    public class DataLoader
    {
        string dataAddress;
        public DataLoader(IConfiguration configuration)
        {
            dataAddress = configuration["dummyData"];
        }
        public List<T> Get<T>() where T : new()
        {
            List<T> res = new List<T>();
            XmlDocument doc = new XmlDocument();
            doc.Load(dataAddress);
            var list = doc.GetElementsByTagName(typeof(T).Name);
            var l = typeof(T).GetType().GetProperties();
            foreach(XmlNode item in list)
            {
                T TItem = new T();
                foreach(XmlNode child in item.ChildNodes)
                {
                    
                    var type = TItem.GetType().GetProperty(child.Name).PropertyType;
                    var value = TypeDescriptor.GetConverter(type).ConvertFrom(child.InnerXml);
                    TItem.GetType().GetProperty(child.Name).SetValue(TItem, value);
                }
                res.Add(TItem);
            }
            return res;
        }
    }
}
