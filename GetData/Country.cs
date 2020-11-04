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
        public Country(string name, string quarantine, string covidtest)
        {
            this.name = name;
            switch (quarantine)
            {
                case "yes":
                    this.quarantine = Quarantine.yes;
                    break;
                case "no":
                    this.quarantine = Quarantine.no;
                    break;
                default:
                    this.quarantine = Quarantine.unknown;
                    break;

            }
            switch (covidtest)
            {
                case "yes":
                    this.covidtest = CovidTest.yes;
                    break;
                case "no":
                    this.covidtest = CovidTest.no;
                    break;
                default:
                    this.covidtest = CovidTest.unknown;
                    break;

            }

        }
    }
}
