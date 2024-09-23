using MongoDB.Bson.Serialization;

namespace TaxCalculator.Infrastructure.Mongo.Models
{
    public class TimeOnlyBsonSerializer : IBsonSerializer<TimeOnly>
    {
        public Type ValueType => typeof(TimeOnly);

        public TimeOnly Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            var bsonReader = context.Reader;
            var timeString = bsonReader.ReadString();
            return TimeOnly.Parse(timeString);
        }

        public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, TimeOnly value)
        {
            var bsonWriter = context.Writer;
            bsonWriter.WriteString(value.ToString("HH:mm"));
        }

        public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, object value)
        {
            throw new NotImplementedException();
        }

        object IBsonSerializer.Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            return Deserialize(context, args);
        }
    }
}
