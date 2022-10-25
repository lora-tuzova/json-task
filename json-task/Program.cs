using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;


using (FileStream f = new FileStream("provided_info.json", FileMode.OpenOrCreate))
{
    var books = await JsonSerializer.DeserializeAsync<List<Book>>(f);
    foreach (var book in books) { Console.WriteLine($"{book.PublishingHouseId}, {book.Title}, {book.PublishingHouse.Name}"); }
}
class Book
{
    //[JsonIgnore]
    public int PublishingHouseId { get; set; }
    //[JsonPropertyName ("Name")]
    public string Title { get; set; }
    public PublishingHouse PublishingHouse { get; set; }


    public Book (int PublishingHouseId, string Title, PublishingHouse PublishingHouse)
    {
        this.PublishingHouseId = PublishingHouseId;
        this.Title = Title;
        this.PublishingHouse = PublishingHouse;
    }
}

class PublishingHouse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Adress { get; set; }

    public PublishingHouse (int Id, string Name, string Adress)
    {
        this.Id = Id;
        this.Name = Name;
        this.Adress = Adress;
    }
}