using Newtonsoft.Json;
using System.IO;

namespace GprinterDEMO
{
    class DB
    {
        public static Configer DataSet = new Configer();

        public static void SyncConfigFile()
        {
            using (StreamReader r = new StreamReader("db.txt"))
            {
                string json = r.ReadToEnd();
                DataSet = JsonConvert.DeserializeObject<Configer>(json);
            }
        }

        public static void SyncConfigFile(Configer configer)
        {
            string d = JsonConvert.SerializeObject(configer);
            using (StreamWriter w = new StreamWriter("db.txt"))
            {
                w.Write(d);
                w.Flush();
            }
        }
    }
}
