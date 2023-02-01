using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.CRUD.Mongo.Entities
{
    public class Product
    {
        /*
         
        Desteklenen veri tipleri :

         JSON => Number String Boolean Array Object null
         BSON => string, integer (32- or 64-bit), double, date, byte array, boolean  BSON object, BSON array, regular expression JavaScript code

        BSON jsona göre daha fazla veri tipi destekler.
         */


        [BsonId] // Db de id olarak yapılandırır.
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)] 
        // tipi objectid olarak yapılandırır.
        public string Id { get; set; }

        // tipi string olarak yapılandırır.
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Name { get; set; }

        // tipi int olarak yapılandırır, double için Int64
        [BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
        public int Stock { get; set; }

        // tipi decimal olarak yapılandırır
        [BsonRepresentation(MongoDB.Bson.BsonType.Decimal128)]
        public decimal Price { get; set; }
    }
}
