// See https://aka.ms/new-console-template for more information
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace ConAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee obj = new Employee()
            {
                ID = 5,
                FirstName = "ramesh",
                LastName = "Kumar",
                Salary = 75000.29
            };

            // Binary Serialization using DataContractSerializer
            DataContractSerializer serializer = new DataContractSerializer(typeof(Employee));
            using (Stream stream = new FileStream("employee.bin", FileMode.Create, FileAccess.Write))
            {
                serializer.WriteObject(stream, obj);
            }

            // Binary Deserialization using DataContractSerializer
            using (Stream stream = new FileStream("employee.bin", FileMode.Open, FileAccess.Read))
            {
                Employee empdata = (Employee)serializer.ReadObject(stream);
                Console.WriteLine($"ID: {empdata.ID}, FirstName: {empdata.FirstName}, LastName: {empdata.LastName}, Salary: {empdata.Salary}");
            }

            // XML Serialization using XmlSerializer
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Employee));
            using (TextWriter writer = new StreamWriter("employee.xml"))
            {
                xmlSerializer.Serialize(writer, obj);
            }

            // XML Deserialization using XmlSerializer
            using (TextReader reader = new StreamReader("employee.xml"))
            {
                Employee deserializedemployee = (Employee)xmlSerializer.Deserialize(reader);
                Console.WriteLine($"ID: {deserializedemployee.ID}, FirstName: {deserializedemployee.FirstName}, LastName: {deserializedemployee.LastName}, Salary: {deserializedemployee.Salary}");
            }

            Console.ReadKey();
        }
    }
}
