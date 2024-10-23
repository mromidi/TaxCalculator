
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace TaxCalculator.Domain.Entities
{
    public class CityRulesDetail
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("id")]
        [BsonIgnoreIfNull]
        public string Id { get; set; }
        public bool Active { get; set; }
        public int Year { get; set; }
        public string City { get; set; }
        public decimal MaxDailyTax { get; set; }
        public List<string> ExemptVehicles { get; set; }
        public List<TaxRuleHour> HourTaxRules { get; set; }
        public decimal SingleChargeWindow { get; set; }
        public NonTaxablePeriods NonTaxablePeriods { get; set; }
    }
}
