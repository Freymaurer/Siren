from siren.index import siren, er_diagram, er_key, er_cardinality

class TestEntityRelationshipDiagram:

  def test_manufacturer(self):
      CAR, NAMED_DRIVER, PERSON, MANUFACTURER = "CAR", "NAMED-DRIVER", "PERSON", "MANUFACTURER"
      actual = siren.er_diagram([
          er_diagram.relationship (CAR, er_cardinality.only_one(), NAMED_DRIVER, er_cardinality.zero_or_many(), "allows"),
          er_diagram.entity (CAR, [
              er_diagram.attribute("string", "registrationNumber", [er_key.pk()]),
              er_diagram.attribute("string", "make"),
              er_diagram.attribute("string", "model"),
              er_diagram.attribute("string[]", "parts")
          ]),
          er_diagram.relationship (PERSON, er_cardinality.only_one(), NAMED_DRIVER, er_cardinality.zero_or_many(), "is"),
          er_diagram.entity (PERSON, [
              er_diagram.attribute("string", "driversLicense", [er_key.pk()], "The license is #"),
              er_diagram.attribute("string(99)", "firstName", comment="Only 99 characters are allowed"),
              er_diagram.attribute("string", "lastName"),
              er_diagram.attribute("string", "phone", [er_key.uk()]),
              er_diagram.attribute("int", "age")
          ]),
          er_diagram.entity(NAMED_DRIVER, [
              er_diagram.attribute("string", "carRegistrationNumber", [er_key.pk(), er_key.fk()]),
              er_diagram.attribute("string", "driverLicence", [er_key.pk(), er_key.fk()])
          ]),
          er_diagram.relationship(MANUFACTURER,er_cardinality.only_one(), CAR, er_cardinality.zero_or_many(), "makes")
      ]).write()
      expected = """erDiagram
    CAR only one to zero or many NAMED-DRIVER : allows
    CAR {
        string registrationNumber PK
        string make
        string model
        string[] parts
    }
    PERSON only one to zero or many NAMED-DRIVER : is
    PERSON {
        string driversLicense PK "The license is #"
        string(99) firstName "Only 99 characters are allowed"
        string lastName
        string phone UK
        int age
    }
    NAMED-DRIVER {
        string carRegistrationNumber PK, FK
        string driverLicence PK, FK
    }
    MANUFACTURER only one to zero or many CAR : makes
"""
      assert actual == expected