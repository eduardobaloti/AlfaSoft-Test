class main{
	public static void Main(string[] args)
	{
        //First Step - > receive a parameter
        Console.WriteLine("Input the file location");
        string path = Console.ReadLine();

        //Second Step -> file processing

        using (StreamReader sr = File.OpenText(path))
        {
            string s = "";
            while ((s = sr.ReadLine()) != null)
            {
                Console.WriteLine(s);
            }
        }

        //Third Step -> Api retrieve

        //Fouth Step -> Generate a log file
	}
};
