using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Xml;
using DAL;
using DAL.EF;
using System.IO;
 

namespace DAL
{
    public   class GoogelMaps
    {
        
        public static double GooglePlaces(string source, string destination, bool isDriving)
        {
            
            string mode = "walking";
            if (isDriving)
                mode = "driving";
           

            string uri = "https://maps.googleapis.com/maps/api/distancematrix/xml?key=AIzaSyD7Wui1ikC-x4CMLYBpPz-8Yutf2l3glNo&origins="
                          + source+ "&destinations=" +destination + "&mode=" + mode + "&units=imperial&sensor=false";
            WebClient wc = new WebClient();
            try
            {
                string geoCodeInfo = wc.DownloadString(uri);
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(geoCodeInfo);
                var distance = xmlDoc.DocumentElement.SelectSingleNode("/DistanceMatrixResponse/row/element/distance/text").InnerText ;
                string st = distance.Substring(0, distance.Length - 2);
                
                double p= (Convert.ToDouble(st) )* 1.609344;
                return p;
            }
            catch (Exception e)
            {
                return -1;
            }
        }
        public static double GooglePlacesTime(string source, string destination, bool isDriving)
        {
            string mode = "walking";
            if (isDriving)
                mode = "driving";

            string uri = "https://maps.googleapis.com/maps/api/distancematrix/xml?key=AIzaSyD7Wui1ikC-x4CMLYBpPz-8Yutf2l3glNo&origins="
                          + source + "&destinations=" + destination + "&mode=" + mode + "&units=imperial&sensor=false";
            WebClient wc = new WebClient();
            try
            {
                string geoCodeInfo = wc.DownloadString(uri);
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(geoCodeInfo);
                var distance = xmlDoc.DocumentElement.SelectSingleNode("/DistanceMatrixResponse/row/element/duration/value").InnerText;
                double p = Convert.ToDouble(distance);
                return p /60;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public static double GetDistanceSource(TravelingPassenger travelingPassenger, string source)
        {
            string uri = "https://maps.googleapis.com/maps/api/distancematrix/xml?key=AIzaSyD7Wui1ikC-x4CMLYBpPz-8Yutf2l3glNo&origins="
                        + source + "&destinations=" + travelingPassenger.Source + "&mode=driving" + " & units=imperial&sensor=false";
            WebClient wc = new WebClient();
            try
            {
                string geoCodeInfo = wc.DownloadString(uri);
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(geoCodeInfo);
                var distance = xmlDoc.DocumentElement.SelectSingleNode("/DistanceMatrixResponse/row/element/distance/text").InnerText;
                string st = distance.Substring(0, distance.Length - 2);
                double p = (Convert.ToDouble(st)) * 1.609344;
                return p;
            }
            catch (Exception e)
            {
                return -1;
            }
        }
        public static double GetDistanceDestination(TravelingPassenger travelingPassenger, string source)
        {
            string uri = "https://maps.googleapis.com/maps/api/distancematrix/xml?key=AIzaSyD7Wui1ikC-x4CMLYBpPz-8Yutf2l3glNo&origins="
                        + source + "&destinations=" + travelingPassenger.Destination + "&mode=driving" + " & units=imperial&sensor=false";
            WebClient wc = new WebClient();
            try
            {
                string geoCodeInfo = wc.DownloadString(uri);
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(geoCodeInfo);
                var distance = xmlDoc.DocumentElement.SelectSingleNode("/DistanceMatrixResponse/row/element/distance/text").InnerText;
                string st = distance.Substring(0, distance.Length - 2);
                double p = (Convert.ToDouble(st)) * 1.609344;
                return p ;
            }
            catch (Exception e)
            {
                return -1;
            }
        }
    }
}
 
