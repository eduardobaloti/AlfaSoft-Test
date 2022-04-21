using System.Collections.Generic;

class FileApp{
	public static void Main(string[] args)
	{
        //First Step - > receive a parameter
        Console.WriteLine("Input the file location:");
        string path = Console.ReadLine();

        //Second Step -> file processing
        List<string> users = new List<string>();
        using (StreamReader sr = File.OpenText(path))
        {
            string s = "";
            while ((s = sr.ReadLine()) != null)
            {
                Console.WriteLine(s);
                
                
            }
        };

        //Third Step -> Api retrieve

        HttpClient client = new HttpClient();
        async Task GetUser()
        {

            for (var i = 0; i < users.Count; i++){
                string response = client.GetAsync("https://api.bitbucket.org/2.0/users/{user}", user);
                await Task.Delay(500);
                Console.WriteLine(response);

                using (StreamWriter writer = new StreamWriter("/logfile.txt"))  
                {  
                   writer.WriteLine(response);  
                } 
            }
        }
        GetUser();
        Thread.Sleep(500);
	}
};
