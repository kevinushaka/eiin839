using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WS_SOAP
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    public class Authentification : IAuthentification
    {
        private Dictionary<string, string> Credentials = new Dictionary<string, string>();
        public Authentification()
        {
            string[] logins = File.ReadAllLines(@"..\..\..\passwd.csv");
            foreach (string login in logins)
            {
                string[] parts = login.Split(';');
                Credentials.Add(parts[0].Trim(), parts[1].Trim());
            }
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public bool ValidateCredentials(string username, string password)
        {
            return Credentials.Any(entry => entry.Key == username && entry.Value == password);
        }
    }
}
