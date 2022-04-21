using System;
using System.Collections.Generic;
class FileApp{
	static async Task Main(string[] args)
	{
        //Timer check
        string timestamp = File.ReadAllText("timelock.txt");
        DateTime lastRun = DateTime.Parse(timestamp);
        if (DateTime.Now > lastRun.AddMinutes(1))
        {
            //First Step - > receive a parameter
            Console.Write("Input the file location: ");
            string path = Console.ReadLine();

            //Second Step -> file processing
            List<string> users = new List<string>();
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    users.Add(s);
                    Console.WriteLine(s);
                }
            };

            //Third Step -> Api retrieve
            HttpClient client = new HttpClient();
            for (var i = 0; i <= users.Count-1; i++)
            {
                string user = users[i];
                string url = ("https://api.bitbucket.org/2.0/workspaces/"+user);
                try
                {
                    string response = await client.GetStringAsync(url);
                    Console.WriteLine(url);
                    Console.WriteLine(response);
                    await Task.Delay(5000);
                    //Whrite in LogFile
                    using (StreamWriter writer = new StreamWriter("logfile.txt", true))   
                    {  
                        writer.WriteLine(response.Trim());
                    }
                }
                catch { }
            }
            File.WriteAllText("timelock.txt", DateTime.Now.ToString());
            Thread.Sleep(5000);
         }
         else
         {
             Console.WriteLine("wait one minute to use again");
         }
	}
};

