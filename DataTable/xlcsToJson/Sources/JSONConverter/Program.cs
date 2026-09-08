namespace JSONConverter
{
    static class Program
    {
        public const string ConfigFilePath = "./config.json";

        public static JSONConverterConfig Config = new JSONConverterConfig();
        
        [System.STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new JSONConverterForm());
        }

    }
}
