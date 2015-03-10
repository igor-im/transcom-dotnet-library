using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LinkCondition.Load
{
    class saveToLocal
    {
        public static bool saveToLocalDisk(string JSON, string folderpath)
        {
            bool status = false;
            using (TextWriter writer = File.CreateText(folderpath + utility.getTimeStamp() + ".json"))
            {
                var temp = writer.WriteAsync(JSON);
                temp.Wait();
                status = temp.IsCompleted;
            }
            return status;
        }
    }
}
