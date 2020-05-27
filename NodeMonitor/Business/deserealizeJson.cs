using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using DatabaseLib.Entities;
using NodeMonitor.Models.JsonModels;

namespace NodeMonitor.Business
{
    public static class DeserealizeJson
    {
        #region json deserealization
        public static JsonNode CheckUriForNodeAndGetJson(ThreefoldApiUriEntity UriString)
        {
            JsonNode returnobject = null;

            Log.Warning("ChoosenUri: " + UriString.Uri);
            if (CheckUri(UriString) != null)
            {
                returnobject = JsonNode.FromJson(CheckUri(UriString));
            }
            return returnobject;
        }

        public static List<JsonNode> CheckUriForNodeListAndGetJson(ThreefoldApiUriEntity UriString)
        {
            List<JsonNode> returnobject = null;

            Log.Warning("ChoosenUri: " + UriString.Uri);
            if (CheckUri(UriString) != null)
            {
                returnobject = JsonNode.FromJsonList(CheckUri(UriString));
            }
            return returnobject;
        }

        public static JsonFarm CheckUriForFarmAndGetJson(ThreefoldApiUriEntity UriString)
        {
            JsonFarm returnobject = null;

            Log.Warning("ChoosenUri: " + UriString.Uri);
            if (CheckUri(UriString) != null)
            {
                returnobject = JsonFarm.FromJson(CheckUri(UriString));
            }
            return returnobject;
        }

        public static List<JsonFarm> CheckUriForFarmListAndGetJson(ThreefoldApiUriEntity UriString)
        {
            List<JsonFarm> returnobject = null;

            Log.Warning("ChoosenUri: " + UriString.Uri);
            if (CheckUri(UriString) != null)
            {
                returnobject = JsonFarm.FromJsonList(CheckUri(UriString));

            }
            return returnobject;
        }

        public static string CheckUri(ThreefoldApiUriEntity UriString)
        {
            Uri outUri;
            if (Uri.TryCreate(UriString.Uri, UriKind.Absolute, out outUri)
                && (outUri.Scheme == Uri.UriSchemeHttp || outUri.Scheme == Uri.UriSchemeHttps))
            {
                return Get(UriString.Uri);
            }
            else
            {
                Log.Warning("Ungültiger URI");
                return null;
            }
        }
        #endregion

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
        #endregion
    }
}