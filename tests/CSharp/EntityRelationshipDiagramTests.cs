using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siren.Sea.Tests
{
    public class EntityRelationshipDiagramTests
    {
        [Fact]
        public void docs()
        {
            (string CAR, string NAMED_DRIVER, string PERSON, string MANUFACTURER) = ("CAR", "NAMED-DRIVER", "PERSON", "MANUFACTURER");
            SirenElement graph =
                siren.erDiagram([
                    erDiagram.relationship(CAR, erCardinality.onlyOne, NAMED_DRIVER, erCardinality.zeroOrMany, "allows"),
                    erDiagram.entity(CAR, attr: new ERAttribute[] {
                        erDiagram.attribute("string", "registrationNumber", keys: new ERKeyType[] {erKey.pk }),
                        erDiagram.attribute("string", "make"),
                        erDiagram.attribute("string", "model"),
                        erDiagram.attribute("string[]", "parts")
                    }),
                    erDiagram.relationship(PERSON, erCardinality.onlyOne, NAMED_DRIVER, erCardinality.zeroOrMany, "is"),
                    erDiagram.entity(PERSON, attr: new ERAttribute[] {
                        erDiagram.attribute("string", "driversLicense", new ERKeyType[] {erKey.pk }, "The license is #"),
                        erDiagram.attribute("string(99)", "firstName", comment: "Only 99 characters are allowed"),
                        erDiagram.attribute("string", "lastName"),
                        erDiagram.attribute("string", "phone", keys: new ERKeyType[] {erKey.uk}),
                        erDiagram.attribute("int", "age")
                    }),
                    erDiagram.entity(NAMED_DRIVER, attr: new ERAttribute[] {
                        erDiagram.attribute("string", "carRegistrationNumber", keys: new ERKeyType[] {erKey.pk, erKey.fk }),
                        erDiagram.attribute("string", "driverLicence", keys: new ERKeyType[] {erKey.pk, erKey.fk }),
                    }),
                    erDiagram.relationship(MANUFACTURER, erCardinality.onlyOne, CAR, erCardinality.zeroOrMany, "makes")
                ]);
            string actual = siren.write(graph);
            string expected = @"erDiagram
    CAR only one to zero or many NAMED-DRIVER : allows
    CAR {
        string registrationNumber PK
        string make
        string model
        string[] parts
    }
    PERSON only one to zero or many NAMED-DRIVER : is
    PERSON {
        string driversLicense PK ""The license is #""
        string(99) firstName ""Only 99 characters are allowed""
        string lastName
        string phone UK
        int age
    }
    NAMED-DRIVER {
        string carRegistrationNumber PK, FK
        string driverLicence PK, FK
    }
    MANUFACTURER only one to zero or many CAR : makes
";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CompletenessTest()
        {
            Type csharpType = typeof(Siren.Sea.erDiagram);
            Type fsharpType = typeof(Siren.erDiagram);
            Utils.CompareClasses(csharpType, fsharpType);
        }
    }
}
