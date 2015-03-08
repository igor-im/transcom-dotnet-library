using System;
using System.Xml.Linq;

namespace LinkCondition.Download
{
    public static class Download
    {

        public static XElement getXMLFeed(string username, string password)
        {
             return getXMLFeedHelper(usernametohelper: username, passwordtohelper: password);
        }

        public static XElement getXMLFeed(string requesturl)
        {
            return getXMLFeedHelper(requesturltohelper: requesturl);
        }

        private static XElement getXMLFeedHelper(string usernametohelper = null, string passwordtohelper = null, string requesturltohelper = null)
        {
            if (string.IsNullOrEmpty(requesturltohelper))
            {
                if (string.IsNullOrEmpty(usernametohelper) || string.IsNullOrEmpty(passwordtohelper))
                {
                    throw new Exception(
                        "Incorrect Arguments. Arguments passed were empty. Either Username/Password combination or RequestURL must not be empty");
                }
            }
            string baseurl = "";
            if (string.IsNullOrEmpty(requesturltohelper))
            {
                baseurl = "https://data.xcmdata.org/ISGDE/rest/linkProvider/getXmitLinkConditions?System=" +
                              usernametohelper + "&Key=" + passwordtohelper;
            }
            else
            {
                baseurl = requesturltohelper;
            }
            XElement feed = XElement.Load(baseurl);
           // IEnumerable<XElement> linkElements = from x in feed.Descendants().Descendants().Descendants().Descendants() where x.Name == "linkCondition" select x; // 
            return feed;
        }
    }
}
