using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Banque.Modele
{
   public class Serialise
    {
        private static List<Compte> lstcpt;

        public static List<Compte> Lstcpt { get => lstcpt; }

        public static void chargement()
        {

            try
            {
                if (File.Exists("data"))
                {
                    BinaryFormatter deserializer = new BinaryFormatter();
                    FileStream stream = new FileStream("data", FileMode.Open);
                    lstcpt = (List<Compte>)deserializer.Deserialize(stream);
                    stream.Close();
                }

            }
            catch (Exception ex)
            {


                throw (ex);

            }

        }

        public static void sauvegarde(List<Compte> lstcpt)
        {

            try
            {
                FileStream stream = new FileStream("data", FileMode.Create);
                BinaryFormatter serializer = new BinaryFormatter();
                serializer.Serialize(stream, lstcpt);
                stream.Close();
            }

            catch (Exception ex)
            {


                throw (ex);

            }


        }

    }
}
