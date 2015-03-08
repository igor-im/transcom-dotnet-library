using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace LinkCondition.Process

{
    public static class toJSON
    {
        

        public static string toJSONRaw(this XElement feed)
        {
            string JSON = null;
            JSON = JsonConvert.SerializeXNode(feed);
            return JSON;
        }

        public static string toJSONNoMeta(this XElement feed)
        {
            string JSON = null;
            IEnumerable<XElement> linkElements = from x in feed.Descendants().Descendants().Descendants().Descendants() where x.Name == "linkCondition" select x;
            ConcurrentBag<XElement> _linkElementBag = new ConcurrentBag<XElement>(linkElements);
            Parallel.ForEach(_linkElementBag, linkElement =>
            {
                var tempvar = linkElement.Attribute("asOf").Value;
                XElement temp = new XElement("Date", tempvar);
                linkElement.Add(temp);
                linkElement.RemoveAttributes();

                JSON += JsonConvert.SerializeXNode(linkElement, Formatting.None, true); 
            });
            return JSON;
        }

        public static string toJSONOnlyMeta(this XElement feed)
        {
            string JSON = null;
            var attributes = feed.Element("return").Element("dataResponse").Element("linkConditions").Attributes(); // todo: handle possible null reference in case of future changes
            string tempstring;
            JSON = JsonConvert.SerializeObject(attributes);
            return JSON;
        }
    }
}
