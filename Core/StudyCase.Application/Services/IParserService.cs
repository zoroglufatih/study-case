using StudyCase.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCase.Application.Services
{
    public interface IParserService
    {
        Project XmlParser(string value);
        Tasks JsonParser(string value);
    }
}
