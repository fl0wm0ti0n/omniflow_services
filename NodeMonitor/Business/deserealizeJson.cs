using DatabaseLib.Entities;
using NodeMonitor.Models.JsonModels;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace NodeMonitor.Business
{
    public static class DeserealizeJson
    {
        #region json deserealization

        public static JsonNode CheckUriForNodeAndGetJson(ThreefoldApiUriEntity UriStringObj)
        {
            JsonNode returnobject = null;
            string UriString = UriStringObj.Uri;
            if (CheckUri(UriString) != null)
            {
                returnobject = JsonNode.FromJson(CheckUri(UriString));
            }
            return returnobject;
        }

        public static List<JsonNode> CheckUriForNodeListAndGetJson(ThreefoldApiUriEntity UriStringObj)
        {
            List<JsonNode> returnobject = new List<JsonNode>();

            string UriString = UriStringObj.Uri + "?page=";

            int i = 1;
            while (true)
            {
                string finalUri = UriString + i;

                string checkreturn = CheckUri(finalUri);
                if (checkreturn.Length > 5)
                {
                    returnobject.AddRange(JsonNode.FromJsonList(checkreturn));
                }
                else
                {
                    break;
                }
                i++;
            }
            return returnobject;
        }

        public static JsonFarm CheckUriForFarmAndGetJson(ThreefoldApiUriEntity UriStringObj)
        {
            JsonFarm returnobject = null;
            string UriString = UriStringObj.Uri;
            if (CheckUri(UriString) != null)
            {
                returnobject = JsonFarm.FromJson(CheckUri(UriString));
            }
            return returnobject;
        }

        public static List<JsonFarm> CheckUriForFarmListAndGetJson(ThreefoldApiUriEntity UriStringObj)
        {
            List<JsonFarm> returnobject = new List<JsonFarm>();
            string UriString = UriStringObj.Uri + "?page=";

            int i = 1;
            while (true)
            {
                string finalUri = UriString + i;

                string checkreturn = CheckUri(finalUri);
                if (checkreturn.Length > 5)
                {
                    returnobject.AddRange(JsonFarm.FromJsonList(checkreturn));
                }
                else
                {
                    break;
                }
                i++;
            }
            return returnobject;
        }

        #endregion json deserealization

        #region Check  Uri and Get Data

        public static string CheckUri(string UriString)
        {
            Uri outUri;
            if (Uri.TryCreate(UriString, UriKind.Absolute, out outUri)
                && (outUri.Scheme == Uri.UriSchemeHttp || outUri.Scheme == Uri.UriSchemeHttps))
            {
                return Get(UriString);
            }
            else
            {
                Log.Warning("Ungültiger URI");
                return null;
            }
        }

        #endregion Check  Uri and Get Data

        #region Get Data

        public static string Get(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        #endregion Get Data
    }
}