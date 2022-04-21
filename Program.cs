﻿using System.Collections.Generic;
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
                users.Append(s);
                Console.WriteLine(s);
            }
        };

        //Third Step -> Api retrieve
        HttpClient client = new HttpClient();
        async Task GetUser()
        {
            for (var i = 0; i < users.Count; i++){
                string user = users[i];
                string url = ("https://api.bitbucket.org/2.0/users/"+user);
                string response = ("url.com");
                await Task.Delay(500);
                Console.WriteLine(response);
                //Whrite in LogFile
                using (StreamWriter writer = new StreamWriter("/logfile.txt"))   
                {  
                   writer.WriteLine(response);  
                } 
            }
            await Task.FromResult("Ok");
        }
        GetUser();
        Thread.Sleep(500);
	}
};
