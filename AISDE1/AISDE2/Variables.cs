

namespace AISDE2
{
    class Variables
    {
        public static string CONFIG_TEST_FILE = "testConfig";
        public static string TEST_FILE_OUT = "Outputs";
        public static int MAX_ARRAY_LENGTH = 50;
        public static int DEFAULT_NODES_LENGTH = 50;
        public static int DEFAULT_LINKS_LENGTH =100;

        public static int A = 2; //ile razy ma się wykonać pętla
        internal static int nodeSource = 1;

        public static string NO_PATH_INFO = "Nie ma połączenia z source";

        public static string START_INFO = "Start Symulacji, czekaj ...";
        internal static int nodeDestination = 3;

        public enum ALGORITHM { FLOYD, DIJIKSTRA};
    }
}
