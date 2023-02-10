using Penguin.Reflection.Serialization.XML;
using System.Net;

namespace Penguin.Web.XmlClient
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
            return new XMLSerializer().DeserializeObject<T>(DownloadString(url));
        }

        public T UploadXml<T>(string url, object toUpload) where T : class
        {
            return new XMLSerializer().DeserializeObject<T>(UploadString(url, new XMLSerializer().SerializeObject(toUpload)));
        }

        public string UploadXml(string url, object toUpload)
        {
            return UploadString(url, new XMLSerializer().SerializeObject(toUpload));
        }

        public T DownloadXml<T>(System.Uri url) where T : class
        {
            throw new System.NotImplementedException();
        }

        public T UploadXml<T>(System.Uri url, object toUpload) where T : class
        {
            throw new System.NotImplementedException();
        }

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }
}