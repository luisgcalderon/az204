using System.Net;
using Microsoft.Azure.Cosmos;

namespace PracticeCosmos
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string my_connection_string = "AccountEndpoint=https://pluralsightlab-776-fd7.documents.azure.com:443/;AccountKey=JsevBcTbJY15Nq7JxCKL86CPgGxJblty6vtYDGJaFq7ouLNjbvWdSt8oddeDhlYD2phZxvCIAZVqACDb6YEVAg==;";

            CosmosClient myClient = new CosmosClient(connectionString: my_connection_string);

            Database myDatabase = await myClient.CreateDatabaseIfNotExistsAsync("LabDBNet");

            Container myContainer = await myDatabase.CreateContainerIfNotExistsAsync("LabItemsNet", "/labPK");

            GenericItem myItem = new(
                id: "70b63682-b93a-4c77-aad2-65501347265f",
                itemName: "This is my string",
                labPK: "Springfield"
            );

            GenericItem upsertedItem = await myContainer.UpsertItemAsync<GenericItem>(myItem, new PartitionKey(myItem.labPK));
        }
        public record GenericItem (
            string id,
            string itemName,
            string labPK
        );
    }

}