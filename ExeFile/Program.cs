using System;
using System.Globalization;
using System.IO;
using ExeFile.Entities;

namespace ExeFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter file full path: ");

            //caminho do arquivo
            string sourceFilePath = Console.ReadLine();

            try
            {
                //separa cada linha do arquivo
                string[] lines = File.ReadAllLines(sourceFilePath);

                //caminho do arquivo
                string sourceFolderPath = Path.GetDirectoryName(sourceFilePath);

                //craindo a subpasta a partir do arquivo de origem
                string targetFolderPath = sourceFolderPath + @"\out";

                //criando outro arquivo a partir da subpasta criada
                string targetFilePath = targetFolderPath + @"\summary.csv";

                //cria a pasta 
                Directory.CreateDirectory(targetFolderPath);

                //escrever os caracteres no arquivo criado
                using (StreamWriter sw = File.AppendText(targetFilePath))
                {
                    //pegando cada linha do arquivo
                    foreach (string line in lines)
                    {

                        //separando os itens da linha pela virgula
                        string[] fields = line.Split(',');

                        string name = fields[0];

                        //.PARSE foi é um array de string
                        double price = double.Parse(fields[1].ToString(CultureInfo.InvariantCulture));
                        int quantity = int.Parse(fields[2]);
                        
                        //instanciando os produtos na classe
                        Products products = new Products(name,price,quantity);

                        //escrevendo de fato os produtos e o total no arquivo criado (sumatty)
                        sw.WriteLine(products.ProductName + "," + products.Total().ToString("F2", CultureInfo.InvariantCulture));
                    }

                }
            }

            catch (IOException e)
            {
                Console.WriteLine("AN ERROR OCCURRED!");
                Console.WriteLine(e.Message);
            }
        }
    }
}