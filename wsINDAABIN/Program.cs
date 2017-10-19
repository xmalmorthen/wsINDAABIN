using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using wsINDAABIN.INDAABINService;
using wsINDAABIN.Models;
using wsINDAABIN.Utils;

namespace wsINDAABIN
{
    class Program
    {
        private static Dictionary<string, string> codigoCatalogo = new Dictionary<string, string>() {
            {"ESTADOS", "CA00001"},
            {"MUNICIPIOS", "CA00002"},
            {"LOCALIDADES", "CA00003"},
            {"COMPONENTE ESPACIAL", "CA00004"},
            {"ADMINISTRACION CARRETERA", "CA00005"},
            {"TERMINO GENERICO CAMINO", "CA00006"},
            {"TIPO VIALIDAD", "CA00007"},
            {"ASENTAMIENTO HUMANO", "CA00008"}
        };

        static void Main(string[] args)
        {
            WS_BUSClient client = new WS_BUSClient();

            string response = string.Empty;

            response = client.ObtenerCatalogo(
                Properties.Settings.Default.INDAABINUsr,
                Properties.Settings.Default.INDAABINPwd,
                codigoCatalogo["ESTADOS"],
                0,
                0
                );

            XDocument xDoc = XDocument.Load(new StringReader(response));

            var unwrappedResponse = xDoc.Descendants((XNamespace)"http://schemas.xmlsoap.org/soap/envelope/" + "ArrayOfCatalogo")
                .First()
                .FirstNode;



            //List<Catalog> catResponse = XMLActions.XMLToObject(response, typeof(List<Catalog>)) as List<Catalog>;


            client.Close();


        }
    }
}
