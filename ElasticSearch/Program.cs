//docker network create somenetwork
//docker run -d --name elasticsearch --net somenetwork -p 9200:9200 - p 9300:9300 - e "discovery.type=single-node" elasticsearch: 6.8.20
//docker run -d --name kibana --net somenetwork -p 5601:5601 kibana: 6.8.20

// See https://aka.ms/new-console-template for more information
using Nest;

Console.WriteLine("Inicio");

ConnectionSettings settings = new ConnectionSettings(new Uri("http://localhost:9200"))
    .DefaultIndex("people");

ElasticClient client = new ElasticClient(settings);



Person person = new Person
{
    Id = 1,
    FirstName = "Martijn",
    LastName = "Laarman"
};

var indexResponse = client.IndexDocument(person);

var asyncIndexResponse = await client.IndexDocumentAsync(person);

Console.WriteLine("Fim");

public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}