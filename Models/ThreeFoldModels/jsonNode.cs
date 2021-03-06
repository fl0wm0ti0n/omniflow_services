// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using JSON_Deserealising_Test;
//
//    var node = Node.FromJson(jsonString);

using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using J = Newtonsoft.Json.JsonPropertyAttribute;
using R = Newtonsoft.Json.Required;
using N = Newtonsoft.Json.NullValueHandling;

namespace Models.ThreeFoldModels
{
    public partial class JsonNode
    {
        [J("id")] public long Id { get; set; }
        [J("node_id")] public string NodeId { get; set; }
        [J("node_id_v1")] public string NodeIdV1 { get; set; }
        [J("farm_id")] public long FarmId { get; set; }
        [J("os_version")] public string OsVersion { get; set; }
        [J("created")] public long Created { get; set; }
        [J("updated")] public long Updated { get; set; }
        [J("uptime")] public long Uptime { get; set; }
        [J("address")] public string Address { get; set; }
        [J("location")] public NodeLocation Location { get; set; }
        [J("total_resources")] public TotalResources TotalResources { get; set; }
        [J("used_resources")] public UsedResources UsedResources { get; set; }
        [J("reserved_resources")] public ReservedResources ReservedResources { get; set; }
        [J("public_config")] public PublicConfig PublicConfigs { get; set; }
        [J("workloads")] public Workloads Workloads { get; set; }
        [J("proofs")] public string Proofs { get; set; }
        [J("ifaces")] public List<Iface> Ifaces { get; set; }
        [J("free_to_use")] public bool FreeToUse { get; set; }
        [J("approved")] public bool Approved { get; set; }
        [J("public_key_hex")] public string PublicKeyHex { get; set; }
        [J("wg_ports")] public List<long> WgPorts { get; set; }
    }

    public class Iface
    {
        [J("name")] public string Name { get; set; }
        [J("addrs")] public List<string> Addrs { get; set; }
        [J("gateway")] public List<string> Gateway { get; set; }
        [J("macaddress")] public string Macaddress { get; set; }
    }

    public class NodeLocation
    {
        [J("city")] public string CityNode { get; set; }
        [J("country")] public string CountryNode { get; set; }
        [J("continent")] public string ContinentNode { get; set; }
        [J("latitude")] public double LatitudeNode { get; set; }
        [J("longitude")] public double LongitudeNode { get; set; }
    }

    public class TotalResources
    {
        [J("cru")] public long Cru { get; set; }
        [J("mru")] public long Mru { get; set; }
        [J("hru")] public long Hru { get; set; }
        [J("sru")] public long Sru { get; set; }
    }

    public class ReservedResources
    {
        [J("cru")] public long Cru { get; set; }
        [J("mru")] public long Mru { get; set; }
        [J("hru")] public long Hru { get; set; }
        [J("sru")] public long Sru { get; set; }
    }

    public class UsedResources
    {
        [J("cru")] public long Cru { get; set; }
        [J("mru")] public long Mru { get; set; }
        [J("hru")] public long Hru { get; set; }
        [J("sru")] public long Sru { get; set; }
    }

    public class PublicConfig
    {
        [J("master")] public string Master { get; set; }
        [J("type")] public long Type { get; set; }
        [J("ipv4")] public string Ipv4 { get; set; }
        [J("ipv6")] public string Ipv6 { get; set; }
        [J("gw4")] public string Gw4 { get; set; }
        [J("gw6")] public string Gw6 { get; set; }
        [J("version")] public long Version { get; set; }
    }

    public class Workloads
    {
        [J("network")] public long Network { get; set; }
        [J("volume")] public long Volume { get; set; }
        [J("zdb_namespace")] public long ZdbNamespace { get; set; }
        [J("container")] public long Container { get; set; }
        [J("k8s_vm")] public long K8SVm { get; set; }
        [J("proxy")] public long Proxy { get; set; }
        [J("reverse_proxy")] public long ReverseProxy { get; set; }
        [J("subdomain")] public long Subdomain { get; set; }
        [J("delegate_domain")] public long DelegateDomain { get; set; }
    }

    public partial class JsonNode
    {
        public static JsonNode FromJson(string json) => JsonConvert.DeserializeObject<JsonNode>(json, NodeConverter.Settings);
    }

    public partial class JsonNode
    {
        public static List<JsonNode> FromJsonList(string jsonList) => JsonConvert.DeserializeObject<List<JsonNode>>(jsonList, NodeConverter.Settings);
    }

    public static class NodeSerialize
    {
        public static string ToJson(this JsonNode self) => JsonConvert.SerializeObject(self, NodeConverter.Settings);
    }

    internal static class NodeConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}