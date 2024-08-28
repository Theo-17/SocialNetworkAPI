using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    private static readonly HttpClient client = new HttpClient();

    static async Task Main(string[] args)
    {
        client.BaseAddress = new Uri("https://localhost:7031/"); //CAMBIAR URL SEGUN LA EJECUCIÓN DEL PUERTO

        while (true)
        {
            Console.WriteLine("Ingrese un comando:");
            var command = Console.ReadLine();

            if (string.IsNullOrEmpty(command))
                continue;

            var commandParts = command.Split(' ');

            if (commandParts[0] == "post")
            {
                await PostMessage(commandParts);
            }
            else if (commandParts[0] == "follow")
            {
                await FollowUser(commandParts);
            }
            else if (commandParts[0] == "dashboard")
            {
                await GetDashboard(commandParts);
            }
            else
            {
                Console.WriteLine("Comando no reconocido.");
            }
        }
    }

    private static async Task PostMessage(string[] commandParts)
    {
        if (commandParts.Length < 3)
        {
            Console.WriteLine("Formato de comando 'post' incorrecto.");
            return;
        }

        var user = commandParts[1].Trim('@');
        var message = string.Join(" ", commandParts, 2, commandParts.Length - 2);
        var content = new StringContent($"{{\"Content\":\"{message}\"}}", System.Text.Encoding.UTF8, "application/json");

        var response = await client.PostAsync($"api/Controlador/post?username={user}", content);
        var result = await response.Content.ReadAsStringAsync();
        Console.WriteLine(result);
    }

    private static async Task FollowUser(string[] commandParts)
    {
        if (commandParts.Length < 3)
        {
            Console.WriteLine("Formato de comando 'follow' incorrecto.");
            return;
        }

        var follower = commandParts[1].Trim('@');
        var followee = commandParts[2].Trim('@');
        var response = await client.PostAsync($"api/Controlador/follow?followerUsername={follower}&followeeUsername={followee}", null);
        var result = await response.Content.ReadAsStringAsync();
        Console.WriteLine(result);
    }

    private static async Task GetDashboard(string[] commandParts)
    {
        if (commandParts.Length < 2)
        {
            Console.WriteLine("Formato de comando 'dashboard' incorrecto.");
            return;
        }

        var user = commandParts[1].Trim('@');
        var response = await client.GetStringAsync($"api/Controlador/dashboard?username={user}");
        Console.WriteLine(response);
    }
}
