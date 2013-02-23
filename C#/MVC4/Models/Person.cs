using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;
using Newtonsoft.Json;

namespace MVC4.Models
{
    [DataContract]
    public class Person
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Address { get; set; }

        private List<Person> _persons;
        public async Task<List<Person>> GetPersonsAsync()
        {
            if (_persons != null)
                return _persons;

            _persons = HttpRuntime.Cache["PersonList"] as List<Person>;
            if (_persons != null)
                return _persons;

            try
            {
                const string uri = "http://localhost:2302/NodeJSTR/Content/json.txt";
                var request = WebRequest.Create(uri) as HttpWebRequest;
                if (request == null)
                    return null;

                request.Method = "GET";
                request.ContentType = "application/json";

                using (var response = await request.GetResponseAsync())  // Get response async
                {
                    if (response != null)
                    {
                        var data = "";
                        var stream = response.GetResponseStream();
                        if (stream != null)
                        {
                            StreamReader reader;
                            using (reader = new StreamReader(stream))
                            {
                                data = await reader.ReadToEndAsync(); // Read async all json data as a single string
                            }
                        }

                        // Use Json.NET to deserialize the json array...
                        if (!string.IsNullOrEmpty(data))
                            _persons = JsonConvert.DeserializeObject<List<Person>>(data);

                        // Cache the post list for subsequent use
                        if (_persons != null)
                            HttpRuntime.Cache.Insert("PersonList", _persons, null, Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(10));
                    }
                }
            }
            catch
            {
                _persons = null;
            }

            return _persons;
        }
    }
}