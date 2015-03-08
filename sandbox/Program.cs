using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkCondition.Process;

namespace sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
           // LinkCondition.Download.Download.getXMLFeed(@"..\..\data\getXmitLinkConditions.xml").toJSONRaw();
            Console.Write(LinkCondition.Download.Download.getXMLFeed(@"..\..\data\getXmitLinkConditions.xml").toJSONOnlyMeta());
        }
    }
}
