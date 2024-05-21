import {siren, erDiagram, erKey, erCardinality } from "./siren/index.js"
import * as assert from "assert"

describe('Entity Relationship Diagram', function(){
    it('Manufacturer', function(){
        const [CAR, NAMED_DRIVER, PERSON, MANUFACTURER] = ["CAR", "NAMED-DRIVER", "PERSON", "MANUFACTURER"];
        const actual = 
          siren.erDiagram([
            erDiagram.relationship (CAR, erCardinality.onlyOne, NAMED_DRIVER, erCardinality.zeroOrMany, "allows"),
            erDiagram.entity (CAR, [
                erDiagram.attribute("string", "registrationNumber", [erKey.pk]),
                erDiagram.attribute("string", "make"),
                erDiagram.attribute("string", "model"),
                erDiagram.attribute("string[]", "parts")
            ]),
            erDiagram.relationship (PERSON, erCardinality.onlyOne, NAMED_DRIVER, erCardinality.zeroOrMany, "is"),
            erDiagram.entity (PERSON, [
                erDiagram.attribute("string", "driversLicense", [erKey.pk], "The license is #"),
                erDiagram.attribute("string(99)", "firstName", null, "Only 99 characters are allowed"),
                erDiagram.attribute("string", "lastName"),
                erDiagram.attribute("string", "phone", [erKey.uk]),
                erDiagram.attribute("int", "age")
            ]),
            erDiagram.entity(NAMED_DRIVER, [
                erDiagram.attribute("string", "carRegistrationNumber", [erKey.pk, erKey.fk]),
                erDiagram.attribute("string", "driverLicence", [erKey.pk, erKey.fk])
            ]),
            erDiagram.relationship(MANUFACTURER,erCardinality.onlyOne, CAR,erCardinality.zeroOrMany, "makes")
        ]).write();
        const expected = `erDiagram
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
`
        assert.equal(actual,expected,"This should be equal")
    });
})