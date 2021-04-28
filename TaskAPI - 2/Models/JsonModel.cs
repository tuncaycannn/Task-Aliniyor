using Newtonsoft.Json;
using System.Collections.Generic;

namespace TaskAPI.Models
{

    public partial class JsonModel
    {
        [JsonProperty("AddressInfo")]
        public AddressInfo AddressInfo { get; set; }
    }

    public partial class AddressInfo
    {
        [JsonProperty("City")]
        public List<City> City { get; set; }
    }

    public partial class City
    {
        [JsonProperty("@name")]
        public string Name { get; set; }

        [JsonProperty("@code")]
        public string Code { get; set; }

        [JsonProperty("District")]
        public List<District> District { get; set; }
    }

    public partial class District
    {
        [JsonProperty("@name")]
        public string Name { get; set; }

        [JsonProperty("Zip")]
        public ZipUnion Zip { get; set; }
    }

    public partial class ZipElement
    {
        [JsonProperty("@code")]
        public string Code { get; set; }
    }

    public partial struct ZipUnion
    {
        public ZipElement ZipElement;
        public List<ZipElement> ZipElementArray;

        public static implicit operator ZipUnion(ZipElement ZipElement) => new ZipUnion { ZipElement = ZipElement };
        public static implicit operator ZipUnion(List<ZipElement> ZipElementArray) => new ZipUnion { ZipElementArray = ZipElementArray };
    }

}
