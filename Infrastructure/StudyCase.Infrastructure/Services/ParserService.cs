using StudyCase.Application.Dto;
using StudyCase.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace StudyCase.Infrastructure.Services
{
    public class ParserService : IParserService
    {
        Project IParserService.XmlParser(string value)
        {
            XDocument xmlDocument = XDocument.Parse(value);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Project));
            Project model = (Project)xmlSerializer.Deserialize(xmlDocument.CreateReader());

            return model;
        }

        Tasks IParserService.JsonParser(string value)
        {
            Tasks model = JsonSerializer.Deserialize<Tasks>(value);

            return model;
        }
    }
}
