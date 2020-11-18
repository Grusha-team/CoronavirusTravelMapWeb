using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
namespace GetData
{
    public enum Quarantine
    {
        [EnumMember(Value = "yes")]
        yes,
        [EnumMember(Value = "no")]
        no,
        [EnumMember(Value = "unknown")]
        unknown
    }
    public enum CovidTest
    {
        [EnumMember(Value = "yes")]
        yes,
        [EnumMember(Value = "no")]
        no,
        [EnumMember(Value = "unknown")]
        unknown
    }
    public sealed class Country
    {
        public string name { get; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Quarantine quarantine { get; }
        [JsonConverter(typeof(StringEnumConverter))]
        public CovidTest covidtest { get; }
        public Country(string name)
        {
            this.name = name;
        }
        public Country(string name, Quarantine quarantine, CovidTest covidtest)
        {
            this.name = name;
            this.quarantine = quarantine;
            this.covidtest = covidtest;

        }
    }
}
