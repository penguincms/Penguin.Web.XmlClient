using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Penguin.Reflection.Serialization.XML;

namespace Penguin.Web
{
    /// <summary>
    /// WebClient with options to upload/download objects by converting to/from XML, for XML endpoints. Use "UploadXml" and "DownloadXml"
    /// </summary>
    public class XmlClient : WebClient
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public XmlClient()
        {
           
        }

        public T DownloadXml<T>(string url) where T : class
        {
             return new XMLSerializer().DeserializeObject<T>(this.DownloadString(url));
        }

        public T UploadXml<T>(string url, object toUpload) where T : class
        {
            return new XMLSerializer().DeserializeObject<T>(this.UploadString(url, new XMLSerializer().SerializeObject(toUpload)));
        }

        public string UploadXml(string url, object toUpload)
        {
            return this.UploadString(url, new XMLSerializer().SerializeObject(toUpload));
        }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }
}
